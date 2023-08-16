namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// NumberSearchListOptions.
    /// </summary>
    public class NumberSearchOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets Filter numbers starting with a pattern.
        /// </summary>
        [JsonProperty("filter[phone_number][starts_with]")]
        public string StartsWith { get; set; }

        /// <summary>
        /// Gets or sets Filter numbers ending with a pattern.
        /// </summary>
        [JsonProperty("filter[phone_number][ends_with]")]
        public string EndsWith { get; set; }

        /// <summary>
        /// Gets or sets Filter numbers containing a pattern.
        /// </summary>
        [JsonProperty("filter[phone_number][contains]")]
        public string Contains { get; set; }

        /// <summary>
        /// Gets or sets Filter phone numbers by city.
        /// </summary>
        [JsonProperty("filter[locality]")]
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets Filter phone numbers by US state/CA province.
        /// </summary>
        [JsonProperty("filter[administrative_area]")]
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// Gets or sets Filter phone numbers by ISO 2 country code.
        /// </summary>
        [JsonProperty("filter[country_code]")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets Filter by the national destination code of the number. This filter is only applicable to North American numbers.
        /// </summary>
        [JsonProperty("filter[national_destination_code]")]
        public string NationalDestinationCode { get; set; }

        /// <summary>
        /// Gets or sets Filter phone numbers by NANP rate center. This filter is only applicable to North American numbers.
        /// </summary>
        [JsonProperty("filter[rate_center]")]
        public string RateCenter { get; set; }

        /// <summary>
        /// Gets or sets Filter phone numbers by number type.
        /// </summary>
        [JsonProperty("filter[number_type]")]
        public string NumberType { get; set; }

        /// <summary>
        /// Gets or sets Filter if the phone number should be used for voice, fax, sms. For right now.
        /// </summary>
        [JsonProperty("filter[features][]")]
        public List<string> Features { get; set; }

        /// <summary>
        /// Gets or sets Filter to determine if best effort results should be included.
        /// </summary>
        [JsonProperty("filter[best_effort]")]
        public bool? BestEffort { get; set; }

        /// <summary>
        /// Gets or sets Filter to exclude phone numbers that need additional time after to purchase to receive phone calls.
        /// </summary>
        [JsonProperty("filter[quickship]")]
        public bool? Quickship { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Filter to exclude phone numbers that cannot be reserved before purchase.
        /// </summary>
        [JsonProperty("filter[reservable]")]
        public bool? Reservable { get; set; }

        /// <summary>
        /// Gets or sets Filter to determine if the phone number has regulatory requirements.
        /// </summary>
        [JsonProperty("filter[exclude_regulatory_requirements]")]
        public bool? ExcludeRegulatoryRequirements { get; set; }

        /// <summary>
        /// Gets or sets Filter to limit the amount of results to be returned.
        /// </summary>
        [JsonProperty("filter[limit]")]
        public long? Limit { get; set; }
    }
}