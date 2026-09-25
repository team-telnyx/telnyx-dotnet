using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<ResembleVoiceSettings, ResembleVoiceSettingsFromRaw>))]
public sealed record class ResembleVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, ResembleVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ResembleVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Output audio format.
    /// </summary>
    public ApiEnum<string, Format>? Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// Audio precision format.
    /// </summary>
    public ApiEnum<string, Precision>? Precision {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Precision>>(
                "precision"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("precision", value);
        }
    }

    /// <summary>
    /// Audio sample rate in Hz.
    /// </summary>
    public ApiEnum<string, SampleRate>? SampleRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SampleRate>>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Format?.Validate();
        this.Precision?.Validate();
        this.SampleRate?.Validate();
    }

    public ResembleVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResembleVoiceSettings (
        ResembleVoiceSettings resembleVoiceSettings
    ) : base(resembleVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public ResembleVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResembleVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResembleVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static ResembleVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ResembleVoiceSettings (
        ApiEnum<string, ResembleVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class ResembleVoiceSettingsFromRaw : IFromRawJson<ResembleVoiceSettings>
{
    /// <inheritdoc/>
    public ResembleVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResembleVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(ResembleVoiceSettingsTypeConverter))]
public enum ResembleVoiceSettingsType
{
    Resemble
}sealed class ResembleVoiceSettingsTypeConverter : JsonConverter<ResembleVoiceSettingsType>
{
    public override ResembleVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "resemble"=>ResembleVoiceSettingsType.Resemble,
            _ =>(ResembleVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResembleVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResembleVoiceSettingsType.Resemble=>"resemble",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Output audio format.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Wav, Mp3
}sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "wav"=>Format.Wav, "mp3"=>Format.Mp3, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Wav=>"wav",
            Format.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Audio precision format.
/// </summary>
[JsonConverter(typeof(PrecisionConverter))]
public enum Precision
{
    Pcm16, Pcm24, Pcm32, Mulaw
}sealed class PrecisionConverter : JsonConverter<Precision>
{
    public override Precision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PCM_16"=>Precision.Pcm16,
            "PCM_24"=>Precision.Pcm24,
            "PCM_32"=>Precision.Pcm32,
            "MULAW"=>Precision.Mulaw,
            _ =>(Precision)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Precision value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Precision.Pcm16=>"PCM_16",
            Precision.Pcm24=>"PCM_24",
            Precision.Pcm32=>"PCM_32",
            Precision.Mulaw=>"MULAW",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Audio sample rate in Hz.
/// </summary>
[JsonConverter(typeof(SampleRateConverter))]
public enum SampleRate
{
    SampleRate8000,
    SampleRate16000,
    SampleRate22050,
    SampleRate32000,
    SampleRate44100,
    SampleRate48000
}sealed class SampleRateConverter : JsonConverter<SampleRate>
{
    public override SampleRate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "8000"=>SampleRate.SampleRate8000,
            "16000"=>SampleRate.SampleRate16000,
            "22050"=>SampleRate.SampleRate22050,
            "32000"=>SampleRate.SampleRate32000,
            "44100"=>SampleRate.SampleRate44100,
            "48000"=>SampleRate.SampleRate48000,
            _ =>(SampleRate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SampleRate value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SampleRate.SampleRate8000=>"8000",
            SampleRate.SampleRate16000=>"16000",
            SampleRate.SampleRate22050=>"22050",
            SampleRate.SampleRate32000=>"32000",
            SampleRate.SampleRate44100=>"44100",
            SampleRate.SampleRate48000=>"48000",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}