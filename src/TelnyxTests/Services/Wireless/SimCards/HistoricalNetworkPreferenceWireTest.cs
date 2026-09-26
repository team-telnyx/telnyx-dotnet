namespace TelnyxTests.Services.Wireless.SimCards
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
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards.SIMCardNetworkPreference;
    using Xunit;

    // Ref: openapi@1d97a787b3c88edce00428076ec0c236392a3f18:
    // POST /sim_cards/{id}/actions/{set,delete}_network_preferences, no requestBody.
    [Collection("Telnyx-mock tests")]
    public class HistoricalNetworkPreferenceWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task UsesBodylessArchivedAction(bool delete, bool asynchronous)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var originalBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var call = Task.Run(() => Invoke(delete, asynchronous, Id));
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

                    // Synthetic transport-only response; original tests separately use archived Prism.
                    var response = Encoding.ASCII.GetBytes("HTTP/1.1 202 Accepted\r\nContent-Type: application/json\r\nContent-Length: 11\r\nConnection: close\r\n\r\n{\"data\":{}}");
                    await stream.WriteAsync(response, 0, response.Length);
                    await stream.FlushAsync();
                    await call.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"POST /v2/sim_cards/{Id}/actions/{(delete ? "delete" : "set")}_network_preferences HTTP/1.1", line);
                    Assert.Equal("Bearer wireless-wire-key", headers["Authorization"]);
                    Assert.Equal("wireless-route-key", headers["Idempotency-Key"]);
                    Assert.Equal("2019-08-16", headers["Telnyx-Version"]);
                    Assert.False(headers.ContainsKey("Content-Type"));
                    Assert.False(headers.ContainsKey("Transfer-Encoding"));
                    Assert.True(!headers.ContainsKey("Content-Length") || headers["Content-Length"] == "0");
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(originalBase);
            }
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task RejectsInvalidUuidBeforeTransport(bool delete, bool asynchronous)
        {
            var originalBase = TelnyxConfiguration.GetApiBase();
            try
            {
                foreach (var id in new[] { null, "", "../other", "id/other", "id?x=y", "id#fragment", "%2e%2e", " " + Id, Id + " ", "{" + Id + "}", Id.Replace("-", "") })
                {
                    var listener = new TcpListener(IPAddress.Loopback, 0);
                    listener.Start();
                    try
                    {
                        TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                        var connection = listener.AcceptTcpClientAsync();
                        var call = Task.Run(() => Invoke(delete, asynchronous, id));
                        var completed = await Task.WhenAny(call, connection).WaitAsync(TimeSpan.FromSeconds(10));
                        if (completed == connection)
                        {
                            using (var client = await connection)
                            using (var stream = client.GetStream())
                            {
                                var response = Encoding.ASCII.GetBytes("HTTP/1.1 202 Accepted\r\nContent-Type: application/json\r\nContent-Length: 11\r\nConnection: close\r\n\r\n{\"data\":{}}");
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
                TelnyxConfiguration.SetApiBase(originalBase);
            }
        }

        private static async Task Invoke(bool delete, bool asynchronous, string id)
        {
            var request = new RequestOptions { ApiKey = "wireless-wire-key", IdempotencyKey = "wireless-route-key", TelnyxVersion = "2019-08-16" };
            if (delete)
            {
                var service = new SIMCardDeleteNetworkPreferenceService();
                Assert.NotNull(asynchronous ? await service.CreateAsync(id, new BaseOptions(), request, "", CancellationToken.None) : service.Create(id, new BaseOptions(), request));
            }
            else
            {
                var service = new SIMCardNetworkPreferenceService();
                var options = new UpsertSIMCardNetworkPreference { Id = Guid.Parse(Id) };
                Assert.NotNull(asynchronous ? await service.CreateAsync(id, options, request, "", CancellationToken.None) : service.Create(id, "retained-unused-argument", options, request));
            }
        }
    }
}
