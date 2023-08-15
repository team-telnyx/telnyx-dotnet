namespace Telnyx.net.Services.Calls.ConferenceCommands.UpdateConference
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UpdateConferenceOptions : BaseOptions
    {

        /// <summary>
        /// Unique identifier and token for controlling the call.
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Use this field to avoid execution of duplicate commands. Telnyx will ignore subsequent commands with the same command_id as one that has already been executed.
        /// </summary>
        [JsonProperty("command_id")]
        public string CommandId { get; set; }

        /// <summary>
        /// Sets the participant as a supervisor for the conference. A conference can have multiple supervisors. "barge" means the supervisor
        /// enters the conference as a normal participant. This is the same as "none". "monitor" means the supervisor is muted but can hear
        /// all participants. "whisper" means that only the specified "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
        /// Enum: "barge" "monitor" "none" "whisper".
        /// </summary>
        [JsonProperty("supervisor_role")]
        public string SupervisorRole { get; set; }

        /// <summary>
        /// Array of unique call_control_ids the supervisor can whisper to. If none provided, the supervisor will join the conference as a monitoring participant only.
        /// </summary>
        [JsonProperty("whisper_call_control_ids")]
        public IEnumerable<string> WhisperCallControlIds { get; set; }
    }
}
