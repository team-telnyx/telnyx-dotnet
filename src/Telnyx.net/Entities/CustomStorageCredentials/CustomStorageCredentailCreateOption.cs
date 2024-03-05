namespace Telnyx.net.Entities.CustomStorageCredentials
{
    using Newtonsoft.Json;

    public class CustomStorageCredentialCreateOptions : BaseOptions
    {
        /// <summary>
        /// The backend storage provider.
        /// </summary>
        [JsonProperty("backend")]
        public string Backend { get; set; }

        /// <summary>
        /// The configuration for the storage backend.
        /// </summary>
        [JsonProperty("configuration")]
        public StorageConfiguration Configuration { get; set; }


    }
}
