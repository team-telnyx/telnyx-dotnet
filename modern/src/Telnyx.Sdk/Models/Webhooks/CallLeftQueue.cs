using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallLeftQueue, CallLeftQueueFromRaw>))]
public sealed record class CallLeftQueue : JsonModel
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
    public ApiEnum<string, CallLeftQueueEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallLeftQueueEventType>>(
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

    public CallLeftQueuePayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallLeftQueuePayload>(
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
    public ApiEnum<string, CallLeftQueueRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallLeftQueueRecordType>>(
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

    public CallLeftQueue ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallLeftQueue (CallLeftQueue callLeftQueue) : base(callLeftQueue)
    {  }
    #pragma warning restore CS8618

    public CallLeftQueue (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallLeftQueue (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallLeftQueueFromRaw.FromRawUnchecked"/>
    public static CallLeftQueue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallLeftQueueFromRaw : IFromRawJson<CallLeftQueue>
{
    /// <inheritdoc/>
    public CallLeftQueue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallLeftQueue.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallLeftQueueEventTypeConverter))]
public enum CallLeftQueueEventType
{
    CallDequeued
}sealed class CallLeftQueueEventTypeConverter : JsonConverter<CallLeftQueueEventType>
{
    public override CallLeftQueueEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.dequeued"=>CallLeftQueueEventType.CallDequeued,
            _ =>(CallLeftQueueEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallLeftQueueEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallLeftQueueEventType.CallDequeued=>"call.dequeued",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallLeftQueuePayload, CallLeftQueuePayloadFromRaw>))]
public sealed record class CallLeftQueuePayload : JsonModel
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
    /// The name of the queue
    /// </summary>
    public string? Queue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "queue"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("queue", value);
        }
    }

    /// <summary>
    /// Last position of the call in the queue.
    /// </summary>
    public long? QueuePosition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "queue_position"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("queue_position", value);
        }
    }

    /// <summary>
    /// The reason for leaving the queue
    /// </summary>
    public ApiEnum<string, Reason>? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reason>>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <summary>
    /// Time call spent in the queue in seconds.
    /// </summary>
    public long? WaitTimeSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "wait_time_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wait_time_secs", value);
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
        _ = this.Queue;
        _ = this.QueuePosition;
        this.Reason?.Validate();
        _ = this.WaitTimeSecs;
    }

    public CallLeftQueuePayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallLeftQueuePayload (
        CallLeftQueuePayload callLeftQueuePayload
    ) : base(callLeftQueuePayload)
    {  }
    #pragma warning restore CS8618

    public CallLeftQueuePayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallLeftQueuePayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallLeftQueuePayloadFromRaw.FromRawUnchecked"/>
    public static CallLeftQueuePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallLeftQueuePayloadFromRaw : IFromRawJson<CallLeftQueuePayload>
{
    /// <inheritdoc/>
    public CallLeftQueuePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallLeftQueuePayload.FromRawUnchecked(rawData);
}/// <summary>
/// The reason for leaving the queue
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Bridged, BridgingInProcess, Hangup, Leave, Timeout
}sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bridged"=>Reason.Bridged,
            "bridging-in-process"=>Reason.BridgingInProcess,
            "hangup"=>Reason.Hangup,
            "leave"=>Reason.Leave,
            "timeout"=>Reason.Timeout,
            _ =>(Reason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Reason value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Reason.Bridged=>"bridged",
            Reason.BridgingInProcess=>"bridging-in-process",
            Reason.Hangup=>"hangup",
            Reason.Leave=>"leave",
            Reason.Timeout=>"timeout",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallLeftQueueRecordTypeConverter))]
public enum CallLeftQueueRecordType
{
    Event
}sealed class CallLeftQueueRecordTypeConverter : JsonConverter<CallLeftQueueRecordType>
{
    public override CallLeftQueueRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallLeftQueueRecordType.Event,
            _ =>(CallLeftQueueRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallLeftQueueRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallLeftQueueRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}