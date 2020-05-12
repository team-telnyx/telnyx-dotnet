using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    public class VoiceSettingsListOptions : ListOptions
    {
        /// <summary>
        /// Filter contains connection name. Requires at least three characters
        /// </summary>
        [JsonProperty("filter[connection_name][contains]")]
        public string ConnectionNameContains { get; set; }
        /// <summary>
        ///Filter by usage_payment_method.
        /// </summary>
        [JsonProperty("filter[usage_payment_method]")]
        public PaymentMethod? UsagePaymentMethod { get; set; }
        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order
        /// </summary>
        [JsonProperty("sort")]
        public Sort? Sort { get; set; }
        /// <summary>
        /// Filter by phone number. Requires at least three digits. 
        /// Non-numerical characters will result in no values being returned.
        /// </summary>
        /// 
        [JsonProperty("filter[phone_number]")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The size of the page
        /// </summary>
        /// 
        [JsonProperty("page[size]")]
        public int? Size { get; set; }
        /// <summary>
        /// The page number to load
        /// </summary>
        [JsonProperty("page[number]")]
        public int? Page { get; set; }
    }
}
