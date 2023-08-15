namespace Telnyx.net.Services.DetailRecords
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.DetailRecords;

    public class DetailRecordOptions : ListOptions
    {
        /// <summary>
        /// Filter by the given record type.
        /// Enum: "amd" "conference" "conference-participant" "media_storage" "messaging" "verify" "whatsapp" "whatsapp-conversation" "wireless"
        /// Examples:
        /// Searches for messaging detail records: filter[record_type]=messaging
        /// Searches for verify detail records: filter[record_type]=verify.
        /// </summary>
        [JsonProperty("filter[record_type]")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Filter by the given user-friendly date range.
        /// Enum: "yesterday" "today" "tomorrow" "last_week" "this_week" "next_week" "last_month" "this_month" "next_month"
        /// Examples:
        /// Filter detail records for yesterday: filter[date_range]=yesterday
        /// Filter detail records for the last 30 days: filter[date_range]=last_30_days.
        /// </summary>
        [JsonProperty("filter[date_range]")]
        public DateRange? DateRange { get; set; }

        /// <summary>
        /// Specifies the sort order for results.
        /// Examples:
        /// Sorts search results using the `created_at` date-time in descending order: sort=-created_at
        /// Sorts search results using the `created_at` date-time in ascending order: sort=created_at.
        /// </summary>
        [JsonProperty("sort")]
        public IEnumerable<string> Sort { get; set; }
    }
}
