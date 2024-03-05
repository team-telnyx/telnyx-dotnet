using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PortingOrders;
using Telnyx.net.Services.PortingOrders;
using Xunit;

namespace TelnyxTests.Services.PortingOrders
{
    public class PortingOrderActivateServiceTest : BaseTelnyxTest
    {
        private readonly PortingOrderActivateService service;
        private readonly UpsertPortingOrders createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "f1486bae-f067-460c-ad43-73a92848f902";
        private string parentId = "";

        public PortingOrderActivateServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PortingOrderActivateService();

            this.createOptions = new UpsertPortingOrders()
            {
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortingOrderActivate), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortingOrderActivate), result.GetType());
        }
    }
}
