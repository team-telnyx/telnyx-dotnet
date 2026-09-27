using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderRegulatoryRequirement, SubNumberOrderRegulatoryRequirementFromRaw>))]
public sealed record class SubNumberOrderRegulatoryRequirement : JsonModel
{
    public ApiEnum<string, SubNumberOrderRegulatoryRequirementFieldType>? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubNumberOrderRegulatoryRequirementFieldType>>(
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
    /// Unique id for a requirement.
    /// </summary>
    public string? RequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType?.Validate();
        _ = this.RecordType;
        _ = this.RequirementID;
    }

    public SubNumberOrderRegulatoryRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderRegulatoryRequirement (
        SubNumberOrderRegulatoryRequirement subNumberOrderRegulatoryRequirement
    ) : base(subNumberOrderRegulatoryRequirement)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderRegulatoryRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderRegulatoryRequirement (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderRegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderRegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderRegulatoryRequirementFromRaw : IFromRawJson<SubNumberOrderRegulatoryRequirement>
{
    /// <inheritdoc/>
    public SubNumberOrderRegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderRegulatoryRequirement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubNumberOrderRegulatoryRequirementFieldTypeConverter))]
public enum SubNumberOrderRegulatoryRequirementFieldType
{
    Textual, Datetime, Address, Document
}sealed class SubNumberOrderRegulatoryRequirementFieldTypeConverter : JsonConverter<SubNumberOrderRegulatoryRequirementFieldType>
{
    public override SubNumberOrderRegulatoryRequirementFieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "textual"=>SubNumberOrderRegulatoryRequirementFieldType.Textual,
            "datetime"=>SubNumberOrderRegulatoryRequirementFieldType.Datetime,
            "address"=>SubNumberOrderRegulatoryRequirementFieldType.Address,
            "document"=>SubNumberOrderRegulatoryRequirementFieldType.Document,
            _ =>(SubNumberOrderRegulatoryRequirementFieldType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubNumberOrderRegulatoryRequirementFieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SubNumberOrderRegulatoryRequirementFieldType.Textual=>"textual",
            SubNumberOrderRegulatoryRequirementFieldType.Datetime=>"datetime",
            SubNumberOrderRegulatoryRequirementFieldType.Address=>"address",
            SubNumberOrderRegulatoryRequirementFieldType.Document=>"document",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}