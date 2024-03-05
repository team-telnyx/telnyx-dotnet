using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.BulkSettingSIMCardPublicIPs;
using Telnyx.net.Services.PhoneNumbers.BulkSettingSIMCardPublicIPs;
using Xunit;

namespace TelnyxTests.Services.Wireless.BulkSimCards
{
    public class BulkSettingSIMCardPublicIPServiceTest : BaseTelnyxTest
    {
        private readonly BulkSettingSIMCardPublicIPService service;
        private readonly UpsertBulkSettingSIMCardPublicIP createOptions;

        public BulkSettingSIMCardPublicIPServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new BulkSettingSIMCardPublicIPService();

            this.createOptions = new UpsertBulkSettingSIMCardPublicIP()
            {
                SimCardIds = new Guid[] { Guid.Parse("6b14e151-8493-4fa1-8664-1cc4e6d14158") }
            };

        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateBulkSettingSIMCardPublicIP(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(BulkSettingSIMCardPublicIP), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateBulkSettingSIMCardPublicIPAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(BulkSettingSIMCardPublicIP), result.GetType());
        }
    }
}
