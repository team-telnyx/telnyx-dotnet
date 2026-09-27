namespace TelnyxTests.Infrastructure.Middleware
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;
    using Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class PlainQueryWireTest
    {
        [Theory]
        [InlineData("POST")]
        [InlineData("PATCH")]
        [InlineData("PUT")]
        public async Task BodyMethodsKeepJsonCarrierUnchanged(string method)
        {
            const string json = "{\"name\":\"literal & + ? #\",\"count\":42,\"enabled\":true}";
            using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                "http://localhost/v2/resource?" + json, new System.Net.Http.HttpMethod(method), new RequestOptions { ApiKey = "wire-test-key" }))
            {
                Assert.Equal("http://localhost/v2/resource", request.RequestUri.AbsoluteUri);
                Assert.Equal(json, await request.Content.ReadAsStringAsync());
                Assert.Equal("application/json", request.Content.Headers.ContentType.MediaType);
            }
        }

        [Theory]
        [InlineData("GET")]
        [InlineData("DELETE")]
        public void PlainQueriesPreserveEncodedSuffixAndDateText(string method)
        {
            using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                "http://localhost/v2/resource?{\"sort\":\"literal & + #\",\"since\":\"2020-02-02T22:25:27.1200000+05:30\"}&expand[]=detail",
                new System.Net.Http.HttpMethod(method), new RequestOptions { ApiKey = "wire-test-key" }))
            {
                Assert.Equal("?sort=literal+%26+%2B+%23&since=2020-02-02T22%3A25%3A27.1200000%2B05%3A30&expand[]=detail", request.RequestUri.Query);
                Assert.Null(request.Content);
            }
        }

        [Theory]
        [InlineData("GET")]
        [InlineData("DELETE")]
        public void OrdinaryEncodedQueriesRemainUnchanged(string method)
        {
            const string url = "http://localhost/v2/resource?filter[name]=a%26b%2Bc%2520&tags=one&tags=two&expand[]=x%23y";
            using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                url, new System.Net.Http.HttpMethod(method), new RequestOptions { ApiKey = "wire-test-key" }))
            {
                Assert.Equal(url, request.RequestUri.AbsoluteUri);
                Assert.Null(request.Content);
            }
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("?{}", "?")]
        [InlineData("?{}&extra=a%26b%2Bc%2520&expand[]=one&expand[]=two", "?extra=a%26b%2Bc%2520&expand[]=one&expand[]=two")]
        public void EmptyOptionsPreserveEncodedSuffix(string carrier, string expected)
        {
            using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                "http://localhost/v2/resource" + carrier,
                System.Net.Http.HttpMethod.Get, new RequestOptions { ApiKey = "wire-test-key" }))
            {
                Assert.Equal(expected, request.RequestUri.Query);
                Assert.Null(request.Content);
            }
        }

        [Fact]
        public void PlainQueryArraysRepeatEscapedParameterNames()
        {
            using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                "http://localhost/v2/resource?{\"tags\":[\"one & two\",\"+?#{}\\\"\"],\"amounts\":[1.25,2],\"flags\":[true,false]}",
                System.Net.Http.HttpMethod.Get, new RequestOptions { ApiKey = "wire-test-key" }))
            {
                Assert.Equal("?tags=one+%26+two&tags=%2B%3F%23%7B%7D%22&amounts=1.25&amounts=2&flags=true&flags=false&", request.RequestUri.Query);
            }
        }

        [Fact]
        public void PlainQueryScalarsUseInvariantFormatting()
        {
            var previous = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
                using (var request = Telnyx.Infrastructure.Requestor.GetRequestMessage(
                    "http://localhost/v2/resource?{\"price\":1.25,\"enabled\":true,\"disabled\":false}",
                    System.Net.Http.HttpMethod.Get, new RequestOptions { ApiKey = "wire-test-key" }))
                {
                    Assert.Equal("?price=1.25&enabled=true&disabled=false&", request.RequestUri.Query);
                }
            }
            finally
            {
                System.Globalization.CultureInfo.CurrentCulture = previous;
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public Task PlainListOptionsBecomeQueryParameters(bool asynchronous)
        {
            return CapturePlainListQuery(asynchronous, false);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public Task PlainListOptionsPreserveExtraParamsAndExpand(bool asynchronous)
        {
            return CapturePlainListQuery(asynchronous, true);
        }

        private static async Task CapturePlainListQuery(bool asynchronous, bool withSuffix)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            var oldKey = TelnyxConfiguration.GetApiKey();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                TelnyxConfiguration.SetApiKey("wire-test-key");
                var task = Task.Run(async () =>
                {
                    var service = new NumberBackgroundJobService();
                    var options = new NumberBackgroundJobListOptions
                    {
                        Type = PhoneNumberJobType.UpdatePhoneNumbers,
                        Sort = "created_at",
                    };
                    if (withSuffix)
                    {
                        options.Sort = "literal & + ? # {} \"";
                        options.AddExtraParam("extra", "a&b+c%20");
                        options.AddExpand("one & two");
                        options.AddExpand("three+#");
                    }

                    var result = asynchronous ? await service.ListNumberBackgroundJobsAsync(options) : service.ListNumberBackgroundJobs(options);
                    Assert.NotNull(result);
                });
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true))
                {
                    var line = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    while (!string.IsNullOrEmpty(await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)))) { }
                    var body = Encoding.UTF8.GetBytes("{\"data\":[]}");
                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {body.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(body, 0, body.Length);
                    await stream.FlushAsync();
                    await task.WaitAsync(TimeSpan.FromSeconds(10));
                    if (withSuffix)
                    {
                        Assert.StartsWith("GET /v2/phone_numbers/jobs?type=update_phone_numbers&sort=literal+%26+%2B+%3F+%23+%7B%7D+%22&", line);
                        Assert.EndsWith("&extra=a%26b%2Bc%2520&expand[]=one+%26+two&expand[]=three%2B%23 HTTP/1.1", line);
                    }
                    else
                    {
                        Assert.Equal("GET /v2/phone_numbers/jobs?type=update_phone_numbers&sort=created_at& HTTP/1.1", line);
                    }
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
