using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceSpeakEnded, ConferenceSpeakEndedFromRaw>))]
public sealed record class ConferenceSpeakEnded : JsonModel
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
    public ApiEnum<string, ConferenceSpeakEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceSpeakEndedEventType>>(
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

    public ConferenceSpeakEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceSpeakEndedPayload>(
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
    public ApiEnum<string, ConferenceSpeakEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceSpeakEndedRecordType>>(
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

    public ConferenceSpeakEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceSpeakEnded (
        ConferenceSpeakEnded conferenceSpeakEnded
    ) : base(conferenceSpeakEnded)
    {  }
    #pragma warning restore CS8618

    public ConferenceSpeakEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceSpeakEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceSpeakEndedFromRaw.FromRawUnchecked"/>
    public static ConferenceSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceSpeakEndedFromRaw : IFromRawJson<ConferenceSpeakEnded>
{
    /// <inheritdoc/>
    public ConferenceSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceSpeakEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(ConferenceSpeakEndedEventTypeConverter))]
public enum ConferenceSpeakEndedEventType
{
    ConferenceSpeakEnded
}sealed class ConferenceSpeakEndedEventTypeConverter : JsonConverter<ConferenceSpeakEndedEventType>
{
    public override ConferenceSpeakEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conference.speak.ended"=>ConferenceSpeakEndedEventType.ConferenceSpeakEnded,
            _ =>(ConferenceSpeakEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceSpeakEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceSpeakEndedEventType.ConferenceSpeakEnded=>"conference.speak.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ConferenceSpeakEndedPayload, ConferenceSpeakEndedPayloadFromRaw>))]
public sealed record class ConferenceSpeakEndedPayload : JsonModel
{
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
        _ = this.ConferenceID;
        _ = this.ConnectionID;
        _ = this.CreatorCallSessionID;
        _ = this.OccurredAt;
    }

    public ConferenceSpeakEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceSpeakEndedPayload (
        ConferenceSpeakEndedPayload conferenceSpeakEndedPayload
    ) : base(conferenceSpeakEndedPayload)
    {  }
    #pragma warning restore CS8618

    public ConferenceSpeakEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceSpeakEndedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceSpeakEndedPayloadFromRaw.FromRawUnchecked"/>
    public static ConferenceSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceSpeakEndedPayloadFromRaw : IFromRawJson<ConferenceSpeakEndedPayload>
{
    /// <inheritdoc/>
    public ConferenceSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceSpeakEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ConferenceSpeakEndedRecordTypeConverter))]
public enum ConferenceSpeakEndedRecordType
{
    Event
}sealed class ConferenceSpeakEndedRecordTypeConverter : JsonConverter<ConferenceSpeakEndedRecordType>
{
    public override ConferenceSpeakEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>ConferenceSpeakEndedRecordType.Event,
            _ =>(ConferenceSpeakEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceSpeakEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceSpeakEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}