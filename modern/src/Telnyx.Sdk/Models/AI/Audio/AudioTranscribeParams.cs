using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Audio;

/// <summary>
/// Transcribe speech to text. This endpoint is consistent with the [OpenAI Transcription
/// API](https://platform.openai.com/docs/api-reference/audio/createTranscription)
/// and may be used with the OpenAI JS or Python SDK.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AudioTranscribeParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// ID of the model to use. `distil-whisper/distil-large-v2` is lower latency
    /// but English-only. `openai/whisper-large-v3-turbo` is multi-lingual but slightly
    /// higher latency. The `deepgram/*` models only accept mp3/wav files: `deepgram/nova-3`
    /// covers ~49 languages plus `multi` and `deepgram/nova-2` covers ~33, while
    /// the `-medical` variants are tuned for clinical vocabulary and accept English
    /// only (`en` and its regional variants, e.g. `en-US`, `en-GB`). `nvidia/parakeet-v3`
    /// is multilingual with automatic language detection; `omi-health/omi-med-stt-v1`
    /// is a medical model, English only.
    /// </summary>
    public required ApiEnum<string, Model> Model {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Model>>(
                "model"
            );
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// The audio file object to transcribe, in one of these formats: flac, mp3, mp4,
    /// mpeg, mpga, m4a, ogg, wav, or webm. File uploads are limited to 100 MB. Cannot
    /// be used together with `file_url`. Note: the `deepgram/*` models only support
    /// mp3 and wav formats.
    /// </summary>
    public BinaryContent? File {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BinaryContent>(
                "file"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("file", value);
        }
    }

    /// <summary>
    /// Link to audio file in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a,
    /// ogg, wav, or webm. Support for hosted files is limited to 100MB. Cannot be
    /// used together with `file`. Note: the `deepgram/*` models only support mp3
    /// and wav formats.
    /// </summary>
    public string? FileUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "file_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("file_url", value);
        }
    }

    /// <summary>
    /// The language of the audio to be transcribed. `deepgram/nova-3` supports ~49
    /// languages plus `multi`, and `deepgram/nova-2` supports ~33 plus `multi`;
    /// the `-medical` variants are English only (`en` and its regional variants,
    /// e.g. `en-US`, `en-GB`). Deepgram models validate on the base language and
    /// forward the full tag, so regional variants such as `de-CH` and `pt-BR` are
    /// accepted where the base language is supported; an unsupported language returns
    /// a 400. For `openai/whisper-large-v3-turbo`, supports multiple languages. `distil-whisper/distil-large-v2`
    /// does not support language parameter. `nvidia/parakeet-v3` detects the language
    /// automatically; `omi-health/omi-med-stt-v1` is English only.
    /// </summary>
    public string? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    /// <summary>
    /// Additional model-specific configuration parameters. Only allowed with the
    /// `deepgram/*` models. Can include Deepgram-specific options such as `smart_format`,
    /// `punctuate`, `diarize`, `utterance`, `numerals`, and `language`. If `language`
    /// is provided both as a top-level parameter and in `model_config`, the top-level
    /// parameter takes precedence.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ModelConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "model_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "model_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The format of the transcript output. Use `verbose_json` to take advantage
    /// of timestamps.
    /// </summary>
    public ApiEnum<string, ResponseFormat>? ResponseFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ResponseFormat>>(
                "response_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("response_format", value);
        }
    }

    /// <summary>
    /// The timestamp granularities to populate for this transcription. `response_format`
    /// must be set verbose_json to use timestamp granularities. Currently `segment`
    /// is supported.
    /// </summary>
    public ApiEnum<string, TimestampGranularities>? TimestampGranularities {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TimestampGranularities>>(
                "timestamp_granularities[]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timestamp_granularities[]", value);
        }
    }

    public AudioTranscribeParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioTranscribeParams (
        AudioTranscribeParams audioTranscribeParams
    ) : base(audioTranscribeParams)
    { this._rawBodyData = new(audioTranscribeParams._rawBodyData); }
    #pragma warning restore CS8618

    public AudioTranscribeParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioTranscribeParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AudioTranscribeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AudioTranscribeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/audio/transcriptions"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    { return MultipartJsonSerializer.Serialize(RawBodyData) ; }

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
/// ID of the model to use. `distil-whisper/distil-large-v2` is lower latency but
/// English-only. `openai/whisper-large-v3-turbo` is multi-lingual but slightly higher
/// latency. The `deepgram/*` models only accept mp3/wav files: `deepgram/nova-3`
/// covers ~49 languages plus `multi` and `deepgram/nova-2` covers ~33, while the
/// `-medical` variants are tuned for clinical vocabulary and accept English only
/// (`en` and its regional variants, e.g. `en-US`, `en-GB`). `nvidia/parakeet-v3`
/// is multilingual with automatic language detection; `omi-health/omi-med-stt-v1`
/// is a medical model, English only.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    DistilWhisperDistilLargeV2,
    OpenAIWhisperLargeV3Turbo,
    DeepgramNova2,
    DeepgramNova2Medical,
    DeepgramNova3,
    DeepgramNova3Medical,
    NvidiaParakeetV3,
    OmiHealthOmiMedSttV1
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
            "distil-whisper/distil-large-v2"=>Model.DistilWhisperDistilLargeV2,
            "openai/whisper-large-v3-turbo"=>Model.OpenAIWhisperLargeV3Turbo,
            "deepgram/nova-2"=>Model.DeepgramNova2,
            "deepgram/nova-2-medical"=>Model.DeepgramNova2Medical,
            "deepgram/nova-3"=>Model.DeepgramNova3,
            "deepgram/nova-3-medical"=>Model.DeepgramNova3Medical,
            "nvidia/parakeet-v3"=>Model.NvidiaParakeetV3,
            "omi-health/omi-med-stt-v1"=>Model.OmiHealthOmiMedSttV1,
            _ =>(Model)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Model value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Model.DistilWhisperDistilLargeV2=>"distil-whisper/distil-large-v2",
            Model.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            Model.DeepgramNova2=>"deepgram/nova-2",
            Model.DeepgramNova2Medical=>"deepgram/nova-2-medical",
            Model.DeepgramNova3=>"deepgram/nova-3",
            Model.DeepgramNova3Medical=>"deepgram/nova-3-medical",
            Model.NvidiaParakeetV3=>"nvidia/parakeet-v3",
            Model.OmiHealthOmiMedSttV1=>"omi-health/omi-med-stt-v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The format of the transcript output. Use `verbose_json` to take advantage of timestamps.
/// </summary>
[JsonConverter(typeof(ResponseFormatConverter))]
public enum ResponseFormat
{
    Json, VerboseJson
}

sealed class ResponseFormatConverter : JsonConverter<ResponseFormat>
{
    public override ResponseFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json"=>ResponseFormat.Json,
            "verbose_json"=>ResponseFormat.VerboseJson,
            _ =>(ResponseFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResponseFormat.Json=>"json",
            ResponseFormat.VerboseJson=>"verbose_json",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The timestamp granularities to populate for this transcription. `response_format`
/// must be set verbose_json to use timestamp granularities. Currently `segment` is supported.
/// </summary>
[JsonConverter(typeof(TimestampGranularitiesConverter))]
public enum TimestampGranularities
{
    Segment
}

sealed class TimestampGranularitiesConverter : JsonConverter<TimestampGranularities>
{
    public override TimestampGranularities Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "segment"=>TimestampGranularities.Segment,
            _ =>(TimestampGranularities)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimestampGranularities value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TimestampGranularities.Segment=>"segment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}