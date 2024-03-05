using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.ChannelZone;

namespace Telnyx.net.Services.ChannelZones
{
    public class ChannelZonePhoneNumberService : ServiceNested<ChannelZonePhoneNumber>
    {

        public override string BasePath => "/phone_numbers/channel_zones/:channel_zone_id/channel_zone_phone_numbers";

        public TelnyxList<ChannelZonePhoneNumber> List(string id, ChannelZonePhoneNumberOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<ChannelZonePhoneNumber>> ListAsync(string id, ChannelZonePhoneNumberOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
