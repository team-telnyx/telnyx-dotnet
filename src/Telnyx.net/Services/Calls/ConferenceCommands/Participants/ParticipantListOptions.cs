namespace Telnyx.net.Services.Calls.ConferenceCommands.Participants
{
    using Newtonsoft.Json;

    public class ParticipantListOptions : ListOptions
    {
        /// <summary>
        /// Uniquely identifies the conference by id.
        /// </summary>
        [JsonProperty("conference_id")]
        public string ConferenceId { get; set; }

        /// <summary>
        /// If present, participants will be filtered to those who are/are not muted.
        /// </summary>
        [JsonProperty("filter[muted]")]
        public bool Muted { get; set; }

        /// <summary>
        /// If present, participants will be filtered to those who are/are not put on hold.
        /// </summary>
        [JsonProperty("filter[on_hold]")]
        public bool OnHold { get; set; }

        /// <summary>
        /// If present, participants will be filtered to those who are whispering or are not.
        /// </summary>
        [JsonProperty("filter[whisper]")]
        public bool Whisper { get; set; }
    }
}
