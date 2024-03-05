using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class ProberLocation
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

}
