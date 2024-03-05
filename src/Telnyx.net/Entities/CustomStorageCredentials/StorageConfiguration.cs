using Newtonsoft.Json;
namespace Telnyx.net.Entities.CustomStorageCredentials
{
    public class StorageConfiguration
    {
        /// <summary>
        /// The opaque credential token used to authenticate and authorize with storage provider.
        /// </summary>
        [JsonProperty("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The name of the bucket to be used to store recording files.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }
    }
}
