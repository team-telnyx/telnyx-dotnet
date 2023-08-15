namespace TelnyxTests.Services.PhoneNumbers.Orders.Comments

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Orders.Comments;
    using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;
    using Telnyx.net.Services.PhoneNumbers.Orders.Comments;
    using Xunit;

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
            this.service = new CommentService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CommentListOptions = new CommentListOptions()
            {
                CommentRecordId = "8ffb3622-7c6b-4ccc-b65f-7a3dc0099576",
                CommentRecordType = "sub_number_order",
            };
        }

        [Fact(Skip = "Filter list query options not working in mocks which are required parameters")]
        public void List()
        {
            var result = this.service.ListComments(this.CommentListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SubNumberOrder>), result.GetType());
        }

        [Fact(Skip = "Filter list query options not working in mocks which are required parameters")]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListCommentsAsync(this.CommentListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SubNumberOrder>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveComments(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveCommentsAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }
    }
}
