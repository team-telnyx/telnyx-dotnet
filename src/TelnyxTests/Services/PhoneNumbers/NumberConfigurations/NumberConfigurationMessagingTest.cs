using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;
using Telnyx.net.Services.PhoneNumbers.NumberConfigurations;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.NumberConfiguration
{
    public class NumberConfigurationMessagingTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";
        private readonly NumberConfigurationMessagingService service;
        private readonly MessagingSettingUpdateOptions updateOptions;

        public NumberConfigurationMessagingTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberConfigurationMessagingService();

            this.updateOptions = new MessagingSettingUpdateOptions
            {
                MessagingProduct = "A2P",
                MessagingProfileId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

        }

        [Fact]
        public async Task ListAsync()
        {
            var response = await this.service.ListMessagingSettingsAsync();
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.IsType<TelnyxList<PhoneNumberMessaging>>(response);
        }
        [Fact]
        public void List()
        {
            var response = this.service.ListMessagingSettings();
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.IsType<TelnyxList<PhoneNumberMessaging>>(response);
        }

        [Fact]
        public void Get()
        {
            var response = this.service.RetrievePhoneNumberMessagingSettings(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberMessaging>(response);
        }

        [Fact]
        public async Task GetAsync()
        {
            var response = await this.service.RetrievePhoneNumberMessagingettingsAsync(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberMessaging>(response);
        }

        [Fact]
        public void Update()
        {
            var response = this.service.UpdateMessagingSettings(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberMessaging>(response);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdateMessagingSettingsAsync(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberMessaging>(response);
        }
    }
}
