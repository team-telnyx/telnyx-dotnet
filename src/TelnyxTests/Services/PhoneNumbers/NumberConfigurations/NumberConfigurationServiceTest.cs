namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
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

    public class NumberConfigurationServiceTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";

        private readonly NumberConfigurationService service;
        private readonly NumberConfigurationOptions updateOptions;
        private readonly NumberConfigurationsListOptions listOptions;

        public NumberConfigurationServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberConfigurationService();

            this.updateOptions = new NumberConfigurationOptions
            {
                BillingGroupId = "86f58db9-0fe3-4adc-9d1f-46e66e6e9323",
                ConnectionId = "1293384261075731499",
                Tags = new List<string>
                {
                    "test"
                }
            };
            this.listOptions = new NumberConfigurationsListOptions
            {
                //Status = Telnyx.net.Entities.PhoneNumbers.NumberConfigurations.NumberConfigStatus.Active,
                //Size = 10,
                //Tag = "region_5",
                //PhoneNumber = "+19705555098"
            };

        }

        [Fact]
        public async Task ListAsync()
        {
            var numberOrder = await this.service.ListPhoneNumbersAsync(listOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Equal(typeof(TelnyxList<NumberConfiguration>), numberOrder.GetType());
        }
        [Fact]
        public void List()
        {
            var numberOrder = this.service.ListPhoneNumbers(listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Single(numberOrder.Data);
            Assert.Equal(typeof(TelnyxList<NumberConfiguration>), numberOrder.GetType());
        }

        [Fact]
        public void Get()
        {
            var numberOrder = this.service.RetrievePhoneNumber(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberOrder);
            Assert.IsType<NumberConfiguration>(numberOrder);
        }

        [Fact]
        public async Task GetAsync()
        {
            var numberOrder = await this.service.RetrievePhoneNumberAsync(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberOrder);
            Assert.IsType<NumberConfiguration>(numberOrder);
        }

        [Fact]
        public void Update()
        {
            var response = this.service.UpdatePhoneNumberSettings(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<NumberConfiguration>(response);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdatePhoneNumberSettingsAsync(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<NumberConfiguration>(response);
        }
    }
}
