namespace TelnyxTests.Services.Notifications.Notifications.CreateAListOfSupportingDocumentsOnAPortoutRequests
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberPortouts;
    using Telnyx.net.Services.NumberPortouts;
    using Xunit;

    /// <summary>
    /// Test class for CreateAListOfSupportingDocumentsOnAPortoutRequestTest.
    /// </summary>
    public class CreateAListOfSupportingDocumentsOnAPortoutRequestTest : BaseTelnyxTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly SupportingDocumentsOnAPortoutRequestService service;
        private readonly CreateAListOfSupportingDocumentsOnAPortoutRequestOptions createAListOfSupportingDocumentsOnAPortoutRequestOptions;
        private readonly RequestOptions requestOptions;

        public CreateAListOfSupportingDocumentsOnAPortoutRequestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SupportingDocumentsOnAPortoutRequestService();
            this.requestOptions = new RequestOptions();
            this.createAListOfSupportingDocumentsOnAPortoutRequestOptions = new CreateAListOfSupportingDocumentsOnAPortoutRequestOptions()
            {
                Documents = new List<Telnyx.net.Entities.NumberPortouts.SupportingDocument>
                {
                    new Telnyx.net.Entities.NumberPortouts.SupportingDocument
                    {
                        DocumentId = Id,
                        Type = Telnyx.net.Entities.Enum.NumberPortouts.DocumentType.Invoice,
                    },
                },
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateAListOfSupportingDocumentsOnAPortoutRequest(Id, this.createAListOfSupportingDocumentsOnAPortoutRequestOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortOutSupportingDocument>), result.GetType());
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAListOfSupportingDocumentsOnAPortoutRequestAsync(Id, this.createAListOfSupportingDocumentsOnAPortoutRequestOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortOutSupportingDocument>), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListSupportingDocumentsOnAPortoutRequest(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortOutSupportingDocument>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListSupportingDocumentsOnAPortoutRequestAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortOutSupportingDocument>), result.GetType());
        }
    }
}
