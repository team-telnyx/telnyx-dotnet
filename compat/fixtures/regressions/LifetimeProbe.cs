using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Audio;
using Telnyx.Sdk.Models.Portouts;

// Offline package contract tests. The runner must deny OS network egress.
public static class LifetimeProbe
{
    public static async Task Run()
    {
        int failures = 0;
        async Task Check(string name, Func<Task> body) {
            try { await body(); Console.WriteLine("PASS lifetime/" + name); }
            catch (Exception e) { failures++; Console.WriteLine("FAIL lifetime/" + name + ": " + e); }
        }
        await Check("body-timeout", async () => {
            var stream = new SlowStream();
            using var client = Client(new Handler((r,c) => Task.FromResult(Response(stream))), 0, 80);
            using var response = await client.Execute(Request());
            await Cancelled(response.Deserialize<JsonElement>());
        });
        await Check("postheaders-caller-cancellation", async () => {
            using var cancel = new CancellationTokenSource();
            using var client = Client(new Handler((r,c) => Task.FromResult(Response(new SlowStream()))));
            using var response = await client.Execute(Request(), cancel.Token);
            var task = response.Deserialize<JsonElement>();
            cancel.Cancel();
            await Cancelled(task);
        });
        await Check("typed-deserialize-cancellation", async () => {
            var stream = new SlowStream();
            using var client = new TelnyxClient { ApiKey="dummy", HttpClient=new HttpClient(new Handler((r,c)=>Task.FromResult(Response(stream)))), MaxRetries=0 };
            using var response = await client.WithRawResponse.Balance.Retrieve();
            using var cancel = new CancellationTokenSource();
            var task = response.Deserialize(cancel.Token);
            await stream.Started.Task;
            cancel.Cancel();
            await Cancelled(task);
        });
        await Check("shared-disposal-and-unlink", async () => {
            var content = new TrackingContent();
            using var cancel = new CancellationTokenSource();
            using var client = new TelnyxClient { ApiKey="dummy", HttpClient=new HttpClient(new Handler((r,c)=>Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK){Content=content}))), MaxRetries=0 };
            var response = await client.WithRawResponse.Balance.Retrieve(cancellationToken:cancel.Token);
            response.Dispose(); response.Dispose();
            cancel.Cancel();
            if (content.Disposals != 1 || response.CancellationToken.IsCancellationRequested)
                throw new Exception("Response lifetime not disposed exactly once/unlinked");
        });
        foreach (bool retry in new[]{false,true})
        await Check("error-disposal-retry-" + retry, async () => {
            var first = new TrackingContent(); var second = new TrackingContent(); int sends=0;
            using var client = Client(new Handler((r,c)=> {
                var response = new HttpResponseMessage(++sends == 1 ? HttpStatusCode.InternalServerError : HttpStatusCode.OK){ Content=sends==1 ? first : second };
                response.Headers.Add("retry-after-ms", "1"); return Task.FromResult(response);
            }), retry ? 1 : 0);
            try { using var response = await client.Execute(Request()); if (!retry) throw new Exception("Expected original HTTP error"); }
            catch (Telnyx.Sdk.Exceptions.TelnyxApiException) when (!retry) { }
            if (first.Disposals != 1 || (retry && second.Disposals != 1)) throw new Exception("Discarded/terminal response leaked");
        });
        await Check("send-failure-preserves-caller-stream", async () => {
            using var stream = new UploadStream(true);
            using var client = Client(new Handler(async (r,c) => {
                await r.Content!.CopyToAsync(Stream.Null, c);
                throw new HttpRequestException("injected send failure");
            }));
            try {
                using var response = await client.Execute(new HttpRequest<AudioTranscribeParams> {
                    Method=HttpMethod.Post, Params=new(){ Model=Model.OpenAIWhisperLargeV3Turbo, File=stream }
                });
                throw new Exception("Expected send failure");
            } catch (Telnyx.Sdk.Exceptions.TelnyxIOException) { }
            if (stream.Disposals != 0) throw new Exception("Send failure disposed caller stream");
        });
        foreach (var mode in new[] { "bytes", "seekable", "nonseekable" })
        await Check("multipart-" + mode, async () => {
            int sends = 0;
            byte[]? first = null;
            using var stream = new UploadStream(mode != "nonseekable");
            if (mode == "seekable") stream.Position = 2;
            using var client = Client(new Handler(async (r,c) => {
                using var wire = new MemoryStream();
                await r.Content!.CopyToAsync(wire, c);
                var bytes = wire.ToArray();
                if (mode == "seekable" && Encoding.Latin1.GetString(bytes).Contains("\t\t"))
                    throw new Exception("Did not preserve initial stream offset");
                sends++;
                if (first == null) first = bytes;
                else if (!first.SequenceEqual(bytes)) throw new Exception("Retry changed multipart bytes");
                var response = new HttpResponseMessage(sends == 1 ? HttpStatusCode.InternalServerError : HttpStatusCode.OK) { Content = new StringContent("original-upload-error") };
                response.Headers.Add("retry-after-ms", "1");
                return response;
            }), 1);
            try {
                using var response = await client.Execute(new HttpRequest<AudioTranscribeParams> {
                    Method=HttpMethod.Post, Params=new(){ Model=Model.OpenAIWhisperLargeV3Turbo,
                    File= mode == "bytes" ? (BinaryContent)new byte[]{1,2,3} : (BinaryContent)stream }
                });
                if (mode == "nonseekable") throw new Exception("Nonseekable upload unexpectedly retried");
                if (sends != 2) throw new Exception("Expected two sends");
            } catch (Telnyx.Sdk.Exceptions.TelnyxApiException e) when (mode == "nonseekable") {
                if ((int)e.StatusCode != 500 || !e.Message.Contains("original-upload-error") || sends != 1)
                    throw new Exception("Did not preserve first HTTP error", e);
            }
            if (stream.Disposals != 0) throw new Exception("Disposed caller stream");
        });
        if (failures != 0) throw new Exception($"{failures} lifetime regressions failed");
    }
    static HttpRequest<PortoutListRejectionCodesParams> Request() => new() { Method=HttpMethod.Get, Params=new(){PortoutID="dummy"} };
    static TelnyxClientWithRawResponse Client(HttpMessageHandler handler, int retries=0, int timeout=5000) => new() { ApiKey="dummy", HttpClient=new HttpClient(handler), MaxRetries=retries, Timeout=TimeSpan.FromMilliseconds(timeout) };
    static HttpResponseMessage Response(Stream stream) => new(HttpStatusCode.OK) { Content=new StreamContent(stream) };
    static async Task Cancelled(Task task) {
        try { await task.WaitAsync(TimeSpan.FromSeconds(2)); }
        catch (OperationCanceledException) { return; }
        throw new Exception("Expected OperationCanceledException");
    }
    sealed class Handler : HttpMessageHandler {
        readonly Func<HttpRequestMessage,CancellationToken,Task<HttpResponseMessage>> send;
        public Handler(Func<HttpRequestMessage,CancellationToken,Task<HttpResponseMessage>> send) { this.send=send; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage r,CancellationToken c)=>send(r,c);
    }
    sealed class TrackingContent : StringContent {
        public int Disposals;
        public TrackingContent():base("{}") {}
        protected override void Dispose(bool disposing) { if(disposing) Disposals++; base.Dispose(disposing); }
    }
    sealed class UploadStream : MemoryStream {
        readonly bool seekable;
        public int Disposals;
        public UploadStream(bool seekable):base(new byte[]{9,9,1,2,3}) { this.seekable=seekable; }
        public override bool CanSeek => seekable;
        protected override void Dispose(bool disposing) { if (disposing) Disposals++; base.Dispose(disposing); }
    }
    sealed class SlowStream : MemoryStream {
        public TaskCompletionSource<bool> Started = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public SlowStream():base(Encoding.UTF8.GetBytes("{}")) {}
        public override async ValueTask<int> ReadAsync(Memory<byte> buffer,CancellationToken c=default) { Started.TrySetResult(true); await Task.Delay(1000,c); return await base.ReadAsync(buffer,c); }
    }
}
