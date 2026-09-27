using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSpeakEnded, CallSpeakEndedFromRaw>))]
public sealed record class CallSpeakEnded : JsonModel
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
    public ApiEnum<string, CallSpeakEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSpeakEndedEventType>>(
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

    public CallSpeakEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSpeakEndedPayload>(
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
    public ApiEnum<string, CallSpeakEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSpeakEndedRecordType>>(
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
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public CallSpeakEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSpeakEnded (CallSpeakEnded callSpeakEnded) : base(callSpeakEnded)
    {  }
    #pragma warning restore CS8618

    public CallSpeakEnded (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSpeakEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSpeakEndedFromRaw.FromRawUnchecked"/>
    public static CallSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSpeakEndedFromRaw : IFromRawJson<CallSpeakEnded>
{
    /// <inheritdoc/>
    public CallSpeakEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSpeakEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallSpeakEndedEventTypeConverter))]
public enum CallSpeakEndedEventType
{
    CallSpeakEnded
}sealed class CallSpeakEndedEventTypeConverter : JsonConverter<CallSpeakEndedEventType>
{
    public override CallSpeakEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.speak.ended"=>CallSpeakEndedEventType.CallSpeakEnded,
            _ =>(CallSpeakEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSpeakEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSpeakEndedEventType.CallSpeakEnded=>"call.speak.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallSpeakEndedPayload, CallSpeakEndedPayloadFromRaw>))]
public sealed record class CallSpeakEndedPayload : JsonModel
{
    /// <summary>
    /// Call ID used to issue commands via Call Control API.
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
    /// Reflects how the command ended.
    /// </summary>
    public ApiEnum<string, CallSpeakEndedPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSpeakEndedPayloadStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.Status?.Validate();
    }

    public CallSpeakEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSpeakEndedPayload (
        CallSpeakEndedPayload callSpeakEndedPayload
    ) : base(callSpeakEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallSpeakEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSpeakEndedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSpeakEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallSpeakEndedPayloadFromRaw : IFromRawJson<CallSpeakEndedPayload>
{
    /// <inheritdoc/>
    public CallSpeakEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSpeakEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Reflects how the command ended.
/// </summary>
[JsonConverter(typeof(CallSpeakEndedPayloadStatusConverter))]
public enum CallSpeakEndedPayloadStatus
{
    Completed, CallHangup, CancelledAmd
}sealed class CallSpeakEndedPayloadStatusConverter : JsonConverter<CallSpeakEndedPayloadStatus>
{
    public override CallSpeakEndedPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed"=>CallSpeakEndedPayloadStatus.Completed,
            "call_hangup"=>CallSpeakEndedPayloadStatus.CallHangup,
            "cancelled_amd"=>CallSpeakEndedPayloadStatus.CancelledAmd,
            _ =>(CallSpeakEndedPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSpeakEndedPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSpeakEndedPayloadStatus.Completed=>"completed",
            CallSpeakEndedPayloadStatus.CallHangup=>"call_hangup",
            CallSpeakEndedPayloadStatus.CancelledAmd=>"cancelled_amd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallSpeakEndedRecordTypeConverter))]
public enum CallSpeakEndedRecordType
{
    Event
}sealed class CallSpeakEndedRecordTypeConverter : JsonConverter<CallSpeakEndedRecordType>
{
    public override CallSpeakEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallSpeakEndedRecordType.Event,
            _ =>(CallSpeakEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSpeakEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSpeakEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}