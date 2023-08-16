namespace Telnyx.net.Entities.VerifyAPI
{
    using Newtonsoft.Json;

    public class VerifyBase : TelnyxEntity
    {
        /// <summary>
        /// +E164 formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
