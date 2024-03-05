namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.PhoneNumbers.Searches;

    /// <summary>
    /// Phone Number Search.
    /// </summary>
    public class AvailablePhoneNumberSearch : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets VanityFormat.
        /// </summary>
        [JsonProperty("vanity_format")]
        public string VanityFormat { get; set; }

        /// <summary>
        /// Gets or sets BestEffort.
        /// </summary>
        [JsonProperty("best_effort")]
        public bool BestEffort { get; set; }

        /// <summary>
        /// Gets or sets Quickship.
        /// </summary>
        [JsonProperty("quickship")]
        public bool Quickship { get; set; }

        /// <summary>
        /// Gets or sets Reservable.
        /// </summary>
        [JsonProperty("reservable")]
        public bool Reservable { get; set; }

        /// <summary>
        /// Gets or sets RegionInformation.
        /// </summary>
        [JsonProperty("region_information")]
        public List<RegionInformation> RegionInformation { get; set; }

        /// <summary>
        /// Gets or sets CostInformation.
        /// </summary>
        [JsonProperty("cost_information")]
        public CostInformation CostInformation { get; set; }

        /// <summary>
        /// Gets or sets Features.
        /// </summary>
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
