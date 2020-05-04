namespace Telnyx
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Regulatory Requirement.
    /// </summary>
    public class RegulatoryRequirement
    {
        /// <summary>
        /// Gets or sets RequirementType.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RequirementTypeEnum
        {
            /// <summary>
            /// Enum EntityIdentificationEnum for entity identification
            /// </summary>
            [EnumMember(Value = "entity identification")]
            EntityIdentificationEnum = 0,

            /// <summary>
            /// Enum EndUserAddressEnum for end user address
            /// </summary>
            [EnumMember(Value = "end user address")]
            EndUserAddressEnum = 1,

            /// <summary>
            /// Enum EndUserProofOfAddressEnum for end user proof of address
            /// </summary>
            [EnumMember(Value = "end user proof of address")]
            EndUserProofOfAddressEnum = 2
        }

        /// <summary>
        /// Gets or sets FieldType.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum FieldTypeEnum
        {
            /// <summary>
            /// Enum TextFieldEnum for text field
            /// </summary>
            [EnumMember(Value = "text field")]
            TextFieldEnum = 0,

            /// <summary>
            /// Enum FileUploadEnum for file upload
            /// </summary>
            [EnumMember(Value = "file upload")]
            FileUploadEnum = 1,

            /// <summary>
            /// Enum AddressEnum for address
            /// </summary>
            [EnumMember(Value = "address")]
            AddressEnum = 2,

            /// <summary>
            /// Enum DatetimeEnum for datetime
            /// </summary>
            [EnumMember(Value = "datetime")]
            DatetimeEnum = 3
        }

        /// <summary>
        /// Gets or sets RequirementType.
        /// </summary>
        [JsonProperty("requirement_type")]
        public RequirementTypeEnum? RequirementType { get; set; }

        /// <summary>
        /// Gets or sets Label.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets FieldType.
        /// </summary>
        [JsonProperty("field_type")]
        public FieldTypeEnum? FieldType { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
