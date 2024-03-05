using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.BulkTelephonyCredentials
{
    public class BulkTelephonyCredential : TelnyxEntity
    {
        [JsonProperty("credentials")]
        public int Credentials { get; set; }
    }
}
