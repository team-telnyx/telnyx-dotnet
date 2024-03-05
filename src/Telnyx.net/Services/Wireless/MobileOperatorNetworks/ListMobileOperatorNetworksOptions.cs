using Newtonsoft.Json;

namespace Telnyx.net.Services.Wireless.MobileOperatorNetworks
{
    public class ListMobileOperatorNetworksOptions : ListOptions
    {
        [JsonProperty("filter[name][starts_with]")]
        public string NameStartsWith { get; set; }

        [JsonProperty("filter[name][contains]")]
        public string NameContains { get; set; }

        [JsonProperty("filter[name][ends_with]")]
        public string NameEndsWith { get; set; }

        [JsonProperty("filter[country_code]")]
        public string CountryCode { get; set; }

        [JsonProperty("filter[mcc]")]
        public string Mcc { get; set; }

        [JsonProperty("filter[mnc]")]
        public string Mnc { get; set; }

        [JsonProperty("filter[tadig]")]
        public string Tadig { get; set; }

        [JsonProperty("filter[network_preferences_enabled]")]
        public bool? NetworkPreferencesEnabled { get; set; }
    }
}