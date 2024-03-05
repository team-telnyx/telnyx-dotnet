using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.AI.AiGenerates
{
    public class UpsertAiGenerate : BaseOptions
    {
        [JsonProperty("text")]
        public string[] Text { get; set; }

        [JsonProperty("model")]
        public object SupportedModels { get; set; }

        [JsonProperty("bucket")]
        public Bucket Bucket { get; set; }

        [JsonProperty("openai_api_key")]
        public string OpenaiApiKey { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; } = 128;

        [JsonProperty("temperature")]
        public double Temperature { get; set; } = 0.9;
    }
    public class Bucket
    {
        [JsonProperty("bucket")]
        public string BucketName { get; set; }
    }
}
