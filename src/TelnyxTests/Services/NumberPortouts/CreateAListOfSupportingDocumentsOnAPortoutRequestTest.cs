using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.NumberPortouts;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.NumberPortouts;
using System;
using System.Collections.Generic;
using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;

namespace TelnyxTests.Services.Notifications.Notifications.CreateAListOfSupportingDocumentsOnAPortoutRequests

{
    /// <summary>
    /// Test class for CreateAListOfSupportingDocumentsOnAPortoutRequestTest.
    /// </summary>
    public class CreateAListOfSupportingDocumentsOnAPortoutRequestTest : BaseTelnyxTest
    {
        private readonly SupportingDocumentsOnAPortoutRequestService service;
        private readonly CreateAListOfSupportingDocumentsOnAPortoutRequestOptions CreateAListOfSupportingDocumentsOnAPortoutRequestOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateAListOfSupportingDocumentsOnAPortoutRequestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SupportingDocumentsOnAPortoutRequestService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CreateAListOfSupportingDocumentsOnAPortoutRequestOptions = new CreateAListOfSupportingDocumentsOnAPortoutRequestOptions()
            {
                Documents = {}
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateAListOfSupportingDocumentsOnAPortoutRequest(Id, this.CreateAListOfSupportingDocumentsOnAPortoutRequestOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAListOfSupportingDocumentsOnAPortoutRequestAsync(Id, this.CreateAListOfSupportingDocumentsOnAPortoutRequestOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }
        [Fact]
        public void List()
        {
            var result = this.service.ListSupportingDocumentsOnAPortoutRequest(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListSupportingDocumentsOnAPortoutRequestAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }
    }
}
