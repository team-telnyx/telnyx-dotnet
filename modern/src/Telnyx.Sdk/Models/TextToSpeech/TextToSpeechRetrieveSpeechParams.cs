using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TextToSpeech;

/// <summary>
/// Open a WebSocket connection to stream text and receive synthesized audio in real
/// time. Authentication is provided via the standard `Authorization: Bearer &lt;API_KEY&gt;`
/// header. Send JSON frames with text to synthesize; receive JSON frames containing
/// base64-encoded audio chunks.
///
/// <para>Supported providers: `aws`, `telnyx`, `azure`, `minimax`, `resemble`, `elevenlabs`,
/// `xai`, `humain`, `soniox`.</para>
///
/// <para>**Connection flow:** 1. Open WebSocket with query parameters specifying
/// provider, voice, and model. 2. Send an initial handshake message `{"text": " "}`
/// (single space) with optional `voice_settings` to initialize the session. 3. Send
/// text messages as `{"text": "Hello world"}`. 4. Receive audio chunks as JSON frames
/// with base64-encoded audio. 5. A final frame with `isFinal: true` indicates the
/// end of audio for the current text.</para>
///
/// <para>To interrupt and restart synthesis mid-stream, send `{"force": true}` —
/// the current worker is stopped and a new one is started.</para>
///
/// <para>**Note:** The Telnyx `Ultra` model is not available over WebSocket. Use
/// the HTTP POST `/text-to-speech/speech` endpoint instead.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TextToSpeechRetrieveSpeechParams : ParamsBase
{
    /// <summary>
    /// Audio output format override. Supported for Telnyx models. The `Ultra` model
    /// outputs PCM at 24kHz s16le or MP3 at 128kbps 24kHz.
    /// </summary>
    public ApiEnum<string, TextToSpeechRetrieveSpeechParamsAudioFormat>? AudioFormat {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TextToSpeechRetrieveSpeechParamsAudioFormat>>(
                "audio_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("audio_format", value);
        }
    }

    /// <summary>
    /// When `true`, bypass the audio cache and generate fresh audio.
    /// </summary>
    public bool? DisableCache {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "disable_cache"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("disable_cache", value);
        }
    }

    /// <summary>
    /// Model identifier for the chosen provider. Examples: `Ultra`, `KokoroTTS` (Telnyx);
    /// `Polly.Generative` (AWS).
    /// </summary>
    public string? ModelID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "model_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("model_id", value);
        }
    }

    /// <summary>
    /// TTS provider. Defaults to `telnyx` if not specified. Ignored when `voice`
    /// is provided.
    /// </summary>
    public ApiEnum<string, TextToSpeechRetrieveSpeechParamsProvider>? Provider {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TextToSpeechRetrieveSpeechParamsProvider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("provider", value);
        }
    }

    /// <summary>
    /// Client-provided socket identifier for tracking. If not provided, one is generated server-side.
    /// </summary>
    public string? SocketID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "socket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("socket_id", value);
        }
    }

    /// <summary>
    /// Voice identifier in the format `provider.model_id.voice_id` or `provider.voice_id`
    /// (e.g. `Telnyx.Ultra.&lt;voice_id&gt;`, `Telnyx.Bayan.Ahmed`, `Telnyx.Sukhan.urdu-professor`,
    /// or `azure.en-US-AvaMultilingualNeural`). When provided, the `provider`, `model_id`,
    /// and `voice_id` are extracted automatically. Takes precedence over individual
    /// `provider`/`model_id`/`voice_id` parameters.
    /// </summary>
    public string? Voice {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("voice", value);
        }
    }

    /// <summary>
    /// Voice identifier for the chosen provider.
    /// </summary>
    public string? VoiceID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "voice_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("voice_id", value);
        }
    }

    public TextToSpeechRetrieveSpeechParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextToSpeechRetrieveSpeechParams (
        TextToSpeechRetrieveSpeechParams textToSpeechRetrieveSpeechParams
    ) : base(textToSpeechRetrieveSpeechParams)
    {  }
    #pragma warning restore CS8618

    public TextToSpeechRetrieveSpeechParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextToSpeechRetrieveSpeechParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TextToSpeechRetrieveSpeechParams FromRawUnchecked(
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

    public virtual bool Equals(TextToSpeechRetrieveSpeechParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/text-to-speech/speech"
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
/// Audio output format override. Supported for Telnyx models. The `Ultra` model outputs
/// PCM at 24kHz s16le or MP3 at 128kbps 24kHz.
/// </summary>
[JsonConverter(typeof(TextToSpeechRetrieveSpeechParamsAudioFormatConverter))]
public enum TextToSpeechRetrieveSpeechParamsAudioFormat
{
    Pcm, Wav, Mp3
}

sealed class TextToSpeechRetrieveSpeechParamsAudioFormatConverter : JsonConverter<TextToSpeechRetrieveSpeechParamsAudioFormat>
{
    public override TextToSpeechRetrieveSpeechParamsAudioFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pcm"=>TextToSpeechRetrieveSpeechParamsAudioFormat.Pcm,
            "wav"=>TextToSpeechRetrieveSpeechParamsAudioFormat.Wav,
            "mp3"=>TextToSpeechRetrieveSpeechParamsAudioFormat.Mp3,
            _ =>(TextToSpeechRetrieveSpeechParamsAudioFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextToSpeechRetrieveSpeechParamsAudioFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TextToSpeechRetrieveSpeechParamsAudioFormat.Pcm=>"pcm",
            TextToSpeechRetrieveSpeechParamsAudioFormat.Wav=>"wav",
            TextToSpeechRetrieveSpeechParamsAudioFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// TTS provider. Defaults to `telnyx` if not specified. Ignored when `voice` is provided.
/// </summary>
[JsonConverter(typeof(TextToSpeechRetrieveSpeechParamsProviderConverter))]
public enum TextToSpeechRetrieveSpeechParamsProvider
{
    Aws, Telnyx, Azure, Elevenlabs, Minimax, Resemble, Xai, Humain, Soniox
}

sealed class TextToSpeechRetrieveSpeechParamsProviderConverter : JsonConverter<TextToSpeechRetrieveSpeechParamsProvider>
{
    public override TextToSpeechRetrieveSpeechParamsProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>TextToSpeechRetrieveSpeechParamsProvider.Aws,
            "telnyx"=>TextToSpeechRetrieveSpeechParamsProvider.Telnyx,
            "azure"=>TextToSpeechRetrieveSpeechParamsProvider.Azure,
            "elevenlabs"=>TextToSpeechRetrieveSpeechParamsProvider.Elevenlabs,
            "minimax"=>TextToSpeechRetrieveSpeechParamsProvider.Minimax,
            "resemble"=>TextToSpeechRetrieveSpeechParamsProvider.Resemble,
            "xai"=>TextToSpeechRetrieveSpeechParamsProvider.Xai,
            "humain"=>TextToSpeechRetrieveSpeechParamsProvider.Humain,
            "soniox"=>TextToSpeechRetrieveSpeechParamsProvider.Soniox,
            _ =>(TextToSpeechRetrieveSpeechParamsProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextToSpeechRetrieveSpeechParamsProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TextToSpeechRetrieveSpeechParamsProvider.Aws=>"aws",
            TextToSpeechRetrieveSpeechParamsProvider.Telnyx=>"telnyx",
            TextToSpeechRetrieveSpeechParamsProvider.Azure=>"azure",
            TextToSpeechRetrieveSpeechParamsProvider.Elevenlabs=>"elevenlabs",
            TextToSpeechRetrieveSpeechParamsProvider.Minimax=>"minimax",
            TextToSpeechRetrieveSpeechParamsProvider.Resemble=>"resemble",
            TextToSpeechRetrieveSpeechParamsProvider.Xai=>"xai",
            TextToSpeechRetrieveSpeechParamsProvider.Humain=>"humain",
            TextToSpeechRetrieveSpeechParamsProvider.Soniox=>"soniox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}