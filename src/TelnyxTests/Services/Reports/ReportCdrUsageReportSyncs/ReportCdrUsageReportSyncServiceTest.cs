using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs;
using Telnyx.net.Services.Reports.ReportCdrUsageReportSyncs;
using Xunit;

namespace TelnyxTests.Services.Reports.ReportCdrUsageReportSyncs
{
    public class ReportCdrUsageReportSyncServiceTest : BaseTelnyxTest
    {
        private readonly ReportCdrUsageReportSyncService service;
        private readonly ReportCdrUsageReportSyncOption listOptions;
        private readonly RequestOptions requestOptions;

        public ReportCdrUsageReportSyncServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ReportCdrUsageReportSyncService();

            this.listOptions = new ReportCdrUsageReportSyncOption()
            {
                StartDate = Convert.ToDateTime("2018-02-02T22:25:27.521Z"),
                EndDate = Convert.ToDateTime("2018-02-02T22:25:27.521Z"),
                ProductBreakdown = "NO_BREAKDOWN",
                AggregationType = "NO_AGGREGATION",
                Connections = new long[] { 1234567890, 9876543210 }
        };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListReportCdrUsageReportSync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportCdrUsageReportSync>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListReportCdrUsageReportSyncAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportCdrUsageReportSync>), result.GetType());
        }
    }
}
