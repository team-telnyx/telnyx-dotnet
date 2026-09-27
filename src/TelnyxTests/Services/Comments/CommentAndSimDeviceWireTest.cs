using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PhoneNumbers.CommentAsRead;
using Telnyx.net.Services.PhoneNumbers.CommentAsRead;
using Xunit;

namespace TelnyxTests.Services.Comments
{
    [Collection("Telnyx-mock tests")]
    public class CommentAndSimDeviceWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CommentReadUsesPatchAndOnlyCommentId(bool asynchronous)
        {
            // PATCH /comments/{id}/read has no requestBody and returns data: Comment.
            // Legacy parentId/options are not identifiers for this single-resource action.
            await AssertWireRequest(async () =>
            {
                var service = new CommentAsReadService();
                var options = new UpsertCommentAsRead { Id = "not-the-comment" };
                var result = asynchronous
                    ? await service.UpdateAsync("not-a-parent", Id, options, null, string.Empty, CancellationToken.None)
                    : service.Update("not-a-parent", Id, options, null);
                Assert.Equal(Guid.Parse(Id), result.Id);
                Assert.Equal("read comment", result.Body);
            }, "PATCH", $"/v2/comments/{Id}/read", "{\"data\":{\"id\":\"" + Id + "\",\"body\":\"read comment\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task SimDeviceUsesInterpolatedRouteAndDataEnvelope(bool asynchronous)
        {
            // GET /sim_cards/{id}/device_details, SIMCardDeviceDetails canonical examples.
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.Wireless.SimCards.SIMCardDeviceDetails.SIMCardDeviceDetailService();
                var result = asynchronous ? await service.GetAsync(Id) : service.Get(Id);
                Assert.Equal("device_details", result.RecordType);
                Assert.Equal(457032284023794L, result.IMEI);
                Assert.Equal("iPad Pro 11 2020 Cellular", result.ModelName);
                Assert.Equal("Apple", result.BrandName);
                Assert.Equal("Tablet", result.DeviceType);
                Assert.Equal("iOS 12", result.OperatingSystem);
            }, "GET", $"/v2/sim_cards/{Id}/device_details", "{\"data\":{\"record_type\":\"device_details\",\"imei\":\"457032284023794\",\"model_name\":\"iPad Pro 11 2020 Cellular\",\"brand_name\":\"Apple\",\"device_type\":\"Tablet\",\"operating_system\":\"iOS 12\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task AssignmentUses10dlcRouteAndPreservesScalarStatus(bool asynchronous)
        {
            // AssignmentTaskStatusResponse is at the root, with string status.
            await AssertWireRequest(async () =>
            {
                var service = new Telnyx.net.Services.PhoneNumbers.PhoneNumberAssignmentByProfiles.PhoneNumberAssignmentByProfileService();
                var result = asynchronous
                    ? await service.GetPhoneNumberAssignmentByProfileAsync(Id)
                    : service.GetPhoneNumberAssignmentByProfile(Id);
                Assert.Equal(Id, result.TaskId);
                Assert.Equal("pending", result.Status.Status);
                var serialized = Newtonsoft.Json.Linq.JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                Assert.Equal(Newtonsoft.Json.Linq.JTokenType.String, serialized["status"].Type);
                Assert.Equal("pending", (string)serialized["status"]);
            }, "GET", $"/v2/10dlc/phoneNumberAssignmentByProfile/{Id}", "{\"taskId\":\"" + Id + "\",\"status\":\"pending\"}");
        }

        [Fact]
        public void AssignmentLegacyObjectStatusRoundTripsWithoutShapeChange()
        {
            const string json = "{\"taskId\":\"task\",\"status\":{\"status\":\"pending\"}}";
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles.PhoneNumberAssignmentByProfile>(json);
            Assert.Equal("pending", result.Status.Status);
            var serialized = Newtonsoft.Json.Linq.JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            Assert.Equal(Newtonsoft.Json.Linq.JTokenType.Object, serialized["status"].Type);
            Assert.Equal("pending", (string)serialized["status"]["status"]);
        }

        [Theory]
        [InlineData("\"completed\"")]
        [InlineData("\"future_status\"")]
        [InlineData("\"\"")]
        [InlineData("null")]
        public void AssignmentStatusRetainsExactScalarValue(string statusJson)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles.PhoneNumberAssignmentByProfile>("{\"status\":" + statusJson + "}");
            var serialized = Newtonsoft.Json.Linq.JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            Assert.True(Newtonsoft.Json.Linq.JToken.DeepEquals(Newtonsoft.Json.Linq.JToken.Parse(statusJson), serialized["status"]));
        }

        [Theory]
        [InlineData("42")]
        [InlineData("true")]
        [InlineData("[]")]
        public void AssignmentStatusDoesNotCoerceInvalidScalarTypes(string statusJson)
        {
            Assert.Throws<Newtonsoft.Json.JsonSerializationException>(() =>
                Newtonsoft.Json.JsonConvert.DeserializeObject<Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles.PhoneNumberAssignmentByProfile>("{\"status\":" + statusJson + "}"));
        }

        [Fact]
        public void NewlyConstructedAssignmentStatusRetainsLegacyObjectShape()
        {
            var result = new Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles.PhoneNumberAssignmentByProfile
            {
                Status = new Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles.StatusObject { Status = "pending" },
            };
            var serialized = Newtonsoft.Json.Linq.JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            Assert.Equal(Newtonsoft.Json.Linq.JTokenType.Object, serialized["status"].Type);
            Assert.Equal("pending", (string)serialized["status"]["status"]);
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
                    var error = await Record.ExceptionAsync(async () => await requestTask.WaitAsync(TimeSpan.FromSeconds(10)));
                    Assert.Equal($"{method} {path} HTTP/1.1", requestLine);
                    Assert.Equal(0, contentLength);
                    Assert.Null(error);
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
