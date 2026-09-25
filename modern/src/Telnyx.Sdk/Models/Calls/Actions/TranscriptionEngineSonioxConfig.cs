using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineSonioxConfig, TranscriptionEngineSonioxConfigFromRaw>))]
public sealed record class TranscriptionEngineSonioxConfig : JsonModel
{
    /// <summary>
    /// Engine identifier for Soniox transcription service
    /// </summary>
    public required ApiEnum<string, TranscriptionEngineSonioxConfigTranscriptionEngine> TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TranscriptionEngineSonioxConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init { this._rawData.Set("transcription_engine", value); }
    }

    /// <summary>
    /// When true, Soniox emits end-of-utterance events at the cadence configured
    /// by `max_endpoint_delay_ms`.
    /// </summary>
    public bool? EnableEndpointDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_endpoint_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_endpoint_detection", value);
        }
    }

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
    /// ISO 639-1 language hint (e.g. `en`, `es`), or `auto` to omit the hint and
    /// let Soniox auto-detect supported languages multilingually.
    /// </summary>
    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Maximum silence (in milliseconds) before Soniox emits an end-of-utterance
    /// event. Only honored when `enable_endpoint_detection` is true. Range: 500-3000 ms.
    /// </summary>
    public long? MaxEndpointDelayMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_endpoint_delay_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_endpoint_delay_ms", value);
        }
    }

    /// <summary>
    /// The model to use for transcription.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineSonioxConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineSonioxConfigTranscriptionModel>>(
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
        this.TranscriptionEngine.Validate();
        _ = this.EnableEndpointDetection;
        _ = this.InterimResults;
        _ = this.Language;
        _ = this.MaxEndpointDelayMs;
        this.TranscriptionModel?.Validate();
    }

    public TranscriptionEngineSonioxConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineSonioxConfig (
        TranscriptionEngineSonioxConfig transcriptionEngineSonioxConfig
    ) : base(transcriptionEngineSonioxConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineSonioxConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineSonioxConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineSonioxConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineSonioxConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TranscriptionEngineSonioxConfig (
        ApiEnum<string, TranscriptionEngineSonioxConfigTranscriptionEngine> transcriptionEngine
    ) : this()
    { this.TranscriptionEngine = transcriptionEngine; }
}

class TranscriptionEngineSonioxConfigFromRaw : IFromRawJson<TranscriptionEngineSonioxConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineSonioxConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineSonioxConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine identifier for Soniox transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineSonioxConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineSonioxConfigTranscriptionEngine
{
    Soniox
}sealed class TranscriptionEngineSonioxConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineSonioxConfigTranscriptionEngine>
{
    public override TranscriptionEngineSonioxConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Soniox"=>TranscriptionEngineSonioxConfigTranscriptionEngine.Soniox,
            _ =>(TranscriptionEngineSonioxConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineSonioxConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineSonioxConfigTranscriptionEngine.Soniox=>"Soniox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineSonioxConfigTranscriptionModelConverter))]
public enum TranscriptionEngineSonioxConfigTranscriptionModel
{
    SonioxSttRtV4
}sealed class TranscriptionEngineSonioxConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineSonioxConfigTranscriptionModel>
{
    public override TranscriptionEngineSonioxConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "soniox/stt-rt-v4"=>TranscriptionEngineSonioxConfigTranscriptionModel.SonioxSttRtV4,
            _ =>(TranscriptionEngineSonioxConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineSonioxConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineSonioxConfigTranscriptionModel.SonioxSttRtV4=>"soniox/stt-rt-v4",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}