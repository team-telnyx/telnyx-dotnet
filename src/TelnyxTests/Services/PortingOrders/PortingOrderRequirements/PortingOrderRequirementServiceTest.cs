using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PortingOrders.PortingOrderRequirements;
using Telnyx.net.Services.PortingOrders.PortingOrderRequirements;
using Xunit;

namespace TelnyxTests.Services.PortingOrders.PortingOrderRequirements
{
    public class PortingOrderRequirementServiceTest : BaseTelnyxTest
    {

        private readonly PortingOrderRequirementService service;
        private readonly ListOptions listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public PortingOrderRequirementServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PortingOrderRequirementService();

            this.listOptions = new ListOptions()
            {
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortingOrderRequirement>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortingOrderRequirement>), result.GetType());
        }
    }
}
