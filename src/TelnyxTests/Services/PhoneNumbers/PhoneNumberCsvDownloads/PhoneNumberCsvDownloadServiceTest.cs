using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberCsvDownloads;
using Telnyx.net.Services.PhoneNumbers.PhoneNumberCsvDownloadService;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.PhoneNumberCsvDownloads
{
    public class PhoneNumberCsvDownloadServiceTest : BaseTelnyxTest
    {
        private readonly PhoneNumberCsvDownloadService service;
        private readonly PhoneNumberCsvDownloadOption listOptions;
        private readonly UpsertPhoneNumberCsvDownload createOptions;
        private readonly RequestOptions requestOptions;
        private const string Id = "42587e44-3a3e-46de-9255-0c9a7a1d1ec7";

        public PhoneNumberCsvDownloadServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PhoneNumberCsvDownloadService();

            this.listOptions = new PhoneNumberCsvDownloadOption()
            {
            };
            this.createOptions = new UpsertPhoneNumberCsvDownload()
            {
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListPhoneNumberCsvDownload(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PhoneNumberCsvDownload>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPhoneNumberCsvDownloadAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PhoneNumberCsvDownload>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetPhoneNumberCsvDownload(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<PhoneNumberCsvDownload>), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetPhoneNumberCsvDownloadAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PhoneNumberCsvDownload), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreatePhoneNumberCsvDownload(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumberCsvDownload), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreatePhoneNumberCsvDownloadAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumberCsvDownload), result.GetType());
        }
    }
}
