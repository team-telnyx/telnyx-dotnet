using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.ChannelZone;
using Telnyx.net.Services.ChannelZones;
using Xunit;

namespace TelnyxTests.Services.ChannelZone
{
    public class ChannelZonePhoneNumberServiceTest : BaseTelnyxTest
    {
        private readonly ChannelZonePhoneNumberService service;
        private readonly ChannelZonePhoneNumberOption listOptions;
        private const string Id = "1653e6a1-4bfd-4857-97c6-6a51e1c34477";

        public ChannelZonePhoneNumberServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ChannelZonePhoneNumberService();

            this.listOptions = new ChannelZonePhoneNumberOption()
            {
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ChannelZonePhoneNumber>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ChannelZonePhoneNumber>), result.GetType());
        }
    }
}
