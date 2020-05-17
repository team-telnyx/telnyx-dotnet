﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;
using Telnyx.net.Services.PhoneNumbers.NumberConfigurations;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
    public class NumberConfigurationVoiceServiceTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";
        private const string PhoneNumber = "+13127000090";

        private readonly NumberConfigurationVoiceService service;
        private readonly VoiceSettingUpdateOptions updateOptions;
        private readonly VoiceSettingsListOptions listOptions;
        private readonly EmergencyOptions emergencyOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        private List<PhoneNumber> phoneNumbers;

        public NumberConfigurationVoiceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberConfigurationVoiceService();

            this.updateOptions = new VoiceSettingUpdateOptions
            {
                
            };
            this.emergencyOptions = new EmergencyOptions
            {
                EmergencyAddressId = "1315261609962112019",
                EmergencyEnabled = false
            };
            this.listOptions = new VoiceSettingsListOptions
            {
                //PhoneNumber = "+13035559999",
                //Size = 10,
                //UsagePaymentMethod = PaymentMethod.PayPerMinute
            };

            this.requestOptions = new RequestOptions();

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public async Task ListAsync()
        {
            var response = await this.service.ListPhoneNumberVoiceAsync(listOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.IsType<TelnyxList<PhoneNumberVoiceSettings>>(response);
        }
        [Fact]
        public void List()
        {
            var response = this.service.ListPhoneNumberVoice(listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.IsType<TelnyxList<PhoneNumberVoiceSettings>>(response);
        }

        [Fact]
        public void Get()
        {
            var response = this.service.RetrievePhoneNumberVoiceSettings(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
          
        }

        [Fact]
        public async Task GetAsync()
        {
            var response = await this.service.RetrievePhoneNumberVoiceSettingsAsync(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
        }

        [Fact]
        public void Update()
        {
            var response = this.service.UpdateVoiceSettings(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdateVoiceSettingsAsync(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
        }
        [Fact]
        public void UpdateEmergency()
        {
            var response = this.service.EnableEmergencySettings(NumberOrderId, this.emergencyOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
        }

        [Fact]
        public async Task UpdateEmergencyAsync()
        {
            var response = await this.service.EnableEmergencySettingsAsync(NumberOrderId, this.emergencyOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.IsType<PhoneNumberVoiceSettings>(response);
        }
    }
}