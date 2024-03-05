namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.Searches;

    /// <summary>
    /// Available Phone Number Block.
    /// </summary>
    public class AvailablePhoneNumberBlock : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets StartingNumber.
        /// </summary>
        [JsonProperty("starting_number")]
        public string StartingNumber { get; set; }

        /// <summary>
        /// Gets or sets Range.
        /// </summary>
        [JsonProperty("range")]
        public int Range { get; set; }

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
