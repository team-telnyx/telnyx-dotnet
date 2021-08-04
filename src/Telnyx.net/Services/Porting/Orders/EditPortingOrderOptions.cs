using Newtonsoft.Json;
using Telnyx.net.Entities.Porting.Orders;

namespace Telnyx.net.Services.Porting.Orders
{
    public class EditPortingOrderOptions : BaseOptions
    {
        [JsonProperty("activation_settings")]
        public ActivationSettings ActivationSettings { get; set; }

        [JsonProperty("documents")]
        public Documents Documents { get; set; }

        [JsonProperty("end_user")]
        public EndUser EndUser { get; set; }

        [JsonProperty("misc")]
        public Misc Misc { get; set; }

        [JsonProperty("phone_number_configuration")]
        public PhoneNumberConfiguration PhoneNumberConfiguration { get; set; }

        [JsonProperty("user_feedback")]
        public UserFeedback UserFeedback { get; set; }

        /// <summary>
        /// URL to webhook for updates.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }
}
