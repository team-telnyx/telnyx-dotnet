using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineTelnyxConfig, TranscriptionEngineTelnyxConfigFromRaw>))]
public sealed record class TranscriptionEngineTelnyxConfig : JsonModel
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
    public ApiEnum<string, TranscriptionEngineTelnyxConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineTelnyxConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineTelnyxConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineTelnyxConfigTranscriptionModel>>(
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

    public TranscriptionEngineTelnyxConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineTelnyxConfig (
        TranscriptionEngineTelnyxConfig transcriptionEngineTelnyxConfig
    ) : base(transcriptionEngineTelnyxConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineTelnyxConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineTelnyxConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineTelnyxConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineTelnyxConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineTelnyxConfigFromRaw : IFromRawJson<TranscriptionEngineTelnyxConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineTelnyxConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineTelnyxConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine identifier for Telnyx transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineTelnyxConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineTelnyxConfigTranscriptionEngine
{
    Telnyx
}sealed class TranscriptionEngineTelnyxConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineTelnyxConfigTranscriptionEngine>
{
    public override TranscriptionEngineTelnyxConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Telnyx"=>TranscriptionEngineTelnyxConfigTranscriptionEngine.Telnyx,
            _ =>(TranscriptionEngineTelnyxConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineTelnyxConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineTelnyxConfigTranscriptionEngine.Telnyx=>"Telnyx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineTelnyxConfigTranscriptionModelConverter))]
public enum TranscriptionEngineTelnyxConfigTranscriptionModel
{
    OpenAIWhisperTiny, OpenAIWhisperLargeV3Turbo
}sealed class TranscriptionEngineTelnyxConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineTelnyxConfigTranscriptionModel>
{
    public override TranscriptionEngineTelnyxConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai/whisper-tiny"=>TranscriptionEngineTelnyxConfigTranscriptionModel.OpenAIWhisperTiny,
            "openai/whisper-large-v3-turbo"=>TranscriptionEngineTelnyxConfigTranscriptionModel.OpenAIWhisperLargeV3Turbo,
            _ =>(TranscriptionEngineTelnyxConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineTelnyxConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineTelnyxConfigTranscriptionModel.OpenAIWhisperTiny=>"openai/whisper-tiny",
            TranscriptionEngineTelnyxConfigTranscriptionModel.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}