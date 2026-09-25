using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TextToSpeech;

/// <summary>
/// Generate synthesized speech audio from text input. Returns audio in the requested
/// format (binary audio stream, base64-encoded JSON, or an audio URL for later retrieval).
///
/// <para>Authentication is provided via the standard `Authorization: Bearer &lt;API_KEY&gt;` header.</para>
///
/// <para>The `voice` parameter provides a convenient shorthand to specify provider,
/// model, and voice in a single string (e.g. `Telnyx.Ultra.&lt;voice_id&gt;`). Alternatively,
/// specify `provider` explicitly along with provider-specific parameters.</para>
///
/// <para>Supported providers: `aws`, `telnyx`, `azure`, `elevenlabs`, `minimax`,
/// `resemble`, `xai`, `humain`, `soniox`.</para>
///
/// <para>The Telnyx `Ultra` model supports 44 languages with emotion control, speed
/// adjustment, and volume control. Use the `telnyx` provider-specific parameters
/// to configure these features.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TextToSpeechGenerateSpeechParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// AWS Polly provider-specific parameters.
    /// </summary>
    public Aws? Aws {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Aws>(
                "aws"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("aws", value);
        }
    }

    /// <summary>
    /// Azure Cognitive Services provider-specific parameters.
    /// </summary>
    public Azure? Azure {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Azure>(
                "azure"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("azure", value);
        }
    }

    /// <summary>
    /// When `true`, bypass the audio cache and generate fresh audio.
    /// </summary>
    public bool? DisableCache {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "disable_cache"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("disable_cache", value);
        }
    }

    /// <summary>
    /// ElevenLabs provider-specific parameters.
    /// </summary>
    public Elevenlabs? Elevenlabs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Elevenlabs>(
                "elevenlabs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("elevenlabs", value);
        }
    }

    /// <summary>
    /// Humain provider-specific parameters. Unlike other providers, Humain has no
    /// format/sample-rate negotiation (output is always PCM16 24kHz mono) and no
    /// language parameter — language is fixed per voice.
    /// </summary>
    public Humain? Humain {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Humain>(
                "humain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("humain", value);
        }
    }

    /// <summary>
    /// Language code (e.g. `en-US`). Usage varies by provider.
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
    /// Minimax provider-specific parameters.
    /// </summary>
    public Minimax? Minimax {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Minimax>(
                "minimax"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("minimax", value);
        }
    }

    /// <summary>
    /// Determines the response format. `binary_output` returns raw audio bytes, `base64_output`
    /// returns base64-encoded audio in JSON.
    /// </summary>
    public ApiEnum<string, OutputType>? OutputType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OutputType>>(
                "output_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("output_type", value);
        }
    }

    /// <summary>
    /// TTS provider. Required unless `voice` is provided.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("provider", value);
        }
    }

    /// <summary>
    /// Resemble AI provider-specific parameters.
    /// </summary>
    public Resemble? Resemble {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Resemble>(
                "resemble"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("resemble", value);
        }
    }

    /// <summary>
    /// Soniox provider-specific parameters. Every voice speaks all supported languages;
    /// set `language` to the language of the text.
    /// </summary>
    public Soniox? Soniox {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Soniox>(
                "soniox"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("soniox", value);
        }
    }

    /// <summary>
    /// Telnyx provider-specific parameters. For the `Ultra` model, use `voice_speed`,
    /// `volume`, and `emotion`. `Bayan` and `Sukhan` don't use `temperature`, `volume`,
    /// or `emotion`, and don't support `voice_speed`. `Sukhan`'s `response_format`
    /// is restricted to `mp3` or `pcm` (no `wav`).
    /// </summary>
    public Telnyx? Telnyx {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Telnyx>(
                "telnyx"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("telnyx", value);
        }
    }

    /// <summary>
    /// The text to convert to speech.
    /// </summary>
    public string? Text {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("text", value);
        }
    }

    /// <summary>
    /// Text type. Use `ssml` for SSML-formatted input (supported by AWS and Azure).
    /// </summary>
    public ApiEnum<string, TextToSpeechGenerateSpeechParamsTextType>? TextType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TextToSpeechGenerateSpeechParamsTextType>>(
                "text_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("text_type", value);
        }
    }

    /// <summary>
    /// Voice identifier in the format `provider.model_id.voice_id` or `provider.voice_id`.
    /// Examples: `Telnyx.Ultra.&lt;voice_id&gt;`, `Telnyx.Bayan.Ahmed`, `Telnyx.Sukhan.urdu-professor`,
    /// `azure.en-US-AvaMultilingualNeural`, `aws.Polly.Generative.Lucia`. When provided,
    /// `provider`, `model_id`, and `voice_id` are extracted automatically and take
    /// precedence over individual parameters.
    /// </summary>
    public string? Voice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice", value);
        }
    }

    /// <summary>
    /// Provider-specific voice settings. Contents vary by provider — see provider-specific
    /// parameter objects below.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? VoiceSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "voice_settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// xAI provider-specific parameters.
    /// </summary>
    public Xai? Xai {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Xai>(
                "xai"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("xai", value);
        }
    }

    public TextToSpeechGenerateSpeechParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextToSpeechGenerateSpeechParams (
        TextToSpeechGenerateSpeechParams textToSpeechGenerateSpeechParams
    ) : base(textToSpeechGenerateSpeechParams)
    { this._rawBodyData = new(textToSpeechGenerateSpeechParams._rawBodyData); }
    #pragma warning restore CS8618

    public TextToSpeechGenerateSpeechParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextToSpeechGenerateSpeechParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TextToSpeechGenerateSpeechParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TextToSpeechGenerateSpeechParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/text-to-speech/speech"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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
/// AWS Polly provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Aws, AwsFromRaw>))]
public sealed record class Aws : JsonModel
{
    /// <summary>
    /// Language code (e.g. `en-US`, `es-ES`).
    /// </summary>
    public string? LanguageCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language_code", value);
        }
    }

    /// <summary>
    /// List of lexicon names to apply.
    /// </summary>
    public IReadOnlyList<string>? LexiconNames {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "lexicon_names"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "lexicon_names",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Audio output format.
    /// </summary>
    public string? OutputFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "output_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("output_format", value);
        }
    }

    /// <summary>
    /// Audio sample rate.
    /// </summary>
    public string? SampleRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <summary>
    /// Input text type.
    /// </summary>
    public ApiEnum<string, TextType>? TextType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextType>>(
                "text_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LanguageCode;
        _ = this.LexiconNames;
        _ = this.OutputFormat;
        _ = this.SampleRate;
        this.TextType?.Validate();
    }

    public Aws ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Aws (Aws aws) : base(aws)
    {  }
    #pragma warning restore CS8618

    public Aws (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Aws (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AwsFromRaw.FromRawUnchecked"/>
    public static Aws FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AwsFromRaw : IFromRawJson<Aws>
{
    /// <inheritdoc/>
    public Aws FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Aws.FromRawUnchecked(rawData);
}

/// <summary>
/// Input text type.
/// </summary>
[JsonConverter(typeof(TextTypeConverter))]
public enum TextType
{
    Text, Ssml
}

sealed class TextTypeConverter : JsonConverter<TextType>
{
    public override TextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "text"=>TextType.Text, "ssml"=>TextType.Ssml, _ =>(TextType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, TextType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TextType.Text=>"text",
            TextType.Ssml=>"ssml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Azure Cognitive Services provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Azure, AzureFromRaw>))]
public sealed record class Azure : JsonModel
{
    /// <summary>
    /// Custom Azure API key. If not provided, the default Telnyx key is used.
    /// </summary>
    public string? ApiKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key", value);
        }
    }

    /// <summary>
    /// Custom Azure deployment ID.
    /// </summary>
    public string? DeploymentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "deployment_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deployment_id", value);
        }
    }

    /// <summary>
    /// Azure audio effect to apply.
    /// </summary>
    public string? Effect {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "effect"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("effect", value);
        }
    }

    /// <summary>
    /// Voice gender preference.
    /// </summary>
    public string? Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gender"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gender", value);
        }
    }

    /// <summary>
    /// Language code (e.g. `en-US`).
    /// </summary>
    public string? LanguageCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language_code", value);
        }
    }

    /// <summary>
    /// Azure audio output format.
    /// </summary>
    public string? OutputFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "output_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("output_format", value);
        }
    }

    /// <summary>
    /// Azure region (e.g. `eastus`, `westeurope`).
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Input text type. Use `ssml` for SSML-formatted input.
    /// </summary>
    public ApiEnum<string, AzureTextType>? TextType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AzureTextType>>(
                "text_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.DeploymentID;
        _ = this.Effect;
        _ = this.Gender;
        _ = this.LanguageCode;
        _ = this.OutputFormat;
        _ = this.Region;
        this.TextType?.Validate();
    }

    public Azure ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Azure (Azure azure) : base(azure)
    {  }
    #pragma warning restore CS8618

    public Azure (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Azure (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AzureFromRaw.FromRawUnchecked"/>
    public static Azure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AzureFromRaw : IFromRawJson<Azure>
{
    /// <inheritdoc/>
    public Azure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Azure.FromRawUnchecked(rawData);
}

/// <summary>
/// Input text type. Use `ssml` for SSML-formatted input.
/// </summary>
[JsonConverter(typeof(AzureTextTypeConverter))]
public enum AzureTextType
{
    Text, Ssml
}

sealed class AzureTextTypeConverter : JsonConverter<AzureTextType>
{
    public override AzureTextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text"=>AzureTextType.Text,
            "ssml"=>AzureTextType.Ssml,
            _ =>(AzureTextType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AzureTextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AzureTextType.Text=>"text",
            AzureTextType.Ssml=>"ssml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// ElevenLabs provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Elevenlabs, ElevenlabsFromRaw>))]
public sealed record class Elevenlabs : JsonModel
{
    /// <summary>
    /// Custom ElevenLabs API key. If not provided, the default Telnyx key is used.
    /// </summary>
    public string? ApiKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key", value);
        }
    }

    /// <summary>
    /// Language code.
    /// </summary>
    public string? LanguageCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language_code", value);
        }
    }

    /// <summary>
    /// ElevenLabs voice settings (stability, similarity_boost, etc.).
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "voice_settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.LanguageCode;
        _ = this.VoiceSettings;
    }

    public Elevenlabs ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Elevenlabs (Elevenlabs elevenlabs) : base(elevenlabs)
    {  }
    #pragma warning restore CS8618

    public Elevenlabs (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Elevenlabs (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ElevenlabsFromRaw.FromRawUnchecked"/>
    public static Elevenlabs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ElevenlabsFromRaw : IFromRawJson<Elevenlabs>
{
    /// <inheritdoc/>
    public Elevenlabs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Elevenlabs.FromRawUnchecked(rawData);
}

/// <summary>
/// Humain provider-specific parameters. Unlike other providers, Humain has no format/sample-rate
/// negotiation (output is always PCM16 24kHz mono) and no language parameter — language
/// is fixed per voice.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Humain, HumainFromRaw>))]
public sealed record class Humain : JsonModel
{
    /// <summary>
    /// Humain voice identifier.
    /// </summary>
    public required ApiEnum<string, VoiceID> VoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VoiceID>>(
                "voice_id"
            );
        }
        init { this._rawData.Set("voice_id", value); }
    }

    /// <summary>
    /// Time-to-first-byte eagerness, trading synthesis latency for quality.
    /// </summary>
    public float? TtfbEagerness {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "ttfb_eagerness"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ttfb_eagerness", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.VoiceID.Validate();
        _ = this.TtfbEagerness;
    }

    public Humain ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Humain (Humain humain) : base(humain)
    {  }
    #pragma warning restore CS8618

    public Humain (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Humain (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HumainFromRaw.FromRawUnchecked"/>
    public static Humain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Humain (ApiEnum<string, VoiceID> voiceID) : this()
    { this.VoiceID = voiceID; }
}

class HumainFromRaw : IFromRawJson<Humain>
{
    /// <inheritdoc/>
    public Humain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Humain.FromRawUnchecked(rawData);
}

/// <summary>
/// Humain voice identifier.
/// </summary>
[JsonConverter(typeof(VoiceIDConverter))]
public enum VoiceID
{
    SaraEn, AbdulazizEn, SaraAr, AbdulazizAr, NourahAr, AbdullahAr
}

sealed class VoiceIDConverter : JsonConverter<VoiceID>
{
    public override VoiceID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sara-en"=>VoiceID.SaraEn,
            "abdulaziz-en"=>VoiceID.AbdulazizEn,
            "sara-ar"=>VoiceID.SaraAr,
            "abdulaziz-ar"=>VoiceID.AbdulazizAr,
            "nourah-ar"=>VoiceID.NourahAr,
            "abdullah-ar"=>VoiceID.AbdullahAr,
            _ =>(VoiceID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, VoiceID value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceID.SaraEn=>"sara-en",
            VoiceID.AbdulazizEn=>"abdulaziz-en",
            VoiceID.SaraAr=>"sara-ar",
            VoiceID.AbdulazizAr=>"abdulaziz-ar",
            VoiceID.NourahAr=>"nourah-ar",
            VoiceID.AbdullahAr=>"abdullah-ar",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Minimax provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Minimax, MinimaxFromRaw>))]
public sealed record class Minimax : JsonModel
{
    /// <summary>
    /// Language code to boost pronunciation for.
    /// </summary>
    public string? LanguageBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language_boost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language_boost", value);
        }
    }

    /// <summary>
    /// Pitch adjustment.
    /// </summary>
    public long? Pitch {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "pitch"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pitch", value);
        }
    }

    /// <summary>
    /// Audio output format.
    /// </summary>
    public string? ResponseFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "response_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("response_format", value);
        }
    }

    /// <summary>
    /// Speech speed multiplier.
    /// </summary>
    public float? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <summary>
    /// Volume level.
    /// </summary>
    public float? Vol {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "vol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vol", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LanguageBoost;
        _ = this.Pitch;
        _ = this.ResponseFormat;
        _ = this.Speed;
        _ = this.Vol;
    }

    public Minimax ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Minimax (Minimax minimax) : base(minimax)
    {  }
    #pragma warning restore CS8618

    public Minimax (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Minimax (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MinimaxFromRaw.FromRawUnchecked"/>
    public static Minimax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MinimaxFromRaw : IFromRawJson<Minimax>
{
    /// <inheritdoc/>
    public Minimax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Minimax.FromRawUnchecked(rawData);
}

/// <summary>
/// Determines the response format. `binary_output` returns raw audio bytes, `base64_output`
/// returns base64-encoded audio in JSON.
/// </summary>
[JsonConverter(typeof(OutputTypeConverter))]
public enum OutputType
{
    BinaryOutput, Base64Output
}

sealed class OutputTypeConverter : JsonConverter<OutputType>
{
    public override OutputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "binary_output"=>OutputType.BinaryOutput,
            "base64_output"=>OutputType.Base64Output,
            _ =>(OutputType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, OutputType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutputType.BinaryOutput=>"binary_output",
            OutputType.Base64Output=>"base64_output",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// TTS provider. Required unless `voice` is provided.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Aws, Telnyx, Azure, Elevenlabs, Minimax, Resemble, Xai, Humain, Soniox
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>Provider.Aws,
            "telnyx"=>Provider.Telnyx,
            "azure"=>Provider.Azure,
            "elevenlabs"=>Provider.Elevenlabs,
            "minimax"=>Provider.Minimax,
            "resemble"=>Provider.Resemble,
            "xai"=>Provider.Xai,
            "humain"=>Provider.Humain,
            "soniox"=>Provider.Soniox,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Aws=>"aws",
            Provider.Telnyx=>"telnyx",
            Provider.Azure=>"azure",
            Provider.Elevenlabs=>"elevenlabs",
            Provider.Minimax=>"minimax",
            Provider.Resemble=>"resemble",
            Provider.Xai=>"xai",
            Provider.Humain=>"humain",
            Provider.Soniox=>"soniox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Resemble AI provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Resemble, ResembleFromRaw>))]
public sealed record class Resemble : JsonModel
{
    /// <summary>
    /// Custom Resemble API key.
    /// </summary>
    public string? ApiKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key", value);
        }
    }

    /// <summary>
    /// Audio output format.
    /// </summary>
    public string? Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// Synthesis precision.
    /// </summary>
    public string? Precision {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "precision"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("precision", value);
        }
    }

    /// <summary>
    /// Audio sample rate.
    /// </summary>
    public string? SampleRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.Format;
        _ = this.Precision;
        _ = this.SampleRate;
    }

    public Resemble ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Resemble (Resemble resemble) : base(resemble)
    {  }
    #pragma warning restore CS8618

    public Resemble (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Resemble (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResembleFromRaw.FromRawUnchecked"/>
    public static Resemble FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ResembleFromRaw : IFromRawJson<Resemble>
{
    /// <inheritdoc/>
    public Resemble FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Resemble.FromRawUnchecked(rawData);
}

/// <summary>
/// Soniox provider-specific parameters. Every voice speaks all supported languages;
/// set `language` to the language of the text.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Soniox, SonioxFromRaw>))]
public sealed record class Soniox : JsonModel
{
    /// <summary>
    /// Soniox voice name from the [voices listing](https://developers.telnyx.com/api-reference/text-to-speech-commands/list-available-voices),
    /// for example `Emma`.
    /// </summary>
    public required string VoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "voice_id"
            );
        }
        init { this._rawData.Set("voice_id", value); }
    }

    /// <summary>
    /// Audio output format.
    /// </summary>
    public ApiEnum<string, AudioFormat>? AudioFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudioFormat>>(
                "audio_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("audio_format", value);
        }
    }

    /// <summary>
    /// Two-letter ISO 639-1 code of the text.
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
    /// Soniox model.
    /// </summary>
    public ApiEnum<string, ModelID>? ModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelID>>(
                "model_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model_id", value);
        }
    }

    /// <summary>
    /// Shortens the pauses between words.
    /// </summary>
    public bool? ReduceSilence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reduce_silence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reduce_silence", value);
        }
    }

    /// <summary>
    /// Audio sample rate in Hz. `pcm_mulaw` and `pcm_alaw` accept 8000 only; `mp3`
    /// does not accept 8000. Defaults to 24000, or 8000 for `pcm_mulaw` and `pcm_alaw`.
    /// </summary>
    public ApiEnum<long, SampleRate>? SampleRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, SampleRate>>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <summary>
    /// Speaking rate. 1.0 is normal speed.
    /// </summary>
    public float? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.VoiceID;
        this.AudioFormat?.Validate();
        _ = this.Language;
        this.ModelID?.Validate();
        _ = this.ReduceSilence;
        this.SampleRate?.Validate();
        _ = this.Speed;
    }

    public Soniox ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Soniox (Soniox soniox) : base(soniox)
    {  }
    #pragma warning restore CS8618

    public Soniox (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Soniox (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SonioxFromRaw.FromRawUnchecked"/>
    public static Soniox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Soniox (string voiceID) : this()
    { this.VoiceID = voiceID; }
}

class SonioxFromRaw : IFromRawJson<Soniox>
{
    /// <inheritdoc/>
    public Soniox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Soniox.FromRawUnchecked(rawData);
}

/// <summary>
/// Audio output format.
/// </summary>
[JsonConverter(typeof(AudioFormatConverter))]
public enum AudioFormat
{
    Mp3, Wav, PcmS16le, PcmMulaw, PcmAlaw
}

sealed class AudioFormatConverter : JsonConverter<AudioFormat>
{
    public override AudioFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3"=>AudioFormat.Mp3,
            "wav"=>AudioFormat.Wav,
            "pcm_s16le"=>AudioFormat.PcmS16le,
            "pcm_mulaw"=>AudioFormat.PcmMulaw,
            "pcm_alaw"=>AudioFormat.PcmAlaw,
            _ =>(AudioFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AudioFormat value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AudioFormat.Mp3=>"mp3",
            AudioFormat.Wav=>"wav",
            AudioFormat.PcmS16le=>"pcm_s16le",
            AudioFormat.PcmMulaw=>"pcm_mulaw",
            AudioFormat.PcmAlaw=>"pcm_alaw",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Soniox model.
/// </summary>
[JsonConverter(typeof(ModelIDConverter))]
public enum ModelID
{
    TtsRtV2
}

sealed class ModelIDConverter : JsonConverter<ModelID>
{
    public override ModelID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "tts-rt-v2"=>ModelID.TtsRtV2, _ =>(ModelID)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ModelID value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ModelID.TtsRtV2=>"tts-rt-v2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Audio sample rate in Hz. `pcm_mulaw` and `pcm_alaw` accept 8000 only; `mp3` does
/// not accept 8000. Defaults to 24000, or 8000 for `pcm_mulaw` and `pcm_alaw`.
/// </summary>
[JsonConverter(typeof(SampleRateConverter))]
public enum SampleRate
{
    V8000, V16000, V24000, V44100, V48000
}

sealed class SampleRateConverter : JsonConverter<SampleRate>
{
    public override SampleRate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            8000L=>SampleRate.V8000,
            16000L=>SampleRate.V16000,
            24000L=>SampleRate.V24000,
            44100L=>SampleRate.V44100,
            48000L=>SampleRate.V48000,
            _ =>(SampleRate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SampleRate value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SampleRate.V8000=>8000L,
            SampleRate.V16000=>16000L,
            SampleRate.V24000=>24000L,
            SampleRate.V44100=>44100L,
            SampleRate.V48000=>48000L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Telnyx provider-specific parameters. For the `Ultra` model, use `voice_speed`,
/// `volume`, and `emotion`. `Bayan` and `Sukhan` don't use `temperature`, `volume`,
/// or `emotion`, and don't support `voice_speed`. `Sukhan`'s `response_format` is
/// restricted to `mp3` or `pcm` (no `wav`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Telnyx, TelnyxFromRaw>))]
public sealed record class Telnyx : JsonModel
{
    /// <summary>
    /// Emotion control for the Ultra model. Adjusts the emotional tone of the synthesized speech.
    /// </summary>
    public ApiEnum<string, Emotion>? Emotion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Emotion>>(
                "emotion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emotion", value);
        }
    }

    /// <summary>
    /// Audio response format.
    /// </summary>
    public string? ResponseFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "response_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("response_format", value);
        }
    }

    /// <summary>
    /// Audio sampling rate in Hz.
    /// </summary>
    public long? SamplingRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "sampling_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sampling_rate", value);
        }
    }

    /// <summary>
    /// Voice speed multiplier. Applies to all models except `Bayan` and `Sukhan`,
    /// which don't support it. Range: 0.5 to 2.0.
    /// </summary>
    public float? VoiceSpeed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "voice_speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_speed", value);
        }
    }

    /// <summary>
    /// Volume level for the Ultra model. Telnyx `Ultra` voices accept values from
    /// 0.5 to 2.0 — requests outside that range are rejected by the synthesis engine.
    /// `KokoroTTS`, `Qwen3TTS`, `Bayan`, and `Sukhan` voices accept the field but
    /// do not apply it.
    /// </summary>
    public float? Volume {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "volume"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("volume", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Emotion?.Validate();
        _ = this.ResponseFormat;
        _ = this.SamplingRate;
        _ = this.VoiceSpeed;
        _ = this.Volume;
    }

    public Telnyx ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Telnyx (Telnyx telnyx) : base(telnyx)
    {  }
    #pragma warning restore CS8618

    public Telnyx (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Telnyx (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxFromRaw.FromRawUnchecked"/>
    public static Telnyx FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxFromRaw : IFromRawJson<Telnyx>
{
    /// <inheritdoc/>
    public Telnyx FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Telnyx.FromRawUnchecked(rawData);
}

/// <summary>
/// Emotion control for the Ultra model. Adjusts the emotional tone of the synthesized speech.
/// </summary>
[JsonConverter(typeof(EmotionConverter))]
public enum Emotion
{
    Neutral, Happy, Sad, Angry, Fearful, Disgusted, Surprised
}

sealed class EmotionConverter : JsonConverter<Emotion>
{
    public override Emotion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "neutral"=>Emotion.Neutral,
            "happy"=>Emotion.Happy,
            "sad"=>Emotion.Sad,
            "angry"=>Emotion.Angry,
            "fearful"=>Emotion.Fearful,
            "disgusted"=>Emotion.Disgusted,
            "surprised"=>Emotion.Surprised,
            _ =>(Emotion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Emotion value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Emotion.Neutral=>"neutral",
            Emotion.Happy=>"happy",
            Emotion.Sad=>"sad",
            Emotion.Angry=>"angry",
            Emotion.Fearful=>"fearful",
            Emotion.Disgusted=>"disgusted",
            Emotion.Surprised=>"surprised",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Text type. Use `ssml` for SSML-formatted input (supported by AWS and Azure).
/// </summary>
[JsonConverter(typeof(TextToSpeechGenerateSpeechParamsTextTypeConverter))]
public enum TextToSpeechGenerateSpeechParamsTextType
{
    Text, Ssml
}

sealed class TextToSpeechGenerateSpeechParamsTextTypeConverter : JsonConverter<TextToSpeechGenerateSpeechParamsTextType>
{
    public override TextToSpeechGenerateSpeechParamsTextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text"=>TextToSpeechGenerateSpeechParamsTextType.Text,
            "ssml"=>TextToSpeechGenerateSpeechParamsTextType.Ssml,
            _ =>(TextToSpeechGenerateSpeechParamsTextType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextToSpeechGenerateSpeechParamsTextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TextToSpeechGenerateSpeechParamsTextType.Text=>"text",
            TextToSpeechGenerateSpeechParamsTextType.Ssml=>"ssml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// xAI provider-specific parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Xai, XaiFromRaw>))]
public sealed record class Xai : JsonModel
{
    /// <summary>
    /// xAI voice identifier.
    /// </summary>
    public required ApiEnum<string, XaiVoiceID> VoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XaiVoiceID>>(
                "voice_id"
            );
        }
        init { this._rawData.Set("voice_id", value); }
    }

    /// <summary>
    /// Language code, or `auto` to detect.
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
    /// Audio output format.
    /// </summary>
    public ApiEnum<string, OutputFormat>? OutputFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutputFormat>>(
                "output_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("output_format", value);
        }
    }

    /// <summary>
    /// Audio sample rate in Hz.
    /// </summary>
    public ApiEnum<long, XaiSampleRate>? SampleRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, XaiSampleRate>>(
                "sample_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.VoiceID.Validate();
        _ = this.Language;
        this.OutputFormat?.Validate();
        this.SampleRate?.Validate();
    }

    public Xai ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Xai (Xai xai) : base(xai)
    {  }
    #pragma warning restore CS8618

    public Xai (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Xai (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="XaiFromRaw.FromRawUnchecked"/>
    public static Xai FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Xai (ApiEnum<string, XaiVoiceID> voiceID) : this()
    { this.VoiceID = voiceID; }
}

class XaiFromRaw : IFromRawJson<Xai>
{
    /// <inheritdoc/>
    public Xai FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Xai.FromRawUnchecked(rawData);
}

/// <summary>
/// xAI voice identifier.
/// </summary>
[JsonConverter(typeof(XaiVoiceIDConverter))]
public enum XaiVoiceID
{
    Eve, Ara, Rex, Sal, Leo
}

sealed class XaiVoiceIDConverter : JsonConverter<XaiVoiceID>
{
    public override XaiVoiceID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eve"=>XaiVoiceID.Eve,
            "ara"=>XaiVoiceID.Ara,
            "rex"=>XaiVoiceID.Rex,
            "sal"=>XaiVoiceID.Sal,
            "leo"=>XaiVoiceID.Leo,
            _ =>(XaiVoiceID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, XaiVoiceID value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            XaiVoiceID.Eve=>"eve",
            XaiVoiceID.Ara=>"ara",
            XaiVoiceID.Rex=>"rex",
            XaiVoiceID.Sal=>"sal",
            XaiVoiceID.Leo=>"leo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Audio output format.
/// </summary>
[JsonConverter(typeof(OutputFormatConverter))]
public enum OutputFormat
{
    Mp3, Wav, Pcm, Mulaw, Alaw
}

sealed class OutputFormatConverter : JsonConverter<OutputFormat>
{
    public override OutputFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3"=>OutputFormat.Mp3,
            "wav"=>OutputFormat.Wav,
            "pcm"=>OutputFormat.Pcm,
            "mulaw"=>OutputFormat.Mulaw,
            "alaw"=>OutputFormat.Alaw,
            _ =>(OutputFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, OutputFormat value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutputFormat.Mp3=>"mp3",
            OutputFormat.Wav=>"wav",
            OutputFormat.Pcm=>"pcm",
            OutputFormat.Mulaw=>"mulaw",
            OutputFormat.Alaw=>"alaw",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Audio sample rate in Hz.
/// </summary>
[JsonConverter(typeof(XaiSampleRateConverter))]
public enum XaiSampleRate
{
    Rate8000, Rate16000, Rate22050, Rate24000, Rate44100, Rate48000
}

sealed class XaiSampleRateConverter : JsonConverter<XaiSampleRate>
{
    public override XaiSampleRate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            8000L=>XaiSampleRate.Rate8000,
            16000L=>XaiSampleRate.Rate16000,
            22050L=>XaiSampleRate.Rate22050,
            24000L=>XaiSampleRate.Rate24000,
            44100L=>XaiSampleRate.Rate44100,
            48000L=>XaiSampleRate.Rate48000,
            _ =>(XaiSampleRate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XaiSampleRate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            XaiSampleRate.Rate8000=>8000L,
            XaiSampleRate.Rate16000=>16000L,
            XaiSampleRate.Rate22050=>22050L,
            XaiSampleRate.Rate24000=>24000L,
            XaiSampleRate.Rate44100=>44100L,
            XaiSampleRate.Rate48000=>48000L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}