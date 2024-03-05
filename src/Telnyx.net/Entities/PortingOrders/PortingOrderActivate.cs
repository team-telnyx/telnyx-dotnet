using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PortingOrders
{
    public class PortingOrderActivate : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("activation_type")]
        public string ActivationType { get; set; }

        [JsonProperty("activate_at")]
        public DateTime ActivateAt { get; set; }

        [JsonProperty("activation_windows")]
        public ActivationWindow[] ActivationWindows { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
    public class ActivationWindow
    {
        [JsonProperty("start_at")]
        public DateTime StartAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime EndAt { get; set; }
    }
}
