using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<SonioxVoiceSettings, SonioxVoiceSettingsFromRaw>))]
public sealed record class SonioxVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, SonioxVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SonioxVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Shortens the pauses between words.
    /// </summary>
    public bool? ReduceSilence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reduce_silence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reduce_silence", value);
        }
    }

    /// <summary>
    /// Speaking rate. 1.0 is normal speed.
    /// </summary>
    public float? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ReduceSilence;
        _ = this.Speed;
    }

    public SonioxVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SonioxVoiceSettings (SonioxVoiceSettings sonioxVoiceSettings) : base(
        sonioxVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public SonioxVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SonioxVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SonioxVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static SonioxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SonioxVoiceSettings (
        ApiEnum<string, SonioxVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class SonioxVoiceSettingsFromRaw : IFromRawJson<SonioxVoiceSettings>
{
    /// <inheritdoc/>
    public SonioxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SonioxVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(SonioxVoiceSettingsTypeConverter))]
public enum SonioxVoiceSettingsType
{
    Soniox
}sealed class SonioxVoiceSettingsTypeConverter : JsonConverter<SonioxVoiceSettingsType>
{
    public override SonioxVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "soniox"=>SonioxVoiceSettingsType.Soniox,
            _ =>(SonioxVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SonioxVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SonioxVoiceSettingsType.Soniox=>"soniox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}