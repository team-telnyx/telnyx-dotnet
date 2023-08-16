namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs;

    public class NumberBackgroundJobListOptions : ListOptions
    {
        /// <summary>
        /// Filter the phone number jobs by type.
        /// </summary>
        [JsonProperty("type")]
        public PhoneNumberJobType Type { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order.
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }
    }
}
