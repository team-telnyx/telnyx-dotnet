namespace Telnyx.net.Entities.BillingReports
{
    using System;
    using Newtonsoft.Json;

    public class LedgerBillingGroupReport : TelnyxEntity
    {
        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Uniquely identifies the organization that owns the resource.
        /// </summary>
        [JsonProperty("organization_id")]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Status of the ledger billing group report.
        /// Possible values: [pending, complete, failed, deleted]
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// External URL of the ledger billing group report, if the status is complete.
        /// Nullable.
        /// </summary>
        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

}
