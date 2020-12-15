using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VerifyAPI;

namespace Telnyx.net.Services.VerifyAPI
{
    internal class VerificationProfileService : Service<VerifyProfile>
    {
        internal VerificationProfileService()
       : base(null)
        {
        }
        internal VerificationProfileService(string apiKey)
            : base(apiKey)
        {
        }
        public override string BasePath => "/verify_profiles";

        public async Task<TelnyxList<VerifyProfile>> ListAsync(VerifyProfileListOptions listOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOps, ct);
        }
        public TelnyxList<VerifyProfile> List(VerifyProfileListOptions listOptions, RequestOptions reqOps = null)
        {
            return this.ListEntities(listOptions, reqOps);
        }
        public async Task<VerifyProfile> CreateAsync(VerifyProfileOptions createOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOps, ct);
        }
        public VerifyProfile Create(VerifyProfileOptions createOptions, RequestOptions reqOps = null)
        {
            return this.CreateEntity(createOptions, reqOps);
        }
        public async Task<VerifyProfile> RetrieveAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, ct);
        }
        public VerifyProfile Retrieve(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }
        public async Task<VerifyProfile> UpdateAsync(string id, VerifyProfileOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.UpgradeEntityAsync(id, updateOptions, reqOps, ct);
        }
        public VerifyProfile Update(string id, VerifyProfileOptions updateOptions, RequestOptions reqOps = null)
        {
            return this.UpgradeEntity(id, updateOptions, reqOps);
        }
        public async Task<VerifyProfile> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct);
        }
        public VerifyProfile Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

    }
}
