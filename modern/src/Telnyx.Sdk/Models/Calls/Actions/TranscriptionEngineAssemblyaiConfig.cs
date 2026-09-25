using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineAssemblyaiConfig, TranscriptionEngineAssemblyaiConfigFromRaw>))]
public sealed record class TranscriptionEngineAssemblyaiConfig : JsonModel
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
    /// Engine identifier for AssemblyAI transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineAssemblyaiConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineAssemblyaiConfigTranscriptionEngine>>(
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
    /// The model to use for transcription. `assemblyai/universal-streaming` is a
    /// legacy alias of `assemblyai/universal-3-5-pro` and resolves to the same model.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineAssemblyaiConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineAssemblyaiConfigTranscriptionModel>>(
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

    public TranscriptionEngineAssemblyaiConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineAssemblyaiConfig (
        TranscriptionEngineAssemblyaiConfig transcriptionEngineAssemblyaiConfig
    ) : base(transcriptionEngineAssemblyaiConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineAssemblyaiConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineAssemblyaiConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineAssemblyaiConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineAssemblyaiConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineAssemblyaiConfigFromRaw : IFromRawJson<TranscriptionEngineAssemblyaiConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineAssemblyaiConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineAssemblyaiConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine identifier for AssemblyAI transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAssemblyaiConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineAssemblyaiConfigTranscriptionEngine
{
    AssemblyAI
}sealed class TranscriptionEngineAssemblyaiConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineAssemblyaiConfigTranscriptionEngine>
{
    public override TranscriptionEngineAssemblyaiConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AssemblyAI"=>TranscriptionEngineAssemblyaiConfigTranscriptionEngine.AssemblyAI,
            _ =>(TranscriptionEngineAssemblyaiConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAssemblyaiConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAssemblyaiConfigTranscriptionEngine.AssemblyAI=>"AssemblyAI",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription. `assemblyai/universal-streaming` is a legacy
/// alias of `assemblyai/universal-3-5-pro` and resolves to the same model.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAssemblyaiConfigTranscriptionModelConverter))]
public enum TranscriptionEngineAssemblyaiConfigTranscriptionModel
{
    AssemblyaiUniversal3_5Pro, AssemblyaiUniversalStreaming
}sealed class TranscriptionEngineAssemblyaiConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineAssemblyaiConfigTranscriptionModel>
{
    public override TranscriptionEngineAssemblyaiConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "assemblyai/universal-3-5-pro"=>TranscriptionEngineAssemblyaiConfigTranscriptionModel.AssemblyaiUniversal3_5Pro,
            "assemblyai/universal-streaming"=>TranscriptionEngineAssemblyaiConfigTranscriptionModel.AssemblyaiUniversalStreaming,
            _ =>(TranscriptionEngineAssemblyaiConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAssemblyaiConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAssemblyaiConfigTranscriptionModel.AssemblyaiUniversal3_5Pro=>"assemblyai/universal-3-5-pro",
            TranscriptionEngineAssemblyaiConfigTranscriptionModel.AssemblyaiUniversalStreaming=>"assemblyai/universal-streaming",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}