using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Connections;

namespace Telnyx.net.Services.Connections
{
    public class ConnectionListOptions : ListOptions
    {
        /// <summary>
        /// If present, connections with connection_name containing the given value will be returned. Matching is not case-sensitive. Requires at least three characters
        /// </summary>
        [JsonProperty("filter[connection_name][contains]")]
        public string ConnectionNameContains { get; set; } = null;
        /// <summary>
        /// Identifies the associated outbound voice profile.
        /// </summary>
        [JsonProperty("filter[outbound_voice_profile_id]")]
        public string OutBoundVoiceProfileId { get; set; }
        /// <summary>
        /// Specifies the sort order for results. By default sorting direction is ascending. To have the results sorterd in descending order use values with DESC in the name.
        /// </summary>
        [JsonProperty("sort")]
        public ConnectionSort Sort { get; set; } = ConnectionSort.CreatedAtDESC;
    }
    
}
