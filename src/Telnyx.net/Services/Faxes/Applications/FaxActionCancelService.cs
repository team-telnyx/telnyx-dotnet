using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Faxes;

namespace Telnyx.net.Services.Faxes.Applications
{
    public class FaxActionCancelService : ServiceNested<TelnyxApiResponse>
    {
        public override string BasePath => "/faxes/:id/actions/cancel";

        public TelnyxApiResponse Create(string parentId, UpsertFaxActionCancel options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertFaxActionCancel options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
