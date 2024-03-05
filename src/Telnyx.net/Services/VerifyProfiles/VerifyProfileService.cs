using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VerifyProfiles;

namespace Telnyx.net.Services.VerifyProfiles
{
    public class VerifyProfileService : Service<VerifyProfile>
    {
        public override string BasePath => "/verify_profiles";

        public async Task<TelnyxList<VerifyProfile>> ListVerifyProfileAsync(VerifyProfileOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<VerifyProfile> ListVerifyProfile(VerifyProfileOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<VerifyProfile> GetVerifyProfileAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public VerifyProfile GetVerifyProfile(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public VerifyProfile DeleteVerifyProfile(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<VerifyProfile> DeleteVerifyProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<VerifyProfile> UpdateVerifyProfileAsync(string id, UpsertVerifyProfile options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public VerifyProfile UpdateVerifyProfile(string id, UpsertVerifyProfile options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }

        public async Task<VerifyProfile> CreateVerifyProfileAsync(UpsertVerifyProfile options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public VerifyProfile CreateVerifyProfile(UpsertVerifyProfile options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
