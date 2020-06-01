using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enums;

namespace Telnyx.net.Entities.Connections.ConnectionsService
{
    public class Connection : TelnyxEntity
    {
        /// <summary>
        /// Defaults to true
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; } = true;
        /// <summary>
        /// `Latency` directs Telnyx to route media through the site with the lowest round-trip time to the user's connection. Telnyx calculates this time using ICMP ping messages. This can be disabled by specifying a site to handle all media
        /// </summary>
        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverrideEnum? AnchorsiteOverride { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }

        [JsonProperty("record_type")]
        public RecordTypeEnum? RecordType { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("webhook_api_version")]
        public WebhookApiVersionEnum? WebhookApiVersion { get; set; }

        [JsonProperty("webhook_event_failover_url")]
        public string WebhookEventFailoverUrl { get; set; }

        [JsonProperty("webhook_event_url")]
        public string WebhookEventUrl { get; set; }
    }
    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RecordTypeEnum
    {
        [EnumMember(Value = "ip_connection")]
        IPConnection = 0
    }
  
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AnchorsiteOverrideEnum
    {

        [EnumMember(Value = "Latency")]
        Latency = 0,
        [EnumMember(Value = "Chicago, IL")]
        ChicagoIL = 1,
        [EnumMember(Value = "Ashburn, VA")]
        AshburnVA = 2,
        [EnumMember(Value = "San Jose, CA")]
        SanJoseCA = 3,
        [EnumMember(Value = "Sydney, Australia")]
        SydneyAUS = 3,
        [EnumMember(Value = "Amsterdam, Netherlands")]
        AmsterdamNL = 5,
        [EnumMember(Value = "London, UK")]
        LondonUK = 6,
        [EnumMember(Value = "Toronto, Canada")]
        TorontoCA = 7,
        [EnumMember(Value = "Vancouver, Canada")]
        VancouverCA = 8,
        [EnumMember(Value = "Frankfurt, Germany")]
        FranfurtDE = 9,
    }

}
