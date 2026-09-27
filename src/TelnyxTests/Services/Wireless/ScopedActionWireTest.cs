namespace TelnyxTests.Services.Wireless
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Faxes;
    using Telnyx.net.Entities.Wireless.PrivateWirelessGatewaySIMCardGroups;
    using Telnyx.net.Services.Faxes.Applications;
    using Telnyx.net.Services.Wireless.PrivateWirelessGatewaySIMCardGroups;
    using Telnyx.net.Services.Wireless.SettingSIMCardPublicIPs;
    using Telnyx.net.Services.Wireless.SimCards.SIMCardRemovePublicIPs;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class ScopedActionWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        // Ref: canonical paths in pr93-legacy-mock-spec.json: cancel has no requestBody.
        [Theory]
        [InlineData("fax", false)]
        [InlineData("fax", true)]
        [InlineData("set", false)]
        [InlineData("set", true)]
        [InlineData("remove", false)]
        [InlineData("remove", true)]
        [InlineData("gateway", false)]
        [InlineData("gateway", true)]
        [InlineData("set", false, "us-east-1")]
        [InlineData("set", true, "us-east-1")]
        public async Task ActionUsesCanonicalWireContract(string action, bool asynchronous, string regionCode = null)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var call = Task.Run(() => Invoke(action, asynchronous, Id, regionCode));
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
                {
                    var line = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    string header;
                    while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10))))
                    {
                        var split = header.IndexOf(':');
                        headers.Add(header.Substring(0, split), header.Substring(split + 1).Trim());
                    }

                    int length = headers.TryGetValue("Content-Length", out var value) ? int.Parse(value) : 0;
                    var body = new char[length];
                    var offset = 0;
                    while (offset < length)
                    {
                        var count = await reader.ReadAsync(body, offset, length - offset).WaitAsync(TimeSpan.FromSeconds(10));
                        Assert.True(count > 0);
                        offset += count;
                    }

                    var response = Encoding.UTF8.GetBytes("{\"data\":{\"id\":\"" + Id + "\",\"result\":\"ok\"}}");
                    var responseHeaders = Encoding.ASCII.GetBytes($"HTTP/1.1 202 Accepted\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(responseHeaders, 0, responseHeaders.Length);
                    await stream.WriteAsync(response, 0, response.Length);
                    await stream.FlushAsync();
                    await call.WaitAsync(TimeSpan.FromSeconds(10));
                    var path = action == "fax" ? $"faxes/{Id}/actions/cancel" : action == "gateway" ? $"sim_card_groups/{Id}/actions/set_private_wireless_gateway" : $"sim_cards/{Id}/actions/{(action == "set" ? "set" : "remove")}_public_ip";
                    var query = regionCode == null ? string.Empty : $"?region_code={regionCode}";
                    Assert.Equal($"POST /v2/{path}{query} HTTP/1.1", line);
                    Assert.Equal("Bearer wire-test-key", headers["Authorization"]);
                    Assert.Equal("action-key", headers["Idempotency-Key"]);
                    Assert.Equal("2019-08-16", headers["Telnyx-Version"]);
                    Assert.False(string.IsNullOrEmpty(headers["User-Agent"]));
                    if (action == "gateway")
                    {
                        Assert.StartsWith("application/json", headers["Content-Type"]);
                        Assert.Equal("{\"private_wireless_gateway_id\":\"" + Id + "\"}", new string(body));
                    }
                    else
                    {
                        Assert.Empty(body);
                        Assert.False(headers.ContainsKey("Content-Type"));
                        Assert.False(headers.ContainsKey("Transfer-Encoding"));
                    }
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }

        [Theory]
        [InlineData("fax", false)]
        [InlineData("fax", true)]
        [InlineData("set", false)]
        [InlineData("set", true)]
        [InlineData("remove", false)]
        [InlineData("remove", true)]
        [InlineData("gateway", false)]
        [InlineData("gateway", true)]
        public async Task InvalidActionIdIsRejectedBeforeTransport(string action, bool asynchronous)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase("http://127.0.0.1:1/v2");
                foreach (var id in new[] { "../other", "id?redirect=x", "id#fragment", "id/other", "%2e%2e", "", null })
                {
                    await Assert.ThrowsAsync<ArgumentException>(() => Invoke(action, asynchronous, id));
                }
            }
            finally
            {
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }

        private static async Task Invoke(string action, bool asynchronous, string id, string regionCode = null)
        {
            var request = new RequestOptions { ApiKey = "wire-test-key", IdempotencyKey = "action-key", TelnyxVersion = "2019-08-16" };
            if (action == "fax")
            {
                var service = new FaxActionCancelService();
                var options = new UpsertFaxActionCancel { Id = Guid.NewGuid() };
                Assert.NotNull(asynchronous ? await service.CreateAsync(id, options, request, "", CancellationToken.None) : service.Create(id, options, request));
            }
            else if (action == "gateway")
            {
                var service = new PrivateWirelessGatewaySIMCardGroupService();
                var options = new UpsertPrivateWirelessGatewaySIMCardGroup { PrivateWirelessGatewayId = Guid.Parse(Id) };
                Assert.NotNull(asynchronous ? await service.CreateAsync(id, options, request, "", CancellationToken.None) : service.Create(id, options, request));
            }
            else if (action == "set")
            {
                var service = new SettingSIMCardPublicIPService();
                var options = new BaseOptions();
                if (regionCode != null)
                {
                    options.AddExtraParam("region_code", regionCode);
                }

                Assert.NotNull(asynchronous ? await service.CreateAsync(id, options, request, "", CancellationToken.None) : service.Create(id, options, request));
            }
            else
            {
                var service = new SIMCardRemovePublicIPService();
                Assert.NotNull(asynchronous ? await service.CreateAsync(id, new BaseOptions(), request, "", CancellationToken.None) : service.Create(id, new BaseOptions(), request));
            }
        }
    }
}
