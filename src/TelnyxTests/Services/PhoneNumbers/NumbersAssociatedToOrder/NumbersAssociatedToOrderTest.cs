using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.PhoneNumbers.NumbersAssociatedToOrders;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;

namespace TelnyxTests.Services.PhoneNumbers.NumbersAssociatedToOrder

{
    /// <summary>
    /// Test class for NumbersAssociatedToOrderTest.
    /// </summary>
    public class NumbersAssociatedToOrderTest : BaseTelnyxTest
    {
        private readonly NumbersAssociatedToOrderService service;
        private readonly UpdateNumbersAssociatedToOrderOptions UpdateNumbersAssociatedToOrderOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NumbersAssociatedToOrderTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new NumbersAssociatedToOrderService();
            baseOptions = new BaseOptions();
            requestOptions = new RequestOptions();
            UpdateNumbersAssociatedToOrderOptions = new UpdateNumbersAssociatedToOrderOptions()
            {
                RegulatoryRequirements = { },
            };
        }

        [Fact]
        public void Update()
        {
            var result = service.UpdateNumbersAssociatedToOrder(Id, UpdateNumbersAssociatedToOrderOptions, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task UpdateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.UpdateNumbersAssociatedToOrderAsync(Id, UpdateNumbersAssociatedToOrderOptions, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
        [Fact]
        public void List()
        {
            var result = service.ListNumbersAssociatedToOrders(requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.ListNumbersAssociatedToOrdersAsync(requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var result = service.RetrieveNumbersAssociatedToOrders(Id, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await service.RetrieveNumbersAssociatedToOrdersAsync(Id, requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumber), result.GetType());
        }
    }
}
