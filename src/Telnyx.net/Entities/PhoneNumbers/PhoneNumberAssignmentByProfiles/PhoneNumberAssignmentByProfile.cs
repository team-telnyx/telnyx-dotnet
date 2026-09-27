using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles
{
   public class PhoneNumberAssignmentByProfile : TelnyxEntity
    {
        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(AssignmentStatusConverter))]
        public StatusObject Status { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
    public class StatusObject
    {
        // Keep the original scalar/object wire shape without changing the public Status property.
        [JsonIgnore]
        internal bool IsScalar { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
