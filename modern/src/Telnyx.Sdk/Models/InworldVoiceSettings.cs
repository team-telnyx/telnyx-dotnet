using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<InworldVoiceSettings, InworldVoiceSettingsFromRaw>))]
public sealed record class InworldVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, InworldVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InworldVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Controls the expressiveness and consistency of the Inworld `TTS2` model's
    /// speech synthesis. `STABLE` favors consistent, predictable output, `CREATIVE`
    /// allows more expressive variation, and `BALANCED` sits in between. Optional
    /// and only supported by `TTS2`; when omitted, the provider default applies.
    /// </summary>
    public ApiEnum<string, DeliveryMode>? DeliveryMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeliveryMode>>(
                "delivery_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.DeliveryMode?.Validate();
    }

    public InworldVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InworldVoiceSettings (
        InworldVoiceSettings inworldVoiceSettings
    ) : base(inworldVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public InworldVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InworldVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InworldVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static InworldVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InworldVoiceSettings (
        ApiEnum<string, InworldVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class InworldVoiceSettingsFromRaw : IFromRawJson<InworldVoiceSettings>
{
    /// <inheritdoc/>
    public InworldVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InworldVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(InworldVoiceSettingsTypeConverter))]
public enum InworldVoiceSettingsType
{
    Inworld
}sealed class InworldVoiceSettingsTypeConverter : JsonConverter<InworldVoiceSettingsType>
{
    public override InworldVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inworld"=>InworldVoiceSettingsType.Inworld,
            _ =>(InworldVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InworldVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InworldVoiceSettingsType.Inworld=>"inworld",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Controls the expressiveness and consistency of the Inworld `TTS2` model's speech
/// synthesis. `STABLE` favors consistent, predictable output, `CREATIVE` allows more
/// expressive variation, and `BALANCED` sits in between. Optional and only supported
/// by `TTS2`; when omitted, the provider default applies.
/// </summary>
[JsonConverter(typeof(DeliveryModeConverter))]
public enum DeliveryMode
{
    Stable, Balanced, Creative
}sealed class DeliveryModeConverter : JsonConverter<DeliveryMode>
{
    public override DeliveryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "STABLE"=>DeliveryMode.Stable,
            "BALANCED"=>DeliveryMode.Balanced,
            "CREATIVE"=>DeliveryMode.Creative,
            _ =>(DeliveryMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DeliveryMode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeliveryMode.Stable=>"STABLE",
            DeliveryMode.Balanced=>"BALANCED",
            DeliveryMode.Creative=>"CREATIVE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}