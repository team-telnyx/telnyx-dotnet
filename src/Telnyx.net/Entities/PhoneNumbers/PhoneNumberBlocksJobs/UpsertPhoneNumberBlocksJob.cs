using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs
{
    public class UpsertPhoneNumberBlocksJob :BaseOptions
    {
        [JsonProperty("phone_number_block_id")]
        public string PhoneNumberBlockId { get; set; }
    }
}
