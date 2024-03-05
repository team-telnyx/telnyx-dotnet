using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Networking.NetworkPreferences;
using Telnyx.net.Services.Networking.NetworkPreferences;
using Xunit;

namespace TelnyxTests.Services.Networking.NetworkPreferences
{
    public class NetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly NetworkPreferenceService service;
        private readonly UpsertNetworkPreference createOptions;

        public NetworkPreferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NetworkPreferenceService();

            this.createOptions = new UpsertNetworkPreference()
            {
                SimCardIds = new Guid[] { Guid.Parse("6b14e151-8493-4fa1-8664-1cc4e6d14158"), Guid.Parse("6b14e151-8493-4fa1-8664-1cc4e6d14158") },
                MobileNetworkOperatorsPreferences = new MobileNetworkOperatorsPreferences
                {
                    MobileNetworkOperatorId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                    Priority = 0
                }
            };
        }


        [Fact]
        public void Update()
        {
            var message = this.service.UpdateNetwork(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NetworkPreference), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateNetworkAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NetworkPreference), message.GetType());
        }
    }
}
