using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs;
using Telnyx.net.Services.PhoneNumbers.PhoneNumberBlockJobs;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.PhoneNumberBlocksJobs
{
    public class PhoneNumberBlockJobServiceTest : BaseTelnyxTest
    {
        private readonly PhoneNumberBlockJobService service;
        private readonly PhoneNumberBlocksJobOption listOptions;
        private readonly UpsertPhoneNumberBlocksJob createOptions;
        private readonly RequestOptions requestOptions;
        private const string Id = "42587e44-3a3e-46de-9255-0c9a7a1d1ec7";

        public PhoneNumberBlockJobServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PhoneNumberBlockJobService();

            this.listOptions = new PhoneNumberBlocksJobOption()
            {
                Sort = "created_at",
                Status = "in_progress",
                Type = "delete_phone_number_block"
            };

            this.createOptions = new UpsertPhoneNumberBlocksJob()
            {
                PhoneNumberBlockId = "f3946371-7199-4261-9c3d-81a0d7935146"
            };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListPhoneNumberblockJob(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PhoneNumberblockJob>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPhoneNumberblockJobAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PhoneNumberblockJob>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetPhoneNumberblockJob(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PhoneNumberblockJob), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetPhoneNumberblockJobAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PhoneNumberblockJob), message.GetType());
        }
        [Fact]
        public void Create()
        {
            var result = this.service.CreatePhoneNumberblockJob(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumberblockJob), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreatePhoneNumberblockJobAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PhoneNumberblockJob), result.GetType());
        }
    }
}
