using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Verify
{
    public class TwoFAOptions : BaseOptions
    {
        /// <summary>
        /// The verification request type.
        /// <para>Example: "sms"</para>
        /// <para>Options: ["sms"]</para>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The identifier of the associated 2FA profile.
        /// </summary>
        [JsonProperty("twofa_profile_id")]
        public Guid TwofaProfileId { get; set; }
        /// <summary>
        /// +E164 formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// This is the number of seconds before the code of the request is expired. Once this request has expired, the code will no longer verify the user. 
        /// <para>Note: this will override the `default_timeout_secs` on the 2FA profile.</para>
        /// <para>Example: 300</para>
        /// </summary>
        [JsonProperty("timeout_secs")]
        public long TimeoutSecs { get; set; }
    }
}
