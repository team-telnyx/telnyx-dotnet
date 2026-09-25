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

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Start a Conversation Relay session on an active call. Conversation Relay connects
/// the call audio to your WebSocket so your application can exchange realtime messages
/// with the caller while Telnyx handles speech recognition and text-to-speech. Only
/// one AI Assistant or Conversation Relay session can be active on a call at a time.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.conversation.ended` - Sent when the Conversation Relay session ends.
/// If the customer WebSocket disconnects, the webhook payload `reason` is `customer_disconnect`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartConversationRelayParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Custom parameters for the Conversation Relay session. Pass key-value data
    /// as `assistant.dynamic_variables` to make it available to the relay session.
    /// </summary>
    public Assistant? Assistant {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Assistant>(
                "assistant"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("assistant", value);
        }
    }

    /// <summary>
    /// Use this field to add state to subsequent webhooks. It must be a valid Base-64
    /// encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
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
    /// Enable DTMF detection for the relay session.
    /// </summary>
    public bool? ConversationRelayDtmfDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "conversation_relay_dtmf_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_relay_dtmf_detection", value);
        }
    }

    /// <summary>
    /// Conversation Relay connection settings. This object can provide `url`, `dtmf_detection`,
    /// `interruptible`, `interruptible_greeting`, and `languages`. Top-level aliases
    /// override nested values when both are present.
    /// </summary>
    public ConversationRelaySettings? ConversationRelaySettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConversationRelaySettings>(
                "conversation_relay_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_relay_settings", value);
        }
    }

    /// <summary>
    /// WebSocket URL for your Conversation Relay server. Must start with `ws://`
    /// or `wss://`.
    /// </summary>
    public string? ConversationRelayUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "conversation_relay_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_relay_url", value);
        }
    }

    /// <summary>
    /// Custom key-value parameters forwarded to the relay session as `assistant.dynamic_variables`.
    /// If `assistant.dynamic_variables` is also present, these values are merged in.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomParameters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "custom_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "custom_parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public alias for `conversation_relay_dtmf_detection`. If both are present,
    /// this value wins.
    /// </summary>
    public bool? DtmfDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "dtmf_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dtmf_detection", value);
        }
    }

    /// <summary>
    /// Text played when the relay session starts.
    /// </summary>
    public string? Greeting {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("greeting", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? Interruptible {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("interruptible", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? InterruptibleGreeting {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible_greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("interruptible_greeting", value);
        }
    }

    /// <summary>
    /// Settings for handling caller interruptions during Conversation Relay speech.
    /// </summary>
    public ConversationRelayInterruptionSettings? InterruptionSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConversationRelayInterruptionSettings>(
                "interruption_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("interruption_settings", value);
        }
    }

    /// <summary>
    /// Default language for the relay session. This value is used for both text-to-speech
    /// and speech recognition.
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
    /// Per-language TTS and transcription settings.
    /// </summary>
    public IReadOnlyList<ConversationRelayLanguage>? Languages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ConversationRelayLanguage>>(
                "languages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ConversationRelayLanguage>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
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
    /// Provider-specific structured voice settings. Must be supplied together with
    /// `provider`; Telnyx sends the value as the nested provider configuration for
    /// Conversation Relay.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? StructuredProvider {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "structured_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "structured_provider",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Not supported for Conversation Relay start requests. Use `transcription_engine`
    /// and `transcription_engine_config` instead.
    /// </summary>
    [System::Obsolete("Use transcription_engine and transcription_engine_config instead.")]
    public IReadOnlyDictionary<string, JsonElement>? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "transcription",
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
    public ApiEnum<string, TranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_engine", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "transcription_engine_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "tts_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tts_provider", value);
        }
    }

    /// <summary>
    /// Public alias for `conversation_relay_url`. Must start with `ws://` or `wss://`.
    /// If both are present, this value wins.
    /// </summary>
    public string? UrlValue {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("url", value);
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
    /// The settings associated with the voice selected
    /// </summary>
    public ActionStartConversationRelayParamsVoiceSettings? VoiceSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ActionStartConversationRelayParamsVoiceSettings>(
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

    public ActionStartConversationRelayParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartConversationRelayParams (
        ActionStartConversationRelayParams actionStartConversationRelayParams
    ) : base(actionStartConversationRelayParams)
    {
        this.CallControlID = actionStartConversationRelayParams.CallControlID;

        this._rawBodyData = new(actionStartConversationRelayParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartConversationRelayParams (
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
    ActionStartConversationRelayParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionStartConversationRelayParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionStartConversationRelayParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/conversation_relay_start",
            this.CallControlID)
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
/// Custom parameters for the Conversation Relay session. Pass key-value data as `assistant.dynamic_variables`
/// to make it available to the relay session.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Assistant, AssistantFromRaw>))]
public sealed record class Assistant : JsonModel
{
    /// <summary>
    /// Custom key-value parameters forwarded to the Conversation Relay session.
    /// </summary>
    public IReadOnlyDictionary<string, string>? DynamicVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.DynamicVariables; }

    public Assistant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Assistant (Assistant assistant) : base(assistant)
    {  }
    #pragma warning restore CS8618

    public Assistant (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Assistant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantFromRaw.FromRawUnchecked"/>
    public static Assistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantFromRaw : IFromRawJson<Assistant>
{
    /// <inheritdoc/>
    public Assistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Assistant.FromRawUnchecked(rawData);
}

/// <summary>
/// Conversation Relay connection settings. This object can provide `url`, `dtmf_detection`,
/// `interruptible`, `interruptible_greeting`, and `languages`. Top-level aliases
/// override nested values when both are present.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationRelaySettings, ConversationRelaySettingsFromRaw>))]
public sealed record class ConversationRelaySettings : JsonModel
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
    /// Whether to enable DTMF detection during the relay session.
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
    /// Language-specific TTS and transcription settings.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.DtmfDetection;
        this.Interruptible?.Validate();
        this.InterruptibleGreeting?.Validate();
        foreach (var item in this.Languages ?? [])
        {
            item.Validate();
        }
    }

    public ConversationRelaySettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRelaySettings (
        ConversationRelaySettings conversationRelaySettings
    ) : base(conversationRelaySettings)
    {  }
    #pragma warning restore CS8618

    public ConversationRelaySettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRelaySettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRelaySettingsFromRaw.FromRawUnchecked"/>
    public static ConversationRelaySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConversationRelaySettings (string url) : this()
    { this.Url = url; }
}

class ConversationRelaySettingsFromRaw : IFromRawJson<ConversationRelaySettings>
{
    /// <inheritdoc/>
    public ConversationRelaySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRelaySettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` - `Telnyx`
/// are supported for backward compatibility. For Conversation Relay, use this field
/// with `transcription_engine_config`; the `transcription` object is not supported.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineConverter))]
public enum TranscriptionEngine
{
    Google, Telnyx, Deepgram, Azure, XAI, AssemblyAI, Speechmatics, Soniox, A, B
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
            "Google"=>TranscriptionEngine.Google,
            "Telnyx"=>TranscriptionEngine.Telnyx,
            "Deepgram"=>TranscriptionEngine.Deepgram,
            "Azure"=>TranscriptionEngine.Azure,
            "xAI"=>TranscriptionEngine.XAI,
            "AssemblyAI"=>TranscriptionEngine.AssemblyAI,
            "Speechmatics"=>TranscriptionEngine.Speechmatics,
            "Soniox"=>TranscriptionEngine.Soniox,
            "A"=>TranscriptionEngine.A,
            "B"=>TranscriptionEngine.B,
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
            TranscriptionEngine.Google=>"Google",
            TranscriptionEngine.Telnyx=>"Telnyx",
            TranscriptionEngine.Deepgram=>"Deepgram",
            TranscriptionEngine.Azure=>"Azure",
            TranscriptionEngine.XAI=>"xAI",
            TranscriptionEngine.AssemblyAI=>"AssemblyAI",
            TranscriptionEngine.Speechmatics=>"Speechmatics",
            TranscriptionEngine.Soniox=>"Soniox",
            TranscriptionEngine.A=>"A",
            TranscriptionEngine.B=>"B",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The settings associated with the voice selected
/// </summary>
[JsonConverter(typeof(ActionStartConversationRelayParamsVoiceSettingsConverter))]
public record class ActionStartConversationRelayParamsVoiceSettings : ModelBase
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

    public ActionStartConversationRelayParamsVoiceSettings (
        ElevenLabsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        TelnyxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        AwsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        MinimaxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        AzureVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        ResembleVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        InworldVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        XaiVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (
        SonioxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartConversationRelayParamsVoiceSettings (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartConversationRelayParamsVoiceSettings");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartConversationRelayParamsVoiceSettings")
        } ;
    }

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        ElevenLabsVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        TelnyxVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        AwsVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        MinimaxVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        AzureVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        ResembleVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        InworldVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
        XaiVoiceSettings value
    )=> new(value) ;

    public static implicit operator ActionStartConversationRelayParamsVoiceSettings (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartConversationRelayParamsVoiceSettings");
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
        ActionStartConversationRelayParamsVoiceSettings? other
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
}

sealed class ActionStartConversationRelayParamsVoiceSettingsConverter : JsonConverter<ActionStartConversationRelayParamsVoiceSettings>
{
    public override ActionStartConversationRelayParamsVoiceSettings? Read(
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
                    return new ActionStartConversationRelayParamsVoiceSettings(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionStartConversationRelayParamsVoiceSettings value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}