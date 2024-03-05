using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.BulkSettingSIMCardPublicIPs
{
    public class UpsertBulkSettingSIMCardPublicIP : BaseOptions
    {
        [JsonProperty("sim_card_ids")]
        public Guid[] SimCardIds { get; set; }
    }
}
