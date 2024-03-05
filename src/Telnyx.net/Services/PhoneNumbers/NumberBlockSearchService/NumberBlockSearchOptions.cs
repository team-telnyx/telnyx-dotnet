using Newtonsoft.Json;

namespace Telnyx
{
    /// <summary>
    /// Options for searching numbers with various filters.
    /// </summary>
    public class NumberBlockSearchOptions : BaseOptions
    {
        [JsonProperty("filter[phone_number][starts_with]")]
        public string StartsWith { get; set; }

        [JsonProperty("filter[phone_number][ends_with]")]
        public string EndsWith { get; set; }

        [JsonProperty("filter[phone_number][contains]")]
        public string Contains { get; set; }

        [JsonProperty("filter[locality]")]
        public string Locality { get; set; }

        [JsonProperty("filter[administrative_area]")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("filter[country_code]")]
        public string CountryCode { get; set; }

        [JsonProperty("filter[national_destination_code]")]
        public string NationalDestinationCode { get; set; }

        [JsonProperty("filter[rate_center]")]
        public string RateCenter { get; set; }

        [JsonProperty("filter[number_type]")]
        public string NumberType { get; set; }

        [JsonProperty("filter[features][]")]
        public string[] Features { get; set; }

        [JsonProperty("filter[minimum_block_size]")]
        public int? MinimumBlockSize { get; set; }

        [JsonProperty("filter[limit]")]
        public int? Limit { get; set; }
    }
}
