namespace TelnyxTests.Services.OutboundVoiceProfiles
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.OutboundVoiceProfiles;
    using Telnyx.net.Services.OutboundVoiceProfiles;
    using Xunit;

    public class OutboundVoiceProfileServiceTest : BaseTelnyxTest
    {
        private const string Id = "1293384261075731499";

        private readonly OutboundVoiceProfileService service;
        private readonly CreateOutboundVoiceProfileOptions option;
        private readonly ListOutboundVoiceProfileOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        private List<PhoneNumber> phoneNumbers;

        public OutboundVoiceProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new OutboundVoiceProfileService();

            this.option = new CreateOutboundVoiceProfileOptions()
            {
                BillingGroupId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                ConcurrentCallLimit = 10,
                Name = "office",
                TrafficType = "conversational",
                ServicePlan = "global",
                Enabled = true,
                Tags = new List<string> { "Tag1", "Tag2" },
                UsagePaymentMethod = null,
                WhitelistedDestinations = new List<string> { "Dest1", },
                MaxDestinationRate = 1,
                DailySpendLimit = "100.00",
                DailySpendLimitEnabled = false,
                CallRecording = new OutboundVoiceProfileCallRecording()
                {
                    CallRecordingCallerPhoneNumbers = new List<string>() { "+19705555099" },
                    CallRecordingChannels = "dual",
                    CallRecordingFormat = "mp3",
                    CallRecordingType = "by_caller_phone_number",
                },
            };

            this.listOptions = new ListOutboundVoiceProfileOptions()
            {
                FilterNameContains = null,
                Sort = null,
            };

            this.requestOptions = new RequestOptions();
            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.option);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
            Assert.NotNull(result.Id);
            Assert.NotNull(result.MaxDestinationRate);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.ServicePlan);
            Assert.NotNull(result.CallRecording);
            Assert.Equal(this.option.Enabled, result.Enabled);
            Assert.Equal(10, result.MaxDestinationRate);
            Assert.Equal("office", result.Name);
            Assert.Equal(this.option.ServicePlan, result.ServicePlan);
            Assert.Single(result.Tags);
            Assert.Equal(this.option.TrafficType, result.TrafficType);
            Assert.Equal(this.option.BillingGroupId, result.BillingGroupId);
            Assert.Equal(this.option.CallRecording.CallRecordingCallerPhoneNumbers.Count, result.CallRecording.CallRecordingCallerPhoneNumbers.Count);
            Assert.Equal(this.option.CallRecording.CallRecordingChannels, result.CallRecording.CallRecordingChannels);
            Assert.Equal(this.option.CallRecording.CallRecordingFormat, result.CallRecording.CallRecordingFormat);
            Assert.Equal("by_caller_phone_number", result.CallRecording.CallRecordingType);
            Assert.Equal(this.option.ConcurrentCallLimit, result.ConcurrentCallLimit);
            Assert.Equal("100.00", result.DailySpendLimit);
            Assert.True(result.DailySpendLimitEnabled);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.option);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(Id);
            Assert.NotNull(result);
            Assert.IsType<OutboundVoiceProfile>(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.Data[0].GetType());
        }

        [Fact]
        public void Update()
        {
            var result = this.service.Update(Id, this.option);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
            Assert.NotNull(result.Id);
            Assert.NotNull(result.MaxDestinationRate);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.ServicePlan);
            Assert.NotNull(result.CallRecording);
            Assert.Equal(this.option.Enabled, result.Enabled);
            Assert.Equal(10, result.MaxDestinationRate);
            Assert.Equal("office", result.Name);
            Assert.Equal(this.option.ServicePlan, result.ServicePlan);
            Assert.Single(result.Tags);
            Assert.Equal(this.option.TrafficType, result.TrafficType);
            Assert.Equal(this.option.BillingGroupId, result.BillingGroupId);
            Assert.Equal(this.option.CallRecording.CallRecordingCallerPhoneNumbers.Count, result.CallRecording.CallRecordingCallerPhoneNumbers.Count);
            Assert.Equal(this.option.CallRecording.CallRecordingChannels, result.CallRecording.CallRecordingChannels);
            Assert.Equal(this.option.CallRecording.CallRecordingFormat, result.CallRecording.CallRecordingFormat);
            Assert.Equal("by_caller_phone_number", result.CallRecording.CallRecordingType);
            Assert.Equal(this.option.ConcurrentCallLimit, result.ConcurrentCallLimit);
            Assert.Equal("100.00", result.DailySpendLimit);
            Assert.True(result.DailySpendLimitEnabled);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var result = await this.service.UpdateAsync(Id, this.option);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }
    }
}
