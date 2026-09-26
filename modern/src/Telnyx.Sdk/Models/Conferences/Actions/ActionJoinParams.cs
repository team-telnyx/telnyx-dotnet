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

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Join an existing call leg to a conference. Issue the Join Conference command with
/// the conference ID in the path and the `call_control_id` of the leg you wish to
/// join to the conference as an attribute. The conference can have up to a certain
/// amount of active participants, as set by the `max_participants` parameter in conference
/// creation request.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `conference.participant.joined` - `conference.participant.left`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionJoinParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Unique identifier and token for controlling the call
    /// </summary>
    public required string CallControlID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawBodyData.Set("call_control_id", value); }
    }

    /// <summary>
    /// Whether a beep sound should be played when the participant joins and/or leaves
    /// the conference. Can be used to override the conference-level setting.
    /// </summary>
    public ApiEnum<string, BeepEnabled>? BeepEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BeepEnabled>>(
                "beep_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("beep_enabled", value);
        }
    }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string. Please note that the client_state will be updated
    /// for the participient call leg and the change will not affect conferencing
    /// webhooks unless the participient is the owner of the conference.
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
    /// Whether the conference should end and all remaining participants be hung up
    /// after the participant leaves the conference. Defaults to "false".
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the participant should be put on hold immediately after joining the
    /// conference. Defaults to "false".
    /// </summary>
    public bool? Hold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold", value);
        }
    }

    /// <summary>
    /// The URL of a file to be played to the participant when they are put on hold
    /// after joining the conference. hold_media_name and hold_audio_url cannot be
    /// used together in one request. Takes effect only when "start_conference_on_create"
    /// is set to "false". This property takes effect only if "hold" is set to "true".
    /// </summary>
    public string? HoldAudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "hold_audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold_audio_url", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played to the participant when they are put
    /// on hold after joining the conference. The media_name must point to a file
    /// previously uploaded to api.telnyx.com/v2/media by the same user/organization.
    /// The file must either be a WAV or MP3 file. Takes effect only when "start_conference_on_create"
    /// is set to "false". This property takes effect only if "hold" is set to "true".
    /// </summary>
    public string? HoldMediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "hold_media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold_media_name", value);
        }
    }

    /// <summary>
    /// Whether the participant should be muted immediately after joining the conference.
    /// Defaults to "false".
    /// </summary>
    public bool? Mute {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "mute"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mute", value);
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
    /// Whether the conference should end after the participant leaves the conference.
    /// NOTE this doesn't hang up the other participants. Defaults to "false".
    /// </summary>
    public bool? SoftEndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "soft_end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("soft_end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the conference should be started after the participant joins the conference.
    /// Defaults to "false".
    /// </summary>
    public bool? StartConferenceOnEnter {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "start_conference_on_enter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("start_conference_on_enter", value);
        }
    }

    /// <summary>
    /// Sets the joining participant as a supervisor for the conference. A conference
    /// can have multiple supervisors. "barge" means the supervisor enters the conference
    /// as a normal participant. This is the same as "none". "monitor" means the
    /// supervisor is muted but can hear all participants. "whisper" means that only
    /// the specified "whisper_call_control_ids" can hear the supervisor. Defaults
    /// to "none".
    /// </summary>
    public ApiEnum<string, ActionJoinParamsSupervisorRole>? SupervisorRole {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionJoinParamsSupervisorRole>>(
                "supervisor_role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("supervisor_role", value);
        }
    }

    /// <summary>
    /// Array of unique call_control_ids the joining supervisor can whisper to. If
    /// none provided, the supervisor will join the conference as a monitoring participant only.
    /// </summary>
    public IReadOnlyList<string>? WhisperCallControlIds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "whisper_call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "whisper_call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ActionJoinParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionJoinParams (ActionJoinParams actionJoinParams) : base(
        actionJoinParams
    )
    {
        this.ID = actionJoinParams.ID;

        this._rawBodyData = new(actionJoinParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionJoinParams (
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
    ActionJoinParams (
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
    public static ActionJoinParams FromRawUnchecked(
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

    public virtual bool Equals(ActionJoinParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/actions/join",
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
/// Whether a beep sound should be played when the participant joins and/or leaves
/// the conference. Can be used to override the conference-level setting.
/// </summary>
[JsonConverter(typeof(BeepEnabledConverter))]
public enum BeepEnabled
{
    Always, Never, OnEnter, OnExit
}

sealed class BeepEnabledConverter : JsonConverter<BeepEnabled>
{
    public override BeepEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>BeepEnabled.Always,
            "never"=>BeepEnabled.Never,
            "on_enter"=>BeepEnabled.OnEnter,
            "on_exit"=>BeepEnabled.OnExit,
            _ =>(BeepEnabled)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, BeepEnabled value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BeepEnabled.Always=>"always",
            BeepEnabled.Never=>"never",
            BeepEnabled.OnEnter=>"on_enter",
            BeepEnabled.OnExit=>"on_exit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sets the joining participant as a supervisor for the conference. A conference
/// can have multiple supervisors. "barge" means the supervisor enters the conference
/// as a normal participant. This is the same as "none". "monitor" means the supervisor
/// is muted but can hear all participants. "whisper" means that only the specified
/// "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
/// </summary>
[JsonConverter(typeof(ActionJoinParamsSupervisorRoleConverter))]
public enum ActionJoinParamsSupervisorRole
{
    Barge, Monitor, None, Whisper
}

sealed class ActionJoinParamsSupervisorRoleConverter : JsonConverter<ActionJoinParamsSupervisorRole>
{
    public override ActionJoinParamsSupervisorRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>ActionJoinParamsSupervisorRole.Barge,
            "monitor"=>ActionJoinParamsSupervisorRole.Monitor,
            "none"=>ActionJoinParamsSupervisorRole.None,
            "whisper"=>ActionJoinParamsSupervisorRole.Whisper,
            _ =>(ActionJoinParamsSupervisorRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionJoinParamsSupervisorRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionJoinParamsSupervisorRole.Barge=>"barge",
            ActionJoinParamsSupervisorRole.Monitor=>"monitor",
            ActionJoinParamsSupervisorRole.None=>"none",
            ActionJoinParamsSupervisorRole.Whisper=>"whisper",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}