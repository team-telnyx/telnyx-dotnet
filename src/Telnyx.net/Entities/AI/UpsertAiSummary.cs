using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.AI.AiSummarize
{
    public class UpsertAiSummary : BaseOptions
    {
        [JsonProperty("bucket")]
        public string BucketName { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }
    }
}
