namespace Telnyx.net.Entities.NumberLookup
{
    using Newtonsoft.Json;

    public class Portability
    {
        /// <summary>
        /// Local Routing Number, if assigned to the requested phone number.
        /// </summary>
        [JsonProperty("lrn")]
        public string Lrn { get; set; }

        /// <summary>
        /// Indicates whether or not the requested phone number has been ported.
        /// </summary>
        [JsonProperty("ported_status")]
        public string PortedStatus { get; set; }

        /// <summary>
        /// ISO-formatted date when the requested phone number has been ported.
        /// </summary>
        [JsonProperty("ported_date")]
        public string PortedDate { get; set; }

        /// <summary>
        /// Operating Company Name (OCN) as per the Local Exchange Routing Guide (LERG) database.
        /// </summary>
        [JsonProperty("ocn")]
        public string Ocn { get; set; }

        /// <summary>
        /// Type of number.
        /// </summary>
        [JsonProperty("line_type")]
        public string LineType { get; set; }

        /// <summary>
        /// SPID (Service Provider ID).
        /// </summary>
        [JsonProperty("spid")]
        public string Spid { get; set; }

        /// <summary>
        /// Service provider name.
        /// </summary>
        [JsonProperty("spid_carrier_name")]
        public string SpidCarrierName { get; set; }

        /// <summary>
        /// Service provider type.
        /// </summary>
        [JsonProperty("spid_carrier_type")]
        public string SpidCarrierType { get; set; }

        /// <summary>
        /// Alternative SPID (Service Provider ID). Often used when a carrier is using a number from another carrier.
        /// </summary>
        [JsonProperty("altspid")]
        public string Altspid { get; set; }

        /// <summary>
        /// Alternative service provider name.
        /// </summary>
        [JsonProperty("altspid_carrier_name")]
        public string AltspidCarrierName { get; set; }

        /// <summary>
        /// Alternative service provider type.
        /// </summary>
        [JsonProperty("altspid_carrier_type")]
        public string AltspidCarrierType { get; set; }

        /// <summary>
        /// City name extracted from the locality in the Local Exchange Routing Guide (LERG) database.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets State.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
