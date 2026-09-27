using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<HangupTool, HangupToolFromRaw>))]
public sealed record class HangupTool : JsonModel
{
    public required HangupToolParams Hangup {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<HangupToolParams>(
                "hangup"
            );
        }
        init { this._rawData.Set("hangup", value); }
    }

    public required ApiEnum<string, HangupToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, HangupToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Hangup.Validate();
        this.Type.Validate();
    }

    public HangupTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HangupTool (HangupTool hangupTool) : base(hangupTool)
    {  }
    #pragma warning restore CS8618

    public HangupTool (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HangupTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HangupToolFromRaw.FromRawUnchecked"/>
    public static HangupTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HangupToolFromRaw : IFromRawJson<HangupTool>
{
    /// <inheritdoc/>
    public HangupTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HangupTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(HangupToolTypeConverter))]
public enum HangupToolType
{
    Hangup
}sealed class HangupToolTypeConverter : JsonConverter<HangupToolType>
{
    public override HangupToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "hangup"=>HangupToolType.Hangup, _ =>(HangupToolType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HangupToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HangupToolType.Hangup=>"hangup",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}