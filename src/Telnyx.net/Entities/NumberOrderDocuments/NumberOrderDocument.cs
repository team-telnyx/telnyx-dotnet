namespace Telnyx.net.Entities.NumberOrderDocuments
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.NumberOrderDocuments;

    public class NumberOrderDocument : TelnyxEntity
    {
        /// <summary>
        /// An ISO 8901 datetime string denoting when the number order document was uploaded.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// A customer reference string for customer lookups.
        /// </summary>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// The ID of the file associated as a number order document.
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// The unique identifier of the number order document.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// The type of requirement.
        /// </summary>
        [JsonProperty("requirement_type")]
        public RequirementType RequirementType { get; set; }

        /// <summary>
        /// Unique ID for a requirement.
        /// </summary>
        [JsonProperty("requirements_id")]
        public string RequirementsId { get; set; }
    }
}
