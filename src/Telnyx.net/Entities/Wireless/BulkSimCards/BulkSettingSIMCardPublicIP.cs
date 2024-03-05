using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.BulkSettingSIMCardPublicIPs
{
    public class BulkSettingSIMCardPublicIP : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        [JsonProperty("settings")]
        public BulkActionSettings Settings { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
    public class BulkActionSettings
    {
        // Define the properties based on the actual structure of your JSON payload.
        // For example:
        [JsonProperty("public_ips")]
        public string[] PublicIps { get; set; }
    }
}
