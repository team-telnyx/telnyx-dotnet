using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Calls.ConferenceCommands.ConferenceResume;
using Xunit;

namespace TelnyxTests.Services.Calls.ConferenceCommands.ConferenceResume
{
    public class ConferenceResumeServiceTest : BaseTelnyxTest
    {
        private readonly ConferenceResumeService service;
        private readonly ConferenceResumeOption createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public ConferenceResumeServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConferenceResumeService();

            this.createOptions = new ConferenceResumeOption()
            {
                CommandId = "891510ac-f3e4-11e8-af5b-de00688a4901",
                RecordingId = "891510ac-f3e4-11e8-af5b-de00688a4901"
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
