using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Documents
{
    public class DocumentSize
    {
        /// <summary>
        /// The number of bytes.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Identifies the unit.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
