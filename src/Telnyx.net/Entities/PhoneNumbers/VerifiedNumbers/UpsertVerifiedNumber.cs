using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers
{
    public class UpsertVerifiedNumber : BaseOptions
    {
        [JsonProperty("verification_code")]
        public string VerificationCode { get; set; }
    }
}
