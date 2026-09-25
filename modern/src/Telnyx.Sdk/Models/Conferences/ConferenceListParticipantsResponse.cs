using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceListParticipantsResponse, ConferenceListParticipantsResponseFromRaw>))]
public sealed record class ConferenceListParticipantsResponse : JsonModel
{
    /// <summary>
    /// Uniquely identifies the participant
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
    /// Call Control ID associated with the partiipant of the conference
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
    /// Uniquely identifies the call leg associated with the participant
    /// </summary>
    public required string CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_leg_id"
            );
        }
        init { this._rawData.Set("call_leg_id", value); }
    }

    /// <summary>
    /// Info about the conference that the participant is in
    /// </summary>
    public required ConferenceListParticipantsResponseConference Conference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConferenceListParticipantsResponseConference>(
                "conference"
            );
        }
        init { this._rawData.Set("conference", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the participant was created
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Whether the conference will end and all remaining participants be hung up
    /// after the participant leaves the conference.
    /// </summary>
    public required bool EndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "end_conference_on_exit"
            );
        }
        init { this._rawData.Set("end_conference_on_exit", value); }
    }

    /// <summary>
    /// Whether the participant is muted.
    /// </summary>
    public required bool Muted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "muted"
            );
        }
        init { this._rawData.Set("muted", value); }
    }

    /// <summary>
    /// Whether the participant is put on_hold.
    /// </summary>
    public required bool OnHold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "on_hold"
            );
        }
        init { this._rawData.Set("on_hold", value); }
    }

    public required ApiEnum<string, ConferenceListParticipantsResponseRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConferenceListParticipantsResponseRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Whether the conference will end after the participant leaves the conference.
    /// </summary>
    public required bool SoftEndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "soft_end_conference_on_exit"
            );
        }
        init { this._rawData.Set("soft_end_conference_on_exit", value); }
    }

    /// <summary>
    /// The status of the participant with respect to the lifecycle within the conference
    /// </summary>
    public required ApiEnum<string, ConferenceListParticipantsResponseStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConferenceListParticipantsResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the participant was last updated
    /// </summary>
    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Array of unique call_control_ids the participant can whisper to..
    /// </summary>
    public required IReadOnlyList<string> WhisperCallControlIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "whisper_call_control_ids"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "whisper_call_control_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallControlID;
        _ = this.CallLegID;
        this.Conference.Validate();
        _ = this.CreatedAt;
        _ = this.EndConferenceOnExit;
        _ = this.Muted;
        _ = this.OnHold;
        this.RecordType.Validate();
        _ = this.SoftEndConferenceOnExit;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.WhisperCallControlIds;
    }

    public ConferenceListParticipantsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParticipantsResponse (
        ConferenceListParticipantsResponse conferenceListParticipantsResponse
    ) : base(conferenceListParticipantsResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceListParticipantsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParticipantsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceListParticipantsResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceListParticipantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceListParticipantsResponseFromRaw : IFromRawJson<ConferenceListParticipantsResponse>
{
    /// <inheritdoc/>
    public ConferenceListParticipantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceListParticipantsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Info about the conference that the participant is in
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConferenceListParticipantsResponseConference, ConferenceListParticipantsResponseConferenceFromRaw>))]
public sealed record class ConferenceListParticipantsResponseConference : JsonModel
{
    /// <summary>
    /// Uniquely identifies the conference
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Name of the conference
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public ConferenceListParticipantsResponseConference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParticipantsResponseConference (
        ConferenceListParticipantsResponseConference conferenceListParticipantsResponseConference
    ) : base(conferenceListParticipantsResponseConference)
    {  }
    #pragma warning restore CS8618

    public ConferenceListParticipantsResponseConference (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParticipantsResponseConference (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceListParticipantsResponseConferenceFromRaw.FromRawUnchecked"/>
    public static ConferenceListParticipantsResponseConference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceListParticipantsResponseConferenceFromRaw : IFromRawJson<ConferenceListParticipantsResponseConference>
{
    /// <inheritdoc/>
    public ConferenceListParticipantsResponseConference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceListParticipantsResponseConference.FromRawUnchecked(rawData);
}[JsonConverter(typeof(ConferenceListParticipantsResponseRecordTypeConverter))]
public enum ConferenceListParticipantsResponseRecordType
{
    Participant
}sealed class ConferenceListParticipantsResponseRecordTypeConverter : JsonConverter<ConferenceListParticipantsResponseRecordType>
{
    public override ConferenceListParticipantsResponseRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "participant"=>ConferenceListParticipantsResponseRecordType.Participant,
            _ =>(ConferenceListParticipantsResponseRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceListParticipantsResponseRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceListParticipantsResponseRecordType.Participant=>"participant",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the participant with respect to the lifecycle within the conference
/// </summary>
[JsonConverter(typeof(ConferenceListParticipantsResponseStatusConverter))]
public enum ConferenceListParticipantsResponseStatus
{
    Joining, Joined, Left
}sealed class ConferenceListParticipantsResponseStatusConverter : JsonConverter<ConferenceListParticipantsResponseStatus>
{
    public override ConferenceListParticipantsResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "joining"=>ConferenceListParticipantsResponseStatus.Joining,
            "joined"=>ConferenceListParticipantsResponseStatus.Joined,
            "left"=>ConferenceListParticipantsResponseStatus.Left,
            _ =>(ConferenceListParticipantsResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceListParticipantsResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceListParticipantsResponseStatus.Joining=>"joining",
            ConferenceListParticipantsResponseStatus.Joined=>"joined",
            ConferenceListParticipantsResponseStatus.Left=>"left",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}