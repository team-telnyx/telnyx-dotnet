namespace Telnyx.net.Entities.PhoneNumbers.Campaigns
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PhoneNumberCampaign : TelnyxEntity
    {
        /// <summary>
        /// Array of objects (Records).
        /// </summary>
        [JsonProperty("records")]
        public List<Records> Records { get; set; }
    }
}
