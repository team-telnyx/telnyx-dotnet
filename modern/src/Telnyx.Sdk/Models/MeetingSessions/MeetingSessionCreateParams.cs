using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MeetingSessions;

/// <summary>
/// Creates a new meeting session. When an idempotency_key is supplied in the request
/// body, replay lookup is scoped to the authenticated account and compares only the
/// key; the request payload is not fingerprinted or compared. If a session with that
/// key already exists for the account, the existing session is replayed (200); otherwise
/// a new session is created (201). Supports bring-your-own-key (BYOK) configuration.
/// The session may enter asynchronous states (e.g. joining, waiting_for_admission)
/// before becoming active. Optional `camera_image` input is write-only and applies
/// only when no Avatar or Assistant webpage output takes precedence. An ignored
/// URL is not fetched. An effective URL source is resolved before bot creation; neither
/// the source URL nor image bytes are persisted, returned, or logged. Treat signed
/// URLs as credentials.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MeetingSessionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The meeting URL the bot should join.
    /// </summary>
    public required string MeetingUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "meeting_url"
            );
        }
        init { this._rawBodyData.Set("meeting_url", value); }
    }

    /// <summary>
    /// Attach a Telnyx AI Assistant to the session. Supply the Assistant's ID; the
    /// Meeting service connects it to the meeting directly. The Call Control connection,
    /// caller ID and loopback SIP URI previously required here have been removed
    /// and are now rejected as unknown fields.
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
    /// Request options for attaching a bring-your-own-key avatar to the session.
    /// </summary>
    public Avatar? Avatar {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Avatar>(
                "avatar"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("avatar", value);
        }
    }

    /// <summary>
    /// When enabled, a human participant `speech_on` event interrupts and stops
    /// the current bot audio; it does not bypass admission or initiate speech. Assistant
    /// sessions reject `barge_in: true`.
    /// </summary>
    public bool? BargeIn {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "barge_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("barge_in", value);
        }
    }

    /// <summary>
    /// Display name for the bot in the meeting. Defaults to "Meeting Bot".
    /// </summary>
    public string? BotName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "bot_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bot_name", value);
        }
    }

    /// <summary>
    /// Write-only static camera-tile image for this session, not a native account
    /// or participant profile photo. Supply exactly one JPEG source. When effective,
    /// the image is used as the bot's static camera/video output; presentation varies
    /// by meeting platform and recording configuration and is not guaranteed in recordings.
    /// An effective Avatar or Assistant webpage output takes precedence, so this
    /// input is ignored and a URL source is not fetched.
    /// </summary>
    public CameraImage? CameraImage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CameraImage>(
                "camera_image"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("camera_image", value);
        }
    }

    /// <summary>
    /// A message the bot posts to the meeting's chat as soon as it becomes active
    /// — typically a recording disclosure. Delivered at most once. Independent of
    /// `speak_on_enter`: both may be set, and the chat message posts first because
    /// it does not wait for text-to-speech or avatar startup. Rejected with 422
    /// `unsupported_capability` on platforms without meeting chat.
    /// </summary>
    public string? ChatOnEnter {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "chat_on_enter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("chat_on_enter", value);
        }
    }

    /// <summary>
    /// Client-supplied idempotency key to safely retry creation requests without
    /// duplicating sessions. Lookup is scoped to the authenticated account and compares
    /// the key only; the request payload is not fingerprinted or compared.
    /// </summary>
    public string? IdempotencyKey {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "idempotency_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("idempotency_key", value);
        }
    }

    /// <summary>
    /// ISO-8601 timestamp in the future at which the bot should join. If omitted,
    /// the bot joins immediately.
    /// </summary>
    public System::DateTimeOffset? JoinAt {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>(
                "join_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("join_at", value);
        }
    }

    /// <summary>
    /// Arbitrary key-value metadata attached to the session. The serialized JSON
    /// representation must not exceed 16384 characters at runtime.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Text the bot speaks when it enters the meeting. **Not spoken when an `assistant`
    /// is attached**: the value is accepted and echoed back on the session, but the
    /// assistant owns the voice and the line is never delivered, with no event reporting
    /// the omission. Use `chat_on_enter` to announce an assistant-backed bot.
    /// </summary>
    public string? SpeakOnEnter {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "speak_on_enter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("speak_on_enter", value);
        }
    }

    /// <summary>
    /// If true, generate a summary artifact when the session ends.
    /// </summary>
    public bool? SummarizeOnEnd {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "summarize_on_end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("summarize_on_end", value);
        }
    }

    /// <summary>
    /// Session-default voice identifier used for `speak_on_enter` and ordinary speak
    /// actions. A voice supplied on an individual speak action overrides this default
    /// for that utterance.
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
    /// HTTPS endpoint to receive session lifecycle callbacks. Static validation requires
    /// HTTPS, rejects embedded credentials and blocked hosts, and enforces egress
    /// policy. Validation makes no network request to the endpoint.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public MeetingSessionCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionCreateParams (
        MeetingSessionCreateParams meetingSessionCreateParams
    ) : base(meetingSessionCreateParams)
    { this._rawBodyData = new(meetingSessionCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public MeetingSessionCreateParams (
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
    MeetingSessionCreateParams (
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
    public static MeetingSessionCreateParams FromRawUnchecked(
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

    public virtual bool Equals(MeetingSessionCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/meeting_sessions"
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
/// Attach a Telnyx AI Assistant to the session. Supply the Assistant's ID; the Meeting
/// service connects it to the meeting directly. The Call Control connection, caller
/// ID and loopback SIP URI previously required here have been removed and are now
/// rejected as unknown fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Assistant, AssistantFromRaw>))]
public sealed record class Assistant : JsonModel
{
    /// <summary>
    /// Identifier of the assistant to attach.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Audio gating strategy for the assistant call leg. `half_duplex` (default)
    /// sends the assistant a single mixed meeting stream and mutes it while the assistant
    /// speaks, so the assistant cannot hear itself and cannot be interrupted. `full_duplex`
    /// sends a separate stream per participant, which allows barge-in and removes
    /// self-hearing, and COSTS SIGNIFICANTLY MORE: per-participant streams multiply
    /// the per-minute cost by the number of participants.
    /// </summary>
    public ApiEnum<string, AudioGate>? AudioGate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudioGate>>(
                "audio_gate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("audio_gate", value);
        }
    }

    /// <summary>
    /// Per-conversation values for the [dynamic variables](/docs/inference/ai-assistants/dynamic-variables)
    /// used in the Assistant's instructions, greeting, or tools. Delivered before
    /// the Assistant's first utterance, so they resolve for the opening line as
    /// well as the rest of the conversation. At most 63 entries; keys 1-128 characters;
    /// values must be strings. The map is budgeted in aggregate at 1,047,552 bytes
    /// (1023 KiB) rather than capped per value. `streaming_audio`, `ai_assistant_streaming_audio`
    /// and `meeting_session_id` are reserved and rejected with `400 invalid_request`
    /// -- they toggle provider infrastructure or are set by the service rather than
    /// fill a prompt template.
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

    /// <summary>
    /// Leave the meeting when the Assistant's conversation reaches a terminal state
    /// -- `ended` **or** `failed`. Off by default, which leaves the bot in the meeting
    /// after the Assistant stops. Fires once: a second terminal transition does
    /// not leave twice, and a leave the provider refuses is logged without changing
    /// how the session settles.
    /// </summary>
    public bool? LeaveOnEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "leave_on_end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("leave_on_end", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AudioGate?.Validate();
        _ = this.DynamicVariables;
        _ = this.LeaveOnEnd;
    }

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

    [SetsRequiredMembers]
    public Assistant (string id) : this()
    { this.ID = id; }
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
/// Audio gating strategy for the assistant call leg. `half_duplex` (default) sends
/// the assistant a single mixed meeting stream and mutes it while the assistant
/// speaks, so the assistant cannot hear itself and cannot be interrupted. `full_duplex`
/// sends a separate stream per participant, which allows barge-in and removes self-hearing,
/// and COSTS SIGNIFICANTLY MORE: per-participant streams multiply the per-minute
/// cost by the number of participants.
/// </summary>
[JsonConverter(typeof(AudioGateConverter))]
public enum AudioGate
{
    HalfDuplex, FullDuplex
}

sealed class AudioGateConverter : JsonConverter<AudioGate>
{
    public override AudioGate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "half_duplex"=>AudioGate.HalfDuplex,
            "full_duplex"=>AudioGate.FullDuplex,
            _ =>(AudioGate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AudioGate value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AudioGate.HalfDuplex=>"half_duplex",
            AudioGate.FullDuplex=>"full_duplex",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Request options for attaching a bring-your-own-key avatar to the session.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Avatar, AvatarFromRaw>))]
public sealed record class Avatar : JsonModel
{
    /// <summary>
    /// Bring-your-own-key API key for the avatar provider. The key is never stored
    /// or returned by the API.
    /// </summary>
    public required string ApiKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_key"
            );
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// Identifier of the avatar to use.
    /// </summary>
    public required string AvatarID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "avatar_id"
            );
        }
        init { this._rawData.Set("avatar_id", value); }
    }

    /// <summary>
    /// Avatar provider identifier. Currently only "anam" is supported.
    /// </summary>
    public JsonElement Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.AvatarID;
        if (!JsonElementEquality.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("anam")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Avatar ()
    { this.Provider = JsonSerializer.SerializeToElement("anam"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Avatar (Avatar avatar) : base(avatar)
    {  }
    #pragma warning restore CS8618

    public Avatar (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("anam");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Avatar (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AvatarFromRaw.FromRawUnchecked"/>
    public static Avatar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AvatarFromRaw : IFromRawJson<Avatar>
{
    /// <inheritdoc/>
    public Avatar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Avatar.FromRawUnchecked(rawData);
}

/// <summary>
/// Write-only static camera-tile image for this session, not a native account or
/// participant profile photo. Supply exactly one JPEG source. When effective, the
/// image is used as the bot's static camera/video output; presentation varies by
/// meeting platform and recording configuration and is not guaranteed in recordings.
/// An effective Avatar or Assistant webpage output takes precedence, so this input
/// is ignored and a URL source is not fetched.
/// </summary>
[JsonConverter(typeof(CameraImageConverter))]
public record class CameraImage : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement Format {
        get {
            return Match(meetingSessionCameraImageBase64Source: ( x )=>x.Format,
            meetingSessionCameraImageUrlSource: ( x )=>x.Format);
        }
    }

    public CameraImage (
        MeetingSessionCameraImageBase64Source value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CameraImage (
        MeetingSessionCameraImageUrlSource value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CameraImage (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MeetingSessionCameraImageBase64Source"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMeetingSessionCameraImageBase64Source(out var value)) {
///     // `value` is of type `MeetingSessionCameraImageBase64Source`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMeetingSessionCameraImageBase64Source(
        [NotNullWhen(true)] out MeetingSessionCameraImageBase64Source? value
    )
    {
        value =this.Value as MeetingSessionCameraImageBase64Source ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MeetingSessionCameraImageUrlSource"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMeetingSessionCameraImageUrlSource(out var value)) {
///     // `value` is of type `MeetingSessionCameraImageUrlSource`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMeetingSessionCameraImageUrlSource(
        [NotNullWhen(true)] out MeetingSessionCameraImageUrlSource? value
    )
    {
        value =this.Value as MeetingSessionCameraImageUrlSource ;
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
///     (MeetingSessionCameraImageBase64Source value) =&gt; {...},
///     (MeetingSessionCameraImageUrlSource value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<MeetingSessionCameraImageBase64Source> meetingSessionCameraImageBase64Source,
        System::Action<MeetingSessionCameraImageUrlSource> meetingSessionCameraImageUrlSource
    )
    {
        switch (this.Value)
        {
            case MeetingSessionCameraImageBase64Source value:
                meetingSessionCameraImageBase64Source(value);
                break;
            case MeetingSessionCameraImageUrlSource value:
                meetingSessionCameraImageUrlSource(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CameraImage");

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
///     (MeetingSessionCameraImageBase64Source value) =&gt; {...},
///     (MeetingSessionCameraImageUrlSource value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<MeetingSessionCameraImageBase64Source, T> meetingSessionCameraImageBase64Source,
        System::Func<MeetingSessionCameraImageUrlSource, T> meetingSessionCameraImageUrlSource
    )
    {
        return this.Value switch
        {
            MeetingSessionCameraImageBase64Source value=>meetingSessionCameraImageBase64Source(value),
            MeetingSessionCameraImageUrlSource value=>meetingSessionCameraImageUrlSource(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CameraImage")
        } ;
    }

    public static implicit operator CameraImage (
        MeetingSessionCameraImageBase64Source value
    )=> new(value) ;

    public static implicit operator CameraImage (
        MeetingSessionCameraImageUrlSource value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CameraImage");
        }
        this.Switch((meetingSessionCameraImageBase64Source) => meetingSessionCameraImageBase64Source.Validate(),
        (meetingSessionCameraImageUrlSource) => meetingSessionCameraImageUrlSource.Validate());
    }

    public virtual bool Equals(CameraImage? other)
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
            MeetingSessionCameraImageBase64Source _=>0,
            MeetingSessionCameraImageUrlSource _=>1,
            _ =>-1
        } ;
    }
}

sealed class CameraImageConverter : JsonConverter<CameraImage>
{
    public override CameraImage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<MeetingSessionCameraImageBase64Source>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MeetingSessionCameraImageUrlSource>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, CameraImage value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<MeetingSessionCameraImageBase64Source, MeetingSessionCameraImageBase64SourceFromRaw>))]
public sealed record class MeetingSessionCameraImageBase64Source : JsonModel
{
    /// <summary>
    /// Canonical plain RFC 4648 Base64 for a valid decoded JPEG. Data URIs, whitespace,
    /// and the URL-safe alphabet are rejected. The encoded value is limited to 1,835,008
    /// characters and the decoded JPEG to 1,363,148 bytes. The JPEG is limited to
    /// 4,096 pixels per dimension, 4 megapixels, and 128 MB of decoder memory. The
    /// image bytes are not persisted, returned, or logged.
    /// </summary>
    public required string Base64Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "base64_data"
            );
        }
        init { this._rawData.Set("base64_data", value); }
    }

    /// <summary>
    /// Only JPEG images are accepted.
    /// </summary>
    public JsonElement Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "format"
            );
        }
        init { this._rawData.Set("format", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Base64Data;
        if (!JsonElementEquality.DeepEquals(this.Format, JsonSerializer.SerializeToElement("jpeg")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public MeetingSessionCameraImageBase64Source ()
    { this.Format = JsonSerializer.SerializeToElement("jpeg"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionCameraImageBase64Source (
        MeetingSessionCameraImageBase64Source meetingSessionCameraImageBase64Source
    ) : base(meetingSessionCameraImageBase64Source)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionCameraImageBase64Source (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Format = JsonSerializer.SerializeToElement("jpeg");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionCameraImageBase64Source (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionCameraImageBase64SourceFromRaw.FromRawUnchecked"/>
    public static MeetingSessionCameraImageBase64Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionCameraImageBase64Source (string base64Data) : this()
    { this.Base64Data = base64Data; }
}

class MeetingSessionCameraImageBase64SourceFromRaw : IFromRawJson<MeetingSessionCameraImageBase64Source>
{
    /// <inheritdoc/>
    public MeetingSessionCameraImageBase64Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionCameraImageBase64Source.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MeetingSessionCameraImageUrlSource, MeetingSessionCameraImageUrlSourceFromRaw>))]
public sealed record class MeetingSessionCameraImageUrlSource : JsonModel
{
    /// <summary>
    /// Only JPEG images are accepted.
    /// </summary>
    public JsonElement Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "format"
            );
        }
        init { this._rawData.Set("format", value); }
    }

    /// <summary>
    /// Public HTTPS JPEG URL with at most 2,048 characters and no credentials, fragment,
    /// surrounding whitespace, raw control characters, or explicit non-default port.
    /// Signed queries are allowed but must be treated as credentials. Fetching is
    /// limited to public network destinations, a five-second timeout, no redirects,
    /// a 2xx image/jpeg response with identity or no content encoding, and a 1,363,148-byte
    /// limit enforced against both declared and streamed content. The service resolves
    /// the URL before bot creation and does not persist, return, or log the URL
    /// or image bytes.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.Format, JsonSerializer.SerializeToElement("jpeg")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public MeetingSessionCameraImageUrlSource ()
    { this.Format = JsonSerializer.SerializeToElement("jpeg"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionCameraImageUrlSource (
        MeetingSessionCameraImageUrlSource meetingSessionCameraImageUrlSource
    ) : base(meetingSessionCameraImageUrlSource)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionCameraImageUrlSource (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Format = JsonSerializer.SerializeToElement("jpeg");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionCameraImageUrlSource (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionCameraImageUrlSourceFromRaw.FromRawUnchecked"/>
    public static MeetingSessionCameraImageUrlSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionCameraImageUrlSource (string url) : this()
    { this.Url = url; }
}

class MeetingSessionCameraImageUrlSourceFromRaw : IFromRawJson<MeetingSessionCameraImageUrlSource>
{
    /// <inheritdoc/>
    public MeetingSessionCameraImageUrlSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionCameraImageUrlSource.FromRawUnchecked(rawData);
}