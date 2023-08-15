namespace Telnyx.net.Services.Wireless.SimCards
{
    using Newtonsoft.Json;

    public class SimCardRegisterOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets sim_card_group_id.
        /// </summary>
        [JsonProperty("sim_card_group_id")]
        public string SimCardGroupId { get; set; }

        /// <summary>
        /// Gets or sets registration codes.
        /// </summary>
        [JsonProperty("registration_codes")]
        public string[] RegistrationCodes { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}