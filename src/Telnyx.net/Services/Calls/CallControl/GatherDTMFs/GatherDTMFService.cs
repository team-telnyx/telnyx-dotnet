using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Calls.CallControl.GatherDTMFs;

namespace Telnyx.net.Services.Calls.CallControl.GatherDTMFs
{
    
    public class GatherDTMFService : ServiceNested<GatherDTMF>
    {
        public override string BasePath => "/calls/:call_control_id/actions/gather";

        public GatherDTMF Create(string parentId, UpsertGatherDTMF options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<GatherDTMF> CreateAsync(string parentId, UpsertGatherDTMF options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
