using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TelnyxVoiceSettings, TelnyxVoiceSettingsFromRaw>))]
public sealed record class TelnyxVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, TelnyxVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The voice speed to be used for the voice. The voice speed must be between
    /// 0.1 and 2.0. Default value is 1.0. Not supported for `Telnyx.Bayan.*` or `Telnyx.Sukhan.*` voices.
    /// </summary>
    public float? VoiceSpeed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "voice_speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.VoiceSpeed;
    }

    public TelnyxVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxVoiceSettings (TelnyxVoiceSettings telnyxVoiceSettings) : base(
        telnyxVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public TelnyxVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static TelnyxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TelnyxVoiceSettings (
        ApiEnum<string, TelnyxVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class TelnyxVoiceSettingsFromRaw : IFromRawJson<TelnyxVoiceSettings>
{
    /// <inheritdoc/>
    public TelnyxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(TelnyxVoiceSettingsTypeConverter))]
public enum TelnyxVoiceSettingsType
{
    Telnyx
}sealed class TelnyxVoiceSettingsTypeConverter : JsonConverter<TelnyxVoiceSettingsType>
{
    public override TelnyxVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>TelnyxVoiceSettingsType.Telnyx,
            _ =>(TelnyxVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxVoiceSettingsType.Telnyx=>"telnyx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}