using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.RoomSessions;
using Telnyx.net.Services.Recordings;
using Telnyx.net.Services.RoomSessions;
using Xunit;

namespace TelnyxTests.Services.Recordings
{
    [Collection("Telnyx-mock tests")]
    public class RecordingRoomSessionWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task RecordingUsesResourceRoute(bool delete, bool asynchronous)
        {
            // Public GET/DELETE /recordings/{recording_id}, RecordingResponse envelope.
            await AssertWireRequest(async () =>
            {
                var service = new RecordingService();
                var result = delete
                    ? (asynchronous ? await service.DeleteRecordingAsync(Id) : service.DeleteRecording(Id))
                    : (asynchronous ? await service.GetRecordingAsync(Id) : service.GetRecording(Id));
                Assert.NotNull(result);
            }, delete ? "DELETE" : "GET", $"/v2/recordings/{Id}", "{\"data\":{\"id\":\"" + Id + "\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task EndSessionUsesPathIdWithoutRequestBody(bool asynchronous)
        {
            // Public POST /room_sessions/{room_session_id}/actions/end has no requestBody.
            // A conflicting legacy option must not override the explicit path argument.
            var options = new UpsertRoomSession { RoomSessionId = Guid.Parse("0ccc7b54-4df3-4bca-a65a-3da1ecc777f0") };
            await AssertWireRequest(async () =>
            {
                var service = new RoomSessionService();
                var result = asynchronous
                    ? await service.CreateAsync(Id, options, new RequestOptions(), string.Empty, CancellationToken.None)
                    : service.Create(Id, options, new RequestOptions());
                Assert.NotNull(result);
            }, "POST", $"/v2/room_sessions/{Id}/actions/end", "{\"data\":{\"result\":\"ok\"}}");
        }

        private static async Task AssertWireRequest(Func<Task> invoke, string method, string path, string response)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                var requestTask = Task.Run(invoke);
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true))
                {
                    var requestLine = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    var contentLength = 0;
                    string header;
                    while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10))))
                    {
                        if (header.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                        {
                            contentLength = int.Parse(header.Substring("Content-Length:".Length).Trim());
                        }
                    }

                    var bytes = Encoding.UTF8.GetBytes(response);
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {bytes.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    await stream.FlushAsync();
                    await requestTask.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"{method} {path} HTTP/1.1", requestLine);
                    Assert.Equal(0, contentLength);
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
                TelnyxConfiguration.SetApiKey(oldKey);
            }
        }
    }
}
