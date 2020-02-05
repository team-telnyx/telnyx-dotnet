namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// MuteConferenceCreateOptions
    /// </summary>
    public class MuteConferenceCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier and token for controlling the call
        /// </summary>
        [JsonProperty("call_control_ids")]
        public List<string> CallControlIds { get; set; }
    }
}