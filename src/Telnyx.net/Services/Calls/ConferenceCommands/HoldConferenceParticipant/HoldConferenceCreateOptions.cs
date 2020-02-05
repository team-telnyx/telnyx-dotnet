namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Hold conference create options
    /// </summary>
    public class HoldConferenceCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier and token for controlling the call
        /// </summary>
        [JsonProperty("call_control_ids")]
        public List<string> CallControlIds { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }
    }
}