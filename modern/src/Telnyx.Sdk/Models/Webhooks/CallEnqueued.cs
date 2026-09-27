using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallEnqueued, CallEnqueuedFromRaw>))]
public sealed record class CallEnqueued : JsonModel
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
    public ApiEnum<string, CallEnqueuedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallEnqueuedEventType>>(
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

    public CallEnqueuedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallEnqueuedPayload>(
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
    public ApiEnum<string, CallEnqueuedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallEnqueuedRecordType>>(
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

    public CallEnqueued ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEnqueued (CallEnqueued callEnqueued) : base(callEnqueued)
    {  }
    #pragma warning restore CS8618

    public CallEnqueued (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEnqueued (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallEnqueuedFromRaw.FromRawUnchecked"/>
    public static CallEnqueued FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallEnqueuedFromRaw : IFromRawJson<CallEnqueued>
{
    /// <inheritdoc/>
    public CallEnqueued FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallEnqueued.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallEnqueuedEventTypeConverter))]
public enum CallEnqueuedEventType
{
    CallEnqueued
}sealed class CallEnqueuedEventTypeConverter : JsonConverter<CallEnqueuedEventType>
{
    public override CallEnqueuedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.enqueued"=>CallEnqueuedEventType.CallEnqueued,
            _ =>(CallEnqueuedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallEnqueuedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallEnqueuedEventType.CallEnqueued=>"call.enqueued",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallEnqueuedPayload, CallEnqueuedPayloadFromRaw>))]
public sealed record class CallEnqueuedPayload : JsonModel
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
    /// Current position of the call in the queue.
    /// </summary>
    public long? CurrentPosition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "current_position"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_position", value);
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
    /// Average time call spends in the queue in seconds.
    /// </summary>
    public long? QueueAvgWaitTimeSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "queue_avg_wait_time_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("queue_avg_wait_time_secs", value);
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
        _ = this.CurrentPosition;
        _ = this.Queue;
        _ = this.QueueAvgWaitTimeSecs;
    }

    public CallEnqueuedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEnqueuedPayload (CallEnqueuedPayload callEnqueuedPayload) : base(
        callEnqueuedPayload
    )
    {  }
    #pragma warning restore CS8618

    public CallEnqueuedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEnqueuedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallEnqueuedPayloadFromRaw.FromRawUnchecked"/>
    public static CallEnqueuedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallEnqueuedPayloadFromRaw : IFromRawJson<CallEnqueuedPayload>
{
    /// <inheritdoc/>
    public CallEnqueuedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallEnqueuedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallEnqueuedRecordTypeConverter))]
public enum CallEnqueuedRecordType
{
    Event
}sealed class CallEnqueuedRecordTypeConverter : JsonConverter<CallEnqueuedRecordType>
{
    public override CallEnqueuedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallEnqueuedRecordType.Event,
            _ =>(CallEnqueuedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallEnqueuedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallEnqueuedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}