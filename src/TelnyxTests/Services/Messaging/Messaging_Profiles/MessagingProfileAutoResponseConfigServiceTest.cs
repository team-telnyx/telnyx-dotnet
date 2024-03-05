using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Messaging.Messaging_Profiles;
using Telnyx.net.Services.Messaging.Messaging_Profiles;
using Xunit;

namespace TelnyxTests.Services.Messaging.Messaging_Profiles
{
    public class MessagingProfileAutoResponseConfigServiceTest : BaseTelnyxTest
    {

        private readonly MessagingProfileAutoResponseConfigService service;
        private readonly MessagingProfileAutoResponseConfigOption listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public MessagingProfileAutoResponseConfigServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingProfileAutoResponseConfigService();

            this.listOptions = new MessagingProfileAutoResponseConfigOption()
            {
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<MessagingProfileAutoResponseConfig>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<MessagingProfileAutoResponseConfig>), result.GetType());
        }
    }
}
