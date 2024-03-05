using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.WDRReports
{
    public class ReportWdr : TelnyxEntity
    {
        [JsonProperty("id")]
        public string WdrId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("cost")]
        public CostDetails Cost { get; set; }

        [JsonProperty("downlink_data")]
        public DataUsageDetails DownlinkData { get; set; }

        [JsonProperty("duration_seconds")]
        public int DurationSeconds { get; set; }

        [JsonProperty("imsi")]
        public string Imsi { get; set; }

        [JsonProperty("rate")]
        public RateDetails Rate { get; set; }

        [JsonProperty("sim_group_name")]
        public string SimGroupName { get; set; }

        [JsonProperty("sim_group_id")]
        public string SimGroupId { get; set; }

        [JsonProperty("sim_card_id")]
        public string SimCardId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("uplink_data")]
        public DataUsageDetails UplinkData { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
    public class CostDetails
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class DataUsageDetails
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class RateDetails
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
