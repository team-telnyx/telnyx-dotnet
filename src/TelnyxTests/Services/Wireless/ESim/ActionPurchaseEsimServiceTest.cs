using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.ESim.ActionPurchaseEsims;
using Telnyx.net.Services.Wireless.ESim;
using Xunit;

namespace TelnyxTests.Services.Wireless.ESim
{
    public class ActionPurchaseEsimServiceTest : BaseTelnyxTest
    {
        private readonly ActionPurchaseEsimService service;
        private readonly UpsertActionPurchaseEsim createOptions;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public ActionPurchaseEsimServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ActionPurchaseEsimService();
            this.createOptions = new UpsertActionPurchaseEsim
            {
                SimCardGroupId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Tags = new string[] { "personal", "customers", "active-customers" },
                Amount = 10,
                Status = "standby"
            };

        }


        [Fact]
        public void Create()
        {
            var result = this.service.CreateActionPurchaseEsim(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ActionPurchaseEsim), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateActionPurchaseEsimAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ActionPurchaseEsim), result.GetType());
        }
    }
}
