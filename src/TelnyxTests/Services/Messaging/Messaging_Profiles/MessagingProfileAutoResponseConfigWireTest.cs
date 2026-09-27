using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Services.Messaging.Messaging_Profiles;
using Xunit;

namespace TelnyxTests.Services.Messaging.Messaging_Profiles
{
    [Collection("Telnyx-mock tests")]
    public class MessagingProfileAutoResponseConfigWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public static System.Collections.Generic.IEnumerable<object[]> InvalidIds()
        {
            foreach (var id in new[] { null, "", " ", "not-a-uuid", "..", "../other", "%2e%2e%2fother", Id + "/other", Id + "?x=1", Id + "#fragment", " " + Id, Id + " ", Id.Replace("-", ""), "{" + Id + "}" })
            {
                yield return new object[] { false, id };
                yield return new object[] { true, id };
            }
        }

        [Theory]
        [MemberData(nameof(InvalidIds))]
        public async Task InvalidProfileIdIsRejectedBeforeSend(bool asynchronous, string id)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            try
            {
                // Closed loopback port prevents external traffic if validation regresses.
                TelnyxConfiguration.SetApiBase("http://127.0.0.1:1/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                var service = new MessagingProfileAutoResponseConfigService();
                var error = asynchronous
                    ? await Assert.ThrowsAsync<ArgumentException>(() => service.ListAsync(id))
                    : Assert.Throws<ArgumentException>(() => service.List(id));
                Assert.Equal("id", error.ParamName);
            }
            finally
            {
                TelnyxConfiguration.SetApiBase(oldBase);
                TelnyxConfiguration.SetApiKey(oldKey);
            }
        }

        [Theory]
        [InlineData(false, Id)]
        [InlineData(true, Id)]
        [InlineData(false, "6A09CDC3-8948-47F0-AA62-74AC943D6C58")]
        [InlineData(true, "6A09CDC3-8948-47F0-AA62-74AC943D6C58")]
        public async Task ListUsesProfileIdOnWire(bool asynchronous, string id)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                var requestTask = Task.Run(async () =>
                {
                    var service = new MessagingProfileAutoResponseConfigService();
                    var result = asynchronous ? await service.ListAsync(id) : service.List(id);
                    var config = Assert.Single(result.Data);
                    Assert.Equal("response-id", config.Id);
                    Assert.Equal("start", config.Operation);
                    Assert.Equal("Subscribed", config.ResponseText);
                });
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true))
                {
                    var requestLine = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    while (!string.IsNullOrEmpty(await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10))))
                    {
                    }

                    var body = Encoding.UTF8.GetBytes("{\"data\":[{\"id\":\"response-id\",\"op\":\"start\",\"resp_text\":\"Subscribed\"}]}");
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {body.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(body, 0, body.Length);
                    await stream.FlushAsync();
                    await requestTask.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"GET /v2/messaging_profiles/{id}/autoresp_configs HTTP/1.1", requestLine);
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
