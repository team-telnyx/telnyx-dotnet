using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PhoneNumbers.CommentAsRead;
using Telnyx.net.Services.PhoneNumbers.CommentAsRead;
using Xunit;

namespace TelnyxTests.Services.Comments
{
    public class CommentAsReadServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly CommentAsReadService service;
        private readonly UpsertCommentAsRead createOptions;
        private readonly RequestOptions requestOptions;
        private string parentId = "";
        private string parenttoken = "";

        public CommentAsReadServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CommentAsReadService();

            this.createOptions = new UpsertCommentAsRead()
            {
            };
        }

        [Fact]
        public void Update()
        {
            var message = this.service.Update(this.parentId, this.credConnId, this.createOptions,this.requestOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CommentsAsRead), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var cts = new CancellationTokenSource();
            var message = await this.service.UpdateAsync(this.parentId, this.credConnId, this.createOptions, this.requestOptions, this.parenttoken, cts.Token);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CommentsAsRead), message.GetType());
        }
    }
}
