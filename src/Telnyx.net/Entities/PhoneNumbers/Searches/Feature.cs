namespace Telnyx
{
    using Newtonsoft.Json;

    public class Feature
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}