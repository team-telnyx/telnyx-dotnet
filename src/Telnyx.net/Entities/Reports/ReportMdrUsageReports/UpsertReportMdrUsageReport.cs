using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Reports.ReportMdrUsageReports
{
    public class UpsertReportMdrUsageReport : BaseOptions
    {
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("aggregation_type")]
        public string AggregationType { get; set; }

        [JsonProperty("profiles")]
        public string Profiles { get; set; }
    }
}
