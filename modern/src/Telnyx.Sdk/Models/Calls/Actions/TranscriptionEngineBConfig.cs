using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineBConfig, TranscriptionEngineBConfigFromRaw>))]
public sealed record class TranscriptionEngineBConfig : JsonModel
{
    /// <summary>
    /// Language to use for speech recognition
    /// </summary>
    public ApiEnum<string, TelnyxTranscriptionLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TelnyxTranscriptionLanguage>>(
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
    /// Engine identifier for Telnyx transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineBConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineBConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineBConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineBConfigTranscriptionModel>>(
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

    public TranscriptionEngineBConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineBConfig (
        TranscriptionEngineBConfig transcriptionEngineBConfig
    ) : base(transcriptionEngineBConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineBConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineBConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineBConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineBConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineBConfigFromRaw : IFromRawJson<TranscriptionEngineBConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineBConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineBConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine identifier for Telnyx transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineBConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineBConfigTranscriptionEngine
{
    B
}sealed class TranscriptionEngineBConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineBConfigTranscriptionEngine>
{
    public override TranscriptionEngineBConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "B"=>TranscriptionEngineBConfigTranscriptionEngine.B,
            _ =>(TranscriptionEngineBConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineBConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineBConfigTranscriptionEngine.B=>"B",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineBConfigTranscriptionModelConverter))]
public enum TranscriptionEngineBConfigTranscriptionModel
{
    OpenAIWhisperTiny, OpenAIWhisperLargeV3Turbo
}sealed class TranscriptionEngineBConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineBConfigTranscriptionModel>
{
    public override TranscriptionEngineBConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai/whisper-tiny"=>TranscriptionEngineBConfigTranscriptionModel.OpenAIWhisperTiny,
            "openai/whisper-large-v3-turbo"=>TranscriptionEngineBConfigTranscriptionModel.OpenAIWhisperLargeV3Turbo,
            _ =>(TranscriptionEngineBConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineBConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineBConfigTranscriptionModel.OpenAIWhisperTiny=>"openai/whisper-tiny",
            TranscriptionEngineBConfigTranscriptionModel.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}