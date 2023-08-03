namespace TelnyxTests.Services.HostedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.HostedNumbers;
    using Telnyx.net.Services.HostedNumbers;
    using Xunit;

    public class HostedNumberOrdersTests : BaseTelnyxTest
    {
        private readonly HostedNumberOrderService service;
        private readonly HostedNumberOrderOptions options;
        private readonly FileUploadOptions fOptions;

        public HostedNumberOrdersTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.options = new HostedNumberOrderOptions { MessagingProfileId = Guid.NewGuid().ToString(), PhoneNumbers = new List<string> { "+17735555555" } };
            this.service = new HostedNumberOrderService();
            this.fOptions = new FileUploadOptions { Bill = "test", Loa = "test2" };
        }


        [Fact]
        public void Get()
        {
            var result = this.service.RetrieveHostedNumberOrders(Guid.NewGuid().ToString());
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.RetrieveHostedNumberOrdersAsync(Guid.NewGuid().ToString());
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListHostedNumberOrders(new Telnyx.ListOptions(1, 25));
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<HostedNumberOrder>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListHostedNumberOrdersAsync(new Telnyx.ListOptions(1, 25));
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<HostedNumberOrder>), result.GetType());
        }

        [Fact(Skip = "Mock returning incorrect response data")]
        public void Create()
        {
            var result = this.service.CreateHostedNumberOrders(this.options);
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }

        [Fact(Skip = "Mock returning incorrect response data")]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateHostedNumberOrdersAsync(this.options);
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }

        [Fact(Skip = "Mock not mapping auth header properly")]
        public void UploadFiles()
        {
            var result = this.service.UploadFile(Guid.NewGuid().ToString(), this.fOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }

        [Fact(Skip = "Mock not mapping auth header properly")]
        public async Task UploadFilesAsync()
        {
            var result = await this.service.UploadFileAsync(Guid.NewGuid().ToString(), this.fOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(HostedNumberOrder), result.GetType());
        }
    }
}
