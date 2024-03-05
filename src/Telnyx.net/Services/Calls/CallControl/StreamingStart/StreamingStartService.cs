using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Calls.CallControl.StreamingStart;

namespace Telnyx.net.Services.Calls.CallControl.StreamingStart
{
    
    public class StreamingStartService : ServiceNested<TelnyxApiResponse>
    {
        public override string BasePath => "/calls/:call_control_id/actions/streaming_start";

        public TelnyxApiResponse Create(string parentId, UpsertStreamingStart options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertStreamingStart options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
