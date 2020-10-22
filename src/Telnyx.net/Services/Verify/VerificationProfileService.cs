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
    internal class VerificationProfileService : Service<TwoFAProfile>
    {
        public override string BasePath => "/2fa_profiles";

        public async Task<TelnyxList<TwoFAProfile>> ListAsync(TwoFAProfileListOptions listOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOps, ct);
        }
        public TelnyxList<TwoFAProfile> List(TwoFAProfileListOptions listOptions, RequestOptions reqOps = null)
        {
            return this.ListEntities(listOptions, reqOps);
        }
        public async Task<TwoFAProfile> CreateAsync(TwoFaProfileOptions createOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOps, ct);
        }
        public TwoFAProfile Create(TwoFaProfileOptions createOptions, RequestOptions reqOps = null)
        {
            return this.CreateEntity(createOptions, reqOps);
        }
        public async Task<TwoFAProfile> RetrieveAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, ct);
        }
        public TwoFAProfile Retrieve(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }
        public async Task<TwoFAProfile> UpdateAsync(string id, TwoFaProfileOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, reqOps, ct);
        }
        public TwoFAProfile Update(string id, TwoFaProfileOptions updateOptions, RequestOptions reqOps = null)
        {
            return this.UpdateEntity(id, updateOptions, reqOps);
        }
        public async Task<TwoFAProfile> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct);
        }
        public TwoFAProfile Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

    }
}
