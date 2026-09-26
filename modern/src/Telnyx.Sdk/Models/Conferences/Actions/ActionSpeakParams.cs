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
using Actions = Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Convert text to speech and play it to all or some participants.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionSpeakParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The text or SSML to be converted into speech. There is a 3,000 character limit.
    /// </summary>
    public required string Payload {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "payload"
            );
        }
        init { this._rawBodyData.Set("payload", value); }
    }

    /// <summary>
    /// Specifies the voice used in speech synthesis.
    ///
    /// <para>- Define voices using the format `&lt;Provider&gt;.&lt;Model&gt;.&lt;VoiceId&gt;`.
    /// Specifying only the provider will give default values for voice_id and model_id.</para>
    ///
    /// <para> **Supported Providers:** - **AWS:** Use `AWS.Polly.&lt;VoiceId&gt;`
    /// (e.g., `AWS.Polly.Joanna`). For neural voices, which provide more realistic,
    /// human-like speech, append `-Neural` to the `VoiceId` (e.g., `AWS.Polly.Joanna-Neural`).
    /// Check the [available voices](https://docs.aws.amazon.com/polly/latest/dg/available-voices.html)
    /// for compatibility. - **Azure:** Use `Azure.&lt;VoiceId&gt;` (e.g., `Azure.en-CA-ClaraNeural`,
    /// `Azure.en-US-BrianMultilingualNeural`, `Azure.en-US-Ava:DragonHDLatestNeural`).
    /// For a complete list of voices, go to [Azure Voice Gallery](https://speech.microsoft.com/portal/voicegallery).
    /// Use `voice_settings` to configure custom deployments, regions, or API keys.
    /// - **ElevenLabs:** Use `ElevenLabs.&lt;ModelId&gt;.&lt;VoiceId&gt;` (e.g.,
    /// `ElevenLabs.eleven_multilingual_v2.21m00Tcm4TlvDq8ikWAM`). The `ModelId` part
    /// is optional. To use ElevenLabs, you must provide your ElevenLabs API key
    /// as an integration identifier secret in `"voice_settings": {"api_key_ref":
    /// "&lt;secret_identifier&gt;"}`. See [integration secrets documentation](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// for details. Check [available voices](https://elevenlabs.io/docs/api-reference/get-voices).
    /// - **Telnyx:** Use `Telnyx.&lt;model_id&gt;.&lt;voice_id&gt;` (e.g., `Telnyx.KokoroTTS.af`).
    /// Use `voice_settings` to configure voice_speed and other synthesis parameters.
    /// `Bayan` provides Arabic (multiple dialects) and English voices (e.g., `Telnyx.Bayan.Ahmed`,
    /// `Telnyx.Bayan.Amanda`). `Sukhan` provides Urdu voices (e.g., `Telnyx.Sukhan.urdu-professor`);
    /// `voice_speed` is not supported. - **Minimax:** Use `Minimax.&lt;ModelId&gt;.&lt;VoiceId&gt;`
    /// (e.g., `Minimax.speech-02-hd.Wise_Woman`). Supported models: `speech-02-turbo`,
    /// `speech-02-hd`, `speech-2.6-turbo`, `speech-2.8-turbo`. Use `voice_settings`
    /// to configure speed, volume, pitch, and language_boost. - **Resemble:** Use
    /// `Resemble.Turbo.&lt;voice_id&gt;` (e.g., `Resemble.Turbo.my_voice`). Only
    /// `Turbo` model is supported. Use `voice_settings` to configure precision, sample_rate,
    /// and format. - **Inworld:** Use `Inworld.&lt;ModelId&gt;.&lt;VoiceId&gt;`
    /// (e.g., `Inworld.Mini.Loretta`, `Inworld.Max.Oliver`, `Inworld.TTS2.Loretta`).
    /// Supported models: `Mini`, `Max`, `TTS2`. Use `voice_settings` to configure
    /// `delivery_mode` (`STABLE`, `BALANCED`, `CREATIVE`), supported by `TTS2` only.
    /// - **Fish Audio:** Use `FishAudio.&lt;ModelId&gt;.&lt;VoiceId&gt;` (e.g., `FishAudio.s2.1-pro.&lt;reference_id&gt;`).
    /// Supported models: `s2.1-pro`, `s2-pro`, `s1`. `VoiceId` is a Fish Voice-Library
    /// reference ID. - **Soniox:** Use `Soniox.&lt;ModelId&gt;.&lt;VoiceId&gt;`
    /// (e.g., `Soniox.tts-rt-v2.Emma`). Supported model: `tts-rt-v2`. Browse the
    /// catalog via the [Voices API](https://developers.telnyx.com/api-reference/text-to-speech-commands/list-available-voices).
    /// Every voice speaks all supported languages; set `language` to the two-letter
    /// ISO 639-1 code of the text, for example `it`. SSML is not supported. Use `voice_settings`
    /// to configure `speed` (0.7 to 1.3) and `reduce_silence`. - **xAI:** Use `xAI.&lt;VoiceId&gt;`
    /// (e.g., `xAI.eve`). Available voices: `eve`, `ara`, `rex`, `sal`, `leo`. -
    /// **Humain:** Use `Humain.&lt;VoiceId&gt;` (e.g., `Humain.sara-ar`). Available
    /// voices: `sara-en`, `abdulaziz-en`, `sara-ar`, `abdulaziz-ar`, `nourah-ar`,
    /// `abdullah-ar`. Native Arabic (Saudi dialect) and English voices only — no
    /// `ModelId` segment.</para>
    ///
    /// <para>For service_level basic, you may define the gender of the speaker (male
    /// or female).</para>
    /// </summary>
    public required string Voice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "voice"
            );
        }
        init { this._rawBodyData.Set("voice", value); }
    }

    /// <summary>
    /// Call Control IDs of participants who will hear the spoken text. When empty
    /// all participants will hear the spoken text.
    /// </summary>
    public IReadOnlyList<string>? CallControlIds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Use this field to avoid execution of duplicate commands. Telnyx will ignore
    /// subsequent commands with the same `command_id` as one that has already been executed.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// The language you want spoken. This parameter is ignored when a `Polly.*`
    /// voice is specified.
    /// </summary>
    public ApiEnum<string, Language>? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Language>>(
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
    /// The type of the provided payload. The payload can either be plain text, or
    /// Speech Synthesis Markup Language (SSML).
    /// </summary>
    public ApiEnum<string, PayloadType>? PayloadType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PayloadType>>(
                "payload_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("payload_type", value);
        }
    }

    /// <summary>
    /// Region where the conference data is located. Defaults to the region defined
    /// in user's data locality settings (Europe or US).
    /// </summary>
    public ApiEnum<string, ConferenceRegion>? Region {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceRegion>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("region", value);
        }
    }

    /// <summary>
    /// The settings associated with the voice selected
    /// </summary>
    public VoiceSettings? VoiceSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice_settings", value);
        }
    }

    public ActionSpeakParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSpeakParams (ActionSpeakParams actionSpeakParams) : base(
        actionSpeakParams
    )
    {
        this.ID = actionSpeakParams.ID;

        this._rawBodyData = new(actionSpeakParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionSpeakParams (
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
    ActionSpeakParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionSpeakParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionSpeakParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/actions/speak",
            EncodePathSegment(this.ID))
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
/// The language you want spoken. This parameter is ignored when a `Polly.*` voice
/// is specified.
/// </summary>
[JsonConverter(typeof(LanguageConverter))]
public enum Language
{
    Arb,
    CmnCn,
    CyGB,
    DaDk,
    DeDe,
    EnAu,
    EnGB,
    EnGBWls,
    EnIn,
    EnUs,
    EsEs,
    EsMx,
    EsUs,
    FrCa,
    FrFr,
    HiIn,
    IsIs,
    ItIt,
    JaJp,
    KoKr,
    NbNo,
    NlNl,
    PlPl,
    PtBr,
    PtPt,
    RoRo,
    RuRu,
    SvSe,
    TrTr
}

sealed class LanguageConverter : JsonConverter<Language>
{
    public override Language Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "arb"=>Language.Arb,
            "cmn-CN"=>Language.CmnCn,
            "cy-GB"=>Language.CyGB,
            "da-DK"=>Language.DaDk,
            "de-DE"=>Language.DeDe,
            "en-AU"=>Language.EnAu,
            "en-GB"=>Language.EnGB,
            "en-GB-WLS"=>Language.EnGBWls,
            "en-IN"=>Language.EnIn,
            "en-US"=>Language.EnUs,
            "es-ES"=>Language.EsEs,
            "es-MX"=>Language.EsMx,
            "es-US"=>Language.EsUs,
            "fr-CA"=>Language.FrCa,
            "fr-FR"=>Language.FrFr,
            "hi-IN"=>Language.HiIn,
            "is-IS"=>Language.IsIs,
            "it-IT"=>Language.ItIt,
            "ja-JP"=>Language.JaJp,
            "ko-KR"=>Language.KoKr,
            "nb-NO"=>Language.NbNo,
            "nl-NL"=>Language.NlNl,
            "pl-PL"=>Language.PlPl,
            "pt-BR"=>Language.PtBr,
            "pt-PT"=>Language.PtPt,
            "ro-RO"=>Language.RoRo,
            "ru-RU"=>Language.RuRu,
            "sv-SE"=>Language.SvSe,
            "tr-TR"=>Language.TrTr,
            _ =>(Language)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Language value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Language.Arb=>"arb",
            Language.CmnCn=>"cmn-CN",
            Language.CyGB=>"cy-GB",
            Language.DaDk=>"da-DK",
            Language.DeDe=>"de-DE",
            Language.EnAu=>"en-AU",
            Language.EnGB=>"en-GB",
            Language.EnGBWls=>"en-GB-WLS",
            Language.EnIn=>"en-IN",
            Language.EnUs=>"en-US",
            Language.EsEs=>"es-ES",
            Language.EsMx=>"es-MX",
            Language.EsUs=>"es-US",
            Language.FrCa=>"fr-CA",
            Language.FrFr=>"fr-FR",
            Language.HiIn=>"hi-IN",
            Language.IsIs=>"is-IS",
            Language.ItIt=>"it-IT",
            Language.JaJp=>"ja-JP",
            Language.KoKr=>"ko-KR",
            Language.NbNo=>"nb-NO",
            Language.NlNl=>"nl-NL",
            Language.PlPl=>"pl-PL",
            Language.PtBr=>"pt-BR",
            Language.PtPt=>"pt-PT",
            Language.RoRo=>"ro-RO",
            Language.RuRu=>"ru-RU",
            Language.SvSe=>"sv-SE",
            Language.TrTr=>"tr-TR",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The type of the provided payload. The payload can either be plain text, or Speech
/// Synthesis Markup Language (SSML).
/// </summary>
[JsonConverter(typeof(PayloadTypeConverter))]
public enum PayloadType
{
    Text, Ssml
}

sealed class PayloadTypeConverter : JsonConverter<PayloadType>
{
    public override PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text"=>PayloadType.Text,
            "ssml"=>PayloadType.Ssml,
            _ =>(PayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, PayloadType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PayloadType.Text=>"text",
            PayloadType.Ssml=>"ssml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The settings associated with the voice selected
/// </summary>
[JsonConverter(typeof(VoiceSettingsConverter))]
public record class VoiceSettings : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? ApiKeyRef {
        get {
            return Match<string?>(elevenLabs: ( x )=>x.ApiKeyRef,
            telnyx: ( _ )=>null,
            aws: ( _ )=>null,
            minimax: ( _ )=>null,
            azure: ( x )=>x.ApiKeyRef,
            resemble: ( _ )=>null,
            inworld: ( _ )=>null,
            xai: ( _ )=>null,
            soniox: ( _ )=>null);
        }
    }

    public float? Speed {
        get {
            return Match<float?>(elevenLabs: ( _ )=>null,
            telnyx: ( _ )=>null,
            aws: ( _ )=>null,
            minimax: ( x )=>x.Speed,
            azure: ( _ )=>null,
            resemble: ( _ )=>null,
            inworld: ( _ )=>null,
            xai: ( _ )=>null,
            soniox: ( x )=>x.Speed);
        }
    }

    public VoiceSettings (
        Actions::ElevenLabsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        Actions::TelnyxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        Actions::AwsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        MinimaxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (AzureVoiceSettings value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        ResembleVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        InworldVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (XaiVoiceSettings value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        Actions::SonioxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Actions::ElevenLabsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickElevenLabs(out var value)) {
///     // `value` is of type `Actions::ElevenLabsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickElevenLabs(
        [NotNullWhen(true)] out Actions::ElevenLabsVoiceSettings? value
    )
    {
        value =this.Value as Actions::ElevenLabsVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Actions::TelnyxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyx(out var value)) {
///     // `value` is of type `Actions::TelnyxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyx(
        [NotNullWhen(true)] out Actions::TelnyxVoiceSettings? value
    )
    {
        value =this.Value as Actions::TelnyxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Actions::AwsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAws(out var value)) {
///     // `value` is of type `Actions::AwsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAws(
        [NotNullWhen(true)] out Actions::AwsVoiceSettings? value
    )
    {
        value =this.Value as Actions::AwsVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MinimaxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMinimax(out var value)) {
///     // `value` is of type `MinimaxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMinimax(
        [NotNullWhen(true)] out MinimaxVoiceSettings? value
    )
    {
        value =this.Value as MinimaxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AzureVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAzure(out var value)) {
///     // `value` is of type `AzureVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAzure([NotNullWhen(true)] out AzureVoiceSettings? value)
    {
        value =this.Value as AzureVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResembleVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickResemble(out var value)) {
///     // `value` is of type `ResembleVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickResemble(
        [NotNullWhen(true)] out ResembleVoiceSettings? value
    )
    {
        value =this.Value as ResembleVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="InworldVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInworld(out var value)) {
///     // `value` is of type `InworldVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInworld(
        [NotNullWhen(true)] out InworldVoiceSettings? value
    )
    {
        value =this.Value as InworldVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="XaiVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickXai(out var value)) {
///     // `value` is of type `XaiVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickXai([NotNullWhen(true)] out XaiVoiceSettings? value)
    {
        value =this.Value as XaiVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Actions::SonioxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSoniox(out var value)) {
///     // `value` is of type `Actions::SonioxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSoniox(
        [NotNullWhen(true)] out Actions::SonioxVoiceSettings? value
    )
    {
        value =this.Value as Actions::SonioxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (Actions::ElevenLabsVoiceSettings value) =&gt; {...},
///     (Actions::TelnyxVoiceSettings value) =&gt; {...},
///     (Actions::AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (Actions::SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Actions::ElevenLabsVoiceSettings> elevenLabs,
        System::Action<Actions::TelnyxVoiceSettings> telnyx,
        System::Action<Actions::AwsVoiceSettings> aws,
        System::Action<MinimaxVoiceSettings> minimax,
        System::Action<AzureVoiceSettings> azure,
        System::Action<ResembleVoiceSettings> resemble,
        System::Action<InworldVoiceSettings> inworld,
        System::Action<XaiVoiceSettings> xai,
        System::Action<Actions::SonioxVoiceSettings> soniox
    )
    {
        switch (this.Value)
        {
            case Actions::ElevenLabsVoiceSettings value:
                elevenLabs(value);
                break;
            case Actions::TelnyxVoiceSettings value:
                telnyx(value);
                break;
            case Actions::AwsVoiceSettings value:
                aws(value);
                break;
            case MinimaxVoiceSettings value:
                minimax(value);
                break;
            case AzureVoiceSettings value:
                azure(value);
                break;
            case ResembleVoiceSettings value:
                resemble(value);
                break;
            case InworldVoiceSettings value:
                inworld(value);
                break;
            case XaiVoiceSettings value:
                xai(value);
                break;
            case Actions::SonioxVoiceSettings value:
                soniox(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettings");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (Actions::ElevenLabsVoiceSettings value) =&gt; {...},
///     (Actions::TelnyxVoiceSettings value) =&gt; {...},
///     (Actions::AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (Actions::SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Actions::ElevenLabsVoiceSettings, T> elevenLabs,
        System::Func<Actions::TelnyxVoiceSettings, T> telnyx,
        System::Func<Actions::AwsVoiceSettings, T> aws,
        System::Func<MinimaxVoiceSettings, T> minimax,
        System::Func<AzureVoiceSettings, T> azure,
        System::Func<ResembleVoiceSettings, T> resemble,
        System::Func<InworldVoiceSettings, T> inworld,
        System::Func<XaiVoiceSettings, T> xai,
        System::Func<Actions::SonioxVoiceSettings, T> soniox
    )
    {
        return this.Value switch
        {
            Actions::ElevenLabsVoiceSettings value=>elevenLabs(value),
            Actions::TelnyxVoiceSettings value=>telnyx(value),
            Actions::AwsVoiceSettings value=>aws(value),
            MinimaxVoiceSettings value=>minimax(value),
            AzureVoiceSettings value=>azure(value),
            ResembleVoiceSettings value=>resemble(value),
            InworldVoiceSettings value=>inworld(value),
            XaiVoiceSettings value=>xai(value),
            Actions::SonioxVoiceSettings value=>soniox(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettings")
        } ;
    }

    public static implicit operator VoiceSettings (
        Actions::ElevenLabsVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        Actions::TelnyxVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        Actions::AwsVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        MinimaxVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        AzureVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        ResembleVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        InworldVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        XaiVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        Actions::SonioxVoiceSettings value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettings");
        }
        this.Switch((elevenLabs) => elevenLabs.Validate(),
        (telnyx) => telnyx.Validate(),
        (aws) => aws.Validate(),
        (minimax) => minimax.Validate(),
        (azure) => azure.Validate(),
        (resemble) => resemble.Validate(),
        (inworld) => inworld.Validate(),
        (xai) => xai.Validate(),
        (soniox) => soniox.Validate());
    }

    public virtual bool Equals(VoiceSettings? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            Actions::ElevenLabsVoiceSettings _=>0,
            Actions::TelnyxVoiceSettings _=>1,
            Actions::AwsVoiceSettings _=>2,
            MinimaxVoiceSettings _=>3,
            AzureVoiceSettings _=>4,
            ResembleVoiceSettings _=>5,
            InworldVoiceSettings _=>6,
            XaiVoiceSettings _=>7,
            Actions::SonioxVoiceSettings _=>8,
            _ =>-1
        } ;
    }
}

sealed class VoiceSettingsConverter : JsonConverter<VoiceSettings>
{
    public override VoiceSettings? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "elevenlabs":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Actions::ElevenLabsVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "telnyx":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Actions::TelnyxVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "aws":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Actions::AwsVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "minimax":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MinimaxVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "azure":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "resemble":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ResembleVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "inworld":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InworldVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "xai":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<XaiVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "soniox":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Actions::SonioxVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new VoiceSettings(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceSettings value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}