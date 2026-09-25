using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<CheckAvailabilityTool, CheckAvailabilityToolFromRaw>))]
public sealed record class CheckAvailabilityTool : JsonModel
{
    public required CheckAvailabilityToolParams CheckAvailability {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CheckAvailabilityToolParams>(
                "check_availability"
            );
        }
        init { this._rawData.Set("check_availability", value); }
    }

    public required ApiEnum<string, CheckAvailabilityToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckAvailabilityToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CheckAvailability.Validate();
        this.Type.Validate();
    }

    public CheckAvailabilityTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckAvailabilityTool (
        CheckAvailabilityTool checkAvailabilityTool
    ) : base(checkAvailabilityTool)
    {  }
    #pragma warning restore CS8618

    public CheckAvailabilityTool (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckAvailabilityTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CheckAvailabilityToolFromRaw.FromRawUnchecked"/>
    public static CheckAvailabilityTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CheckAvailabilityToolFromRaw : IFromRawJson<CheckAvailabilityTool>
{
    /// <inheritdoc/>
    public CheckAvailabilityTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CheckAvailabilityTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CheckAvailabilityToolTypeConverter))]
public enum CheckAvailabilityToolType
{
    CheckAvailability
}sealed class CheckAvailabilityToolTypeConverter : JsonConverter<CheckAvailabilityToolType>
{
    public override CheckAvailabilityToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "check_availability"=>CheckAvailabilityToolType.CheckAvailability,
            _ =>(CheckAvailabilityToolType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckAvailabilityToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CheckAvailabilityToolType.CheckAvailability=>"check_availability",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}