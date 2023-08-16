namespace Telnyx.net.Services.Calls.ConferenceCommands.LeaveConference
{
    using Newtonsoft.Json;
    using static Telnyx.CreateConferenceOptions;

    public class LeaveConferenceOptions : BaseOptions
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
        /// Whether a beep sound should be played when the participant leaves the conference. Can be used to override the conference-level setting.
        /// Enum: "always" "never" "on_enter" "on_exit".
        /// </summary>
        [JsonProperty("beep_enabled")]
        public BeepEnum BeepEnabled { get; set; }
    }
}
