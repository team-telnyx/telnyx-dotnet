namespace TelnyxTests.Services.Reports.ReportCdrUsageReportSyncs
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs;
    using Telnyx.net.Services.Reports.ReportCdrUsageReportSyncs;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class ReportCdrUsageReportSyncWireTest
    {
        // Current CdrUsageReportResponse: result is an open object. Arrays below are
        // compatibility controls, not examples of the pinned current contract.
        private const string Report = "{\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"start_time\":\"2018-02-02T22:25:27.521Z\",\"end_time\":\"2018-02-03T22:25:27.521Z\",\"connections\":[1234567890,9876543210],\"aggregation_type\":\"CONNECTION\",\"status\":\"COMPLETE\",\"report_url\":\"https://example.test/report.csv\",\"result\":{\"rows\":[{\"calls\":9007199254740993,\"label\":\"a\\\"b\"},null,true],\"nested\":{\"cost\":1.2345678901234567890123456789,\"time\":\"2018-02-02T22:25:27.521Z\"}},\"created_at\":\"2018-02-02T22:25:27.521Z\",\"updated_at\":\"2018-02-03T22:25:27.521Z\",\"record_type\":\"cdr_usage_report\",\"product_breakdown\":\"COUNTRY\"}";

        [Theory]
        [InlineData(false, "object")]
        [InlineData(true, "object")]
        [InlineData(false, "empty")]
        [InlineData(true, "empty")]
        [InlineData(false, "one")]
        [InlineData(true, "one")]
        [InlineData(false, "many")]
        [InlineData(true, "many")]
        [InlineData(false, "meta")]
        [InlineData(true, "meta")]
        [InlineData(false, "null")]
        [InlineData(true, "null")]
        [InlineData(false, "missing")]
        [InlineData(true, "missing")]
        public async Task PreservesReportShapeAndOriginalResponse(bool asynchronous, string shape)
        {
            var second = Report.Replace("COMPLETE", "PENDING");
            var data = shape == "object" ? Report : (shape == "one" || shape == "meta") ? "[" + Report + "]"
                : shape == "many" ? "[" + Report + "," + second + "," + Report + "]"
                : shape == "empty" ? "[]" : "null";
            var json = shape == "missing" ? "{ \"unknown\":true }" : "{ \"unknown\":true, \"data\": " + data + " }";
            if (shape == "meta") json = json.Insert(1, "\"meta\":{\"page_number\":2,\"page_size\":1,\"total_pages\":4,\"total_results\":4},");
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var original = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var service = new ReportCdrUsageReportSyncService();
                var options = new ReportCdrUsageReportSyncOption { AggregationType = "CONNECTION", ProductBreakdown = "COUNTRY" };
                var req = new RequestOptions { ApiKey = "cdr-test-only" };
                var call = Task.Run(async () => asynchronous
                    ? await service.ListReportCdrUsageReportSyncAsync(options, req)
                    : service.ListReportCdrUsageReportSync(options, req));
                using var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10));
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true);
                var first = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                var headers = new StringBuilder();
                string header;
                while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)))) headers.AppendLine(header);
                var response = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n"));
                await stream.WriteAsync(response);
                await stream.FlushAsync();
                var result = await call.WaitAsync(TimeSpan.FromSeconds(10));
                Assert.StartsWith("GET /v2/reports/cdr_usage_reports/sync?", first);
                Assert.Contains("aggregation_type=CONNECTION", first);
                Assert.Contains("product_breakdown=COUNTRY", first);
                Assert.Contains("Authorization: Bearer cdr-test-only", headers.ToString());
                Assert.Equal(json, result.TelnyxResponse.ResponseJson);
                Assert.Equal(json, result.TelnyxResponse.ObjectJson);
                if (shape == "meta")
                {
                    Assert.Equal(2, result.PageInfo.PageNumber);
                    Assert.Equal(1, result.PageInfo.PageSize);
                    Assert.Equal(4, result.PageInfo.TotalPages);
                    Assert.Equal(4, result.PageInfo.TotalResults);
                    Assert.True(result.HasMore);
                }
                else
                {
                    Assert.Null(result.PageInfo);
                    Assert.False(result.HasMore);
                }

                Assert.False(listener.Pending());
                if (shape == "missing" || shape == "null")
                {
                    Assert.Null(result.Data);
                    return;
                }

                var expected = shape == "object" ? new JArray(Parse(Report)) : (JArray)Parse(data);
                Assert.Equal(expected.Count, result.Data.Count);
                for (var i = 0; i < expected.Count; i++)
                {
                    var item = result.Data[i];
                    var mapped = JsonConvert.DeserializeObject<ReportCdrUsageReportSync>(expected[i].ToString(), new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                    Assert.Equal(mapped.Id, item.Id);
                    Assert.Equal(mapped.StartTime, item.StartTime);
                    Assert.Equal(mapped.EndTime, item.EndTime);
                    Assert.Equal(mapped.Connections, item.Connections);
                    Assert.Equal(mapped.AggregationType, item.AggregationType);
                    Assert.Equal(mapped.Status, item.Status);
                    Assert.Equal(mapped.ReportUrl, item.ReportUrl);
                    Assert.Equal(mapped.CreatedAt, item.CreatedAt);
                    Assert.Equal(mapped.UpdatedAt, item.UpdatedAt);
                    Assert.Equal(mapped.RecordType, item.RecordType);
                    Assert.Equal(mapped.ProductBreakdown, item.ProductBreakdown);
                    Assert.True(JToken.DeepEquals(expected[i]["result"], (JToken)item.Result));
                    Assert.Equal(json, item.TelnyxResponse.ResponseJson);
                    Assert.NotSame(result.TelnyxResponse, item.TelnyxResponse);
                    Assert.True(JToken.DeepEquals(expected[i], Parse(item.TelnyxResponse.ObjectJson)));
                    Assert.Equal(result.TelnyxResponse.Url, item.TelnyxResponse.Url);
                    Assert.Equal(result.TelnyxResponse.RequestId, item.TelnyxResponse.RequestId);
                    Assert.Equal(result.TelnyxResponse.RequestDate, item.TelnyxResponse.RequestDate);
                    if (i > 0) Assert.NotSame(result.Data[i - 1].TelnyxResponse, item.TelnyxResponse);
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(original);
            }
        }

        [Theory]
        [InlineData(false, false, 0)]
        [InlineData(true, false, 0)]
        [InlineData(false, true, 0)]
        [InlineData(true, true, 0)]
        [InlineData(true, false, 1)]
        [InlineData(true, false, 2)]
        public async Task ExplicitPagingPreservesLegacyArraysButNeverPaginatesObjects(bool asynchronous, bool objectShape, int cancelPage)
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var original = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var service = new ReportCdrUsageReportSyncService();
                var options = new ReportCdrUsageReportSyncOption { NumberOfPagesToFetch = 2, PageNumber = 1 };
                var request = new RequestOptions { ApiKey = "cdr-paging-only" };
                using var cancellation = new System.Threading.CancellationTokenSource();
                var call = Task.Run(async () => asynchronous
                    ? await service.ListReportCdrUsageReportSyncAsync(options, request, cancellation.Token)
                    : service.ListReportCdrUsageReportSync(options, request));
                for (var page = 1; page <= (objectShape ? 1 : 2); page++)
                {
                    var accept = listener.AcceptTcpClientAsync();
                    if (page > 1) Assert.Same(accept, await Task.WhenAny(accept, call).WaitAsync(TimeSpan.FromSeconds(10)));
                    using var client = await accept.WaitAsync(TimeSpan.FromSeconds(10));
                    using var stream = client.GetStream();
                    using var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true);
                    var first = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.Contains("page[number]=" + page, Uri.UnescapeDataString(first));
                    var headers = new StringBuilder();
                    string header;
                    while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)))) headers.AppendLine(header);
                    Assert.Contains("Authorization: Bearer cdr-paging-only", headers.ToString());
                    if (page == cancelPage)
                    {
                        await stream.WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: 100000\r\nConnection: close\r\n\r\n{\"data\":"));
                        await stream.FlushAsync();
                        cancellation.Cancel();
                        var error = await Record.ExceptionAsync(async () => await call.WaitAsync(TimeSpan.FromSeconds(10)));
                        Assert.IsAssignableFrom<OperationCanceledException>(error);
                        Assert.True(cancellation.IsCancellationRequested);
                        return;
                    }
                    var item = page == 1 ? Report : Report.Replace("COMPLETE", "PENDING");
                    var json = "{\"meta\":{\"page_number\":" + page + ",\"page_size\":1,\"total_pages\":2,\"total_results\":2},\"data\":" + (objectShape ? item : "[" + item + "]") + "}";
                    var response = Encoding.UTF8.GetBytes(json);
                    await stream.WriteAsync(Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n"));
                    await stream.WriteAsync(response);
                    await stream.FlushAsync();
                }

                var result = await call.WaitAsync(TimeSpan.FromSeconds(10));
                Assert.Equal(objectShape ? 1 : 2, result.Data.Count);
                Assert.Equal("COMPLETE", result.Data[0].Status);
                if (!objectShape)
                {
                    Assert.Equal("PENDING", result.Data[1].Status);
                    Assert.Contains("COMPLETE", result.Data[0].TelnyxResponse.ResponseJson);
                    Assert.Contains("PENDING", result.Data[1].TelnyxResponse.ResponseJson);
                    Assert.Equal(2, result.PageInfo.PageNumber);
                }
                Assert.False(listener.Pending());
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(original);
            }
        }

        private static JToken Parse(string json)
        {
            using var reader = new JsonTextReader(new StringReader(json)) { DateParseHandling = DateParseHandling.None };
            return JToken.ReadFrom(reader);
        }
    }
}
