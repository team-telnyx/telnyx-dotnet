using Newtonsoft.Json;
using System;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Porting.Orders;

namespace Telnyx.net.Entities.Porting.PhoneNumbers
{
    public class PortingPhoneNumber
    {
        /// <summary>
        /// Activation status of ported phone number.
        /// </summary>
        [JsonProperty("activation_status")]
        public ActivationStatus ActivationStatus { get; set; }

        /// <summary>
        /// E164 formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Specifies whether Telnyx is able to confirm portability this number in the United States & Canada. International phone numbers are provisional by default.
        /// <para>Options: ["pending","confirmed","provisional"]</para>
        /// </summary>
        [JsonProperty("portability_status")]
        public string PortabilityStatus { get; set; }

        /// <summary>
        /// Identifies the associated port request.
        /// </summary>
        [JsonProperty("porting_order_id")]
        public Guid PortingOrderId { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }
    }
}
