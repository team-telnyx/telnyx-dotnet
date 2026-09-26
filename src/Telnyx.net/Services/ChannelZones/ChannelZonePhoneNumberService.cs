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

        public override string BasePath => "/channel_zones/{PARENT_ID}/channel_zone_phone_numbers";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Archived GcbChannelZoneId is a string, not a UUID. Keep it within one path segment.
            if (string.IsNullOrWhiteSpace(parentId) || parentId == "." || parentId == "..")
            {
                throw new ArgumentException("The channel zone ID must be a nonempty path segment.", nameof(parentId));
            }

            return base.ClassUrl(Uri.EscapeDataString(parentId), baseUrl);
        }

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
