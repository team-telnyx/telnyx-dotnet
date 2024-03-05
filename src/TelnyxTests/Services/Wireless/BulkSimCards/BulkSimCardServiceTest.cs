using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Xunit;

namespace TelnyxTests.Services.Wireless.BulkSimCards
{
    public class BulkSimCardServiceTest : BaseTelnyxTest
    {
        private readonly BulkSimCardService service;
        private readonly BulkSimCardSearchOptions listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public BulkSimCardServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new BulkSimCardService();

            this.listOptions = new BulkSimCardSearchOptions()
            {
                ActionType = "bulk_set_public_ips"
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<BulkSimCardSearch>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(this.listOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<BulkSimCardSearch>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.Get(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkSimCardSearch), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkSimCardSearch), message.GetType());
        }
    }
}
