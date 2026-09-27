using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ElevenLabsVoiceSettings, ElevenLabsVoiceSettingsFromRaw>))]
public sealed record class ElevenLabsVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, ElevenLabsVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ElevenLabsVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The `identifier` for an integration secret [/v2/integration_secrets](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// that refers to your ElevenLabs API key. Warning: Free plans are unlikely to
    /// work with this integration.
    /// </summary>
    public string? ApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key_ref", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ApiKeyRef;
    }

    public ElevenLabsVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevenLabsVoiceSettings (
        ElevenLabsVoiceSettings elevenLabsVoiceSettings
    ) : base(elevenLabsVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public ElevenLabsVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevenLabsVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ElevenLabsVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static ElevenLabsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ElevenLabsVoiceSettings (
        ApiEnum<string, ElevenLabsVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class ElevenLabsVoiceSettingsFromRaw : IFromRawJson<ElevenLabsVoiceSettings>
{
    /// <inheritdoc/>
    public ElevenLabsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ElevenLabsVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(ElevenLabsVoiceSettingsTypeConverter))]
public enum ElevenLabsVoiceSettingsType
{
    Elevenlabs
}sealed class ElevenLabsVoiceSettingsTypeConverter : JsonConverter<ElevenLabsVoiceSettingsType>
{
    public override ElevenLabsVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "elevenlabs"=>ElevenLabsVoiceSettingsType.Elevenlabs,
            _ =>(ElevenLabsVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElevenLabsVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ElevenLabsVoiceSettingsType.Elevenlabs=>"elevenlabs",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}