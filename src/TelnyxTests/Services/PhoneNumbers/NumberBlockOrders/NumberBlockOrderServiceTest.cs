using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberBlockOrders;
using Telnyx.net.Services.PhoneNumbers.NumberBlockOrders;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.NumberBlockOrders
{
    public class NumberBlockOrderServiceTest : BaseTelnyxTest
    {
        private readonly NumberBlockOrderService service;
        private readonly NumberBlockOrderOptions listOptions;
        private readonly UpsertNumberBlockOrder createOptions;
        private readonly RequestOptions requestOptions;
        private const string Id = "12ade33a-21c0-473b-b055-b3c836e1c292";

        public NumberBlockOrderServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberBlockOrderService();

            this.listOptions = new NumberBlockOrderOptions()
            {
            };
            this.createOptions = new UpsertNumberBlockOrder()
            {
                StartingNumber = "+19705555000",
                Range = 10,
                ConnectionId = "346789098765567",
                MessagingProfileId = "abc85f64-5717-4562-b3fc-2c9600",
                CustomerReference = "MY REF 001",
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNumberBlockOrders(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumberBlockOrder>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNumberBlockOrdersAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumberBlockOrder>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetNumberBlockOrder(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberBlockOrder), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetNumberBlockOrderAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(NumberBlockOrder), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateNumberBlockOrder(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberBlockOrder), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateNumberBlockOrderAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberBlockOrder), result.GetType());
        }

    }
}
