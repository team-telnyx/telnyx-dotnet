namespace LegacyFixture {
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Telnyx;

public static class Program
{
    public static void Main()
    {
        var handler = new RecordingHandler();
        TelnyxConfiguration.HttpMessageHandler = handler;
        TelnyxConfiguration.SetApiBase("https://compat.invalid/v2");
        TelnyxConfiguration.SetApiKey("dummy-global");
        var value = LegacyContract.Send(CancellationToken.None).GetAwaiter().GetResult();
        Check(value.Type == OutboundMessage.TypeEnum.SmsEnum, "enum response");
        Check(value.Text == "compatibility", "response text");
        var sync = new CustomerMessageService().Create(LegacyContract.Options(), new RequestOptions {IdempotencyKey="fixed-test-key"});
        Check(sync.Type == OutboundMessage.TypeEnum.SmsEnum, "sync response");
        Check(handler.Count == 2, "exactly one request per operation (no retries)");
        var name = typeof(MessageService).Assembly.GetName();
        Check(name.Name == "Telnyx.net" && name.Version.ToString() == "3.1.0.0", "assembly identity");
        Check(name.GetPublicKeyToken().Length == 0, "unsigned legacy identity");
        Check(typeof(OutboundMessage).Assembly == typeof(MessageService).Assembly, "type assembly identity");
        Console.WriteLine("PASS: sync/async wire, auth precedence, enum, legacy assembly identity; requests=" + handler.Count);
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies().OrderBy(a => a.FullName)) Console.WriteLine("LOADED " + a.FullName);
    }
    public static void Check(bool condition, string description)
    { if (!condition) throw new Exception("FAIL: " + description); }
}
public sealed class RecordingHandler : HttpMessageHandler
{
    public int Count;
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Never delegates to a sockets handler: no API/network I/O is possible here.
        Program.Check(request.RequestUri.AbsoluteUri == "https://compat.invalid/v2/messages", "URL");
        Program.Check(request.Method == HttpMethod.Post, "verb");
        Program.Check(request.Headers.Authorization.ToString() == "Bearer dummy-service", "service wins over request/global key");
        Program.Check(request.Headers.GetValues("Idempotency-Key").Single() == "fixed-test-key", "idempotency");
        Program.Check(request.Headers.GetValues("Telnyx-Version").Single() == "2019-03-14", "API version");
        var body = JObject.Parse(await request.Content.ReadAsStringAsync());
        Program.Check((string)body["text"] == "compatibility", "body text");
        Program.Check((bool)body["use_profile_webhooks"] == false, "false preserved");
        Program.Check(body["webhook_url"] == null, "null omitted");
        Count++;
        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"data\":{\"id\":\"00000000-0000-0000-0000-000000000000\",\"type\":\"sms\",\"text\":\"compatibility\"}}") };
    }
}


}