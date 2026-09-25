using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderRegulatoryRequirementWithValue, SubNumberOrderRegulatoryRequirementWithValueFromRaw>))]
public sealed record class SubNumberOrderRegulatoryRequirementWithValue : JsonModel
{
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
    /// The value of the requirement, this could be an id to a resource or a string value.
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
        _ = this.FieldValue;
        _ = this.RecordType;
        _ = this.RequirementID;
    }

    public SubNumberOrderRegulatoryRequirementWithValue ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderRegulatoryRequirementWithValue (
        SubNumberOrderRegulatoryRequirementWithValue subNumberOrderRegulatoryRequirementWithValue
    ) : base(subNumberOrderRegulatoryRequirementWithValue)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderRegulatoryRequirementWithValue (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderRegulatoryRequirementWithValue (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderRegulatoryRequirementWithValueFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderRegulatoryRequirementWithValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderRegulatoryRequirementWithValueFromRaw : IFromRawJson<SubNumberOrderRegulatoryRequirementWithValue>
{
    /// <inheritdoc/>
    public SubNumberOrderRegulatoryRequirementWithValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderRegulatoryRequirementWithValue.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Textual, Datetime, Address, Document
}sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "textual"=>FieldType.Textual,
            "datetime"=>FieldType.Datetime,
            "address"=>FieldType.Address,
            "document"=>FieldType.Document,
            _ =>(FieldType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FieldType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FieldType.Textual=>"textual",
            FieldType.Datetime=>"datetime",
            FieldType.Address=>"address",
            FieldType.Document=>"document",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}