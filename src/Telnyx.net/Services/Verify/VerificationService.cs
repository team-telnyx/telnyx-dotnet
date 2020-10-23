using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Verify;

namespace Telnyx.net.Services.Verify
{
    public class VerificationService
    {
        private VerificationProfileService _profileService;
        private VerificationAuthenticationService _authenticationService;
        private VerificationAuthenticationPhoneService _phoneService;
        private VerificationAuthenticationCodeService _codeService;

        public VerificationService()
        {
            _profileService = new VerificationProfileService();
            _authenticationService = new VerificationAuthenticationService();
            _phoneService = new VerificationAuthenticationPhoneService();
            _codeService = new VerificationAuthenticationCodeService();

        }
        public VerificationService(string apiKey)
        {
            _profileService = new VerificationProfileService(apiKey);
            _authenticationService = new VerificationAuthenticationService(apiKey);
            _phoneService = new VerificationAuthenticationPhoneService(apiKey);
            _codeService = new VerificationAuthenticationCodeService(apiKey);

        }

        public async Task<TelnyxList<TwoFAProfile>> List2FAProfilesAsync(TwoFAProfileListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.ListAsync(listOptions, requestOptions, ct);
        }
        public TelnyxList<TwoFAProfile> List2FAProfiles(TwoFAProfileListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this._profileService.List(listOptions, requestOptions);
        }
        public async Task<TwoFAProfile> Create2FAProfileAsync(TwoFaProfileOptions createOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this._profileService.CreateAsync(createOptions, reqOps, ct);
        }
        public TwoFAProfile Create2FAProfile(TwoFaProfileOptions createOptions, RequestOptions reqOps = null)
        {
            return this._profileService.Create(createOptions, reqOps);
        }
        public async Task<TwoFAProfile> Get2FAProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.RetrieveAsync(id, requestOptions, ct);
        }
        public TwoFAProfile Get2FAProfile(string id, RequestOptions requestOptions = null)
        {
            return this._profileService.Retrieve(id, requestOptions);
        }
        public async Task<TwoFAProfile> Update2FAProfileAsync(string id, TwoFaProfileOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this._profileService.UpdateAsync(id, updateOptions, reqOps, ct);
        }
        public TwoFAProfile Update2FAProfile(string id, TwoFaProfileOptions updateOptions, RequestOptions reqOps = null)
        {
            return this._profileService.Update(id, updateOptions, reqOps);
        }
        public async Task<TwoFAProfile> Delete2FAProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._profileService.DeleteAsync(id, requestOptions, ct);
        }
        public TwoFAProfile Delete2FAProfile(string id, RequestOptions requestOptions = null)
        {
            return this._profileService.Delete(id, requestOptions);
        }
        public async Task<TwoFA> Create2FAVerificationAsync(TwoFAOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._authenticationService.CreateAsync(options, requestOptions, ct);
        }
        public TwoFA Create2FAVerification(TwoFAOptions options, RequestOptions requestOptions = null)
        {
            return this._authenticationService.Create(options, requestOptions);
        }
        public async Task<TwoFA> Get2FAVerificationAsync(string verificationId, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._authenticationService.GetAsync(verificationId, requestOptions, ct);
        }
        public TwoFA Get2FAVerification(string verificationId, RequestOptions requestOptions = null)
        {
            return this._authenticationService.Get(verificationId, requestOptions);
        }
        public async Task<TelnyxList<TwoFA>> GetVerificationByPhoneAsync(string phone, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            if (listOptions == null)
                listOptions = new ListOptions(1, 25);
            return await this._phoneService.GetAsync(phone, listOptions, requestOptions, ct);
        }
        public TelnyxList<TwoFA> GetVerificationByPhone(string phone, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            if(listOptions == null)
                listOptions = new ListOptions(1, 25);

            return this._phoneService.Get(phone, listOptions, requestOptions);
        }
        public async Task<TwoFACode> Submit2FACodeAsync(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._codeService.PostAsync(phone, options, requestOptions, ct);
        }
        public TwoFACode Submit2FACode(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null)
        {
            return this._codeService.Post(phone, options, requestOptions);
        }
    }
}
