using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Reports.ReportMdrUsageReports
{
    public class ReportMdrUsageReport : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("connections")]
        public long[] Connections { get; set; }

        [JsonProperty("aggregation_type")]
        public string AggregationType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }

        [JsonProperty("result")]
        public ResultItem[] Result { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("profiles")]
        public string Profiles { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
    public class ResultItem
    {
        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("received")]
        public string Received { get; set; }

        [JsonProperty("delivered")]
        public string Delivered { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("parts")]
        public string Parts { get; set; }

        [JsonProperty("sent")]
        public string Sent { get; set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("message_type")]
        public string MessageType { get; set; }

        [JsonProperty("tn_type")]
        public string TnType { get; set; }

        [JsonProperty("carrier_passthrough_fee")]
        public string CarrierPassthroughFee { get; set; }
    }
}
