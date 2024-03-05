namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using Newtonsoft.Json;

    public class GlobalIpProtocol : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
