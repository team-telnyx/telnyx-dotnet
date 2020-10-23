using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Verify;
using Telnyx.net.Services.Verify;
using Xunit;

namespace TelnyxTests.Services.Verification
{
    public class VerificationTwoFaTest : BaseTelnyxTest
    {
        private readonly VerificationService _verificationService;
        private TwoFAProfileListOptions profileListOptions;
        private TwoFaProfileOptions profileOptions;
        private TwoFAOptions verifyOptions;
        private TwoFACodeOptions codeOptions;


        public VerificationTwoFaTest(MockHttpClientFixture mockHttpClientFixture) : base(mockHttpClientFixture)
        {
            _verificationService = new VerificationService("KEYSUPERSECRET");
            profileListOptions = new TwoFAProfileListOptions
            {
                Filter = "Test"
            };
            profileOptions = new TwoFaProfileOptions
            {
                DefaultTimeoutSecs = 300,
                MsgEnabled = true,
                MsgTemplate = "Hello this is a test {code}",
                Name = "Test Profile",
                RcsEnabled = false
            };
            verifyOptions = new TwoFAOptions
            {
                TimeoutSecs = 300,
                PhoneNumber = "+13100000010",
                TwofaProfileId = Guid.NewGuid(),
                Type = "sms",
            };
            codeOptions = new TwoFACodeOptions
            {
                Code = "2222"
            };
        }

        
        [Fact(Skip = "Mock not working, does not allow listOptions")]
        public async Task List2FAProfiles()
        {
            var result = this._verificationService.List2FAProfiles(this.profileListOptions);
            var resultAsync = await this._verificationService.List2FAProfilesAsync(this.profileListOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<TwoFAProfile>), result.GetType());
            Assert.Equal(typeof(TelnyxList<TwoFAProfile>), resultAsync.GetType());

        }

        [Fact]
        public async Task Create2FaProfiles()
        {
            var result = this._verificationService.Create2FAProfile(this.profileOptions);
            var resultAsync = await this._verificationService.Create2FAProfileAsync(this.profileOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFAProfile), result.GetType());
            Assert.Equal(typeof(TwoFAProfile), resultAsync.GetType());
        }

        [Fact]
        public async Task Retrieve2FaProfiles()
        {
            var result = this._verificationService.Get2FAProfile(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.Get2FAProfileAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFAProfile), result.GetType());
            Assert.Equal(typeof(TwoFAProfile), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, not recognizing PUT Url")]
        public async Task Update2FaProfiles()
        {
            var result = this._verificationService.Update2FAProfile(Guid.NewGuid().ToString(), this.profileOptions);
            var resultAsync = await this._verificationService.Update2FAProfileAsync(Guid.NewGuid().ToString(), this.profileOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFAProfile), result.GetType());
            Assert.Equal(typeof(TwoFAProfile), resultAsync.GetType());
        }
        [Fact]
        public async Task Delete2FaProfiles()
        {
            var result = this._verificationService.Delete2FAProfile(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.Delete2FAProfileAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFAProfile), result.GetType());
            Assert.Equal(typeof(TwoFAProfile), resultAsync.GetType());
        }
        [Fact]
        public async Task CreateVerification()
        {
            var result = this._verificationService.Create2FAVerification(this.verifyOptions);
            var resultAsync = await this._verificationService.Create2FAVerificationAsync(this.verifyOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFA), result.GetType());
            Assert.Equal(typeof(TwoFA), resultAsync.GetType());
        }
        [Fact]
        public async Task RetrieveVerification()
        {
            var result = this._verificationService.Get2FAVerification(Guid.NewGuid().ToString());
            var resultAsync = await this._verificationService.Get2FAVerificationAsync(Guid.NewGuid().ToString());
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFA), result.GetType());
            Assert.Equal(typeof(TwoFA), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, does not allow listOptions")]
        public async Task RetrieveVerificationByPhone()
        {
            var result = this._verificationService.GetVerificationByPhone("+13100000010");
            var resultAsync = await this._verificationService.GetVerificationByPhoneAsync("+13100000010");
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<TwoFA>), result.GetType());
            Assert.Equal(typeof(TelnyxList<TwoFA>), resultAsync.GetType());
        }
        [Fact(Skip = "Mock not working, not recognizing auth header")]
        public async Task Submit2FACode()
        {
            var result = this._verificationService.Submit2FACode("+13100000010", this.codeOptions);
            var resultAsync = await this._verificationService.Submit2FACodeAsync("+13100000010", this.codeOptions);
            Assert.NotNull(resultAsync);
            Assert.NotNull(result);
            Assert.Equal(typeof(TwoFACode), result.GetType());
            Assert.Equal(typeof(TwoFACode), resultAsync.GetType());
        }
    }
}
