using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.PhoneNumbers;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.NumberPortouts;
using System;
using System.Collections.Generic;
using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;

namespace TelnyxTests.Services.Notifications.Notifications.DeleteABatchOfNumberss

{
    /// <summary>
    /// Test class for DeleteABatchOfNumbersTest.
    /// </summary>
    public class DeleteABatchOfNumbersTest : BaseTelnyxTest
    {
        private readonly NumberBackgroundJobService service;
        private readonly DeleteABatchOfNumbersOptions DeleteABatchOfNumbersOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public DeleteABatchOfNumbersTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberBackgroundJobService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.DeleteABatchOfNumbersOptions = new DeleteABatchOfNumbersOptions()
            {
                PhoneNumber = {}
            };
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteABatchOfNumbers(this.DeleteABatchOfNumbersOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task DeleteSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteABatchOfNumbersAsync(this.DeleteABatchOfNumbersOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
    }
}
