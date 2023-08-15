namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// Phone Number Regulatory Requirement.
    /// </summary>
    public class PhoneNumberRegulatoryRequirement
    {
        /// <summary>
        /// Gets or sets FieldType.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum FieldTypeEnum
        {
            /// <summary>
            /// Enum StringEnum for string
            /// </summary>
            [EnumMember(Value = "string")]
            StringEnum = 0,

            /// <summary>
            /// Enum DatetimeEnum for datetime
            /// </summary>
            [EnumMember(Value = "datetime")]
            DatetimeEnum = 1,

            /// <summary>
            /// Enum AddressIdEnum for address_id
            /// </summary>
            [EnumMember(Value = "address_id")]
            AddressIdEnum = 2,

            /// <summary>
            /// Enum NumberOrderDocumentIdEnum for number_order_document_id
            /// </summary>
            [EnumMember(Value = "number_order_document_id")]
            NumberOrderDocumentIdEnum = 3,

            /// <summary>
            /// For mocks test cases only, do not use
            /// </summary>
            [Obsolete]
            [EnumMember(Value = "address")]
            Address = -99,
        }

        /// <summary>
        /// Gets or sets recordType.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets unique id for a requirement.
        /// </summary>
        /// <value>Unique id for a requirement.</value>
        [JsonProperty("requirement_id")]
        public Guid? RequirementId { get; set; }

        /// <summary>
        /// Gets or sets the value of the requirement, this could be an id to a resource or a string value.
        /// </summary>
        /// <value>The value of the requirement, this could be an id to a resource or a string value.</value>
        [JsonProperty("field_value")]
        public string FieldValue { get; set; }

        /// <summary>
        /// Gets or sets FieldType.
        /// </summary>
        [JsonProperty("field_type")]
        public FieldTypeEnum? FieldType { get; set; }
    }
}