using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Calls.CallControl.StreamingStop;

namespace Telnyx.net.Services.Calls.CallControl.StreamingStop
{
    
    public class StreamingStopService : ServiceNested<TelnyxApiResponse>
    {
        public override string BasePath => "/calls/:call_control_id/actions/streaming_stop";

        public TelnyxApiResponse Create(string parentId, UpsertStreamingStop options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertStreamingStop options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
