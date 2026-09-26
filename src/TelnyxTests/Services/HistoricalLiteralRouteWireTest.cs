namespace TelnyxTests.Services
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
    using Telnyx.net.Services.PhoneNumbers.WireGuardPeersallowedIps;
    using Xunit;

    // Archived openapi@1d97a787b3c88edce00428076ec0c236392a3f18.
    // These operations are not present in the current contract.
    [Collection("Telnyx-mock tests")]
    public class HistoricalLiteralRouteWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData("wireguard", false)]
        [InlineData("wireguard", true)]
        [InlineData("provision", false)]
        [InlineData("provision", true)]
        [InlineData("channel", false)]
        [InlineData("channel", true)]
        [InlineData("channel", false, "zone/name?key=value#fragment%")]
        [InlineData("channel", true, "zone/name?key=value#fragment%")]
        public async Task UsesArchivedRoute(string operation, bool asynchronous, string identifier = Id)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var call = Task.Run(() => Invoke(operation, asynchronous, identifier));
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

                    // Synthetic minimal transport responses; original classes separately exercise archived Prism responses.
                    var body = Encoding.UTF8.GetBytes(operation == "provision" ? "{\"data\":{}}" : "{\"data\":[]}");
                    var status = operation == "provision" ? "202 Accepted" : "200 OK";
                    var response = Encoding.ASCII.GetBytes($"HTTP/1.1 {status}\r\nContent-Type: application/json\r\nContent-Length: {body.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(response, 0, response.Length);
                    await stream.WriteAsync(body, 0, body.Length);
                    await stream.FlushAsync();
                    await call.WaitAsync(TimeSpan.FromSeconds(10));
                    var expected = operation == "channel" ? $"GET /v2/channel_zones/{Uri.EscapeDataString(identifier)}/channel_zone_phone_numbers HTTP/1.1" : operation == "provision" ? $"POST /v2/virtual_cross_connects/{identifier}/actions/provision HTTP/1.1" : $"GET /v2/wireguard_peers/{identifier}/allowed_ips HTTP/1.1";
                    Assert.Equal(expected, line);
                    Assert.Equal("route-key", headers["Idempotency-Key"]);
                    Assert.Equal("Bearer wire-test-key", headers["Authorization"]);
                    Assert.Equal("2019-08-16", headers["Telnyx-Version"]);
                    Assert.False(headers.ContainsKey("Content-Type"));
                    Assert.False(headers.ContainsKey("Transfer-Encoding"));
                    Assert.True(!headers.ContainsKey("Content-Length") || headers["Content-Length"] == "0");
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }

        [Theory]
        [InlineData("wireguard", false)]
        [InlineData("wireguard", true)]
        [InlineData("provision", false)]
        [InlineData("provision", true)]
        [InlineData("channel", false)]
        [InlineData("channel", true)]
        public async Task RejectsInvalidIdsBeforeTransport(string operation, bool asynchronous)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                foreach (var id in operation == "channel" ? new[] { null, "", " ", ".", ".." } : new[] { null, "", "../other", "id/other", "id?x=y", "id#fragment", "%2e%2e", " " + Id, Id + " ", "{" + Id + "}", Id.Replace("-", "") })
                {
                    var listener = new TcpListener(IPAddress.Loopback, 0);
                    listener.Start();
                    try
                    {
                        TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                        var connection = listener.AcceptTcpClientAsync();
                        var call = Task.Run(() => Invoke(operation, asynchronous, id));
                        var completed = await Task.WhenAny(call, connection).WaitAsync(TimeSpan.FromSeconds(10));
                        if (completed == connection)
                        {
                            using (var client = await connection)
                            using (var stream = client.GetStream())
                            {
                                var response = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: 11\r\nConnection: close\r\n\r\n{\"data\":[]}");
                                await stream.WriteAsync(response, 0, response.Length);
                                await stream.FlushAsync();
                            }
                        }

                        var error = await Record.ExceptionAsync(async () => await call.WaitAsync(TimeSpan.FromSeconds(10)));
                        Assert.IsType<ArgumentException>(error);
                        Assert.False(connection.IsCompletedSuccessfully);
                    }
                    finally
                    {
                        listener.Stop();
                    }
                }
            }
            finally
            {
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }

        private static async Task Invoke(string operation, bool asynchronous, string id)
        {
            var request = new RequestOptions { ApiKey = "wire-test-key", IdempotencyKey = "route-key", TelnyxVersion = "2019-08-16" };
            if (operation == "channel")
            {
                var channel = new Telnyx.net.Services.ChannelZones.ChannelZonePhoneNumberService();
                Assert.NotNull(asynchronous ? await channel.ListAsync(id, requestOptions: request) : channel.List(id, requestOptions: request));
                return;
            }

            if (operation == "provision")
            {
                var provision = new Telnyx.net.Services.VirtualCrossConnects.ProvisionVirtualCrossConnectService();
                var options = new Telnyx.net.Entities.VirtualCrossConnects.UpsertProvisionVirtualCrossConnect();
                Assert.NotNull(asynchronous ? await provision.CreateAsync(id, options, request, "", CancellationToken.None) : provision.Create(id, options, request));
                return;
            }

            var service = new WireGuardPeersallowedIpService();
            Assert.NotNull(asynchronous ? await service.ListAsync(id, requestOptions: request) : service.List(id, requestOptions: request));
        }
    }
}
