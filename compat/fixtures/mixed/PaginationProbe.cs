using System.Net;
using System.Text.Json;
using Telnyx.Sdk;
using Telnyx.Sdk.Models.RecordingTranscriptions;
using Telnyx.Sdk.Models.WirelessBlocklists;

static class PaginationProbe
{
    static void Check(bool condition, string message) { if (!condition) throw new Exception(message); }
    public static async Task Run()
    {
        using var handler = new PagesHandler(new string?[] {"nested/page?cursor=second", "?cursor=third", null});
        using var http = new HttpClient(handler);
        var client = new TelnyxClient { ApiKey="mock", BaseUrl="https://spike.invalid/v2", HttpClient=http, MaxRetries=0 };
        var page = await client.RecordingTranscriptions.List(new RecordingTranscriptionListParams {PageNumber=7, PageSize=2});
        Check(page.Items.Count == 1 && page.HasNext(), "first cursor page");
        page = await page.Next();
        Check(page.Items.Count == 1 && page.HasNext(), "second cursor page");
        page = await page.Next();
        Check(page.Items.Count == 1 && !page.HasNext(), "last cursor page");
        Check(Uri.UnescapeDataString(handler.Uris[0].Query).Contains("page[number]=7"), "initial page number retained");
        Check(Uri.UnescapeDataString(handler.Uris[0].Query).Contains("page[size]=2"), "initial page size retained");
        Check(handler.Uris[1].AbsoluteUri == "https://spike.invalid/v2/nested/page?cursor=second", "relative continuation");
        Check(handler.Uris[2].AbsoluteUri == "https://spike.invalid/v2/nested/page?cursor=third", "successive continuation uses preceding URL");
        Console.WriteLine("PASS: successive relative cursor URLs, first request page[number]/page[size], 3 mock dispatches");
        foreach (var url in new[] {"https://foreign.invalid/steal", "https://user:pass@spike.invalid/v2/steal"})
        {
            using var rejecting = new PagesHandler(new string?[] {url});
            using var rejectedHttp = new HttpClient(rejecting);
            var rejectedClient = new TelnyxClient {ApiKey="mock", BaseUrl="https://spike.invalid/v2", HttpClient=rejectedHttp, MaxRetries=0};
            var rejectedPage = await rejectedClient.RecordingTranscriptions.List(new());
            bool rejected = false;
            try { await rejectedPage.Next(); } catch (InvalidOperationException) { rejected=true; }
            Check(rejected && rejecting.Uris.Count == 1, "unsafe URL must reject before dispatch: " + url);
            Console.WriteLine("PASS: rejected before dispatch " + url);
        }
        using var numbered = new PagesHandler(new string?[] {null, null, null, null}, true);
        using var numberedHttp = new HttpClient(numbered);
        var numberedClient = new TelnyxClient {ApiKey="mock", BaseUrl="https://spike.invalid/v2", HttpClient=numberedHttp, MaxRetries=0};
        var numberedPage = await numberedClient.WirelessBlocklists.List(new WirelessBlocklistListParams {PageNumber=3});
        Check(numberedPage.HasNext(), "existing page-number HasNext");
        await numberedPage.Next();
        Check(Uri.UnescapeDataString(numbered.Uris[1].Query).Contains("page[number]=4"), "existing page-number Next increments");
        Console.WriteLine("PASS: existing WirelessBlocklists page-number continuation");
        var payments = await numberedClient.X402.CreditAccount.Payments.List(new() {PageNumber=3});
        Check(payments.HasNext(), "existing X402 payment page-number HasNext");
        await payments.Next();
        Check(Uri.UnescapeDataString(numbered.Uris[3].Query).Contains("page[number]=4"), "X402 page-number Next increments");
        Console.WriteLine("PASS: existing X402 payment page-number continuation");
        using var roots = new PagesHandler(new string?[] {null, null}, rootArray:true);
        using var rootHttp = new HttpClient(roots);
        var rootClient = new TelnyxClient {ApiKey="mock", BaseUrl="https://spike.invalid/v2", HttpClient=rootHttp, MaxRetries=0};
        var rootPage = await rootClient.AI.McpServers.List(new());
        Check(rootPage.Items.Count == 1 && rootPage.HasNext(), "root array Items and HasNext");
        var emptyRoot = await rootPage.Next();
        Check(emptyRoot.Items.Count == 0 && !emptyRoot.HasNext(), "empty root array ends continuation");
        Console.WriteLine("PASS: MCP root-array Items and page-number Next");
    }
    sealed class PagesHandler(string?[] next, bool numbered=false, bool rootArray=false) : HttpMessageHandler
    {
        public List<Uri> Uris {get;} = new();
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Uris.Add(request.RequestUri!);
            if (Uris.Count > next.Length) throw new Exception("Unexpected dispatch");
            var body = rootArray ? (Uris.Count == 1 ? "[{}]" : "[]") : numbered ? "{\"data\":[{}],\"meta\":{\"page_number\":3,\"total_pages\":4}}" : JsonSerializer.Serialize(new {data=new[]{new {id="recording"}},meta=new {next=next[Uris.Count-1]}});
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {Content=new StringContent(body, System.Text.Encoding.UTF8, "application/json")});
        }
    }
}

