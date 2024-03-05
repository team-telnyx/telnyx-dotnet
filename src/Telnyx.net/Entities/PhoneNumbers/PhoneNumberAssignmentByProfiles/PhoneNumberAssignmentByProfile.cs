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
        public StatusObject Status { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
    public class StatusObject
    {
        // You can replace 'object' with the actual enumeration type if you have it.
        // If it's a string or some other type, you can adjust the type accordingly.
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
