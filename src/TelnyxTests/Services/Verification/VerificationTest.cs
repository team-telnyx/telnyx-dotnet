using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VerifyAPI;
using Telnyx.net.Services.VerifyAPI;
using Xunit;

namespace TelnyxTests.Services.Verification
{
    public class VerificationTest : BaseTelnyxTest
    {
        private readonly VerificationService _verificationService;
        private VerifyProfileListOptions profileListOptions;
        private VerifyProfileOptions profileOptions;
        private VerifyOptions verifyOptions;
        private VerifyCodeOptions codeOptions;


        public VerificationTest(MockHttpClientFixture mockHttpClientFixture) : base(mockHttpClientFixture)
        {
            _verificationService = new VerificationService("KEYSUPERSECRET");
            profileListOptions = new VerifyProfileListOptions
            {
                Filter = "Test"
            };
            profileOptions = new VerifyProfileOptions
            {
                DefaultTimeoutSecs = 300,
                MessagingEnabled = true,
                MessagingTemplate = "Hello this is a test {code}",
                Name = "Test Profile",
                RcsEnabled = false
            };
            verifyOptions = new VerifyOptions
            {
                TimeoutSecs = 300,
                PhoneNumber = "+13100000010",
                VerifyProfileId = Guid.NewGuid(),
                Type = "sms",
            };
            codeOptions = new VerifyCodeOptions
            {
                Code = "2222"
            };
        }

        
        [Fact(Skip = "Mock not working, does not allow listOptions")]
        public async Task List2FAProfiles()
        {
            var result = this._verificationService.ListVerificationProfiles(this.profileListOptions);
            var resultAsync = await this._verificationService.ListVerificationProfilesAsync(this.profileListOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VerifyProfile>), result.GetType());
            Assert.Equal(typeof(TelnyxList<VerifyProfile>), resultAsync.GetType());

        }

        [Fact]
        public async Task Create2FaProfiles()
        {
            var result = this._verificationService.CreateVerificationProfile(this.profileOptions);
            var resultAsync = await this._verificationService.CreateVerificationProfileAsync(this.profileOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
            Assert.Equal(typeof(VerifyProfile), resultAsync.GetType());
        }

        [Fact]
        public async Task Retrieve2FaProfiles()
        {
            var result = this._verificationService.GetVerificationProfile(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.GetVerificationProfileAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
            Assert.Equal(typeof(VerifyProfile), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, not recognizing PUT Url")]
        public async Task Update2FaProfiles()
        {
            var result = this._verificationService.UpdatVerificationProfile(Guid.NewGuid().ToString(), this.profileOptions);
            var resultAsync = await this._verificationService.UpdatVerificationProfileAsync(Guid.NewGuid().ToString(), this.profileOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
            Assert.Equal(typeof(VerifyProfile), resultAsync.GetType());
        }
        [Fact]
        public async Task Delete2FaProfiles()
        {
            var result = this._verificationService.DeleteVerificationProfile(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.DeleteVerificationProfileAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
            Assert.Equal(typeof(VerifyProfile), resultAsync.GetType());
        }
        [Fact]
        public async Task CreateVerification()
        {
            var result = this._verificationService.CreateVerification(this.verifyOptions);
            var resultAsync = await this._verificationService.CreateVerificationAsync(this.verifyOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(Verify), result.GetType());
            Assert.Equal(typeof(Verify), resultAsync.GetType());
        }
        [Fact]
        public async Task RetrieveVerification()
        {
            var result = this._verificationService.GetVerification(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.GetVerificationAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(Verify), result.GetType());
            Assert.Equal(typeof(Verify), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, does not allow listOptions")]
        public async Task RetrieveVerificationByPhone()
        {
            var result = this._verificationService.GetVerificationByPhone("+13100000010");
            var resultAsync = await this._verificationService.GetVerificationByPhoneAsync("+13100000010");
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<Verify>), result.GetType());
            Assert.Equal(typeof(TelnyxList<Verify>), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, not recognizing auth header")]
        public async Task Submit2FACode()
        {
            var result = this._verificationService.SubmitVerificationCode("+13100000010", this.codeOptions);
            var resultAsync = await this._verificationService.SubmiVerificationCodeAsync("+13100000010", this.codeOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyCode), result.GetType());
            Assert.Equal(typeof(VerifyCode), resultAsync.GetType());
        }
    }
}
