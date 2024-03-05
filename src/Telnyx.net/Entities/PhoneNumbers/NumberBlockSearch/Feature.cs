namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Feature.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

