namespace TelnyxTests.Services.PhoneNumbers.InboundChannelService
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.PhoneNumbers.InboundChannels;
    using Telnyx.net.Services.PhoneNumbers.InboundChannels;
    using Xunit;

    public class InboundChannelServiceTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";
        private readonly InboundChannelService service;
        private readonly InboundChannelUpdateOptions updateOptions;

        public InboundChannelServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new InboundChannelService();

            this.updateOptions = new InboundChannelUpdateOptions
            {
                Channels = 7,
            };
        }

        [Fact]
        public void Get()
        {
            var reqOptions = new RequestOptions();
            var response = this.service.Get(string.Empty, reqOptions);
            Assert.NotNull(response);
            Assert.IsType<InboundChannel>(response);
            Assert.True(response.Channels >= 0);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.InboundChannels, response.RecordType);
        }

        [Fact]
        public async Task GetAsync()
        {
            var reqOptions = new RequestOptions();
            var response = await this.service.GetAsync(string.Empty, reqOptions);
            Assert.NotNull(response);
            Assert.IsType<InboundChannel>(response);
        }

        [Fact]
        public void Update()
        {
            var response = this.service.Update(string.Empty, this.updateOptions);
            Assert.NotNull(response);
            Assert.IsType<InboundChannel>(response);
            Assert.Equal(this.updateOptions.Channels, response.Channels);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.InboundChannels, response.RecordType);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdateAsync(string.Empty, this.updateOptions);
            Assert.NotNull(response);
            Assert.IsType<InboundChannel>(response);
            Assert.Equal(this.updateOptions.Channels, response.Channels);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.InboundChannels, response.RecordType);
        }
    }
}
