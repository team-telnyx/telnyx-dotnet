using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.CustomerServiceRecords;
using Telnyx.net.Services.PhoneNumbers.CustomerServiceRecords;
using Xunit;

namespace TelnyxTests.Services.CustomerServiceRecords
{
    public class CustomerServiceRecordServiceTest : BaseTelnyxTest
    {
        private readonly CustomerServiceRecordService service;
        private readonly CustomerServiceRecordOption listOptions;
        private readonly UpsertCustomerServiceRecord createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private object options;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public CustomerServiceRecordServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CustomerServiceRecordService();

            this.listOptions = new CustomerServiceRecordOption()
            {
            };
            this.createOptions = new UpsertCustomerServiceRecord()
            {
                PhoneNumber = "+1234567890",
                WebhookUrl = "https://example.com/webhook",
                AdditionalData = new AdditionalData
                {
                    Name = "Entity Inc.",
                    AuthorizedPersonName = "John Doe",
                    Pin = "1234",
                    AccountNumber = "123456789",
                    CustomerCode = "123456789",
                    AddressLine1 = "123 Main St",
                    City = "New York",
                    State = "NY",
                    ZipCode = "10001",
                    BillingPhoneNumber = "+12065551212"
                }
            };


            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListCustomerServiceRecord(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<CustomerServiceRecord>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListCustomerServiceRecordAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<CustomerServiceRecord>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetCustomerServiceRecord(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CustomerServiceRecord), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetCustomerServiceRecordAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CustomerServiceRecord), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateCustomerServiceRecord(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(CustomerServiceRecord), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateCustomerServiceRecordAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(CustomerServiceRecord), result.GetType());
        }

    }
}
