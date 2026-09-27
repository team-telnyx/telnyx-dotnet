using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SpeechToText;

/// <summary>
/// Open a WebSocket connection to stream audio and receive transcriptions in real-time.
/// Authentication is provided via the standard `Authorization: Bearer &lt;API_KEY&gt;` header.
///
/// <para>Supported engines: `Azure`, `Deepgram`, `Google`, `Telnyx`, `xAI`, `Speechmatics`,
/// `Soniox`, `Parakeet`, `Humain`, `Reson8`, `Cohere`.</para>
///
/// <para>**Connection flow:** 1. Open WebSocket with query parameters specifying
/// engine, input format, and language. 2. Send binary audio frames (mp3, wav, linear16,
/// or linear32 format, per `input_format`). 3. Receive JSON transcript frames with
/// `transcript`, `is_final`, and `confidence` fields. 4. Close connection when done.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpeechToTextRetrieveTranscriptionParams : ParamsBase
{
    /// <summary>
    /// The format of input audio stream.
    /// </summary>
    public required ApiEnum<string, InputFormat> InputFormat {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, InputFormat>>(
                "input_format"
            );
        }
        init { this._rawQueryData.Set("input_format", value); }
    }

    /// <summary>
    /// The transcription engine to use for processing the audio stream.
    /// </summary>
    public required ApiEnum<string, TranscriptionEngine> TranscriptionEngine {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, TranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init { this._rawQueryData.Set("transcription_engine", value); }
    }

    /// <summary>
    /// Silence duration (in milliseconds) that triggers end-of-speech detection.
    /// When set, the engine uses this value to determine when a speaker has stopped
    /// talking. Supported by `xAI`, `Deepgram`, `Google`, `Speechmatics`, and `Soniox`.
    /// `Soniox` accepts values between 500 and 3000. Other engines may not support
    /// this parameter.
    /// </summary>
    public long? Endpointing {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "endpointing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("endpointing", value);
        }
    }

    /// <summary>
    /// Whether to receive interim transcription results.
    /// </summary>
    public bool? InterimResults {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "interim_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("interim_results", value);
        }
    }

    /// <summary>
    /// A key term to boost in the transcription. The engine will be more likely
    /// to recognize this term. Can be specified multiple times for multiple terms.
    /// </summary>
    public string? Keyterm {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "keyterm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("keyterm", value);
        }
    }

    /// <summary>
    /// Comma-separated list of keywords to boost in the transcription. The engine
    /// will prioritize recognition of these words.
    /// </summary>
    public string? Keywords {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "keywords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("keywords", value);
        }
    }

    /// <summary>
    /// The language spoken in the audio stream. For `cohere/ar-stt`, this must be
    /// `ar` or `en` — unlike other engines, Cohere does not auto-detect the language,
    /// and rejects unsupported values including `auto`; omitting it defaults to `ar`.
    /// </summary>
    public string? Language {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("language", value);
        }
    }

    /// <summary>
    /// The specific model to use within the selected transcription engine.
    /// </summary>
    public ApiEnum<string, Model>? Model {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Model>>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("model", value);
        }
    }

    /// <summary>
    /// Enable redaction of sensitive information (e.g., PCI data, SSN) from transcription
    /// results. Supported values depend on the transcription engine.
    /// </summary>
    public string? Redact {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "redact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("redact", value);
        }
    }

    /// <summary>
    /// Audio sample rate in Hz. Required when `input_format` is a raw encoding (`linear16`,
    /// `linear32`) — those formats carry no header metadata. Ignored for container
    /// formats (`mp3`, `wav`), which self-describe their rate.
    /// </summary>
    public long? SampleRate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sample_rate", value);
        }
    }

    public SpeechToTextRetrieveTranscriptionParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextRetrieveTranscriptionParams (
        SpeechToTextRetrieveTranscriptionParams speechToTextRetrieveTranscriptionParams
    ) : base(speechToTextRetrieveTranscriptionParams)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextRetrieveTranscriptionParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextRetrieveTranscriptionParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpeechToTextRetrieveTranscriptionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SpeechToTextRetrieveTranscriptionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/speech-to-text/transcription"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// The format of input audio stream.
/// </summary>
[JsonConverter(typeof(InputFormatConverter))]
public enum InputFormat
{
    Mp3, Wav, Linear16, Linear32
}

sealed class InputFormatConverter : JsonConverter<InputFormat>
{
    public override InputFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3"=>InputFormat.Mp3,
            "wav"=>InputFormat.Wav,
            "linear16"=>InputFormat.Linear16,
            "linear32"=>InputFormat.Linear32,
            _ =>(InputFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, InputFormat value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InputFormat.Mp3=>"mp3",
            InputFormat.Wav=>"wav",
            InputFormat.Linear16=>"linear16",
            InputFormat.Linear32=>"linear32",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The transcription engine to use for processing the audio stream.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineConverter))]
public enum TranscriptionEngine
{
    Azure,
    Deepgram,
    Google,
    Telnyx,
    XAI,
    Speechmatics,
    Soniox,
    Parakeet,
    Humain,
    Reson8,
    Cohere
}

sealed class TranscriptionEngineConverter : JsonConverter<TranscriptionEngine>
{
    public override TranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Azure"=>TranscriptionEngine.Azure,
            "Deepgram"=>TranscriptionEngine.Deepgram,
            "Google"=>TranscriptionEngine.Google,
            "Telnyx"=>TranscriptionEngine.Telnyx,
            "xAI"=>TranscriptionEngine.XAI,
            "Speechmatics"=>TranscriptionEngine.Speechmatics,
            "Soniox"=>TranscriptionEngine.Soniox,
            "Parakeet"=>TranscriptionEngine.Parakeet,
            "Humain"=>TranscriptionEngine.Humain,
            "Reson8"=>TranscriptionEngine.Reson8,
            "Cohere"=>TranscriptionEngine.Cohere,
            _ =>(TranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngine.Azure=>"Azure",
            TranscriptionEngine.Deepgram=>"Deepgram",
            TranscriptionEngine.Google=>"Google",
            TranscriptionEngine.Telnyx=>"Telnyx",
            TranscriptionEngine.XAI=>"xAI",
            TranscriptionEngine.Speechmatics=>"Speechmatics",
            TranscriptionEngine.Soniox=>"Soniox",
            TranscriptionEngine.Parakeet=>"Parakeet",
            TranscriptionEngine.Humain=>"Humain",
            TranscriptionEngine.Reson8=>"Reson8",
            TranscriptionEngine.Cohere=>"Cohere",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The specific model to use within the selected transcription engine.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    Fast,
    DeepgramNova2,
    DeepgramNova3,
    LatestLong,
    LatestShort,
    CommandAndSearch,
    PhoneCall,
    Video,
    Default,
    MedicalConversation,
    MedicalDictation,
    OpenAIWhisperTiny,
    OpenAIWhisperLargeV3Turbo,
    XaiGrokStt,
    SpeechmaticsStandard,
    SonioxSttRtV4,
    NvidiaParakeetV3,
    OmiHealthOmiMedSttV1,
    HumainRealtime,
    Reson8Turns,
    CohereArStt
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast"=>Model.Fast,
            "deepgram/nova-2"=>Model.DeepgramNova2,
            "deepgram/nova-3"=>Model.DeepgramNova3,
            "latest_long"=>Model.LatestLong,
            "latest_short"=>Model.LatestShort,
            "command_and_search"=>Model.CommandAndSearch,
            "phone_call"=>Model.PhoneCall,
            "video"=>Model.Video,
            "default"=>Model.Default,
            "medical_conversation"=>Model.MedicalConversation,
            "medical_dictation"=>Model.MedicalDictation,
            "openai/whisper-tiny"=>Model.OpenAIWhisperTiny,
            "openai/whisper-large-v3-turbo"=>Model.OpenAIWhisperLargeV3Turbo,
            "xai/grok-stt"=>Model.XaiGrokStt,
            "speechmatics/standard"=>Model.SpeechmaticsStandard,
            "soniox/stt-rt-v4"=>Model.SonioxSttRtV4,
            "nvidia/parakeet-v3"=>Model.NvidiaParakeetV3,
            "omi-health/omi-med-stt-v1"=>Model.OmiHealthOmiMedSttV1,
            "humain/realtime"=>Model.HumainRealtime,
            "reson8/turns"=>Model.Reson8Turns,
            "cohere/ar-stt"=>Model.CohereArStt,
            _ =>(Model)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Model value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Model.Fast=>"fast",
            Model.DeepgramNova2=>"deepgram/nova-2",
            Model.DeepgramNova3=>"deepgram/nova-3",
            Model.LatestLong=>"latest_long",
            Model.LatestShort=>"latest_short",
            Model.CommandAndSearch=>"command_and_search",
            Model.PhoneCall=>"phone_call",
            Model.Video=>"video",
            Model.Default=>"default",
            Model.MedicalConversation=>"medical_conversation",
            Model.MedicalDictation=>"medical_dictation",
            Model.OpenAIWhisperTiny=>"openai/whisper-tiny",
            Model.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            Model.XaiGrokStt=>"xai/grok-stt",
            Model.SpeechmaticsStandard=>"speechmatics/standard",
            Model.SonioxSttRtV4=>"soniox/stt-rt-v4",
            Model.NvidiaParakeetV3=>"nvidia/parakeet-v3",
            Model.OmiHealthOmiMedSttV1=>"omi-health/omi-med-stt-v1",
            Model.HumainRealtime=>"humain/realtime",
            Model.Reson8Turns=>"reson8/turns",
            Model.CohereArStt=>"cohere/ar-stt",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}