using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineHumainConfig, TranscriptionEngineHumainConfigFromRaw>))]
public sealed record class TranscriptionEngineHumainConfig : JsonModel
{
    /// <summary>
    /// The language of the audio to be transcribed. `codeswitch` enables Arabic/English
    /// code-switching. `auto` resolves server-side to code-switching.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineHumainConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineHumainConfigLanguage>>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// Engine identifier for Humain transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineHumainConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineHumainConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_engine", value);
        }
    }

    /// <summary>
    /// The model to use for transcription.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineHumainConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineHumainConfigTranscriptionModel>>(
                "transcription_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_model", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Language?.Validate();
        this.TranscriptionEngine?.Validate();
        this.TranscriptionModel?.Validate();
    }

    public TranscriptionEngineHumainConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineHumainConfig (
        TranscriptionEngineHumainConfig transcriptionEngineHumainConfig
    ) : base(transcriptionEngineHumainConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineHumainConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineHumainConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineHumainConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineHumainConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineHumainConfigFromRaw : IFromRawJson<TranscriptionEngineHumainConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineHumainConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineHumainConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The language of the audio to be transcribed. `codeswitch` enables Arabic/English
/// code-switching. `auto` resolves server-side to code-switching.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineHumainConfigLanguageConverter))]
public enum TranscriptionEngineHumainConfigLanguage
{
    Ar, En, Codeswitch, Auto
}sealed class TranscriptionEngineHumainConfigLanguageConverter : JsonConverter<TranscriptionEngineHumainConfigLanguage>
{
    public override TranscriptionEngineHumainConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ar"=>TranscriptionEngineHumainConfigLanguage.Ar,
            "en"=>TranscriptionEngineHumainConfigLanguage.En,
            "codeswitch"=>TranscriptionEngineHumainConfigLanguage.Codeswitch,
            "auto"=>TranscriptionEngineHumainConfigLanguage.Auto,
            _ =>(TranscriptionEngineHumainConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineHumainConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineHumainConfigLanguage.Ar=>"ar",
            TranscriptionEngineHumainConfigLanguage.En=>"en",
            TranscriptionEngineHumainConfigLanguage.Codeswitch=>"codeswitch",
            TranscriptionEngineHumainConfigLanguage.Auto=>"auto",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for Humain transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineHumainConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineHumainConfigTranscriptionEngine
{
    Humain
}sealed class TranscriptionEngineHumainConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineHumainConfigTranscriptionEngine>
{
    public override TranscriptionEngineHumainConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Humain"=>TranscriptionEngineHumainConfigTranscriptionEngine.Humain,
            _ =>(TranscriptionEngineHumainConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineHumainConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineHumainConfigTranscriptionEngine.Humain=>"Humain",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineHumainConfigTranscriptionModelConverter))]
public enum TranscriptionEngineHumainConfigTranscriptionModel
{
    HumainRealtime
}sealed class TranscriptionEngineHumainConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineHumainConfigTranscriptionModel>
{
    public override TranscriptionEngineHumainConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "humain/realtime"=>TranscriptionEngineHumainConfigTranscriptionModel.HumainRealtime,
            _ =>(TranscriptionEngineHumainConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineHumainConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineHumainConfigTranscriptionModel.HumainRealtime=>"humain/realtime",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}