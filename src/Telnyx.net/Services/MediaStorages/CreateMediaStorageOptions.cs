using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.MediaStorages
{
    public class CreateMediaStorageOptions : BaseOptions
    {
        /// <summary>
        /// The unique identifier of a file.
        /// </summary>
        [JsonProperty("media_name")]
        public string MediaName { get; set; }

        /// <summary>
        /// The URL where the media to be stored in Telnyx network is currently hosted.
        /// </summary>
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// The number of seconds after which the media resource will be deleted, defaults to 2 days.
        /// </summary>
        [JsonProperty("ttl_secs")]
        public int TtlSeconds { get; set; }
    }
}
