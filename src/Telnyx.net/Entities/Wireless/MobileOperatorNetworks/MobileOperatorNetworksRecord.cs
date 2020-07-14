namespace Telnyx.net.Entities.Wireless.MobileOperatorNetworks
{
    using Newtonsoft.Json;

    public class MobileOperatorNetworksRecord : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; private set; }

        /// <summary>
        /// The operator network name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// TADIG stands for Transferred Account Data Interchange Group. The TADIG code is a unique identifier for network operators in GSM mobile networks.
        /// </summary>
        [JsonProperty("tadig")]
        public string Tadig { get; set; }

        /// <summary>
        /// The mobile operator two-character (ISO 3166-1 alpha-2) origin country code.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// MCC stands for Mobile Country Code. It&#x27;s a three decimal digit that identifies a country.&lt;br/&gt;&lt;br/&gt; This code is commonly seen joined with a Mobile Network Code (MNC) in a tuple that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
        /// </summary>
        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        /// <summary>
        /// MNC stands for Mobile Network Code. It&#x27;s a two to three decimal digits that identify a network.&lt;br/&gt;&lt;br/&gt;  This code is commonly seen joined with a Mobile Country Code (MCC) in a tuple that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
        /// </summary>
        [JsonProperty("mnc")]
        public string Mnc { get; set; }
    }
}
