using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceResume
{
    public class ConferenceResumeService : ServiceNested<TelnyxApiResponse>
    {
       public override string BasePath => "/conferences/:id/actions/record_resume";

        public TelnyxApiResponse Create(string parentId, ConferenceResumeOption options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, ConferenceResumeOption options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
