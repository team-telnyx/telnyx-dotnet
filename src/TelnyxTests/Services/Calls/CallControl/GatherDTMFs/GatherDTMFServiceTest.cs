using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Calls.CallControl.GatherDTMFs;
using Telnyx.net.Services.Calls.CallControl.GatherDTMFs;
using Xunit;

namespace TelnyxTests.Services.Calls.CallControl.GatherDTMFs
{
    public class GatherDTMFServiceTest : BaseTelnyxTest
    {
        private readonly GatherDTMFService service;
        private readonly UpsertGatherDTMF createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public GatherDTMFServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new GatherDTMFService();

            this.createOptions = new UpsertGatherDTMF()
            {
                MinimumDigits = 1,
                MaximumDigits = 10,
                TimeoutMillis = 60000,
                InterDigitTimeoutMillis = 10000,
                InitialTimeoutMillis = 10000,
                TerminatingDigit = "#",
                ValidDigits = "123",
                GatherId = "my_gather_id",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = "891510ac-f3e4-11e8-af5b-de00688a4901"
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(GatherDTMF), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(GatherDTMF), result.GetType());
        }
    }
}
