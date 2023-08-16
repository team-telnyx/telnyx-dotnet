//namespace TelnyxTests.Services.Calls.ConferenceCommands.LeaveConference
//{
//    using System.Threading.Tasks;
//    using Telnyx;
//    using Telnyx.net.Entities;
//    using Telnyx.net.Services.InventoryCoverage;
//    using Telnyx.net.Services.Documents;
//    using Telnyx.net.Services.WebRTC.Credentials;
//    using Xunit;
//    using static Telnyx.CreateConferenceOptions;

//    /// <summary>
//    /// Test class for LeaveConference.
//    /// </summary>
//    public class InventoryCoverageTest : BaseTelnyxTest
//    {
//        private readonly InventoryCoverageService service;
//        private readonly LeaveConferenceOptions leaveConferenceOptions;
//        private readonly RequestOptions requestOptions;
//        private readonly BaseOptions baseOptions;
//        private readonly DocumentCreateOptions createOptions;
//        private readonly TelephonyCredentialUpdateOptions updateOptions;

//        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

//        public InventoryCoverageTest(MockHttpClientFixture mockHttpClientFixture)
//            : base(mockHttpClientFixture)
//        {
//            service = new LeaveConferenceService();

//            baseOptions = new BaseOptions();

//            requestOptions = new RequestOptions();
//            leaveConferenceOptions = new LeaveConferenceOptions()
//            {
//                CallControlId = "c46e06d7-b78f-4b13-96b6-c576af9640ff",
//                CommandId = "CommandId",
//                BeepEnabled = BeepEnum.ALWAYS,
//            };
//        }

//        [Fact]
//        public void Create()
//        {
//            var result = service.Leave(Id, leaveConferenceOptions, requestOptions);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
//            Assert.Equal("ok", result.Result);
//        }
//    }

