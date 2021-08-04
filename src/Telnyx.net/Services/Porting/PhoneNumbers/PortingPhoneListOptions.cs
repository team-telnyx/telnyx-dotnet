using Newtonsoft.Json;
using Telnyx.net.Entities.Enum.Porting.Orders;

namespace Telnyx.net.Services.Porting.PhoneNumbers
{
    public class PortingPhoneListOptions : ListOptions
    {
        public PortingPhoneListOptions()
            : base(1, 20)
        {
        }

        /// <summary>
        /// Filter results by porting order id
        /// </summary>
        [JsonProperty("filter[porting_order_id]")]
        public string PortingOrderId { get; set; }

        /// <summary>
        /// Filter results by phone number.
        /// </summary>
        [JsonProperty("filter[phone_number]")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Activation status.
        /// </summary>
        [JsonProperty("filter[activation_status]")]
        public ActivationStatus? ActivationStatus { get; set; }

        /// <summary>
        /// Specifies whether Telnyx is able to confirm portability this number in the United States & Canada. International phone numbers are provisional by default.
        /// <para>
        /// Example: "confirmed"
        /// </para>
        /// <para>Options: ["pending","confirmed","provisional"]
        /// </para>
        /// </summary>
        [JsonProperty("filter[portability_status]")]
        public string PortabilityStatus { get; set; }
    }
}
