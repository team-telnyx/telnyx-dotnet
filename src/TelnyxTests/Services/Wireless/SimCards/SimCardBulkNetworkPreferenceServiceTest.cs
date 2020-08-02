namespace TelnyxTests.Services.Wireless.SimCards
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Telnyx.net.Entities.Wireless.OTAUpdates;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;
    using Telnyx.net.Entities;

    public class SimCardBulkNetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly SimCardBulkNetworkPreferenceService service;
        private readonly SimCardBulkNetworkPreferenceUpdateOptions updateOptions;

        private const string parentId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardBulkNetworkPreferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardBulkNetworkPreferenceService();
            this.updateOptions = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new string[]
                {
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };
        }

        [Fact]
        public void Update()
        {
            var result = this.service.Update(this.updateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var result = await this.service.UpdateAsync(this.updateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }
    }
}