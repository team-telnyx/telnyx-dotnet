using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.AI.AiEmbeddings
{
    public class AiEmbedding : TelnyxEntity
    {
        [JsonProperty("task_id")]
        public Guid TaskId { get; set; }

        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("finished_at")]
        public DateTime FinishedAt { get; set; }
        
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
    }
}
