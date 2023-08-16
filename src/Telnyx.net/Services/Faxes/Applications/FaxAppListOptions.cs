namespace Telnyx.net.Services.Faxes.Applications
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Faxes.Applications.Options;

    public class FaxAppListOptions : ListOptions
    {
        public FaxAppListOptions()
            : base(1, 20)
        {
        }

        /// <summary>
        /// If present, applications with application_name containing the given value will be returned. Matching is not case-sensitive. Requires at least three characters.
        /// <para>Example: "fax-app".</para>
        /// </summary>
        [JsonProperty("filter[application_name][contains]")]
        public string ApplicationNameContains { get; set; } = null;

        /// <summary>
        /// Identifies the associated outbound voice profile.
        /// <para>Example: "1293384261075731499".</para>
        /// </summary>
        [JsonProperty("filter[outbound_voice_profile_id]")]
        public string OutboundVoiceProfileId { get; set; }

        /// <summary>
        /// Specifies the sort order for results. By default sorting direction is ascending.
        /// <para>If not given, results are sorted by created_at in descending order.</para>
        /// </summary>
        [JsonProperty("sort")]
        public SortOptions Sort { get; set; } = SortOptions.CreatedAtDESC;
    }
}
