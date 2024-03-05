using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.WDRReports;
using Telnyx.net.Services.Wireless.WDRReports;
using Xunit;

namespace TelnyxTests.Services.Wireless.WDRReports
{
    public class ReportWDRServiceTest : BaseTelnyxTest
    {
        private readonly WDRReportService service;
        private readonly ReportWdrOption listOptions;
        private readonly RequestOptions requestOptions;

        public ReportWDRServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new WDRReportService();

            this.listOptions = new ReportWdrOption();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListReportWdr(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportWdr>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListReportWdrAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ReportWdr>), result.GetType());
        }
    }
}
