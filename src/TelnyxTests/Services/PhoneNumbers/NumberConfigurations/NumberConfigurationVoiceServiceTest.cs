namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;
    using Telnyx.net.Services.PhoneNumbers.NumberConfigurations;
    using Xunit;

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
                CallForwarding = new CallForwarding()
                {
                    CallForwardingEnabled = true,
                    ForwardingType = "on_failure",
                    ForwardsTo = "+13035559997",
                },
                CallRecording = new CallRecording()
                {
                    InboundCallRecordingEnabled = true,
                    InboundCallRecordingChannels = "single",
                    InboundCallRecordingFormat = "wav",
                },
                CnamListing = new CnamListing()
                {
                    CnamListingEnabled = true,
                    CnamListingDetails = "example",
                },
                MediaFeatures = new MediaFeatures()
                {
                    AcceptAnyRtpPacketsEnabled = true,
                    RtpAutoAdjustEnabled = true,
                    T38FaxGatewayEnabled = true,
                    MediaHandlingMode = "default",
                },
                TechPrefixEnabled = false,
                TranslatedNumber = "+13035559996",
                UsagePaymentMethod = PaymentMethod.PayPerMinute,
            };
            this.emergencyOptions = new EmergencyOptions
            {
                EmergencyAddressId = "1315261609962112019",
                EmergencyEnabled = false
            };
            this.listOptions = new VoiceSettingsListOptions
            {
                PageNumber = 1,
                PageSize = 25,
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
            var response = await this.service.ListPhoneNumberVoiceAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.IsType<TelnyxList<PhoneNumberVoiceSettings>>(response);
        }

        [Fact]
        public void List()
        {
            var response = this.service.ListPhoneNumberVoice(this.listOptions);
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
            Assert.NotNull(response.Id);
            Assert.NotNull(response.CallForwarding);
            Assert.True(response.CallForwarding.CallForwardingEnabled);
            Assert.NotNull(response.CallForwarding.ForwardingType);
            Assert.NotNull(response.CallForwarding.ForwardsTo);
            Assert.NotNull(response.CallRecording);
            Assert.NotNull(response.CallRecording.InboundCallRecordingChannels);
            Assert.True(response.CallRecording.InboundCallRecordingEnabled);
            Assert.NotNull(response.CallRecording.InboundCallRecordingFormat);
            Assert.NotNull(response.CnamListing);
            Assert.NotNull(response.CnamListing.CnamListingDetails);
            Assert.True(response.CnamListing.CnamListingEnabled);
            Assert.NotNull(response.ConnectionId);
            Assert.NotNull(response.Emergency);
            Assert.True(response.Emergency.EmergencyEnabled);
            Assert.NotNull(response.Emergency.EmergencyAddressId);
            Assert.NotNull(response.MediaFeatures);
            Assert.True(response.MediaFeatures.AcceptAnyRtpPacketsEnabled);
            Assert.True(response.MediaFeatures.RtpAutoAdjustEnabled);
            Assert.True(response.MediaFeatures.T38FaxGatewayEnabled);
            Assert.Null(response.MediaFeatures.MediaHandlingMode);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.VoiceSettings, response.RecordType);
            Assert.False(response.TechPrefixEnabled);
            Assert.NotNull(response.TranslatedNumber);
            Assert.NotNull(response.UsagePaymentMethod);
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
