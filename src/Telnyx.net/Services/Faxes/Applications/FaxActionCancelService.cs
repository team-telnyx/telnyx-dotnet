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
        public override string BasePath => "/faxes/{PARENT_ID}/actions/cancel";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Ref: canonical action path parameter schema requires a UUID.
            if (!Guid.TryParse(parentId, out _))
            {
                throw new ArgumentException("The action parent ID must be a UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        public TelnyxApiResponse Create(string parentId, UpsertFaxActionCancel options, RequestOptions requestOptions)
        {
            return BodylessActionRequest.Send<TelnyxApiResponse>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions));
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertFaxActionCancel options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await BodylessActionRequest.SendAsync<TelnyxApiResponse>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions), parentToken, cancellationToken);
        }
    }
}
