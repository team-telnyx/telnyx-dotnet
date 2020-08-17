namespace TelnyxTests.Services.WebRTC.Credentials
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.WebRTC.Credentials;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;

    /// <summary>
    /// Test class for TelephonyCredentialService.
    /// </summary>
    public class TelephonyCredentialServiceTest : BaseTelnyxTest
    {
        private readonly TelephonyCredentialService service;
        private readonly ListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public TelephonyCredentialServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new TelephonyCredentialService();

            this.listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.Data[0].GetType());
        }
    }
}
