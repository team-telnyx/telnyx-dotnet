using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderRetrieveRequirementsResponse, PortingOrderRetrieveRequirementsResponseFromRaw>))]
public sealed record class PortingOrderRetrieveRequirementsResponse : JsonModel
{
    /// <summary>
    /// Type of value expected on field_value field
    /// </summary>
    public ApiEnum<string, PortingOrderRetrieveRequirementsResponseFieldType>? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingOrderRetrieveRequirementsResponseFieldType>>(
                "field_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_type", value);
        }
    }

    /// <summary>
    /// Identifies the document that satisfies this requirement
    /// </summary>
    public string? FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_value", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Status of the requirement
    /// </summary>
    public string? RequirementStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_status", value);
        }
    }

    /// <summary>
    /// Identifies the requirement type that meets this requirement
    /// </summary>
    public RequirementType? RequirementType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RequirementType>(
                "requirement_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType?.Validate();
        _ = this.FieldValue;
        _ = this.RecordType;
        _ = this.RequirementStatus;
        this.RequirementType?.Validate();
    }

    public PortingOrderRetrieveRequirementsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRetrieveRequirementsResponse (
        PortingOrderRetrieveRequirementsResponse portingOrderRetrieveRequirementsResponse
    ) : base(portingOrderRetrieveRequirementsResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRetrieveRequirementsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRetrieveRequirementsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRetrieveRequirementsResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderRetrieveRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderRetrieveRequirementsResponseFromRaw : IFromRawJson<PortingOrderRetrieveRequirementsResponse>
{
    /// <inheritdoc/>
    public PortingOrderRetrieveRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRetrieveRequirementsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of value expected on field_value field
/// </summary>
[JsonConverter(typeof(PortingOrderRetrieveRequirementsResponseFieldTypeConverter))]
public enum PortingOrderRetrieveRequirementsResponseFieldType
{
    Document, Textual
}sealed class PortingOrderRetrieveRequirementsResponseFieldTypeConverter : JsonConverter<PortingOrderRetrieveRequirementsResponseFieldType>
{
    public override PortingOrderRetrieveRequirementsResponseFieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "document"=>PortingOrderRetrieveRequirementsResponseFieldType.Document,
            "textual"=>PortingOrderRetrieveRequirementsResponseFieldType.Textual,
            _ =>(PortingOrderRetrieveRequirementsResponseFieldType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingOrderRetrieveRequirementsResponseFieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingOrderRetrieveRequirementsResponseFieldType.Document=>"document",
            PortingOrderRetrieveRequirementsResponseFieldType.Textual=>"textual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the requirement type that meets this requirement
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequirementType, RequirementTypeFromRaw>))]
public sealed record class RequirementType : JsonModel
{
    /// <summary>
    /// Identifies the requirement type
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The acceptance criteria for the requirement type
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? AcceptanceCriteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "acceptance_criteria"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "acceptance_criteria",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A description of the requirement type
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// An example of the requirement type
    /// </summary>
    public string? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "example"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("example", value);
        }
    }

    /// <summary>
    /// The name of the requirement type
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The type of the requirement type
    /// </summary>
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AcceptanceCriteria;
        _ = this.Description;
        _ = this.Example;
        _ = this.Name;
        _ = this.Type;
    }

    public RequirementType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementType (RequirementType requirementType) : base(
        requirementType
    )
    {  }
    #pragma warning restore CS8618

    public RequirementType (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementTypeFromRaw.FromRawUnchecked"/>
    public static RequirementType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RequirementTypeFromRaw : IFromRawJson<RequirementType>
{
    /// <inheritdoc/>
    public RequirementType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementType.FromRawUnchecked(rawData);
}