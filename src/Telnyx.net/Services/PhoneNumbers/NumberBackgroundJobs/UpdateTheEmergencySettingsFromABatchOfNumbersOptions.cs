using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    public class UpdateTheEmergencySettingsFromABatchOfNumbersOptions : BaseOptions
    {

        /// <summary>
        /// Identifies the address to be used with emergency services.
        /// </summary>
        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        /// <summary>
        /// Indicates whether to enable emergency services on this number.
        /// </summary>
        [JsonProperty("emergency_enabled")]
        public bool EmergencyEnabled { get; set; }
        /// <summary>
        /// The array of phone numbers in e164 format.
        /// </summary>
        [JsonProperty("phone_number")]
        public List<string> PhoneNumber { get; set; }
    }
}
