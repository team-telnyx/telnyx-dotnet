namespace Telnyx.net.Entities.AuthenticationProviders
{
    using Newtonsoft.Json;

    public class NameObject
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("formatted_name")]
        public string FormattedName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }
}
