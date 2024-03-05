using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Telnyx
{
    /// <summary>
    /// SimCardSearch.
    /// </summary>
    public class BulkSimCardSearch : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the resource.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the record type.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets the type of action performed on the SIM card.
        /// </summary>
        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets the settings JSON object representation of the action params.
        /// </summary>
        [JsonProperty("settings")]
        public object Settings { get; set; } // Change to specific type if known

        /// <summary>
        /// Gets or sets the list of action summaries for the SIM card.
        /// </summary>
        [JsonProperty("sim_card_actions_summary")]
        public List<SimCardActionsSummary> SimCardActionsSummaries { get; set; }

        /// <summary>
        /// Gets or sets the time when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
