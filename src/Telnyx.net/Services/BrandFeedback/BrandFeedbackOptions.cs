using Newtonsoft.Json;
using System.Collections.Generic;

namespace Telnyx
{
    /// <summary>
    /// BrandFeedback.
    /// </summary>
    public class BrandFeedbackOptions : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets the ID of the brand being queried about.
        /// </summary>
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        /// <summary>
        /// Gets or sets the list of categories.
        /// </summary>
        [JsonProperty("category")]
        public List<FeedbackCategory> Category { get; set; }
    }
}
