using Newtonsoft.Json;
using System.Collections.Generic;

namespace Telnyx
{
    /// <summary>
    /// Represents the channel zone data.
    /// </summary>
    public class ChannelZones : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets the type of record.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets the list of countries in the billing channel zone.
        /// </summary>
        [JsonProperty("countries")]
        public List<string> Countries { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the channel zone.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the channel zone.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of channels.
        /// </summary>
        [JsonProperty("channels")]
        public long Channels { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the channel zone.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update date of the channel zone.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }

}
