using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageMedia
    {
        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets ContentType.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("hash_sha256")]
        public string Sha256 { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

    }
}
