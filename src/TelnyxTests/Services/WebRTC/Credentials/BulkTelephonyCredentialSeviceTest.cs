using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.BulkTelephonyCredentials;
using Telnyx.net.Services.PhoneNumbers.BulkTelephonyCredentials;
using Xunit;

namespace TelnyxTests.Services.WebRTC.Credentials
{
    public class BulkTelephonyCredentialSeviceTest : BaseTelnyxTest
    {
        private readonly BulkTelephonyCredentialSevice service;
        private readonly UpsertBulkTelephonyCredential createOptions; 
        private readonly string credConnId = "1234";
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public BulkTelephonyCredentialSeviceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new BulkTelephonyCredentialSevice();

            this.createOptions = new UpsertBulkTelephonyCredential()
            {

                Name = "Default Name",
                Tag = "My Credentials",
                ConnectionId = "804252963366242252"
            };

        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateUpsertBulkTelephonyCredential(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(BulkTelephonyCredential), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateUpsertBulkTelephonyCredentialAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(BulkTelephonyCredential), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteBulkTelephonyCredential(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkTelephonyCredential), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteBulkTelephonyCredentialAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkTelephonyCredential), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateBulkTelephonyCredential(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkTelephonyCredential), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateBulkTelephonyCredentialAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BulkTelephonyCredential), message.GetType());
        }
    }
}
