namespace TelnyxTests.Services.Reports.ReportMdrUsageReports
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Reports.ReportMdrUsageReports;
    using Telnyx.net.Services.Reports.ReportMdrUsageReports;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class PrivateWirelessGatewayServiceTest : BaseTelnyxTest
    {
        private readonly ReportMdrUsageReportService service;
        private readonly ReportMdrUsageReportOption listOptions;
        private readonly UpsertReportMdrUsageReport createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public PrivateWirelessGatewayServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ReportMdrUsageReportService();

            this.listOptions = new ReportMdrUsageReportOption()
            {
            };
            this.createOptions = new UpsertReportMdrUsageReport()
            {
                StartDate = DateTime.Parse("2020-07-01T00:00:00-06:00"),
                EndDate = DateTime.Parse("2020-07-01T00:00:00-06:00"),
                AggregationType = "NO_AGGREGATION",
                Profiles = "My profile"
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListReportMdrUsageReport(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportMdrUsageReport>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListReportMdrUsageReportAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportMdrUsageReport>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetReportMdrUsageReport(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ReportMdrUsageReport), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetReportMdrUsageReportAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ReportMdrUsageReport), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateReportMdrUsageReport(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ReportMdrUsageReport), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateReportMdrUsageReportAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ReportMdrUsageReport), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteReportMdrUsageReport(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(ReportMdrUsageReport), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteReportMdrUsageReportAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(ReportMdrUsageReport), message.GetType());
        }
    }
}