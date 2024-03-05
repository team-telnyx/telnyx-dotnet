using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.EmbeddingBuckets
{
    public class EmbeddingBucket : TelnyxEntity
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("last_embedded_at")]
        public DateTime LastEmbeddedAt { get; set; }

        [JsonProperty("error_reason")]
        public string ErrorReason { get; set; }
    }
}
