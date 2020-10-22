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
                Name = "admin",
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
            Assert.NotNull(result.Id);
            Assert.NotNull(result.ResourceId);
            Assert.NotNull(result.RecordType);
            Assert.NotNull(result.SipUsername);
            Assert.NotNull(result.SipPassword);
            Assert.NotNull(result.CreatedAt);
            Assert.NotNull(result.UpdatedAt);
            Assert.Equal("credential", result.RecordType);
            Assert.Equal(this.createOptions.Name, result.Name);
            Assert.Equal(this.createOptions.ExpiresAt, result.ExpiredAt);
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

        [Fact(Skip = "Mock not working")]
        public void GetToken()
        {
            var response = this.service.GetToken(Id, this.requestOptions);
            Assert.NotNull(response);
            Assert.Equal(typeof(string), response.GetType());
        }

        [Fact(Skip = "Mock not working")]
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
                Assert.Equal(typeof(Telnyx.TelnyxException), exceptionType);

            }
            //Assert.Null(result);
            //Assert.Equal(400, result.);
        }
    }
}
