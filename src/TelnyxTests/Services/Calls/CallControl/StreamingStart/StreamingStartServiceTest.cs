using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Calls.CallControl.StreamingStart;
using Telnyx.net.Services.Calls.CallControl.StreamingStart;
using Xunit;

namespace TelnyxTests.Services.Calls.CallControl.StreamingStart
{
    public class StreamingStartServiceTest : BaseTelnyxTest
    {
        private readonly StreamingStartService service;
        private readonly UpsertStreamingStart createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public StreamingStartServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new StreamingStartService();

            this.createOptions = new UpsertStreamingStart()
            {
                StreamUrl = "wss://www.example.com/websocket",
                StreamTrack = "both_tracks",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = "891510ac-f3e4-11e8-af5b-de00688a4901",
                EnableDialogflow = false,
                DialogflowConfig = new DialogflowConfig()
                {
                    AnalyzeSentiment = false,
                    PartialAutomatedAgentReply = false
                }
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
