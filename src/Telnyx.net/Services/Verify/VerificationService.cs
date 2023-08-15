namespace Telnyx.net.Services.VerifyAPI
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.VerifyAPI;

    public class VerificationService
    {
        private VerificationProfileService _profileService;
        private VerificationAuthenticationService _authenticationService;
        private VerificationByPhoneService _phoneService;
        private VerificationCodeService _codeService;

        public VerificationService()
        {
            this._profileService = new VerificationProfileService();
            this._authenticationService = new VerificationAuthenticationService();
            this._phoneService = new VerificationByPhoneService();
            this._codeService = new VerificationCodeService();
        }

        public VerificationService(string apiKey)
        {
            this._profileService = new VerificationProfileService(apiKey);
            this._authenticationService = new VerificationAuthenticationService(apiKey);
            this._phoneService = new VerificationByPhoneService(apiKey);
            this._codeService = new VerificationCodeService(apiKey);
        }

        public async Task<TelnyxList<VerifyProfile>> ListVerificationProfilesAsync(VerifyProfileListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.ListAsync(listOptions, requestOptions, ct);
        }

        public TelnyxList<VerifyProfile> ListVerificationProfiles(VerifyProfileListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this._profileService.List(listOptions, requestOptions);
        }

        public async Task<VerifyProfile> CreateVerificationProfileAsync(VerifyProfileOptions createOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this._profileService.CreateAsync(createOptions, reqOps, ct);
        }

        public VerifyProfile CreateVerificationProfile(VerifyProfileOptions createOptions, RequestOptions reqOps = null)
        {
            return this._profileService.Create(createOptions, reqOps);
        }

        public async Task<VerifyProfile> GetVerificationProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.RetrieveAsync(id, requestOptions, ct);
        }

        public VerifyProfile GetVerificationProfile(string id, RequestOptions requestOptions = null)
        {
            return this._profileService.Retrieve(id, requestOptions);
        }

        public async Task<VerifyProfile> UpdatVerificationProfileAsync(string id, VerifyProfileOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this._profileService.UpdateAsync(id, updateOptions, reqOps, ct);
        }

        public VerifyProfile UpdatVerificationProfile(string id, VerifyProfileOptions updateOptions, RequestOptions reqOps = null)
        {
            return this._profileService.Update(id, updateOptions, reqOps);
        }

        public async Task<VerifyProfile> DeleteVerificationProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.DeleteAsync(id, requestOptions, ct);
        }

        public VerifyProfile DeleteVerificationProfile(string id, RequestOptions requestOptions = null)
        {
            return this._profileService.Delete(id, requestOptions);
        }

        public async Task<Verify> CreateVerificationAsync(VerifyOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._authenticationService.CreateAsync(options, requestOptions, ct);
        }

        public Verify CreateVerification(VerifyOptions options, RequestOptions requestOptions = null)
        {
            return this._authenticationService.Create(options, requestOptions);
        }

        public async Task<Verify> GetVerificationAsync(string verificationId, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._authenticationService.GetAsync(verificationId, requestOptions, ct);
        }

        public Verify GetVerification(string verificationId, RequestOptions requestOptions = null)
        {
            return this._authenticationService.Get(verificationId, requestOptions);
        }

        public async Task<TelnyxList<Verify>> GetVerificationByPhoneAsync(string phone, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            if (listOptions == null)
                listOptions = new ListOptions(1, 25);
            return await this._phoneService.GetAsync(phone, listOptions, requestOptions, ct);
        }

        public TelnyxList<Verify> GetVerificationByPhone(string phone, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            if (listOptions == null)
                listOptions = new ListOptions(1, 25);

            return this._phoneService.Get(phone, listOptions, requestOptions);
        }

        public async Task<VerifyCode> SubmiVerificationCodeAsync(string phone, VerifyCodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._codeService.PostAsync(phone, options, requestOptions, ct);
        }

        public VerifyCode SubmitVerificationCode(string phone, VerifyCodeOptions options, RequestOptions requestOptions = null)
        {
            return this._codeService.Post(phone, options, requestOptions);
        }
    }
}
