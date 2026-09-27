using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderRequirement, PortingOrderRequirementFromRaw>))]
public sealed record class PortingOrderRequirement : JsonModel
{
    /// <summary>
    /// Type of value expected on field_value field
    /// </summary>
    public ApiEnum<string, FieldType>? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FieldType>>(
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
    /// identifies the document that satisfies this requirement
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
    /// Identifies the requirement type that meets this requirement
    /// </summary>
    public string? RequirementTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_type_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType?.Validate();
        _ = this.FieldValue;
        _ = this.RecordType;
        _ = this.RequirementTypeID;
    }

    public PortingOrderRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRequirement (
        PortingOrderRequirement portingOrderRequirement
    ) : base(portingOrderRequirement)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRequirementFromRaw.FromRawUnchecked"/>
    public static PortingOrderRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderRequirementFromRaw : IFromRawJson<PortingOrderRequirement>
{
    /// <inheritdoc/>
    public PortingOrderRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRequirement.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of value expected on field_value field
/// </summary>
[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Document
}sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "document"=>FieldType.Document, _ =>(FieldType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, FieldType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FieldType.Document=>"document",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}