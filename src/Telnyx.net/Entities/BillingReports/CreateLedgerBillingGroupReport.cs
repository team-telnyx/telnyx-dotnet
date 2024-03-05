namespace Telnyx.net.Entities.BillingReports
{
    using Newtonsoft.Json;

    public class CreateLedgerBillingGroupReport : BaseOptions
    {
        /// <summary>
        /// Year of the ledger billing group report.
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; set; }

        /// <summary>
        /// Month of the ledger billing group report.
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; set; }
    }
}
