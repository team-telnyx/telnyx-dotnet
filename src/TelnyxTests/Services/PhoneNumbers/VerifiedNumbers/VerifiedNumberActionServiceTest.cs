using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers;
using Telnyx.net.Services.PhoneNumbers.VerifiedNumbers;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.VerifiedNumbers
{
    public class VerifiedNumberActionServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly VerifiedNumberActionService service;
        private readonly UpsertVerifiedNumber createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";
        public VerifiedNumberActionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new VerifiedNumberActionService();

            this.createOptions = new UpsertVerifiedNumber()
            {
                VerificationCode = "123456"
            };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.parentId, this.createOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var message = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, this.parentId, cts.Token);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }
    }
}
