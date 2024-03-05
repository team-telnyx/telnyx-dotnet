using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
using Telnyx.net.Services.Wireless.SimCards.SIMCardRemovePublicIPs;
using Xunit;

namespace TelnyxTests.Services.Wireless.SimCards
{
    public class SIMCardRemovePublicIPServiceTest : BaseTelnyxTest
    {
        private readonly SIMCardRemovePublicIPService service;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public SIMCardRemovePublicIPServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SIMCardRemovePublicIPService();



            this.requestOptions = new RequestOptions();
            this.baseOptions = new BaseOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SettingSIMCardPublicIP), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.baseOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(SettingSIMCardPublicIP), result.GetType());
        }

    }
}
