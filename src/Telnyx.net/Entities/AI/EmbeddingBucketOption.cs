using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.EmbeddingBuckets
{
    public class EmbeddingBucketOption : ListOptions
    {
        [JsonProperty("bucket_name")]
        public string BucketName { get; set; }
    }
}
