using Newtonsoft.Json;

namespace Telnyx.net.Services.VerifyAPI
{
    public class VerifyCodeOptions : BaseOptions
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
