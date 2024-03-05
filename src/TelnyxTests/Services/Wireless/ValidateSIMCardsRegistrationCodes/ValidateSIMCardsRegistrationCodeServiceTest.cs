using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Wireless.ValidateSIMCardsRegistrationCodes;
using Telnyx.net.Services.Wireless.ValidateSIMCardsRegistrationCodes;
using Xunit;

namespace TelnyxTests.Services.Wireless.ValidateSIMCardsRegistrationCodes
{
    public class ValidateSIMCardsRegistrationCodeServiceTest : BaseTelnyxTest
    {
        private readonly ValidateSIMCardsRegistrationCodeService service;
        private readonly UpsertValidateSIMCardsRegistrationCode createOptions;

        public ValidateSIMCardsRegistrationCodeServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ValidateSIMCardsRegistrationCodeService();

            this.createOptions = new UpsertValidateSIMCardsRegistrationCode()
            {
               RegistrationCode = new string[] { "123456780", "1231231230" }
            };

        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateValidateSIMCardsRegistrationCode(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ValidateSIMCardsRegistrationCode), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateValidateSIMCardsRegistrationCodeAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ValidateSIMCardsRegistrationCode), result.GetType());
        }
    }
}
