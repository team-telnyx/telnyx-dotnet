using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Reports.ReportBatchMdrReports
{
    public class ReportBatchMdrReport : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("directions")]
        public string[] Directions { get; set; }

        [JsonProperty("record_types")]
        public string[] RecordTypes { get; set; }

        [JsonProperty("connections")]
        public long[] Connections { get; set; }

        [JsonProperty("report_name")]
        public string ReportName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }

        [JsonProperty("filters")]
        public Filter[] Filters { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("profiles")]
        public string Profiles { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
    public class Filter
    {
        [JsonProperty("filter_type")]
        public string FilterType { get; set; }

        [JsonProperty("cli")]
        public string Cli { get; set; }

        [JsonProperty("cli_filter")]
        public string CliFilter { get; set; }

        [JsonProperty("cld")]
        public string Cld { get; set; }

        [JsonProperty("cld_filter")]
        public string CldFilter { get; set; }

        [JsonProperty("tags_list")]
        public string TagsList { get; set; }

        [JsonProperty("billing_group")]
        public string BillingGroup { get; set; }
    }
}
