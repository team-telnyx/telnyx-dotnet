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

namespace TelnyxTests.Services.Notifications.Notifications.ListPortoutRequests

{
    /// <summary>
    /// Test class for ListPortoutRequestTest.
    /// </summary>
    public class ListPortoutRequestTest : BaseTelnyxTest
    {
        private readonly NumberPortoutService service;
        private readonly ListPortoutRequestOptions ListPortoutRequestOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public ListPortoutRequestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberPortoutService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.ListPortoutRequestOptions = new ListPortoutRequestOptions()
            {
            };
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveNumberPortouts(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNumberPortoutsAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }
        [Fact]
        public void List()
        {
            var result = this.service.ListPortoutRequests(this.ListPortoutRequestOptions,this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPortoutRequestsAsync(this.ListPortoutRequestOptions,this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }
    }
}
