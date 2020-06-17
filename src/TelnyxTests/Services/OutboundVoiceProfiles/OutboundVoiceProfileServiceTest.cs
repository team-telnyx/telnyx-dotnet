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
        private readonly CreateOutboundVoiceProfileOptions createOptions;
        private readonly CreateOutboundVoiceProfileOptions updateOptions;
        private readonly ListOutboundVoiceProfileOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        private List<PhoneNumber> phoneNumbers;

        public OutboundVoiceProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new OutboundVoiceProfileService();

            this.createOptions = new CreateOutboundVoiceProfileOptions()
            {
                BillingGroupId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                ConcurrentCallLimit = 10,
            };

            this.updateOptions = new CreateOutboundVoiceProfileOptions
            {
                BillingGroupId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                ConcurrentCallLimit = 10,
            };

            this.requestOptions = new RequestOptions();

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.createOptions);
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
            var result = this.service.Update(Id, this.updateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var result = await this.service.UpdateAsync(Id, this.updateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OutboundVoiceProfile), result.GetType());
        }
    }
}
