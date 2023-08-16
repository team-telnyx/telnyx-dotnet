namespace TelnyxTests.Services.HostedNumbers
{
    using System;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.HostedNumbers;
    using Telnyx.net.Services.HostedNumbers;
    using Xunit;

    public class HostedNumberServiceTests : BaseTelnyxTest
    {
        private readonly HostedNumberService service;

        public HostedNumberServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new HostedNumberService();
        }

        [Fact(Skip = "Mock not returning json data")]
        public void Delete()
        {
            var result = this.service.DeleteHostedNumber(Guid.NewGuid().ToString());
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumber), result.GetType());
        }

        [Fact(Skip = "Mock not returning json data")]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteHostedNumberAsync(Guid.NewGuid().ToString());
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumber), result.GetType());
        }
    }
}
