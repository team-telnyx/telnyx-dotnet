using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telnyx.net.Entities.AccessIPRanges
{
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
