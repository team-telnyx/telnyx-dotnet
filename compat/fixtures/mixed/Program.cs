using System.Net;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk;
using Telnyx.Sdk.Models.Messages;
using Telnyx.Sdk.Models.AI.Assistants;

if (args.Contains("legacy-first")) LegacyFixture.Program.Main();

// Ref: pinned generated IMessageService, IAssistantService, and parameter classes.
// Real public consumer; all HTTP dispatches terminate in the mock handler.
using var handler = new RecordingHandler();
using var http = new HttpClient(handler);
var client = new TelnyxClient { ApiKey = "spike-not-a-real-key", BaseUrl = "https://spike.invalid/v2", HttpClient = http, MaxRetries = 0 };
var send = await client.Messages.Send(new MessageSendParams {
    To = "+15555550101", From = "+15555550102", Text = "mock only",
    AutoDetect = true, Encoding = Telnyx.Sdk.Models.Messages.Encoding.Gsm7,
    Subject = "spike subject", Type = MessageSendParamsType.Sms,
    MessagingProfileID = "profile-string-not-a-guid", SendAt = DateTimeOffset.Parse("2027-01-01T00:00:00Z")
});
Check(send.Data?.ID == "message-spike", "typed message response");
var assistant = await client.AI.Assistants.Create(new AssistantCreateParams { Name = "spike assistant", Instructions = "Test only", Model = "test-model" });
Check(assistant.ID == "assistant-spike" && assistant.Name == "spike assistant", "typed AI response");
Check(handler.Count == 2, "exact request count");
Console.WriteLine("PASS: 2 public typed messaging/AI wire cases; zero real network requests");
await PaginationProbe.Run();
if (!args.Contains("legacy-first")) LegacyFixture.Program.Main();
static void Check(bool value, string message) { if (!value) throw new Exception(message); }

sealed class RecordingHandler : HttpMessageHandler {
    public int Count { get; private set; }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct) {
        if (request.RequestUri?.Host != "spike.invalid") throw new Exception("Unexpected host");
        if (request.Method != HttpMethod.Post) throw new Exception("Expected POST");
        if (request.Headers.Authorization?.ToString() != "Bearer spike-not-a-real-key") throw new Exception("Bad auth");
        var json = await request.Content!.ReadAsStringAsync(ct);
        using var body = JsonDocument.Parse(json);
        string response;
        switch (request.RequestUri.AbsolutePath) {
            case "/v2/messages":
                if (body.RootElement.GetProperty("to").GetString() != "+15555550101" ||
                    body.RootElement.GetProperty("text").GetString() != "mock only" ||
                    !body.RootElement.GetProperty("auto_detect").GetBoolean() ||
                    body.RootElement.GetProperty("encoding").GetString() != "gsm7" ||
                    body.RootElement.GetProperty("subject").GetString() != "spike subject" ||
                    body.RootElement.GetProperty("type").GetString() != "SMS" ||
                    body.RootElement.GetProperty("messaging_profile_id").GetString() != "profile-string-not-a-guid" ||
                    body.RootElement.GetProperty("send_at").GetDateTimeOffset() != DateTimeOffset.Parse("2027-01-01T00:00:00Z")) throw new Exception("Message body mismatch");
                response = "{\"data\":{\"id\":\"message-spike\"}}";
                break;
            case "/v2/ai/assistants":
                if (body.RootElement.GetProperty("name").GetString() != "spike assistant" ||
                    body.RootElement.GetProperty("instructions").GetString() != "Test only" ||
                    body.RootElement.GetProperty("model").GetString() != "test-model") throw new Exception("AI body mismatch");
                response = "{\"id\":\"assistant-spike\",\"name\":\"spike assistant\",\"instructions\":\"Test only\",\"model\":\"test-model\",\"created_at\":\"2026-01-01T00:00:00Z\"}";
                break;
            default: throw new Exception("Unexpected route: " + request.RequestUri);
        }
        Count++;
        Console.WriteLine($"MOCK {request.Method} {request.RequestUri} {json}");
        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(response, System.Text.Encoding.UTF8, "application/json") };
    }
}

