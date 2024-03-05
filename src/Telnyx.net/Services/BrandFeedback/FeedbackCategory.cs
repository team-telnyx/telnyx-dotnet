using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx
{
    /// <summary>
    /// Represents a category of reasons why brand creation/revetting didn't go as planned.
    /// </summary>
    public class FeedbackCategory
    {
        /// <summary>
        /// Gets or sets the identifier of the category.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the human-readable version of the identifier.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the long-form description of the feedback with additional information.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of relevant fields in the originally-submitted brand json.
        /// </summary>
        [JsonProperty("fields")]
        public List<string> Fields { get; set; }
    }
}
