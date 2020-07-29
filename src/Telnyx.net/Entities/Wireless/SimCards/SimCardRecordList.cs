using Newtonsoft.Json;
using System.Collections.Generic;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    [JsonArray]
    public class SimCardRecordList : TelnyxList<SimCardRecord>
    {
        /// <summary>
        /// Gets or sets PhoneNumbers.
        /// </summary>
        [JsonProperty("data")]
        public IList<SimCardRecord> SimCardRecords { get; set; }
    }
}
