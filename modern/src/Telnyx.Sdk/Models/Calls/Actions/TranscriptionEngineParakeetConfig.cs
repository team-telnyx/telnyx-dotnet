using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineParakeetConfig, TranscriptionEngineParakeetConfigFromRaw>))]
public sealed record class TranscriptionEngineParakeetConfig : JsonModel
{
    /// <summary>
    /// Whether to send also interim results. If set to false, only final results
    /// will be sent.
    /// </summary>
    public bool? InterimResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "interim_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interim_results", value);
        }
    }

    /// <summary>
    /// Engine identifier for Parakeet transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineParakeetConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineParakeetConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineParakeetConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineParakeetConfigTranscriptionModel>>(
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
        _ = this.InterimResults;
        this.TranscriptionEngine?.Validate();
        this.TranscriptionModel?.Validate();
    }

    public TranscriptionEngineParakeetConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineParakeetConfig (
        TranscriptionEngineParakeetConfig transcriptionEngineParakeetConfig
    ) : base(transcriptionEngineParakeetConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineParakeetConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineParakeetConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineParakeetConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineParakeetConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineParakeetConfigFromRaw : IFromRawJson<TranscriptionEngineParakeetConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineParakeetConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineParakeetConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine identifier for Parakeet transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineParakeetConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineParakeetConfigTranscriptionEngine
{
    Parakeet
}sealed class TranscriptionEngineParakeetConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineParakeetConfigTranscriptionEngine>
{
    public override TranscriptionEngineParakeetConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Parakeet"=>TranscriptionEngineParakeetConfigTranscriptionEngine.Parakeet,
            _ =>(TranscriptionEngineParakeetConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineParakeetConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineParakeetConfigTranscriptionEngine.Parakeet=>"Parakeet",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineParakeetConfigTranscriptionModelConverter))]
public enum TranscriptionEngineParakeetConfigTranscriptionModel
{
    NvidiaParakeetV3, OmiHealthOmiMedSttV1
}sealed class TranscriptionEngineParakeetConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineParakeetConfigTranscriptionModel>
{
    public override TranscriptionEngineParakeetConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nvidia/parakeet-v3"=>TranscriptionEngineParakeetConfigTranscriptionModel.NvidiaParakeetV3,
            "omi-health/omi-med-stt-v1"=>TranscriptionEngineParakeetConfigTranscriptionModel.OmiHealthOmiMedSttV1,
            _ =>(TranscriptionEngineParakeetConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineParakeetConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineParakeetConfigTranscriptionModel.NvidiaParakeetV3=>"nvidia/parakeet-v3",
            TranscriptionEngineParakeetConfigTranscriptionModel.OmiHealthOmiMedSttV1=>"omi-health/omi-med-stt-v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}