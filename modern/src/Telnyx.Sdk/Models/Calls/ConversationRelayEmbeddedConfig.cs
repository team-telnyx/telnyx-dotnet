using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Starts a Conversation Relay session automatically when the answered/dialed call
/// is answered. This embedded shape is supported on `answer` and `dial`. It uses
/// public field names (`url`, `dtmf_detection`, `greeting`, `voice`, `language`,
/// etc.) and maps them to the underlying Conversation Relay action. `client_state`,
/// `tts_language`, and `transcription_language` inside this object are ignored;
/// use the parent command's `client_state` and `command_id` fields instead.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationRelayEmbeddedConfig, ConversationRelayEmbeddedConfigFromRaw>))]
public sealed record class ConversationRelayEmbeddedConfig : JsonModel
{
    /// <summary>
    /// WebSocket URL for your Conversation Relay server. Must start with `ws://`
    /// or `wss://`.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Custom key-value parameters forwarded to the relay session as assistant dynamic variables.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "custom_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "custom_parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Enable DTMF detection for the relay session.
    /// </summary>
    public bool? DtmfDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "dtmf_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dtmf_detection", value);
        }
    }

    /// <summary>
    /// Text played when the relay session starts.
    /// </summary>
    public string? Greeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? Interruptible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruptible", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? InterruptibleGreeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible_greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruptible_greeting", value);
        }
    }

    /// <summary>
    /// Settings for handling caller interruptions during Conversation Relay speech.
    /// </summary>
    public ConversationRelayInterruptionSettings? InterruptionSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationRelayInterruptionSettings>(
                "interruption_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruption_settings", value);
        }
    }

    /// <summary>
    /// Default language for both text-to-speech and speech recognition.
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
    /// Per-language TTS and transcription settings.
    /// </summary>
    public IReadOnlyList<ConversationRelayLanguage>? Languages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConversationRelayLanguage>>(
                "languages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ConversationRelayLanguage>?>(
                "languages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Structured voice provider. Must be supplied together with `structured_provider`.
    /// </summary>
    public string? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <summary>
    /// Provider-specific structured voice settings. Must be supplied together with
    /// `provider`; Telnyx sends the value as the nested provider configuration for
    /// Conversation Relay.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? StructuredProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "structured_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "structured_provider",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` -
    /// `Telnyx` are supported for backward compatibility. For Conversation Relay,
    /// use this field with `transcription_engine_config`; the `transcription` object
    /// is not supported.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Calls.TranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Calls.TranscriptionEngine>>(
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
    /// Engine-specific transcription settings for Conversation Relay. This accepts
    /// the same provider-specific options used by the Call Transcription Start command,
    /// such as `transcription_model`, without requiring the engine discriminator
    /// to be repeated inside this object.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? TranscriptionEngineConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "transcription_engine_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "transcription_engine_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Text-to-speech provider. If omitted, Telnyx derives it from `voice` or `provider`.
    /// </summary>
    public string? TtsProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tts_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tts_provider", value);
        }
    }

    /// <summary>
    /// The voice to be used by the voice assistant. Currently we support ElevenLabs,
    /// Telnyx and AWS voices.
    ///
    /// <para> **Supported Providers:** - **AWS:** Use `AWS.Polly.&lt;VoiceId&gt;`
    /// (e.g., `AWS.Polly.Joanna`). For neural voices, which provide more realistic,
    /// human-like speech, append `-Neural` to the `VoiceId` (e.g., `AWS.Polly.Joanna-Neural`).
    /// Check the [available voices](https://docs.aws.amazon.com/polly/latest/dg/available-voices.html)
    /// for compatibility. - **Azure:** Use `Azure.&lt;VoiceId&gt;. (e.g. Azure.en-CA-ClaraNeural,
    /// Azure.en-CA-LiamNeural, Azure.en-US-BrianMultilingualNeural, Azure.en-US-Ava:DragonHDLatestNeural.
    /// For a complete list of voices, go to [Azure Voice Gallery](https://speech.microsoft.com/portal/voicegallery).)
    /// - **ElevenLabs:** Use `ElevenLabs.&lt;ModelId&gt;.&lt;VoiceId&gt;` (e.g.,
    /// `ElevenLabs.BaseModel.John`). The `ModelId` part is optional. To use ElevenLabs,
    /// you must provide your ElevenLabs API key as an integration secret under `"voice_settings":
    /// {"api_key_ref": "&lt;secret_id&gt;"}`. See [integration secrets documentation](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// for details. Check [available voices](https://elevenlabs.io/docs/api-reference/get-voices).
    ///  - **Telnyx:** Use `Telnyx.&lt;model_id&gt;.&lt;voice_id&gt;` - **Inworld:**
    /// Use `Inworld.&lt;ModelId&gt;.&lt;VoiceId&gt;` (e.g., `Inworld.Mini.Loretta`,
    /// `Inworld.Max.Oliver`, `Inworld.TTS2.Loretta`). Supported models: `Mini`, `Max`,
    /// `TTS2`. - **Fish Audio:** Use `FishAudio.&lt;ModelId&gt;.&lt;VoiceId&gt;`
    /// (e.g., `FishAudio.s2.1-pro.&lt;reference_id&gt;`). Supported models: `s2.1-pro`,
    /// `s2-pro`, `s1`. `VoiceId` is a Fish Voice-Library reference ID. - **Soniox:**
    /// Use `Soniox.&lt;ModelId&gt;.&lt;VoiceId&gt;` (e.g., `Soniox.tts-rt-v2.Emma`).
    /// Supported model: `tts-rt-v2`. Browse the catalog via the [Voices API](https://developers.telnyx.com/api-reference/text-to-speech-commands/list-available-voices).
    /// Every voice speaks all supported languages; set `language` to the two-letter
    /// ISO 639-1 code of the text, for example `it`. SSML is not supported. Use `voice_settings`
    /// to configure `speed` (0.7 to 1.3) and `reduce_silence`. - **xAI:** Use `xAI.&lt;VoiceId&gt;`
    /// (e.g., `xAI.eve`). Available voices: `eve`, `ara`, `rex`, `sal`, `leo`. -
    /// **Humain:** Use `Humain.&lt;VoiceId&gt;` (e.g., `Humain.sara-ar`). Available
    /// voices: `sara-en`, `abdulaziz-en`, `sara-ar`, `abdulaziz-ar`, `nourah-ar`,
    /// `abdullah-ar`. Native Arabic (Saudi dialect) and English voices only — no
    /// `ModelId` segment.</para>
    /// </summary>
    public string? Voice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <summary>
    /// The settings associated with the voice selected
    /// </summary>
    public global::Telnyx.Sdk.Models.Calls.VoiceSettings? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Telnyx.Sdk.Models.Calls.VoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.CustomParameters;
        _ = this.DtmfDetection;
        _ = this.Greeting;
        this.Interruptible?.Validate();
        this.InterruptibleGreeting?.Validate();
        this.InterruptionSettings?.Validate();
        _ = this.Language;
        foreach (var item in this.Languages ?? [])
        {
            item.Validate();
        }
        _ = this.Provider;
        _ = this.StructuredProvider;
        this.TranscriptionEngine?.Validate();
        _ = this.TranscriptionEngineConfig;
        _ = this.TtsProvider;
        _ = this.Voice;
        this.VoiceSettings?.Validate();
    }

    public ConversationRelayEmbeddedConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRelayEmbeddedConfig (
        ConversationRelayEmbeddedConfig conversationRelayEmbeddedConfig
    ) : base(conversationRelayEmbeddedConfig)
    {  }
    #pragma warning restore CS8618

    public ConversationRelayEmbeddedConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRelayEmbeddedConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRelayEmbeddedConfigFromRaw.FromRawUnchecked"/>
    public static ConversationRelayEmbeddedConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConversationRelayEmbeddedConfig (string url) : this()
    { this.Url = url; }
}

class ConversationRelayEmbeddedConfigFromRaw : IFromRawJson<ConversationRelayEmbeddedConfig>
{
    /// <inheritdoc/>
    public ConversationRelayEmbeddedConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRelayEmbeddedConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` - `Telnyx`
/// are supported for backward compatibility. For Conversation Relay, use this field
/// with `transcription_engine_config`; the `transcription` object is not supported.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.Calls.TranscriptionEngineConverter))]
public enum TranscriptionEngine
{
    Google, Telnyx, Deepgram, Azure, XAI, AssemblyAI, Speechmatics, Soniox, A, B
}sealed class TranscriptionEngineConverter : JsonConverter<global::Telnyx.Sdk.Models.Calls.TranscriptionEngine>
{
    public override global::Telnyx.Sdk.Models.Calls.TranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Google"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Google,
            "Telnyx"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Telnyx,
            "Deepgram"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Deepgram,
            "Azure"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Azure,
            "xAI"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.XAI,
            "AssemblyAI"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.AssemblyAI,
            "Speechmatics"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Speechmatics,
            "Soniox"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Soniox,
            "A"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.A,
            "B"=>global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.B,
            _ =>(global::Telnyx.Sdk.Models.Calls.TranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Calls.TranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Google=>"Google",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Telnyx=>"Telnyx",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Deepgram=>"Deepgram",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Azure=>"Azure",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.XAI=>"xAI",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.AssemblyAI=>"AssemblyAI",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Speechmatics=>"Speechmatics",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.Soniox=>"Soniox",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.A=>"A",
            global::Telnyx.Sdk.Models.Calls.TranscriptionEngine.B=>"B",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The settings associated with the voice selected
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.Calls.VoiceSettingsConverter))]
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
        ElevenLabsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (
        TelnyxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (AwsVoiceSettings value, JsonElement? element = null)
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
        SonioxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettings (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ElevenLabsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickElevenLabs(out var value)) {
///     // `value` is of type `ElevenLabsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickElevenLabs(
        [NotNullWhen(true)] out ElevenLabsVoiceSettings? value
    )
    {
        value =this.Value as ElevenLabsVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TelnyxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyx(out var value)) {
///     // `value` is of type `TelnyxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyx(
        [NotNullWhen(true)] out TelnyxVoiceSettings? value
    )
    {
        value =this.Value as TelnyxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AwsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAws(out var value)) {
///     // `value` is of type `AwsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAws([NotNullWhen(true)] out AwsVoiceSettings? value)
    {
        value =this.Value as AwsVoiceSettings ;
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
/// type <see cref="SonioxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSoniox(out var value)) {
///     // `value` is of type `SonioxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSoniox(
        [NotNullWhen(true)] out SonioxVoiceSettings? value
    )
    {
        value =this.Value as SonioxVoiceSettings ;
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
///     (ElevenLabsVoiceSettings value) =&gt; {...},
///     (TelnyxVoiceSettings value) =&gt; {...},
///     (AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ElevenLabsVoiceSettings> elevenLabs,
        System::Action<TelnyxVoiceSettings> telnyx,
        System::Action<AwsVoiceSettings> aws,
        System::Action<MinimaxVoiceSettings> minimax,
        System::Action<AzureVoiceSettings> azure,
        System::Action<ResembleVoiceSettings> resemble,
        System::Action<InworldVoiceSettings> inworld,
        System::Action<XaiVoiceSettings> xai,
        System::Action<SonioxVoiceSettings> soniox
    )
    {
        switch (this.Value)
        {
            case ElevenLabsVoiceSettings value:
                elevenLabs(value);
                break;
            case TelnyxVoiceSettings value:
                telnyx(value);
                break;
            case AwsVoiceSettings value:
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
            case SonioxVoiceSettings value:
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
///     (ElevenLabsVoiceSettings value) =&gt; {...},
///     (TelnyxVoiceSettings value) =&gt; {...},
///     (AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ElevenLabsVoiceSettings, T> elevenLabs,
        System::Func<TelnyxVoiceSettings, T> telnyx,
        System::Func<AwsVoiceSettings, T> aws,
        System::Func<MinimaxVoiceSettings, T> minimax,
        System::Func<AzureVoiceSettings, T> azure,
        System::Func<ResembleVoiceSettings, T> resemble,
        System::Func<InworldVoiceSettings, T> inworld,
        System::Func<XaiVoiceSettings, T> xai,
        System::Func<SonioxVoiceSettings, T> soniox
    )
    {
        return this.Value switch
        {
            ElevenLabsVoiceSettings value=>elevenLabs(value),
            TelnyxVoiceSettings value=>telnyx(value),
            AwsVoiceSettings value=>aws(value),
            MinimaxVoiceSettings value=>minimax(value),
            AzureVoiceSettings value=>azure(value),
            ResembleVoiceSettings value=>resemble(value),
            InworldVoiceSettings value=>inworld(value),
            XaiVoiceSettings value=>xai(value),
            SonioxVoiceSettings value=>soniox(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettings")
        } ;
    }

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        ElevenLabsVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        TelnyxVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        AwsVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        MinimaxVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        AzureVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        ResembleVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        InworldVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        XaiVoiceSettings value
    )=> new(value) ;

    public static implicit operator global::Telnyx.Sdk.Models.Calls.VoiceSettings (
        SonioxVoiceSettings value
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

    public virtual bool Equals(
        global::Telnyx.Sdk.Models.Calls.VoiceSettings? other
    )
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
            ElevenLabsVoiceSettings _=>0,
            TelnyxVoiceSettings _=>1,
            AwsVoiceSettings _=>2,
            MinimaxVoiceSettings _=>3,
            AzureVoiceSettings _=>4,
            ResembleVoiceSettings _=>5,
            InworldVoiceSettings _=>6,
            XaiVoiceSettings _=>7,
            SonioxVoiceSettings _=>8,
            _ =>-1
        } ;
    }
}sealed class VoiceSettingsConverter : JsonConverter<global::Telnyx.Sdk.Models.Calls.VoiceSettings>
{
    public override global::Telnyx.Sdk.Models.Calls.VoiceSettings? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ElevenLabsVoiceSettings>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<TelnyxVoiceSettings>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<AwsVoiceSettings>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<SonioxVoiceSettings>(element, options);
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
                {
                    return new global::Telnyx.Sdk.Models.Calls.VoiceSettings(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Calls.VoiceSettings value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}