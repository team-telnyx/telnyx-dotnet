namespace TelnyxTests.Services.WebRTC.Credentials
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Documents;
    using Telnyx.net.Services.Documents.DocumentLinks;
    using Xunit;

    /// <summary>
    /// Test class for DocumentLink.
    /// </summary>
    public class DocumentLinkTest : BaseTelnyxTest
    {
        private readonly DocumentLinkSerive service;
        private readonly DocumentLinkOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public DocumentLinkTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DocumentLinkSerive();

            this.listOptions = new DocumentLinkOptions()
            {
                DocumentId = new System.Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                LinkedRecordType = "porting_order",
                LinkedResourceId = new System.Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListDocuments(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(DocumentLink), result.Data[0].GetType());
        }


        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListDocumentsAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(DocumentLink), result.Data[0].GetType());
        }
    }
}
