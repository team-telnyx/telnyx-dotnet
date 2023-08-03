namespace TelnyxTests.Services.WebRTC.Credentials
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.DetailRecords;
    using Telnyx.net.Services.DetailRecords;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class DetailRecordsTest : BaseTelnyxTest
    {
        private readonly DetailRecordService service;
        private readonly DetailRecordOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public DetailRecordsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DetailRecordService();

            this.listOptions = new DetailRecordOptions
            {
                RecordType = Telnyx.net.Entities.Enum.DetailRecords.RecordType.Amd,
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact(Skip = "Mock filter does not work")]
        public void List()
        {
            var result = this.service.ListDocuments(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<DetailRecord>), result.GetType());
        }

        [Fact(Skip = "Mock filter does not work")]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListDocumentsAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<DetailRecord>), result.GetType());
        }
    }
}