using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;

namespace Telnyx.net.Entities.Verify
{
    public class TwoFACode : TwoFABase
    {
        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Identifies if the verification code has been accepted or rejected.
        /// <para>Options: ["accepted","rejected"]</para>
        /// </summary>
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }
    }
}
