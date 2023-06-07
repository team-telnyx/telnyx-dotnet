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
    /// Test class for CommentCreateTestTest.
    /// </summary>
    public class CommentCreateTestTest : BaseTelnyxTest
    {
        private readonly CommentService service;
        private readonly CommentCreateOptions CommentCreateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CommentCreateTestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new CommentService();
            baseOptions = new BaseOptions();
            requestOptions = new RequestOptions();
            CommentCreateOptions = new CommentCreateOptions()
            {
                Body = "",
                CommentRecordId = "",
                CommentRecordType = Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments.CommentRecordType.NumberOrderPhoneNumber
            };
        }

        [Fact]
        public void List()
        {
            var result = service.Create(CommentCreateOptions, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.CreateAsync(CommentCreateOptions, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
        [Fact]
        public void Update()
        {
            var result = service.UpdateComment(Id, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task UpdateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.UpdateCommentAsync(Id, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
    }
}
