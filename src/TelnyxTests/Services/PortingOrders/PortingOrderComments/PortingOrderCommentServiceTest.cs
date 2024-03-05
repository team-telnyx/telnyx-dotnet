using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PortingOrders.PortingOrderComments;
using Telnyx.net.Services.PortingOrders.PortingOrderComments;
using Xunit;

namespace TelnyxTests.Services.PortingOrders.PortingOrderComments
{
    public class PortingOrderCommentServiceTest : BaseTelnyxTest
    {
        private readonly PortingOrderCommentService service;
        private readonly UpsertPortingOrderComment createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public PortingOrderCommentServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PortingOrderCommentService();

            this.createOptions = new UpsertPortingOrderComment()
            {
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortingOrderComment), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortingOrderComment), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortingOrderComment>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortingOrderComment>), result.GetType());
        }
    }
}
