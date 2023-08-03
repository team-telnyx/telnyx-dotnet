namespace Telnyx.net.Entities.Wireless.SimCards
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Wireless.OTAUpdates;

    public class MobileOperatorNetworksPreferencesRecord : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or Sets MobileOperatorNetworksPreferences.
        /// </summary>
        [JsonProperty("mobile_operator_networks_preferences")]
        public IList<MobileOperatorNetworksPreferences> MobileOperatorNetworksPreferences { get; set; }

        /// <summary>
        /// Gets or sets OTA Updates.
        /// </summary>
        [JsonProperty("ota_updates")]
        public IList<OTAUpdatesRecord> OTAUpdate { get; set; }

        /// <summary>
        /// Gets ts RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; private set; }

        /// <summary>
        /// The indentification UUID of the related SIM card resource.
        /// </summary>
        [JsonProperty("sim_card_id")]
        public string Id { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }
    }
}
