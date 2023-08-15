namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
                ExternalPin = "0738",
                Tags = new List<string> { "test" }
            };
            this.listOptions = new NumberConfigurationsListOptions
            {
                PageNumber = 1,
                PageSize = 20,
                //PhoneNumber = "+19705555098",
                //Status = NumberConfigStatus.Active,
                //Size = 10,
                //Tag = "region_5",
            };
        }

        [Fact]
        public async Task ListAsync()
        {
            var numberOrder = await this.service.ListPhoneNumbersAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Equal(typeof(TelnyxList<NumberConfiguration>), numberOrder.GetType());
        }

        [Fact]
        public void List()
        {
            var numberOrder = this.service.ListPhoneNumbers(this.listOptions);
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
            Assert.NotNull(response.BillingGroupId);
            Assert.True(response.CallerIdNameEnabled);
            Assert.True(response.CallForwardingEnabled);
            Assert.True(response.CallRecordingEnabled);
            Assert.True(response.CnamListingEnabled);
            Assert.Equal("1293384261075731499", response.ConnectionId);
            Assert.NotNull(response.ConnectionName);
            Assert.NotNull(response.CreatedAt); //changed. Mock is not returning updatedAt field..
            Assert.NotNull(response.EmergencyAddressId);
            Assert.True(response.EmergencyEnabled);
            Assert.Equal("1234", response.ExternalPin);
            Assert.NotNull(response.Id);
            Assert.NotNull(response.MessagingProfileId);
            Assert.NotNull(response.MessagingProfileName);
            Assert.NotNull(response.PhoneNumber);
            Assert.NotNull(response.PurchasedAt);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.PhoneNumber, response.RecordType);
            Assert.NotNull(response.Status);
            Assert.True(response.T38FaxGatewayEnabled);
            Assert.Equal(2, response.Tags.Count);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdatePhoneNumberSettingsAsync(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<NumberConfiguration>(response);
        }

        [Fact]
        public void Delete()
        {
            var response = this.service.DeletePhoneNumber(NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<NumberConfiguration>(response);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var response = await this.service.DeletePhoneNumberAsync(NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<NumberConfiguration>(response);
        }
    }
}
