using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.VerifyAPI
{
    public class VerifyBase : TelnyxEntity
    {
        /// <summary>
        /// +E164 formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
