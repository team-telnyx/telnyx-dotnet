namespace Telnyx.net.Entities.Wireless.WDRReports
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class WDRReportsRecord : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating the start time.
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating the end time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// Indicates the status of the report, which is updated asynchronously.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The URL where the report content, when generated, will be published to.
        /// </summary>
        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }
    }
}
