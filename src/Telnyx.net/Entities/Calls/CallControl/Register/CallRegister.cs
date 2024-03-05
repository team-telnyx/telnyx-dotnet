using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CallRegisters
{
    public class CallRegister : TelnyxEntity
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
