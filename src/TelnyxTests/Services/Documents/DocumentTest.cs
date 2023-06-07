namespace TelnyxTests.Services.WebRTC.Credentials
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Documents;
    using Telnyx.net.Entities.WebRTC.Credentials;
    using Telnyx.net.Services.Documents;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;

    /// <summary>
    /// Test class for DocumentService.
    /// </summary>
    public class DocumentServiceTest : BaseTelnyxTest
    {
        private readonly DocumentService service;
        private readonly DocumentListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private readonly DocumentCreateOptions createOptions;
        private readonly TelephonyCredentialUpdateOptions updateOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public DocumentServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DocumentService();

            this.listOptions = new DocumentListOptions()
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.createOptions = new DocumentCreateOptions()
            {
                CustomerReference = "MY REF 001",
                Url = "https://dummy.com",
                FileName = "fileName",
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListDocuments(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Document), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListDocumentsAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Document), result.Data[0].GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.SendDocument(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Document), result.GetType());
            Assert.Equal("MY REF 001", result.CustomerReference);
            var telnyxResponseStr = result.TelnyxResponse.ToString();
            var strn = result.ToString();
            var expectedStr = "<Telnyx.net.Entities.WebRTC.Credentials.WebRtcCredential@18280971 id=c215ade3-0d39-418e-94be-c5f780760199> JSON: {\r\n  \"id\": \"c215ade3-0d39-418e-94be-c5f780760199\",\r\n  \"name\": \"admin\",\r\n  \"record_type\": \"credential\",\r\n  \"resource_id\": \"connection:804252963366242252\",\r\n  \"user_id\": null,\r\n  \"sip_password\": \"a92dbcfb60184a8cb330b0acb2f7617b\",\r\n  \"sip_username\": \"gencrednCvHU5IYpSBPPsXI2iQsDX\",\r\n  \"expires_at\": \"2018-02-02T22:25:27.521Z\",\r\n  \"created_at\": \"2020-06-18T21:32:38\",\r\n  \"updated_at\": \"2020-06-18T21:32:38Z\"\r\n}";
            Assert.NotNull(expectedStr);
        }
    }
}
