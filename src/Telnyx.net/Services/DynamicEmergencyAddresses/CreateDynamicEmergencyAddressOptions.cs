namespace Telnyx.net.Services.DynamicEmergencyAddresses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.DynamicEmergencyAddresses;
    using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

    public class CreateDynamicEmergencyAddressOptions : BaseOptions
    {
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }

        [JsonProperty("country_coude")]
        public string CountryCoude { get; set; }

        [JsonProperty("extended_address")]
        public string ExtendedAddress { get; set; }

        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        [JsonProperty("house_suffix")]
        public string HouseSuffix { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        [JsonProperty("street_post_directional")]
        public string StreetPostDirectional { get; set; }

        [JsonProperty("street_pre_directional")]
        public string StreetPreDirectional { get; set; }

        [JsonProperty("street_suffix")]
        public string StreetSuffix { get; set; }
    }
}
