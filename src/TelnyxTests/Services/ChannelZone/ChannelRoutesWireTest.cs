using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Telnyx;
using Telnyx.net.Services.InboundChannels;
using Xunit;

namespace TelnyxTests.Services.ChannelZone
{
    [Collection("Telnyx-mock tests")]
    public class ChannelRoutesWireTest
    {
        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task InboundChannelsUseAccountRoute(bool update, bool asynchronous)
        {
            // Ref: canonical /inbound_channels GET/PATCH; legacy id remains ignored.
            await AssertWireRequest(async () =>
            {
                var service = new InboundChannelService();
                var options = new InboundChannelUpdateOptions { Channels = 7 };
                var result = update
                    ? (asynchronous ? await service.UpdateAsync("ignored", options) : service.Update("ignored", options))
                    : (asynchronous ? await service.GetAsync("ignored") : service.Get("ignored"));
                Assert.Equal(7, result.Channels);
                Assert.Equal(Telnyx.net.Entities.Enum.RecordType.InboundChannels, result.RecordType);
            }, update ? "PATCH" : "GET", "/v2/inbound_channels", update ? "{\"channels\":7}" : null,
                "{\"data\":{\"channels\":7,\"record_type\":\"inbound_channels\"}}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ChannelZonesListUsesResourceRoute(bool asynchronous)
        {
            // Ref: canonical GET /channel_zones returns the data array.
            await AssertWireRequest(async () =>
            {
                var service = new ChannelZoneService();
                var result = asynchronous ? await service.ListAsync() : service.List();
                var zone = Assert.Single(result.Data);
                Assert.Equal("zone-1", zone.Id);
                Assert.Equal(7, zone.Channels);
            }, "GET", "/v2/channel_zones", null,
                "{\"data\":[{\"id\":\"zone-1\",\"channels\":7,\"record_type\":\"channel_zone\"}]}");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ChannelZoneUpdateUsesPutAndUnwrappedResponse(bool asynchronous)
        {
            // Ref: canonical PUT /channel_zones/{channel_zone_id} returns GcbChannelZone directly.
            await AssertWireRequest(async () =>
            {
                var service = new ChannelZoneService();
                var options = new ChannelZoneUpdate { Channels = 7 };
                var result = asynchronous ? await service.UpdateAsync("zone-1", options) : service.Update("zone-1", options);
                Assert.NotNull(result);
                Assert.Equal("zone-1", result.Id);
                Assert.Equal(7, result.Channels);
                Assert.Equal("channel_zone", result.RecordType);
            }, "PUT", "/v2/channel_zones/zone-1", "{\"channels\":7}",
                "{\"id\":\"zone-1\",\"channels\":7,\"record_type\":\"channel_zone\"}");
        }

        private static async Task AssertWireRequest(Func<Task> invoke, string method, string path, string body, string response)
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
                using (var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
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

                    var buffer = new char[contentLength];
                    var offset = 0;
                    while (offset < buffer.Length)
                    {
                        var count = await reader.ReadAsync(buffer, offset, buffer.Length - offset).WaitAsync(TimeSpan.FromSeconds(10));
                        if (count == 0) { throw new EndOfStreamException(); }
                        offset += count;
                    }

                    var bytes = Encoding.UTF8.GetBytes(response);
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {bytes.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    await stream.FlushAsync();
                    var exception = await Record.ExceptionAsync(() => requestTask.WaitAsync(TimeSpan.FromSeconds(10)));
                    Assert.Equal($"{method} {path} HTTP/1.1", requestLine);
                    if (body == null)
                    {
                        Assert.Equal(0, contentLength);
                    }
                    else
                    {
                        Assert.True(JToken.DeepEquals(JToken.Parse(body), JToken.Parse(new string(buffer))), new string(buffer));
                    }
                    Assert.Null(exception);
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
