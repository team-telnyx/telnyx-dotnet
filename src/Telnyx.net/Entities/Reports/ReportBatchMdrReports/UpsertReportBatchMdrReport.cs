using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Reports.ReportBatchMdrReports
{
    public class UpsertReportBatchMdrReport : BaseOptions
    {
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("directions")]
        public string[] Directions { get; set; }

        [JsonProperty("record_types")]
        public string[] RecordTypes { get; set; }

        [JsonProperty("connections")]
        public long[] Connections { get; set; }

        [JsonProperty("report_name")]
        public string ReportName { get; set; }

        [JsonProperty("include_message_body")]
        public bool IncludeMessageBody { get; set; }

        [JsonProperty("filters")]
        public Filter[] Filters { get; set; }

        [JsonProperty("profiles")]
        public string Profiles { get; set; }
    }

    public class Filters
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
