using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.WebRTC.Credentials;
using Telnyx.net.Services.WebRTC.Credentials;
using Xunit;

namespace TelnyxTests.Services.WebRTC.Credentials
{
    public class TelephonyCredentialTagsServiceTest : BaseTelnyxTest
    {
        private readonly TelephonyCredentialTagsService service;
        private readonly TelephonyCredentialTagOption listOptions;
        private readonly RequestOptions requestOptions;

        public TelephonyCredentialTagsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new TelephonyCredentialTagsService();

            this.listOptions = new TelephonyCredentialTagOption()
            {
            };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListTelephonyCredential(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<TelephonyCredentialTag>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListTelephonyCredentialAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<TelephonyCredentialTag>), result.GetType());
        }
    }
}
