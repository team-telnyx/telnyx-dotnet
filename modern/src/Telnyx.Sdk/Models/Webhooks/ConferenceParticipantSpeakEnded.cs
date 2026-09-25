using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantSpeakEnded, ConferenceParticipantSpeakEndedFromRaw>))]
public sealed record class ConferenceParticipantSpeakEnded : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, ConferenceParticipantSpeakEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceParticipantSpeakEndedEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    public ConferenceParticipantSpeakEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantSpeakEndedPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, ConferenceParticipantSpeakEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceParticipantSpeakEndedRecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public ConferenceParticipantSpeakEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantSpeakEnded (
        ConferenceParticipantSpeakEnded conferenceParticipantSpeakEnded
    ) : base(conferenceParticipantSpeakEnded)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantSpeakEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantSpeakEnded (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantSpeakEndedFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantSpeakEndedFromRaw : IFromRawJson<ConferenceParticipantSpeakEnded>
{
    /// <inheritdoc/>
    public ConferenceParticipantSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantSpeakEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(ConferenceParticipantSpeakEndedEventTypeConverter))]
public enum ConferenceParticipantSpeakEndedEventType
{
    ConferenceParticipantSpeakEnded
}sealed class ConferenceParticipantSpeakEndedEventTypeConverter : JsonConverter<ConferenceParticipantSpeakEndedEventType>
{
    public override ConferenceParticipantSpeakEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conference.participant.speak.ended"=>ConferenceParticipantSpeakEndedEventType.ConferenceParticipantSpeakEnded,
            _ =>(ConferenceParticipantSpeakEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceParticipantSpeakEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceParticipantSpeakEndedEventType.ConferenceParticipantSpeakEnded=>"conference.participant.speak.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantSpeakEndedPayload, ConferenceParticipantSpeakEndedPayloadFromRaw>))]
public sealed record class ConferenceParticipantSpeakEndedPayload : JsonModel
{
    /// <summary>
    /// Participant's call ID used to issue commands via Call Control API.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call and can be used to correlate webhook events.
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call session and can be used to correlate webhook
    /// events. Call session is a group of related call legs that logically belong
    /// to the same phone call, e.g. an inbound and outbound leg of a transferred call.
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <summary>
    /// State received from a command.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// ID of the conference the text was spoken in.
    /// </summary>
    public string? ConferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_id", value);
        }
    }

    /// <summary>
    /// Call Control App ID (formerly Telnyx connection ID) used in the call.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call session that started the conference.
    /// </summary>
    public string? CreatorCallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "creator_call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("creator_call_session_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConferenceID;
        _ = this.ConnectionID;
        _ = this.CreatorCallSessionID;
        _ = this.OccurredAt;
    }

    public ConferenceParticipantSpeakEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantSpeakEndedPayload (
        ConferenceParticipantSpeakEndedPayload conferenceParticipantSpeakEndedPayload
    ) : base(conferenceParticipantSpeakEndedPayload)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantSpeakEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantSpeakEndedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantSpeakEndedPayloadFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceParticipantSpeakEndedPayloadFromRaw : IFromRawJson<ConferenceParticipantSpeakEndedPayload>
{
    /// <inheritdoc/>
    public ConferenceParticipantSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantSpeakEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ConferenceParticipantSpeakEndedRecordTypeConverter))]
public enum ConferenceParticipantSpeakEndedRecordType
{
    Event
}sealed class ConferenceParticipantSpeakEndedRecordTypeConverter : JsonConverter<ConferenceParticipantSpeakEndedRecordType>
{
    public override ConferenceParticipantSpeakEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>ConferenceParticipantSpeakEndedRecordType.Event,
            _ =>(ConferenceParticipantSpeakEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceParticipantSpeakEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceParticipantSpeakEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}