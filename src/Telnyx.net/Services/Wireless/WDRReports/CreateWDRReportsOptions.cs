namespace Telnyx.net.Services.Wireless.WDRReports
{
    using Newtonsoft.Json;

    public class CreateWDRReportsOptions : BaseOptions
    {
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
    }
}
