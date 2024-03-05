using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Requirements;

namespace Telnyx.net.Services.Requirements
{
    public class RequirementTypesService : Service<RequirementType>
    {
        public override string BasePath => "/requirement_types";

        public async Task<TelnyxList<RequirementType>> ListRequirementTypeAsync(RequirementTypeOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<RequirementType> ListRequirementType(RequirementTypeOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<RequirementType> GetRequirementTypeAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public RequirementType GetRequirementType(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
