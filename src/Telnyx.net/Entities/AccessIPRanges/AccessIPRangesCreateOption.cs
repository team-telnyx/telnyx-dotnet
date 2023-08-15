namespace Telnyx.net.Entities.AccessIPRanges
{
    using Newtonsoft.Json;

    public class AccessIPRangesCreateOption : BaseOptions
    {
        /// <summary>
        /// The CIDR block.
        /// </summary>
        [JsonProperty("cidr_block")]
        public string CidrBlock { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
