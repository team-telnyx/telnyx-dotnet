using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<UpdateConference, UpdateConferenceFromRaw>))]
public sealed record class UpdateConference : JsonModel
{
    /// <summary>
    /// Unique identifier and token for controlling the call
    /// </summary>
    public required string CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawData.Set("call_control_id", value); }
    }

    /// <summary>
    /// Sets the participant as a supervisor for the conference. A conference can
    /// have multiple supervisors. "barge" means the supervisor enters the conference
    /// as a normal participant. This is the same as "none". "monitor" means the supervisor
    /// is muted but can hear all participants. "whisper" means that only the specified
    /// "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
    /// </summary>
    public required ApiEnum<string, UpdateConferenceSupervisorRole> SupervisorRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UpdateConferenceSupervisorRole>>(
                "supervisor_role"
            );
        }
        init { this._rawData.Set("supervisor_role", value); }
    }

    /// <summary>
    /// Use this field to avoid execution of duplicate commands. Telnyx will ignore
    /// subsequent commands with the same `command_id` as one that has already been executed.
    /// </summary>
    public string? CommandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Region where the conference data is located. Defaults to the region defined
    /// in user's data locality settings (Europe or US).
    /// </summary>
    public ApiEnum<string, ConferenceRegion>? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceRegion>>(
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
    /// Array of unique call_control_ids the supervisor can whisper to. If none provided,
    /// the supervisor will join the conference as a monitoring participant only.
    /// </summary>
    public IReadOnlyList<string>? WhisperCallControlIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whisper_call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whisper_call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        this.SupervisorRole.Validate();
        _ = this.CommandID;
        this.Region?.Validate();
        _ = this.WhisperCallControlIds;
    }

    public UpdateConference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateConference (UpdateConference updateConference) : base(
        updateConference
    )
    {  }
    #pragma warning restore CS8618

    public UpdateConference (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateConference (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateConferenceFromRaw.FromRawUnchecked"/>
    public static UpdateConference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateConferenceFromRaw : IFromRawJson<UpdateConference>
{
    /// <inheritdoc/>
    public UpdateConference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateConference.FromRawUnchecked(rawData);
}

/// <summary>
/// Sets the participant as a supervisor for the conference. A conference can have
/// multiple supervisors. "barge" means the supervisor enters the conference as a
/// normal participant. This is the same as "none". "monitor" means the supervisor
/// is muted but can hear all participants. "whisper" means that only the specified
/// "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
/// </summary>
[JsonConverter(typeof(UpdateConferenceSupervisorRoleConverter))]
public enum UpdateConferenceSupervisorRole
{
    Barge, Monitor, None, Whisper
}sealed class UpdateConferenceSupervisorRoleConverter : JsonConverter<UpdateConferenceSupervisorRole>
{
    public override UpdateConferenceSupervisorRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>UpdateConferenceSupervisorRole.Barge,
            "monitor"=>UpdateConferenceSupervisorRole.Monitor,
            "none"=>UpdateConferenceSupervisorRole.None,
            "whisper"=>UpdateConferenceSupervisorRole.Whisper,
            _ =>(UpdateConferenceSupervisorRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateConferenceSupervisorRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateConferenceSupervisorRole.Barge=>"barge",
            UpdateConferenceSupervisorRole.Monitor=>"monitor",
            UpdateConferenceSupervisorRole.None=>"none",
            UpdateConferenceSupervisorRole.Whisper=>"whisper",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}