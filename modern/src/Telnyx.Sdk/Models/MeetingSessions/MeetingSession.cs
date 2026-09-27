using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MeetingSessions;

/// <summary>
/// Represents a meeting session. All serializer fields are present and required;
/// nullable fields use null when absent. No actor, provider-bot, idempotency, routing,
/// key, or internal fields are exposed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeetingSession, MeetingSessionFromRaw>))]
public sealed record class MeetingSession : JsonModel
{
    /// <summary>
    /// Unique identifier for the meeting session.
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
    /// Identifier of the owning account.
    /// </summary>
    public required string AccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "account_id"
            );
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Assistant configuration if an assistant is attached, otherwise null.
    /// </summary>
    public required MeetingSessionAssistant? Assistant {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MeetingSessionAssistant>(
                "assistant"
            );
        }
        init { this._rawData.Set("assistant", value); }
    }

    /// <summary>
    /// Current state of the assistant, or null if no assistant is attached.
    /// </summary>
    public required ApiEnum<string, AssistantState>? AssistantState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AssistantState>>(
                "assistant_state"
            );
        }
        init { this._rawData.Set("assistant_state", value); }
    }

    /// <summary>
    /// Timestamp of the last assistant state change, or null.
    /// </summary>
    public required System::DateTimeOffset? AssistantStateChangedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "assistant_state_changed_at"
            );
        }
        init { this._rawData.Set("assistant_state_changed_at", value); }
    }

    /// <summary>
    /// Avatar configuration if an avatar is attached, otherwise null.
    /// </summary>
    public required MeetingSessionAvatar? Avatar {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MeetingSessionAvatar>(
                "avatar"
            );
        }
        init { this._rawData.Set("avatar", value); }
    }

    /// <summary>
    /// Current state of the avatar connection, or null if no avatar is attached.
    /// </summary>
    public required ApiEnum<string, AvatarState>? AvatarState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AvatarState>>(
                "avatar_state"
            );
        }
        init { this._rawData.Set("avatar_state", value); }
    }

    /// <summary>
    /// Timestamp of the last avatar state change, or null.
    /// </summary>
    public required System::DateTimeOffset? AvatarStateChangedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "avatar_state_changed_at"
            );
        }
        init { this._rawData.Set("avatar_state_changed_at", value); }
    }

    /// <summary>
    /// Display name of the bot in the meeting.
    /// </summary>
    public required string BotName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "bot_name"
            );
        }
        init { this._rawData.Set("bot_name", value); }
    }

    public required Config Config {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Config>(
                "config"
            );
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// Timestamp when the session was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Timestamp when the session ended, or null if ongoing.
    /// </summary>
    public required System::DateTimeOffset? EndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "ended_at"
            );
        }
        init { this._rawData.Set("ended_at", value); }
    }

    /// <summary>
    /// Human-readable failure reason if the session failed, or null.
    /// </summary>
    public required string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    /// <summary>
    /// Scheduled join time, or null for immediate join.
    /// </summary>
    public required System::DateTimeOffset? JoinAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "join_at"
            );
        }
        init { this._rawData.Set("join_at", value); }
    }

    /// <summary>
    /// Timestamp when the session first became `active`, or null if it never became
    /// active. This remains positive admission evidence after terminal transitions.
    /// </summary>
    public required System::DateTimeOffset? JoinedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "joined_at"
            );
        }
        init { this._rawData.Set("joined_at", value); }
    }

    /// <summary>
    /// The meeting URL the bot joins.
    /// </summary>
    public required string MeetingUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "meeting_url"
            );
        }
        init { this._rawData.Set("meeting_url", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata attached to the session.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Detected meeting platform.
    /// </summary>
    public required ApiEnum<string, Platform> Platform {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Platform>>(
                "platform"
            );
        }
        init { this._rawData.Set("platform", value); }
    }

    /// <summary>
    /// Provider handling the meeting session.
    /// </summary>
    public required string Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Whether the session is being recorded.
    /// </summary>
    public required bool Recording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "recording"
            );
        }
        init { this._rawData.Set("recording", value); }
    }

    /// <summary>
    /// Lifecycle status. `waiting_for_admission` means the bot reached the meeting
    /// lobby and may require host approval. `active` means the bot entered the meeting/media
    /// path. `ended` alone does not prove attendance; use non-null `joined_at` as
    /// positive evidence that the session became active. `admission_denied` is reserved
    /// for an explicit provider denial, while cancellation or another termination
    /// can end a never-admitted session as `ended`.
    /// </summary>
    public required ApiEnum<string, MeetingSessionStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MeetingSessionStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Additional human-readable detail about the status, or null.
    /// </summary>
    public required string? StatusDetail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status_detail"
            );
        }
        init { this._rawData.Set("status_detail", value); }
    }

    /// <summary>
    /// Timestamp of the last update to the session.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Webhook endpoint for session lifecycle callbacks, or null if not configured.
    /// </summary>
    public required string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.Assistant?.Validate();
        this.AssistantState?.Validate();
        _ = this.AssistantStateChangedAt;
        this.Avatar?.Validate();
        this.AvatarState?.Validate();
        _ = this.AvatarStateChangedAt;
        _ = this.BotName;
        this.Config.Validate();
        _ = this.CreatedAt;
        _ = this.EndedAt;
        _ = this.FailureReason;
        _ = this.JoinAt;
        _ = this.JoinedAt;
        _ = this.MeetingUrl;
        _ = this.Metadata;
        this.Platform.Validate();
        _ = this.Provider;
        _ = this.Recording;
        this.Status.Validate();
        _ = this.StatusDetail;
        _ = this.UpdatedAt;
        _ = this.WebhookUrl;
    }

    public MeetingSession ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSession (MeetingSession meetingSession) : base(meetingSession)
    {  }
    #pragma warning restore CS8618

    public MeetingSession (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSession (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionFromRaw.FromRawUnchecked"/>
    public static MeetingSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MeetingSessionFromRaw : IFromRawJson<MeetingSession>
{
    /// <inheritdoc/>
    public MeetingSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSession.FromRawUnchecked(rawData);
}

/// <summary>
/// Assistant configuration if an assistant is attached, otherwise null.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeetingSessionAssistant, MeetingSessionAssistantFromRaw>))]
public sealed record class MeetingSessionAssistant : JsonModel
{
    /// <summary>
    /// Identifier of the assistant.
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
    /// Audio gating strategy in force for the assistant call leg.
    /// </summary>
    public required ApiEnum<string, MeetingSessionAssistantAudioGate> AudioGate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MeetingSessionAssistantAudioGate>>(
                "audio_gate"
            );
        }
        init { this._rawData.Set("audio_gate", value); }
    }

    /// <summary>
    /// The dynamic variables in force for this session, or null when none were supplied.
    /// </summary>
    public required IReadOnlyDictionary<string, string>? DynamicVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "dynamic_variables"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether the bot leaves when the Assistant's conversation ends or fails.
    /// </summary>
    public required bool LeaveOnEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "leave_on_end"
            );
        }
        init { this._rawData.Set("leave_on_end", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AudioGate.Validate();
        _ = this.DynamicVariables;
        _ = this.LeaveOnEnd;
    }

    public MeetingSessionAssistant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionAssistant (
        MeetingSessionAssistant meetingSessionAssistant
    ) : base(meetingSessionAssistant)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionAssistant (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionAssistant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionAssistantFromRaw.FromRawUnchecked"/>
    public static MeetingSessionAssistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MeetingSessionAssistantFromRaw : IFromRawJson<MeetingSessionAssistant>
{
    /// <inheritdoc/>
    public MeetingSessionAssistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionAssistant.FromRawUnchecked(rawData);
}/// <summary>
/// Audio gating strategy in force for the assistant call leg.
/// </summary>
[JsonConverter(typeof(MeetingSessionAssistantAudioGateConverter))]
public enum MeetingSessionAssistantAudioGate
{
    HalfDuplex, FullDuplex
}sealed class MeetingSessionAssistantAudioGateConverter : JsonConverter<MeetingSessionAssistantAudioGate>
{
    public override MeetingSessionAssistantAudioGate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "half_duplex"=>MeetingSessionAssistantAudioGate.HalfDuplex,
            "full_duplex"=>MeetingSessionAssistantAudioGate.FullDuplex,
            _ =>(MeetingSessionAssistantAudioGate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeetingSessionAssistantAudioGate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MeetingSessionAssistantAudioGate.HalfDuplex=>"half_duplex",
            MeetingSessionAssistantAudioGate.FullDuplex=>"full_duplex",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current state of the assistant, or null if no assistant is attached.
/// </summary>
[JsonConverter(typeof(AssistantStateConverter))]
public enum AssistantState
{
    Starting, Connected, Failed, Ended
}sealed class AssistantStateConverter : JsonConverter<AssistantState>
{
    public override AssistantState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "starting"=>AssistantState.Starting,
            "connected"=>AssistantState.Connected,
            "failed"=>AssistantState.Failed,
            "ended"=>AssistantState.Ended,
            _ =>(AssistantState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssistantState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AssistantState.Starting=>"starting",
            AssistantState.Connected=>"connected",
            AssistantState.Failed=>"failed",
            AssistantState.Ended=>"ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Avatar configuration if an avatar is attached, otherwise null.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeetingSessionAvatar, MeetingSessionAvatarFromRaw>))]
public sealed record class MeetingSessionAvatar : JsonModel
{
    /// <summary>
    /// Identifier of the avatar.
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
    /// Avatar provider identifier.
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
        _ = this.AvatarID;
        if (!JsonElementEquality.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("anam")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public MeetingSessionAvatar ()
    { this.Provider = JsonSerializer.SerializeToElement("anam"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionAvatar (
        MeetingSessionAvatar meetingSessionAvatar
    ) : base(meetingSessionAvatar)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionAvatar (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("anam");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionAvatar (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionAvatarFromRaw.FromRawUnchecked"/>
    public static MeetingSessionAvatar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionAvatar (string avatarID) : this()
    { this.AvatarID = avatarID; }
}class MeetingSessionAvatarFromRaw : IFromRawJson<MeetingSessionAvatar>
{
    /// <inheritdoc/>
    public MeetingSessionAvatar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionAvatar.FromRawUnchecked(rawData);
}/// <summary>
/// Current state of the avatar connection, or null if no avatar is attached.
/// </summary>
[JsonConverter(typeof(AvatarStateConverter))]
public enum AvatarState
{
    Starting, Connected, Degraded, Disconnected
}sealed class AvatarStateConverter : JsonConverter<AvatarState>
{
    public override AvatarState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "starting"=>AvatarState.Starting,
            "connected"=>AvatarState.Connected,
            "degraded"=>AvatarState.Degraded,
            "disconnected"=>AvatarState.Disconnected,
            _ =>(AvatarState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AvatarState value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AvatarState.Starting=>"starting",
            AvatarState.Connected=>"connected",
            AvatarState.Degraded=>"degraded",
            AvatarState.Disconnected=>"disconnected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : JsonModel
{
    /// <summary>
    /// When enabled, a human participant `speech_on` event interrupts and stops
    /// the current bot audio; it does not bypass admission or initiate speech. Assistant
    /// sessions reject `barge_in: true`.
    /// </summary>
    public required bool BargeIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "barge_in"
            );
        }
        init { this._rawData.Set("barge_in", value); }
    }

    /// <summary>
    /// The message posted to chat on join, or null when unset.
    /// </summary>
    public required string? ChatOnEnter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "chat_on_enter"
            );
        }
        init { this._rawData.Set("chat_on_enter", value); }
    }

    /// <summary>
    /// Text spoken on meeting entry, or null if not set.
    /// </summary>
    public required string? SpeakOnEnter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "speak_on_enter"
            );
        }
        init { this._rawData.Set("speak_on_enter", value); }
    }

    /// <summary>
    /// Whether a summary artifact is generated on session end.
    /// </summary>
    public required bool SummarizeOnEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "summarize_on_end"
            );
        }
        init { this._rawData.Set("summarize_on_end", value); }
    }

    /// <summary>
    /// Configured voice identifier, or null if not set.
    /// </summary>
    public required string? Voice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice"
            );
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BargeIn;
        _ = this.ChatOnEnter;
        _ = this.SpeakOnEnter;
        _ = this.SummarizeOnEnd;
        _ = this.Voice;
    }

    public Config ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Config (Config config) : base(config)
    {  }
    #pragma warning restore CS8618

    public Config (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Config (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConfigFromRaw : IFromRawJson<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Config.FromRawUnchecked(rawData);
}/// <summary>
/// Detected meeting platform.
/// </summary>
[JsonConverter(typeof(PlatformConverter))]
public enum Platform
{
    Zoom, GoogleMeet, Teams, Webex, Unknown
}sealed class PlatformConverter : JsonConverter<Platform>
{
    public override Platform Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "zoom"=>Platform.Zoom,
            "google_meet"=>Platform.GoogleMeet,
            "teams"=>Platform.Teams,
            "webex"=>Platform.Webex,
            "unknown"=>Platform.Unknown,
            _ =>(Platform)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Platform value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Platform.Zoom=>"zoom",
            Platform.GoogleMeet=>"google_meet",
            Platform.Teams=>"teams",
            Platform.Webex=>"webex",
            Platform.Unknown=>"unknown",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Lifecycle status. `waiting_for_admission` means the bot reached the meeting lobby
/// and may require host approval. `active` means the bot entered the meeting/media
/// path. `ended` alone does not prove attendance; use non-null `joined_at` as positive
/// evidence that the session became active. `admission_denied` is reserved for an
/// explicit provider denial, while cancellation or another termination can end a
/// never-admitted session as `ended`.
/// </summary>
[JsonConverter(typeof(MeetingSessionStatusConverter))]
public enum MeetingSessionStatus
{
    Scheduled,
    Joining,
    WaitingForAdmission,
    Active,
    Leaving,
    Ended,
    Failed,
    AdmissionDenied
}sealed class MeetingSessionStatusConverter : JsonConverter<MeetingSessionStatus>
{
    public override MeetingSessionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scheduled"=>MeetingSessionStatus.Scheduled,
            "joining"=>MeetingSessionStatus.Joining,
            "waiting_for_admission"=>MeetingSessionStatus.WaitingForAdmission,
            "active"=>MeetingSessionStatus.Active,
            "leaving"=>MeetingSessionStatus.Leaving,
            "ended"=>MeetingSessionStatus.Ended,
            "failed"=>MeetingSessionStatus.Failed,
            "admission_denied"=>MeetingSessionStatus.AdmissionDenied,
            _ =>(MeetingSessionStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeetingSessionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MeetingSessionStatus.Scheduled=>"scheduled",
            MeetingSessionStatus.Joining=>"joining",
            MeetingSessionStatus.WaitingForAdmission=>"waiting_for_admission",
            MeetingSessionStatus.Active=>"active",
            MeetingSessionStatus.Leaving=>"leaving",
            MeetingSessionStatus.Ended=>"ended",
            MeetingSessionStatus.Failed=>"failed",
            MeetingSessionStatus.AdmissionDenied=>"admission_denied",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}