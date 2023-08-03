namespace Telnyx.net.Services.Connections.IPs
{
    using Newtonsoft.Json;

    public class UpsertIPOptions : BaseOptions
    {
        /// <summary>
        /// ID of the IPConnection to which this IP should be attached.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; } = null;

        /// <summary>
        /// IP adddress represented by this resource. Example: "192.168.0.0".
        /// </summary>
        [JsonProperty("ip_address")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Port to use when connecting to this IP.
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; } = 5060;
    }
}