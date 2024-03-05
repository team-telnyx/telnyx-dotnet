using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.NumberOrderDocuments;
using Telnyx.net.Services.NumberOrderDocuments;
using Xunit;

namespace TelnyxTests.Services.NumberOrderDocuments
{
    public class NumberOrderDocumentServiceTest : BaseTelnyxTest
    {
        private readonly NumberOrderDocumentService service;
        private readonly NumberOrderDocumentListOptions listOptions;
        private readonly NumberOrderDocumentCreateOptions createOptions;
        private readonly NumberOrderDocumentUpdateOptions UpdateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private object options;
        private const string Id = "387d1e31-a218-4375-8151-103f2d5e2d2c";
        private readonly string credConnId = "1234";

        public NumberOrderDocumentServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberOrderDocumentService();

            var listOptions = new NumberOrderDocumentListOptions()
            {
                RequirementId = "36aaf27d-986b-493c-bd1b-de16af2e4292",
                CreatedAtLessThan = "2018-01-01T00:00:00.000000Z",
                CreatedAtGreaterThan = "2018-01-01T00:00:00.000000Z"
            };
            this.createOptions = new NumberOrderDocumentCreateOptions()
            {
                FileId = "1e3c5822-0362-4702-8e46-5a129f0d3976",
                RequirementsId = "36aaf27d-986b-493c-bd1b-de16af2e4292",
                CustomerReference = "MY REF 001",

            };
            this.UpdateOptions = new NumberOrderDocumentUpdateOptions()
            {
                FileId = "1e3c5822-0362-4702-8e46-5a129f0d3976",
                RequirementsId = "36aaf27d-986b-493c-bd1b-de16af2e4292",
                CustomerReference = "MY REF 001",

            };


            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNumberOrderDocuments(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumberOrderDocument>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNumberOrderDocumentsAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumberOrderDocument>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetNumberOrderDocument(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberOrderDocument), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetNumberOrderDocumentAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberOrderDocument), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateNumberOrderDocument(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberOrderDocument), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateNumberOrderDocumentAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberOrderDocument), result.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateNumberOrderDocument("123", this.UpdateOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberOrderDocument), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateNumberOrderDocumentAsync("123", this.UpdateOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberOrderDocument), message.GetType());
        }
    }
}
