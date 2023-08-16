namespace TelnyxTests.Services.PhoneNumbers.Orders.Comments

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Orders.Comments;
    using Telnyx.net.Services.PhoneNumbers.Orders.Comments;
    using Xunit;

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
            this.service = new CommentService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CommentCreateOptions = new CommentCreateOptions()
            {
                Body = string.Empty,
                CommentRecordId = "6a09cdc3-8948-47f0-aa62-74ac943d6c99",
                CommentRecordType = Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments.CommentRecordType.NumberOrderPhoneNumber,
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.CommentCreateOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.CommentCreateOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(Comment), result.GetType());
        }
    }
}
