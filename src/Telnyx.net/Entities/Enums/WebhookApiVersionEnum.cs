using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enums
{

    /// <summary>
    /// Determines which webhook format will be used, API V1 or API V2.
    /// </summary>
    /// <value>Webhook format: API V1 or API V2.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WebhookApiVersionEnum
    {
        /// <summary>
        /// Enum ApiV1 for 1
        /// </summary>
        [EnumMember(Value = "1")]
        ApiV1 = 0,

        /// <summary>
        /// Enum ApiV2 for 2
        /// </summary>
        [EnumMember(Value = "2")]
        ApiV2 = 1
    }
}
