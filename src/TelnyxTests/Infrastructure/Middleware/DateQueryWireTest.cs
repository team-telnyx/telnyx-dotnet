namespace TelnyxTests.Infrastructure.Middleware
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services.Faxes;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class DateQueryWireTest
    {
        [Theory]
        [InlineData(false, "en-US", "2020-02-02T22:25:27.521992Z")]
        [InlineData(true, "fr-FR", "2020-02-02T22:25:27.521992Z")]
        [InlineData(false, "fr-FR", "2020-02-02T22:25:27.1234567+05:30")]
        [InlineData(true, "en-US", "2020-02-02T22:25:27.1200000-04:00")]
        public async Task FaxDateStringIsPreservedOnWire(bool asynchronous, string culture, string timestamp)
        {
            var options = new FaxListOptions { CreatedAtDateGreaterThan = timestamp };
            var requestLine = await CaptureFaxRequest(options, asynchronous, culture);

            Assert.Equal("GET /v2/faxes?filter[created_at][gt]=" + WebUtility.UrlEncode(timestamp) + "& HTTP/1.1", requestLine);
        }

        [Theory]
        [InlineData(false, "en-US")]
        [InlineData(true, "fr-FR")]
        public async Task PrimitiveQueryValuesRetainTheirWireRepresentation(bool asynchronous, string culture)
        {
            var options = new PrimitiveFaxOptions
            {
                Count = 42,
                Enabled = true,
                DirectionEquals = "inbound",
            };
            var requestLine = await CaptureFaxRequest(options, asynchronous, culture);

            Assert.Equal("GET /v2/faxes?filter[count]=42&filter[enabled]=true&filter[direction][eq]=inbound& HTTP/1.1", requestLine);
        }

        [Theory]
        [InlineData("+13127367276")]
        [InlineData("literal & plus+ hash# percent% equals= / unicode-é")]
        [InlineData("2020-02-02T22:25:27.123456789+05:30")]
        [InlineData("2020-02-02T22:25:27.0000000Z")]
        [InlineData("not-a-date")]
        [InlineData("")]
        public async Task StringInputsAreEncodedOnceWithoutNormalization(string value)
        {
            var options = new FaxListOptions { CreatedAtDateGreaterThan = value };
            var requestLine = await CaptureFaxRequest(options, true, "en-US");

            Assert.Equal("GET /v2/faxes?filter[created_at][gt]=" + WebUtility.UrlEncode(value) + "& HTTP/1.1", requestLine);
        }

        private static async Task<string> CaptureFaxRequest(FaxListOptions options, bool asynchronous, string culture)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                var requestTask = Task.Run(async () =>
                {
                    var service = new FaxService();
                    var result = asynchronous ? await service.ViewFaxesAsync(options) : service.ViewFaxes(options);
                    Assert.NotNull(result);
                });
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true))
                {
                    var requestLine = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    while (!string.IsNullOrEmpty(await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10))))
                    {
                    }

                    var body = Encoding.UTF8.GetBytes("{\"data\":[]}");
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {body.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(body, 0, body.Length);
                    await stream.FlushAsync();
                    await requestTask.WaitAsync(TimeSpan.FromSeconds(10));
                    return requestLine;
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
                TelnyxConfiguration.SetApiKey(oldKey);
                CultureInfo.CurrentCulture = oldCulture;
            }
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("fr-FR")]
        public void BracketedScalarValuesUseInvariantWireTypes(string culture)
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                var query = Telnyx.Infrastructure.Middleware.RequestStringBuilder.BuildRequestStringFromJObject(
                    new Newtonsoft.Json.Linq.JObject
                    {
                        ["filter[enabled]"] = true,
                        ["filter[disabled]"] = false,
                        ["filter[amount]"] = 1.25m,
                    });
                Assert.Equal("filter[enabled]=true&filter[disabled]=false&filter[amount]=1.25&", query);
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCulture;
            }
        }

        private class PrimitiveFaxOptions : FaxListOptions
        {
            [Newtonsoft.Json.JsonProperty("filter[count]")]
            public int Count { get; set; }

            [Newtonsoft.Json.JsonProperty("filter[enabled]")]
            public bool Enabled { get; set; }
        }
    }
}
