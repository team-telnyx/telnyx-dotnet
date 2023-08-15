namespace Telnyx.net.Entities.AccessIPRanges
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.AccessIPRanges;

    public class AccessIPRangesListOption : ListOptions
    {
        /// <summary>
        /// The CIDR block.
        /// </summary>
        [JsonProperty("filter[cidr_block]")]
        public string CidrBlock { get; set; }

        /// <summary>
        /// The CIDR block starts with.
        /// </summary>
        [JsonProperty("filter[cidr_block][startswith]")]
        public string CidrBlockStartsWith { get; set; }

        /// <summary>
        /// The CIDR block ends with.
        /// </summary>
        [JsonProperty("filter[cidr_block][endswith]")]
        public string CidrBlockEndsWith { get; set; }

        /// <summary>
        /// The CIDR block contains.
        /// </summary>
        [JsonProperty("filter[cidr_block][contains]")]
        public string CidrBlockContains { get; set; }

        /// <summary>
        /// The status.
        /// </summary>
        [JsonProperty("filter[status]")]
        public CloudflareSyncStatus Status { get; set; }

        /// <summary>
        /// The created at greater than filter.
        /// </summary>
        [JsonProperty("filter[created_at][gt]")]
        public DateTime CreatedAtGreaterThan { get; set; }

        /// <summary>
        /// The created at less than filter.
        /// </summary>
        [JsonProperty("filter[created_at][lt]")]
        public DateTime CreatedAtLessThan { get; set; }
    }
}
