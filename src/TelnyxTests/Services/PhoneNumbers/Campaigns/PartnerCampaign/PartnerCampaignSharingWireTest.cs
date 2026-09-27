namespace TelnyxTests.Services.PhoneNumbers.Campaigns.PartnerCampaign
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class PartnerCampaignSharingWireTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task InvalidCampaignIdsAreRejectedBeforeTransport(bool asynchronous)
        {
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                foreach (var id in new[] { null, "", ".", ".." })
                {
                    var listener = new TcpListener(IPAddress.Loopback, 0);
                    listener.Start();
                    try
                    {
                        TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                        var connection = listener.AcceptTcpClientAsync();
                        var service = new PartnerCampaignSharingService();
                        var request = new RequestOptions { ApiKey = "wire-test-key" };
                        var call = Task.Run(async () => asynchronous ? await service.GetAsync(id, requestOptions: request) : service.Get(id, requestOptions: request));
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
        [InlineData(false, "campaign123")]
        [InlineData(true, "campaign123")]
        [InlineData(false, "campaign/name?x=y#fragment%") ]
        [InlineData(true, "campaign/name?x=y#fragment%") ]
        public async Task GetUsesCampaignPathAndRootSharingChain(bool asynchronous, string campaignId)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var service = new PartnerCampaignSharingService();
                var request = new RequestOptions { ApiKey = "wire-test-key", TelnyxVersion = "2019-08-16" };
                var call = Task.Run(async () => asynchronous ? await service.GetAsync(campaignId, requestOptions: request) : service.Get(campaignId, requestOptions: request));
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

                    // Synthetic root-shaped CampaignSharingChain; exercise both branches.
                    var response = Encoding.UTF8.GetBytes("{\"sharedByMe\":{\"downstreamCnpId\":\"downstream-a\",\"sharingStatus\":\"ACTIVE\"},\"sharedWithMe\":{\"upstreamCnpId\":\"upstream-b\",\"sharingStatus\":\"PENDING\"}}");
                    var responseHeaders = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(responseHeaders, 0, responseHeaders.Length);
                    await stream.WriteAsync(response, 0, response.Length);
                    await stream.FlushAsync();
                    var result = await call.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Equal($"GET /v2/10dlc/campaign/{Uri.EscapeDataString(campaignId)}/sharing HTTP/1.1", line);
                    Assert.Equal("Bearer wire-test-key", headers["Authorization"]);
                    Assert.Equal("2019-08-16", headers["Telnyx-Version"]);
                    Assert.False(headers.ContainsKey("Content-Type"));
                    Assert.False(headers.ContainsKey("Transfer-Encoding"));
                    Assert.True(!headers.ContainsKey("Content-Length") || headers["Content-Length"] == "0");
                    Assert.Equal("downstream-a", result.SharedByMe.DownstreamCnpId);
                    Assert.Equal("ACTIVE", result.SharedByMe.SharingStatus);
                    Assert.Equal("upstream-b", result.SharedWithMe.UpstreamCnpId);
                    Assert.Equal("PENDING", result.SharedWithMe.SharingStatus);
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
