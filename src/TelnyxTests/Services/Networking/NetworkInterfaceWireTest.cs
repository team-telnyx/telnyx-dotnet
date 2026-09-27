namespace TelnyxTests.Services.Networking
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services.Networking;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class NetworkInterfaceWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task InvalidNetworkIdsAreRejectedBeforeTransport(bool asynchronous)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
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
                        var service = new NetworkInterfaceService();
                        var request = new RequestOptions { ApiKey = "wire-test-key" };
                        var call = Task.Run(async () => asynchronous ? await service.ListAsync(id, requestOptions: request) : service.List(id, requestOptions: request));
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

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ListUsesNetworkIdInCanonicalPath(bool asynchronous)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var service = new NetworkInterfaceService();
                var request = new RequestOptions { ApiKey = "wire-test-key", TelnyxVersion = "2019-08-16" };
                var call = Task.Run(async () => asynchronous ? await service.ListAsync(Id, requestOptions: request) : service.List(Id, requestOptions: request));
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

                    // Minimal schema-valid response: optional record_type is intentionally absent.
                    // Its legacy bool/string incompatibility is a separate public-model decision.
                    var response = Encoding.UTF8.GetBytes("{\"data\":[{\"id\":\"" + Id + "\",\"name\":\"first\"},{\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"name\":\"second\"}],\"meta\":{\"page_number\":1,\"page_size\":20,\"total_pages\":1,\"total_results\":2}}");
                    var responseHeaders = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(responseHeaders, 0, responseHeaders.Length);
                    await stream.WriteAsync(response, 0, response.Length);
                    await stream.FlushAsync();
                    var result = await call.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"GET /v2/networks/{Id}/network_interfaces HTTP/1.1", line);
                    Assert.Equal("Bearer wire-test-key", headers["Authorization"]);
                    Assert.Equal("2019-08-16", headers["Telnyx-Version"]);
                    Assert.False(headers.ContainsKey("Content-Type"));
                    Assert.False(headers.ContainsKey("Transfer-Encoding"));
                    Assert.True(!headers.ContainsKey("Content-Length") || headers["Content-Length"] == "0");
                    Assert.Collection(result.Data,
                        first => { Assert.Equal(Guid.Parse(Id), first.Id); Assert.Equal("first", first.Name); },
                        second => { Assert.Equal(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), second.Id); Assert.Equal("second", second.Name); });
                    Assert.NotNull(result.PageInfo);
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }
    }
}
