using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineCohereConfig, TranscriptionEngineCohereConfigFromRaw>))]
public sealed record class TranscriptionEngineCohereConfig : JsonModel
{
    /// <summary>
    /// The language of the audio to be transcribed. Unlike other self-hosted models,
    /// Cohere does not auto-detect the language; `auto` is not supported.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineCohereConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineCohereConfigLanguage>>(
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
    /// Engine identifier for Cohere transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineCohereConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineCohereConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineCohereConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineCohereConfigTranscriptionModel>>(
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

    public TranscriptionEngineCohereConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineCohereConfig (
        TranscriptionEngineCohereConfig transcriptionEngineCohereConfig
    ) : base(transcriptionEngineCohereConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineCohereConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineCohereConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineCohereConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineCohereConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineCohereConfigFromRaw : IFromRawJson<TranscriptionEngineCohereConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineCohereConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineCohereConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The language of the audio to be transcribed. Unlike other self-hosted models,
/// Cohere does not auto-detect the language; `auto` is not supported.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineCohereConfigLanguageConverter))]
public enum TranscriptionEngineCohereConfigLanguage
{
    Ar, En
}sealed class TranscriptionEngineCohereConfigLanguageConverter : JsonConverter<TranscriptionEngineCohereConfigLanguage>
{
    public override TranscriptionEngineCohereConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ar"=>TranscriptionEngineCohereConfigLanguage.Ar,
            "en"=>TranscriptionEngineCohereConfigLanguage.En,
            _ =>(TranscriptionEngineCohereConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineCohereConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineCohereConfigLanguage.Ar=>"ar",
            TranscriptionEngineCohereConfigLanguage.En=>"en",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for Cohere transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineCohereConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineCohereConfigTranscriptionEngine
{
    Cohere
}sealed class TranscriptionEngineCohereConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineCohereConfigTranscriptionEngine>
{
    public override TranscriptionEngineCohereConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Cohere"=>TranscriptionEngineCohereConfigTranscriptionEngine.Cohere,
            _ =>(TranscriptionEngineCohereConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineCohereConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineCohereConfigTranscriptionEngine.Cohere=>"Cohere",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineCohereConfigTranscriptionModelConverter))]
public enum TranscriptionEngineCohereConfigTranscriptionModel
{
    CohereArStt
}sealed class TranscriptionEngineCohereConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineCohereConfigTranscriptionModel>
{
    public override TranscriptionEngineCohereConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cohere/ar-stt"=>TranscriptionEngineCohereConfigTranscriptionModel.CohereArStt,
            _ =>(TranscriptionEngineCohereConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineCohereConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineCohereConfigTranscriptionModel.CohereArStt=>"cohere/ar-stt",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}