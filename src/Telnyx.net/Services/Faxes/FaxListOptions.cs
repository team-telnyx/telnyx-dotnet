namespace Telnyx.net.Services.Faxes
{
    using Newtonsoft.Json;

    public class FaxListOptions : ListOptions
    {
        /// <summary>
        /// ISO 8601 date time for filtering faxes created after or on that date.
        /// <para>Example: "2020-02-02T22:25:27.521992Z".</para>
        /// </summary>
        [JsonProperty("filter[created_at][gte]")]
        public string CreatedAtDateGte { get; set; }

        /// <summary>
        /// ISO 8601 date time for filtering faxes created after that date.
        /// <para>Example: "2020-02-02T22:25:27.521992Z".</para>
        /// </summary>
        [JsonProperty("filter[created_at][gt]")]
        public string CreatedAtDateGreaterThan { get; set; }

        /// <summary>
        /// ISO 8601 formatted date time for filtering faxes created on or before that date.
        /// <para>Example: "2020-02-02T22:25:27.521992Z".</para>
        /// </summary>
        [JsonProperty("filter[created_at][lte]")]
        public string CreatedAtDateLte { get; set; }

        /// <summary>
        /// ISO 8601 formatted date time for filtering faxes created before that date.
        /// <para>Example: "2020-02-02T22:25:27.521992Z".</para>
        /// </summary>
        [JsonProperty("filter[created_at][lt]")]
        public string CreatedAtDateLessThan { get; set; }

        /// <summary>
        /// The direction, inbound or outbound, for filtering faxes sent from this account.
        /// <para>Example: "inbound".</para>
        /// </summary>
        [JsonProperty("filter[direction][eq]")]
        public string DirectionEquals { get; set; }

        /// <summary>
        /// The phone number, in E.164 format for filtering faxes sent from this number.
        /// <para>Example: "+13127367276".</para>
        /// </summary>
        [JsonProperty("filter[from][eq]")]
        public string FromEquals { get; set; }
    }
}
