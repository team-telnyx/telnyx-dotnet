using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Applications;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Faxes.Applications;
using Telnyx.net.Services.Faxes.Applications;
using Xunit;

namespace TelnyxTests.Services.Faxes
{
    public class FaxApplicationServiceTest : BaseTelnyxTest
    {
        private readonly FaxApplicationService _faxAppService;
        private FaxAppListOptions faxappListOptions;
        private FaxAppOptions faxappOptions;

        public FaxApplicationServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            _faxAppService = new FaxApplicationService();
            faxappListOptions = new FaxAppListOptions
            {
                Sort = Telnyx.net.Entities.Faxes.Applications.Options.SortOptions.ActiveDESC,
            };
            faxappOptions = new FaxAppOptions
            {
                WebhookEventFailoverUrl = "google.com",
                WebhookEventUrl = "www.apple.com",
                WebhookTimeoutSecs = 30,
                Active = true,
                AnchorsiteOverride = AnchorsiteOverride.AmsterdamNetherlands,
                ApplicationName = "TestApp",
                Inbound = new Inbound
                {
                    SipSubdomain = "telnyx.com",
                    SipSubdomainReceiveSettings = SipSubdomainReceiveSettings.FromAnyone,
                    ChannelLimit = 10,
                },
                Outbound = new Outbound
                {
                    ChannelLimit = 2,
                    OutboundVoiceProfileId = Guid.NewGuid().ToString(),
                },
            };
        }

        [Fact(Skip = "Mock not allowing sort in options")]
        public async Task ListFaxAppTestAsync()
        {
            var faxListResult = await this._faxAppService.ViewFaxApplicationsAsync(this.faxappListOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(TelnyxList<FaxApplication>)));
        }

        [Fact(Skip = "Mock not allowing sort in options")]
        public void ListFaxAppTest()
        {
            var faxListResult = this._faxAppService.ViewFaxApplications(this.faxappListOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(TelnyxList<FaxApplication>)));
        }

        [Fact]
        public async Task GetFaxAppTestAsync()
        {
            var faxListResult = await this._faxAppService.GetFaxApplicationAsync(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public void GetFaxAppTest()
        {
            var faxListResult = this._faxAppService.GetFaxApplication(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public async Task CreateFaxAppTestAsync()
        {
            var faxListResult = await this._faxAppService.CreateFaxApplicationAsync(this.faxappOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public void CreateFaxAppTest()
        {
            var faxListResult = this._faxAppService.CreateFaxApplication(this.faxappOptions);
            Assert.NotNull(faxListResult);
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public async Task UpdateFaxAppTestAsync()
        {
            var faxListResult = await this._faxAppService.UpdateFaxApplicationAsync(Guid.NewGuid().ToString(), this.faxappOptions);
            Assert.NotNull(faxListResult);
            Assert.True(this.PropertiesAreNotNull(faxListResult));
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public void UpdateFaxAppTest()
        {
            var faxListResult = this._faxAppService.UpdateFaxApplication(Guid.NewGuid().ToString(), this.faxappOptions);
            Assert.NotNull(faxListResult);
            Assert.True(this.PropertiesAreNotNull(faxListResult));
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public async Task DeleteFaxAppTestAsync()
        {
            var faxListResult = await this._faxAppService.DeleteFaxApplicationAsync(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(this.PropertiesAreNotNull(
                faxListResult,
                new List<string>
                {
                    nameof(faxListResult.Active),
                    nameof(faxListResult.ApplicationName),
                    nameof(faxListResult.Id),
                }));
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }

        [Fact]
        public void DeleteFaxAppTest()
        {
            var faxListResult = this._faxAppService.DeleteFaxApplication(Guid.NewGuid().ToString());
            Assert.NotNull(faxListResult);
            Assert.True(this.PropertiesAreNotNull(
                faxListResult,
                new List<string>
                {
                    nameof(faxListResult.Active),
                    nameof(faxListResult.ApplicationName),
                    nameof(faxListResult.Id),
                }));
            Assert.True(faxListResult.GetType().Equals(typeof(FaxApplication)));
        }
    }
}
