using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.PhoneNumbers.Orders.Comments;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.PhoneNumbers.Orders.Comments;
using System;
using System.Collections.Generic;
using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;

namespace TelnyxTests.Services.PhoneNumbers.Orders.Comments

{
    /// <summary>
    /// Test class for CommentListTestTest.
    /// </summary>
    public class CommentListTestTest : BaseTelnyxTest
    {
        private readonly CommentService service;
        private readonly CommentListOptions CommentListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CommentListTestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new CommentService();
            baseOptions = new BaseOptions();
            requestOptions = new RequestOptions();
            CommentListOptions = new CommentListOptions()
            {
                CommentRecordId = "",
                CommentRecordType = "",
            };
        }

        [Fact]
        public void List()
        {
            var result = service.ListComments(CommentListOptions, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.ListCommentsAsync(CommentListOptions, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var result = service.RetrieveComments(Id, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.RetrieveCommentsAsync(Id, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
    }
}
