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
using Assistants = Telnyx.Sdk.Models.AI.Assistants;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Gather parameters defined in the request payload using a voice assistant.
///
/// <para> You can pass parameters described as a JSON Schema object and the voice
/// assistant will attempt to gather these informations. </para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.ai_gather.ended` - `call.conversation.ended` - `call.ai_gather.partial_results`
/// (if `send_partial_results` is set to `true`) - `call.ai_gather.message_history_updated`
/// (if `send_message_history_updates` is set to `true`)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionGatherUsingAIParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// The parameters described as a JSON Schema object that needs to be gathered
    /// by the voice assistant. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Parameters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "parameters"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>>(
                "parameters",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Assistant configuration including choice of LLM, custom instructions, and tools.
    /// </summary>
    public Assistants::Assistant? Assistant {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Assistants::Assistant>(
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
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
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
    /// Text that will be played when the gathering has finished. There is a 3,000
    /// character limit.
    /// </summary>
    public string? GatherEndedSpeech {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "gather_ended_speech"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("gather_ended_speech", value);
        }
    }

    /// <summary>
    /// Text that will be played when the gathering starts, if none then nothing will
    /// be played when the gathering starts. The greeting can be text for any voice
    /// or SSML for `AWS.Polly.&lt;voice_id&gt;` voices. There is a 3,000 character limit.
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
    /// Settings for handling user interruptions during assistant speech
    /// </summary>
    public InterruptionSettings? InterruptionSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InterruptionSettings>(
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
    /// Language to use for speech recognition
    /// </summary>
    public ApiEnum<string, GoogleTranscriptionLanguage>? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, GoogleTranscriptionLanguage>>(
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
    /// The message history you want the voice assistant to be aware of, this can
    /// be useful to keep the context of the conversation, or to pass additional information
    /// to the voice assistant.
    /// </summary>
    public IReadOnlyList<MessageHistory>? MessageHistory {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<MessageHistory>>(
                "message_history"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<MessageHistory>?>(
                "message_history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default is `false`. If set to `true`, the voice assistant will send updates
    /// to the message history via the `call.ai_gather.message_history_updated` callback
    /// in real time as the message history is updated.
    /// </summary>
    public bool? SendMessageHistoryUpdates {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "send_message_history_updates"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_message_history_updates", value);
        }
    }

    /// <summary>
    /// Default is `false`. If set to `true`, the voice assistant will send partial
    /// results via the `call.ai_gather.partial_results` callback in real time as
    /// individual fields are gathered. If set to `false`, the voice assistant will
    /// only send the final result via the `call.ai_gather.ended` callback.
    /// </summary>
    public bool? SendPartialResults {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "send_partial_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_partial_results", value);
        }
    }

    /// <summary>
    /// The settings associated with speech to text for the voice assistant. This
    /// is only relevant if the assistant uses a text-to-text language model. Any
    /// assistant using a model with native audio support (e.g. `fixie-ai/ultravox-v0_4`)
    /// will ignore this field.
    /// </summary>
    public TranscriptionConfig? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TranscriptionConfig>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription", value);
        }
    }

    /// <summary>
    /// The maximum time in milliseconds to wait for user response before timing out.
    /// </summary>
    public long? UserResponseTimeoutMs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "user_response_timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("user_response_timeout_ms", value);
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

    public ActionGatherUsingAIParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherUsingAIParams (
        ActionGatherUsingAIParams actionGatherUsingAIParams
    ) : base(actionGatherUsingAIParams)
    {
        this.CallControlID = actionGatherUsingAIParams.CallControlID;

        this._rawBodyData = new(actionGatherUsingAIParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionGatherUsingAIParams (
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
    ActionGatherUsingAIParams (
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
    public static ActionGatherUsingAIParams FromRawUnchecked(
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

    public virtual bool Equals(ActionGatherUsingAIParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/gather_using_ai",
            EncodePathSegment(this.CallControlID))
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

[JsonConverter(typeof(JsonModelConverter<MessageHistory, MessageHistoryFromRaw>))]
public sealed record class MessageHistory : JsonModel
{
    /// <summary>
    /// The content of the message
    /// </summary>
    public string? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// The role of the message sender
    /// </summary>
    public ApiEnum<string, Role>? Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Role>>(
                "role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("role", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role?.Validate();
    }

    public MessageHistory ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageHistory (MessageHistory messageHistory) : base(messageHistory)
    {  }
    #pragma warning restore CS8618

    public MessageHistory (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageHistory (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageHistoryFromRaw.FromRawUnchecked"/>
    public static MessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageHistoryFromRaw : IFromRawJson<MessageHistory>
{
    /// <inheritdoc/>
    public MessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageHistory.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the message sender
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    Assistant, User
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "assistant"=>Role.Assistant, "user"=>Role.User, _ =>(Role)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Role value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Role.Assistant=>"assistant",
            Role.User=>"user",
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
            azure: ( x )=>x.ApiKeyRef,
            resemble: ( _ )=>null,
            xai: ( _ )=>null,
            soniox: ( _ )=>null);
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
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
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
        System::Action<AzureVoiceSettings> azure,
        System::Action<ResembleVoiceSettings> resemble,
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
            case AzureVoiceSettings value:
                azure(value);
                break;
            case ResembleVoiceSettings value:
                resemble(value);
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
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
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
        System::Func<AzureVoiceSettings, T> azure,
        System::Func<ResembleVoiceSettings, T> resemble,
        System::Func<XaiVoiceSettings, T> xai,
        System::Func<SonioxVoiceSettings, T> soniox
    )
    {
        return this.Value switch
        {
            ElevenLabsVoiceSettings value=>elevenLabs(value),
            TelnyxVoiceSettings value=>telnyx(value),
            AwsVoiceSettings value=>aws(value),
            AzureVoiceSettings value=>azure(value),
            ResembleVoiceSettings value=>resemble(value),
            XaiVoiceSettings value=>xai(value),
            SonioxVoiceSettings value=>soniox(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettings")
        } ;
    }

    public static implicit operator VoiceSettings (
        ElevenLabsVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        TelnyxVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        AwsVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        AzureVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        ResembleVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
        XaiVoiceSettings value
    )=> new(value) ;

    public static implicit operator VoiceSettings (
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
        (azure) => azure.Validate(),
        (resemble) => resemble.Validate(),
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
            ElevenLabsVoiceSettings _=>0,
            TelnyxVoiceSettings _=>1,
            AwsVoiceSettings _=>2,
            AzureVoiceSettings _=>3,
            ResembleVoiceSettings _=>4,
            XaiVoiceSettings _=>5,
            SonioxVoiceSettings _=>6,
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