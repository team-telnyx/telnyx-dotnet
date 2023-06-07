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

namespace TelnyxTests.Services.Notifications.Notifications.NumberPortoutComments

{
    /// <summary>
    /// Test class for NumberPortoutCommentTest.
    /// </summary>
    public class NumberPortoutCommentTest : BaseTelnyxTest
    {
        private readonly NumberPortoutCommentService service;
        private readonly CreateCommentsForAPortoutRequestOptions CreateCommentsForAPortoutRequestOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NumberPortoutCommentTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberPortoutCommentService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CreateCommentsForAPortoutRequestOptions = new CreateCommentsForAPortoutRequestOptions()
            {
                Body = "",
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListAllCommentsForAPortoutRequest(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAllCommentsForAPortoutRequestAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateCommentsForAPortoutRequest(Id, this.CreateCommentsForAPortoutRequestOptions,this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateCommentsForAPortoutRequestAsync(Id, this.CreateCommentsForAPortoutRequestOptions,this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberPortoutService), result.GetType());
        }
    }
}
