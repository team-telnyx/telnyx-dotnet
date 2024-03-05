using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.ValidateSIMCardsRegistrationCodes
{
    public class UpsertValidateSIMCardsRegistrationCode : BaseOptions
    {
        [JsonProperty("registration_code")]
        public string[] RegistrationCode { get; set; }
    }
}
