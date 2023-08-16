namespace TelnyxTests.Services.Faxes
{
    using System;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Faxes;
    using Telnyx.net.Services.Faxes;
    using Xunit;

    public class FaxServiceTest : BaseTelnyxTest
    {
        private readonly FaxService _faxService;
        private FaxListOptions faxListOptions;
        private FaxSendOptions faxSendOptions;

        public FaxServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this._faxService = new FaxService();
            this.faxListOptions = new FaxListOptions
            {
                CreatedAtDateGreaterThan = DateTime.UtcNow.ToString()
            };
            this.faxSendOptions = new FaxSendOptions
            {
                ConnectionId = "222344",
                From = "3125555555",
                To = "4432232257",
                MediaUrl = "Google.com",
            };
        }

        [Fact]
        public async Task ListFaxTestAsync()
        {
            var faxListResult = await this._faxService.ViewFaxesAsync(this.faxListOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(TelnyxList<Fax>)));
        }

        [Fact]
        public void ListFaxTest()
        {
            var faxListResult = this._faxService.ViewFaxes(this.faxListOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(TelnyxList<Fax>)));
        }

        [Fact]
        public async Task GetFaxTestAsync()
        {
            var faxListResult = await this._faxService.GetFaxAsync(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }

        [Fact]
        public void GetFaxTest()
        {
            var faxListResult = this._faxService.GetFax(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }

        [Fact]
        public async Task SendFaxTestAsync()
        {
            var faxListResult = await this._faxService.SendFaxAsync(this.faxSendOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }

        [Fact]
        public void SendFaxTest()
        {
            var faxListResult = this._faxService.SendFax(this.faxSendOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }

        [Fact(Skip = "Mock doesnt allow delete")]
        public async Task DeleteFaxTestAsync()
        {
            var faxListResult = await this._faxService.DeleteFaxAsync(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }

        [Fact(Skip = "Mock doesnt allow delete")]
        public void DeleteFaxTest()
        {
            var faxListResult = this._faxService.DeleteFax(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(Fax)));
        }
    }
}
