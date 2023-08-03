namespace Telnyx.net.Services.VerifyAPI
{
    using Newtonsoft.Json;

    public class VerifyCodeOptions : BaseOptions
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
