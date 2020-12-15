using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;

namespace Telnyx.net.Entities.VerifyAPI
{
    public class VerifyCode : VerifyBase
    {
        /// <summary>
        /// Identifies if the verification code has been accepted or rejected.
        /// <para>Options: ["accepted","rejected"]</para>
        /// </summary>
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }
    }
}
