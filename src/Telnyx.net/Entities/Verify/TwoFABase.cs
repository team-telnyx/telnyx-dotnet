using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Verify
{
    public class TwoFABase : TelnyxEntity
    {
        /// <summary>
        /// +E164 formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
