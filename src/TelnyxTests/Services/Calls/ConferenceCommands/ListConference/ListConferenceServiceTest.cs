// <copyright file="ListConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingPhoneNumbers
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class ListConferenceServiceTest : BaseTelnyxTest
    {
        private const string MessagingPhoneNosId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly ListConferenceService service;
        private readonly ListConferenceOptions listOptions;

        public ListConferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ListConferenceService();
        }

        [Fact]
        public void List()
        {
            var conferenceList = this.service.List(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/conferences");
            Assert.NotNull(conferenceList);
            Assert.Single(conferenceList.Data);
            Assert.Equal(typeof(Telnyx.ListConferenceResponse), conferenceList.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var conferenceList = await this.service.ListAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/conferences");
            Assert.NotNull(conferenceList);
            Assert.Single(conferenceList.Data);
            Assert.Equal(typeof(Telnyx.ListConferenceResponse), conferenceList.Data[0].GetType());
        }
    }
}
