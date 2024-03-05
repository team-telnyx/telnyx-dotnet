using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Messaging.Messaging_Profiles;

namespace Telnyx.net.Services.Messaging.Messaging_Profiles
{
    public class MessagingProfileAutoResponseConfigService : ServiceNested<MessagingProfileAutoResponseConfig>
    {
        public override string BasePath => "/messaging_profiles/:profile_id/autoresp_configs";

        public TelnyxList<MessagingProfileAutoResponseConfig> List(string id, MessagingProfileAutoResponseConfigOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingProfileAutoResponseConfig>> ListAsync(string id, MessagingProfileAutoResponseConfigOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
