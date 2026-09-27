using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PortingOrders;
using Telnyx.net.Services.PortingOrders;
using Xunit;

namespace TelnyxTests.Services.PortingOrders
{
    [Collection("Telnyx-mock tests")]
    public class PortingOrderWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ActivationUsesOrderPathWithoutBody(bool asynchronous)
        {
            // Canonical POST /porting_orders/{id}/actions/activate has no requestBody.
            await AssertWireRequest(async () =>
            {
                var service = new PortingOrderActivateService();
                var result = asynchronous
                    ? await service.CreateAsync(Id, new UpsertPortingOrders(), null, "data", CancellationToken.None)
                    : service.Create(Id, new UpsertPortingOrders(), null);
                Assert.Equal(Guid.Parse(Id), result.Id);
            }, "POST", $"/v2/porting_orders/{Id}/actions/activate", "{\"data\":{\"id\":\"" + Id + "\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task SubRequestUsesExactOrderPathAndDataEnvelope(bool asynchronous)
        {
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.PortingOrders.PortingOrdersSubRequests.PortingOrdersSubRequestService();
                var result = asynchronous ? await service.GetAsync(Id) : service.Get(Id);
                Assert.Equal("sub-123", result.SubRequestId);
                Assert.Equal("port-456", result.PortRequestId);
            }, "GET", $"/v2/porting_orders/{Id}/sub_request", "{\"data\":{\"sub_request_id\":\"sub-123\",\"port_request_id\":\"port-456\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CommentsListUsesOrderPath(bool asynchronous)
        {
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.PortingOrders.PortingOrderComments.PortingOrderCommentService();
                var result = asynchronous ? await service.ListAsync(Id) : service.List(Id);
                Assert.Single(result.Data);
                Assert.Equal("hello", result.Data[0].Body);
            }, "GET", $"/v2/porting_orders/{Id}/comments", "{\"data\":[{\"body\":\"hello\"}]}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task RequirementsListUsesOrderPath(bool asynchronous)
        {
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.PortingOrders.PortingOrderRequirements.PortingOrderRequirementService();
                var result = asynchronous ? await service.ListAsync(Id) : service.List(Id);
                Assert.Single(result.Data);
                Assert.Equal("document", result.Data[0].FieldType);
            }, "GET", $"/v2/porting_orders/{Id}/requirements", "{\"data\":[{\"field_type\":\"document\"}]}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CommentCreatePreservesBodyAndReadsData(bool asynchronous)
        {
            var options = Newtonsoft.Json.JsonConvert.DeserializeObject<Telnyx.net.Entities.PortingOrders.PortingOrderComments.UpsertPortingOrderComment>("{\"body\":\"Please confirm the port.\"}");
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.PortingOrders.PortingOrderComments.PortingOrderCommentService();
                var result = asynchronous
                    ? await service.CreateAsync(Id, options, null, string.Empty, CancellationToken.None)
                    : service.Create(Id, options, null);
                Assert.Equal("Please confirm the port.", result.Body);
            }, "POST", $"/v2/porting_orders/{Id}/comments", "{\"data\":{\"body\":\"Please confirm the port.\"}}", "{\"body\":\"Please confirm the port.\"}");
        }

        public static System.Collections.Generic.IEnumerable<object[]> InvalidOrderIds()
        {
            foreach (var operation in new[] { "activate", "sub_request", "comments", "create_comment", "requirements" })
            foreach (var asynchronous in new[] { false, true })
            foreach (var id in new[] { null, " " + Id, "../calls/id/actions/hangup", "id?query=value", "%2e%2e", "..", "id#fragment" })
                yield return new object[] { operation, asynchronous, id };
        }

        [Theory]
        [MemberData(nameof(InvalidOrderIds))]
        public async Task InvalidOrderIdIsRejectedBeforeSend(string operation, bool asynchronous, string id)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            try
            {
                TelnyxConfiguration.SetApiBase("http://127.0.0.1:1/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                await Assert.ThrowsAsync<ArgumentException>(async () =>
                {
                    switch (operation)
                    {
                        case "activate":
                            var activation = new PortingOrderActivateService();
                            if (asynchronous) await activation.CreateAsync(id, null, null, "", CancellationToken.None);
                            else activation.Create(id, null, null);
                            break;
                        case "sub_request":
                            var sub = new Telnyx.net.Services.PortingOrders.PortingOrdersSubRequests.PortingOrdersSubRequestService();
                            if (asynchronous) await sub.GetAsync(id);
                            else sub.Get(id);
                            break;
                        case "comments":
                        case "create_comment":
                            var comments = new Telnyx.net.Services.PortingOrders.PortingOrderComments.PortingOrderCommentService();
                            if (operation == "comments")
                            {
                                if (asynchronous) await comments.ListAsync(id);
                                else comments.List(id);
                            }
                            else
                            {
                                if (asynchronous) await comments.CreateAsync(id, null, null, "", CancellationToken.None);
                                else comments.Create(id, null, null);
                            }
                            break;
                        case "requirements":
                            var requirements = new Telnyx.net.Services.PortingOrders.PortingOrderRequirements.PortingOrderRequirementService();
                            if (asynchronous) await requirements.ListAsync(id);
                            else requirements.List(id);
                            break;
                    }
                });
            }
            finally
            {
                TelnyxConfiguration.SetApiBase(oldBase);
                TelnyxConfiguration.SetApiKey(oldKey);
            }
        }

        private static async Task AssertWireRequest(Func<Task> invoke, string method, string path, string response, string expectedBody = "")
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

                    var body = new char[contentLength];
                    var read = 0;
                    while (read < body.Length)
                    {
                        var count = await reader.ReadAsync(body, read, body.Length - read).WaitAsync(TimeSpan.FromSeconds(10));
                        Assert.True(count > 0);
                        read += count;
                    }

                    var bytes = Encoding.UTF8.GetBytes(response);
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {bytes.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    await stream.FlushAsync();
                    await requestTask.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"{method} {path} HTTP/1.1", requestLine);
                    Assert.Equal(expectedBody, new string(body));
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
