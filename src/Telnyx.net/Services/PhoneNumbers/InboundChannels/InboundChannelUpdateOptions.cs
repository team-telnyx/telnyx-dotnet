namespace Telnyx.net.Services.PhoneNumbers.InboundChannels
{
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    public class InboundChannelUpdateOptions : BaseOptions
    {
        [JsonProperty("channels")]
        public int Channels { get; set; }
    }
}
