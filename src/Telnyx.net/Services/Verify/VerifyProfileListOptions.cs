namespace Telnyx.net.Services.VerifyAPI
{
    using Newtonsoft.Json;

    public class VerifyProfileListOptions
        : ListOptions
    {
        public VerifyProfileListOptions()
            : base(25, 1)
        {
        }

        /// <summary>
        /// Optional filter for profile names.
        /// </summary>
        [JsonProperty("filter[name]")]
        public string Filter { get; set; }
    }
}
