using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs
{
    public class ReportCdrUsageReportSync : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("connections")]
        public long[] Connections { get; set; }

        [JsonProperty("empty")]
        public bool Empty { get; set; }

        [JsonProperty("aggregation_type")]
        public string AggregationType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; } // You may replace 'object' with a more specific type based on the actual structure

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("product_breakdown")]
        public string ProductBreakdown { get; set; }
    }
}
