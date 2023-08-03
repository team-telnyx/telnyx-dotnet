namespace TelnyxTests.Services.WebRTC.Credentials
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Documents;
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
        }
    }
}
