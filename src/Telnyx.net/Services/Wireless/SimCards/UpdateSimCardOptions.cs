namespace Telnyx.net.Services.Wireless.SimCards
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UpdateSimCardOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The current status of the SIM card. It will be one of the following: &lt;br/&gt; &lt;ul&gt;   &lt;li&gt;&lt;code&gt;activating&lt;/code&gt; - the card is being activated&lt;/li&gt;   &lt;li&gt;&lt;code&gt;active&lt;/code&gt; - the card is active and ready for use&lt;/li&gt;   &lt;li&gt;&lt;code&gt;inactivating&lt;/code&gt; - the card is being inactivated&lt;/li&gt;   &lt;li&gt;&lt;code&gt;inactive&lt;/code&gt; - the card has been inactivated and cannot be used&lt;/li&gt;   &lt;li&gt;&lt;code&gt;data_limit_exceeded&lt;/code&gt; - the card has exceeded its data consumption limit&lt;/li&gt; &lt;/ul&gt; Transitioning between the active and inactive states may take a period of time. 
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The group SIMCardGroup identification. This attribute can be &lt;code&gt;null&lt;/code&gt; when it&#x27;s present in an associated resource.
        /// </summary>
        [JsonProperty("sim_card_group_id")]
        public Guid? SimCardGroupId { get; set; }

        /// <summary>
        /// Searchable tags associated with the SIM card.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}