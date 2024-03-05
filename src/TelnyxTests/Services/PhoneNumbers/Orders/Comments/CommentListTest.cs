namespace TelnyxTests.Services.PhoneNumbers.Orders.Comments

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Xunit;

    /// <summary>
    /// Test class for CommentListTestTest.
    /// </summary>
    public class CommentListTestTest : BaseTelnyxTest
    {
        private readonly CommentsService service;
        private readonly CommentQueryOptions CommentListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CommentListTestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CommentsService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CommentListOptions = new CommentQueryOptions()
            {
                CommentRecordId = "8ffb3622-7c6b-4ccc-b65f-7a3dc0099576",
                CommentRecordType = "sub_number_order",
            };
        }

        [Fact(Skip = "Filter list query options not working in mocks which are required parameters")]
        public void List()
        {
            var result = this.service.List(this.CommentListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<Comment>), result.GetType());
        }

        [Fact(Skip = "Filter list query options not working in mocks which are required parameters")]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(this.CommentListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<Comment>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.Get(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.GetAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }
    }
}
