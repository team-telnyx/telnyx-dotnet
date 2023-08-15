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
        private readonly TelephonyCredentialCreateOptions createOptions;
        private readonly TelephonyCredentialUpdateOptions updateOptions;

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
            this.createOptions = new TelephonyCredentialCreateOptions()
            {
                ConnectionId = "1234567890",
                ExpiresAt = "2018-02-02T22:25:27.521Z",
                Name = "2020-06-18 21:32:38.917732Z",
                Tag = "some_tag",
            };

            this.updateOptions = new TelephonyCredentialUpdateOptions()
            {
                ConnectionId = "987654321",
                ExpiresAt = "2018-02-02T22:25:27.521Z",
                Name = "My Creds",
            };
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

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.GetType());
            Assert.Equal("c215ade3-0d39-418e-94be-c5f780760199", result.Id);
            Assert.Equal("connection:804252963366242252", result.ResourceId);
            Assert.Equal("credential", result.RecordType);
            Assert.Equal("gencrednCvHU5IYpSBPPsXI2iQsDX", result.SipUsername);
            Assert.Equal("a92dbcfb60184a8cb330b0acb2f7617b", result.SipPassword);
            Assert.NotNull(result.CreatedAt);
            Assert.NotNull(result.UpdatedAt);
            Assert.Equal("2020-06-18 21:32:38.917732Z", result.Name);
            Assert.Equal("2042-06-18T21:32:38", result.ExpiredAt);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.GetType());
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WebRtcCredential), result.GetType());
        }

        [Fact]
        public void Update()
        {
            var response = this.service.Update(Id, this.updateOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(WebRtcCredential), response.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdateAsync(Id, this.updateOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(WebRtcCredential), response.GetType());
        }

        [Fact]
        public void Delete()
        {
            var response = this.service.Delete(Id, this.requestOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(WebRtcCredential), response.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var response = await this.service.DeleteAsync(Id, this.requestOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(WebRtcCredential), response.GetType());
        }

        [Fact]
        public void GetToken()
        {
            var response = this.service.GetToken(Id, this.requestOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(string), response.GetType());
        }

        [Fact]
        public async Task GetTokenAsync()
        {
            var response = await this.service.GetTokenAsync(Id, this.requestOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(string), response.GetType());
        }

        [Fact]
        public void UnauthorizedRequest()
        {
            var requestOptions = new RequestOptions() { ApiKey = "wrong_key" };
            try
            {
                var result = this.service.Create(this.createOptions, requestOptions);
            }
            catch (System.Exception ex)
            {
                var exceptionType = ex.GetType();
                Assert.Equal(typeof(TelnyxException), exceptionType);
            }
        }
    }
}
