using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.AI
{
    public class UpsertAiEmbedding : BaseOptions
    {
        [JsonProperty("bucket_name")]
        public string BucketName { get; set; }

        [JsonProperty("document_chunk_size")]
        public int DocumentChunkSize { get; set; } = 1024;

        [JsonProperty("document_chunk_overlap_size")]
        public int DocumentChunkOverlapSize { get; set; } = 512;

        [JsonProperty("embedding_model")]
        public EmbeddingModel EmbeddingModel { get; set; }

        [JsonProperty("loader")]
        public DocumentLoader DocumentLoader { get; set; }
    }
    public class EmbeddingModel
    {
        // Define properties for the embedding model if needed
    }

    public class DocumentLoader
    {
        // Define properties for the document loader if needed
    }
}
