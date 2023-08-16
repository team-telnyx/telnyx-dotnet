namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using System;
    using Newtonsoft.Json;

    public class MessagingSettingUpdateOptions : BaseOptions
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }
    }
}
