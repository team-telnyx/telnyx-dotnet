using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Portouts;

public static class UrlProbe
{
    public static async Task Run()
    {
        using var handler = new CaptureHandler();
        using var http = new HttpClient(handler);
        using var client = new TelnyxClientWithRawResponse
        {
            HttpClient = http,
            ApiKey = "test-only",
            BaseUrl = "https://example.test/v2",
            MaxRetries = 0,
        };
        foreach (var id in new[] {
            "ordinary-id", "雪-é", "../messages/victim", "a/b", @"a\b",
            "a?x=1", "a#fragment", "a.b", "%2e%2e", "%2E%2E%2Fmessages",
            "%252e%252e", "%2f", "%5c", "100%", ".%2e", "%2e.", " "
        })
        {
            handler.ExpectedMethod = HttpMethod.Delete;
            handler.ExpectedUri = "https://example.test/v2/recording_transcriptions/" + Uri.EscapeDataString(id);
            var before = handler.Calls;
            using var response = await client.RecordingTranscriptions.Delete(id);
            Check(handler.Calls == before + 1, "DELETE did not reach fake HTTP handler");
            Console.WriteLine("PASS URL literal ID: " + id);
        }
        foreach (var id in new[] { ".", ".." })
        {
            var before = handler.Calls;
            bool rejected = false;
            try { using var response = await client.RecordingTranscriptions.Delete(id); }
            catch (ArgumentException) { rejected = true; }
            Check(rejected && handler.Calls == before, "Bare dot segment was not rejected before HTTP: " + id);
            Console.WriteLine("PASS URL rejected ID: " + id);
        }
        var originalCulture = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
            var parameters = new PortoutListRejectionCodesParams
            {
                PortoutID = "ordinary-id",
                Filter = new() { Code = new Code(new long[] { 1, 2 }) },
            };
            var uri = parameters.Url(new ClientOptions { BaseUrl = "https://example.test/v2" });
            Check(Uri.UnescapeDataString(uri.Query) == "?filter[code]=1,2", "Unexpected numeric-array query: " + uri.Query);
            handler.ExpectedMethod = HttpMethod.Get;
            handler.ExpectedUri = uri.AbsoluteUri;
            var before = handler.Calls;
            using var response = await client.Portouts.ListRejectionCodes(parameters);
            Check(handler.Calls == before + 1, "Numeric-array GET did not reach fake HTTP handler");
            Console.WriteLine("PASS URL numeric array invariant culture");
        }
        finally { CultureInfo.CurrentCulture = originalCulture; }
    }

    private static void Check(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private sealed class CaptureHandler : HttpMessageHandler
    {
        internal HttpMethod ExpectedMethod = HttpMethod.Delete;
        internal string ExpectedUri = "";
        internal int Calls;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Calls++;
            Check(request.Method == ExpectedMethod, "Unexpected method: " + request.Method);
            Check(request.RequestUri?.AbsoluteUri == ExpectedUri, "Unexpected URI: " + request.RequestUri?.AbsoluteUri + "; expected " + ExpectedUri);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });
        }
    }
}
