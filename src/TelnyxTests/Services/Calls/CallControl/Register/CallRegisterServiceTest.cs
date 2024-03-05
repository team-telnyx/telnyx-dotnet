using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.CallRegisters;
using Telnyx.net.Services.PhoneNumbers.CallRegisters;
using Xunit;

namespace TelnyxTests.Services.Calls.CallControl.Register
{
    public class CallRegisterServiceTest : BaseTelnyxTest
    {
        private readonly CallRegisterService service;
        private readonly UpsertCallRegister createOptions;

        public CallRegisterServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallRegisterService();

            this.createOptions = new UpsertCallRegister()
            {
                To = "+18005550100",
                From = "+15001340938",
                Reason = "Confirm the Doctor appointment."
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateCallRegister(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(CallRegister), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateCallRegisterAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(CallRegister), result.GetType());
        }

    }
}
