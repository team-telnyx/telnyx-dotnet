//namespace TelnyxTests.Services.WebRTC.Credentials
//{
//    using System.Net.Mail;
//    using System.Reflection.Metadata;
//    using System.Threading.Tasks;
//    using Telnyx;
//    using Telnyx.net.Entities.Documents;
//    using Telnyx.net.Services.Documents;
//    using Telnyx.net.Services.Documents.DocumentSize;
//    using Xunit;

//    /// <summary>
//    /// Test class for DocumentSize.
//    /// </summary>
//    public class DocumentSizeTest : BaseTelnyxTest
//    {
//        private readonly DocumentSizeSerive service;
//        private readonly DocumentSizeOptions listOptions;
//        private readonly RequestOptions requestOptions;
//        private readonly BaseOptions baseOptions;

//        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

//        public DocumentSizeTest(MockHttpClientFixture mockHttpClientFixture)
//            : base(mockHttpClientFixture)
//        {
//            this.service = new DocumentSizeSerive();

//            this.listOptions = new DocumentSizeOptions()
//            {
//                DocumentId = new System.Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
//                SizeedRecordType = "porting_order",
//                SizeedResourceId = new System.Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58")

//            };

//            this.baseOptions = new BaseOptions();

//            this.requestOptions = new RequestOptions();
//        }

//        [Fact]
//        public void List()
//        {
//            var result = this.service.ListDocuments(this.listOptions, this.requestOptions);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(DocumentSize), result.Data[0].GetType());
//        }


//        [Fact]
//        public async Task ListAsync()
//        {
//            var result = await this.service.ListDocumentsAsync(this.listOptions, this.requestOptions);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(DocumentSize), result.Data[0].GetType());
//        }
//    }
//}
