namespace TelnyxTests.Services.Calls.ConferenceCommands.UpdateConference
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Calls.ConferenceCommands.UpdateConference;
    using Telnyx.net.Services.Documents;
    using Xunit;

    /// <summary>
    /// Test class for UpdateConference.
    /// </summary>
    public class UpdateConferenceTest : BaseTelnyxTest
    {
        private readonly UpdateConferenceService service;
        private readonly UpdateConferenceOptions updateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private readonly DocumentCreateOptions createOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public UpdateConferenceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new UpdateConferenceService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.updateOptions = new UpdateConferenceOptions()
            {
                CallControlId = "CallControlId ",
                CommandId = "CommandId",
                SupervisorRole = "barge",
                WhisperCallControlIds = new string[] { "string1", "string2", "string3" },
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Leave(Id, this.updateOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
            Assert.Equal("ok", result.Result);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.LeaveAsync(Id, this.updateOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
            Assert.Equal("ok", result.Result);
        }
    }
}
