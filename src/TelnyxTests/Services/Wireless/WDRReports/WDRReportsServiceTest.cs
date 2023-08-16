namespace TelnyxTests.Services.Wireless.MobileOperatorNetworks
{
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.WDRReports;
    using Telnyx.net.Services.Wireless.WDRReports;
    using Xunit;

    public class WDRReportsServiceTest : BaseTelnyxTest
    {
        private readonly WDRReportsService service;
        private readonly ListOptions listOptions;
        private readonly CreateWDRReportsOptions createOptions;
        private readonly RequestOptions requestOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public WDRReportsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new WDRReportsService();

            this.listOptions = new ListOptions();

            this.createOptions = new CreateWDRReportsOptions
            {
                EndTime = "2018-02-02T22:25:27.521Z",
                StartTime = "2018-02-02T22:25:27.521Z",
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WDRReportsRecord>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WDRReportsRecord>), result.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
            Assert.NotNull(result.Id);
            Assert.NotNull(result.RecordType);
            Assert.NotNull(result.Status);
            Assert.NotNull(result.ReportUrl);
            Assert.NotNull(result.CreatedAt);
            Assert.NotNull(result.UpdatedAt);
            DateTime startTime, endTime;
            Assert.True(System.DateTime.TryParse(result.StartTime, out startTime));
            Assert.True(System.DateTime.TryParse(result.EndTime, out endTime));
            Assert.True(startTime <= endTime);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WDRReportsRecord), result.GetType());
        }
    }
}
