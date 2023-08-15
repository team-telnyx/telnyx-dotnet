namespace Telnyx.net.Entities.DynamicEmergencyAddresses
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.DynamicEmergencyAddresses;

    public class DynamicEmergencyAddress : TelnyxEntity
    {
        /// <summary>
        /// The administrative area value.
        /// </summary>
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// The country code value.
        /// </summary>
        [JsonProperty("country_code")]
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// The ISO 8601 formatted date of when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The extended address value.
        /// </summary>
        [JsonProperty("extended_address")]
        public string ExtendedAddress { get; set; }

        /// <summary>
        /// The required house number value.
        /// </summary>
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// The house suffix value.
        /// </summary>
        [JsonProperty("house_suffix")]
        public string HouseSuffix { get; set; }

        /// <summary>
        /// The ID of the administrative area.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The required locality value.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// The required postal code value.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// The unique location reference string to be used in SIP INVITE from / p-asserted headers.
        /// </summary>
        [JsonProperty("sip_geolocation_id")]
        public string SipGeolocationId { get; set; }

        /// <summary>
        /// The status of dynamic emergency address.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The required street name value.
        /// </summary>
        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        /// <summary>
        /// The street post directional value.
        /// </summary>
        [JsonProperty("street_post_directional")]
        public string StreetPostDirectional { get; set; }

        /// <summary>
        /// The street pre directional value.
        /// </summary>
        [JsonProperty("street_pre_directional")]
        public string StreetPreDirectional { get; set; }

        /// <summary>
        /// The street suffix value.
        /// </summary>
        [JsonProperty("street_suffix")]
        public string StreetSuffix { get; set; }

        /// <summary>
        /// The ISO 8601 formatted date of when the resource was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
