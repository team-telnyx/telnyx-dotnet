using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Queues.Calls;

[JsonConverter(typeof(JsonModelConverter<QueueCall, QueueCallFromRaw>))]
public sealed record class QueueCall : JsonModel
{
    /// <summary>
    /// Unique identifier and token for controlling the call.
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
    /// ID that is unique to the call and can be used to correlate webhook events
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
    /// ID that is unique to the call session and can be used to correlate webhook
    /// events. Call session is a group of related call legs that logically belong
    /// to the same phone call, e.g. an inbound and outbound leg of a transferred call
    /// </summary>
    public required string CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_session_id"
            );
        }
        init { this._rawData.Set("call_session_id", value); }
    }

    /// <summary>
    /// Call Control App ID (formerly Telnyx connection ID) used in the call.
    /// </summary>
    public required string ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "connection_id"
            );
        }
        init { this._rawData.Set("connection_id", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the call was put in the queue
    /// </summary>
    public required string EnqueuedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "enqueued_at"
            );
        }
        init { this._rawData.Set("enqueued_at", value); }
    }

    /// <summary>
    /// Number or SIP URI placing the call.
    /// </summary>
    public required string From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Unique identifier of the queue the call is in.
    /// </summary>
    public required string QueueID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "queue_id"
            );
        }
        init { this._rawData.Set("queue_id", value); }
    }

    /// <summary>
    /// Current position of the call in the queue
    /// </summary>
    public required long QueuePosition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "queue_position"
            );
        }
        init { this._rawData.Set("queue_position", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Destination number or SIP URI of the call.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// The time the call has been waiting in the queue, given in seconds
    /// </summary>
    public required long WaitTimeSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "wait_time_secs"
            );
        }
        init { this._rawData.Set("wait_time_secs", value); }
    }

    /// <summary>
    /// Indicates whether the call is still active in the queue.
    /// </summary>
    public bool? IsAlive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_alive"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_alive", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ConnectionID;
        _ = this.EnqueuedAt;
        _ = this.From;
        _ = this.QueueID;
        _ = this.QueuePosition;
        this.RecordType.Validate();
        _ = this.To;
        _ = this.WaitTimeSecs;
        _ = this.IsAlive;
    }

    public QueueCall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueCall (QueueCall queueCall) : base(queueCall)
    {  }
    #pragma warning restore CS8618

    public QueueCall (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueCall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueCallFromRaw.FromRawUnchecked"/>
    public static QueueCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueCallFromRaw : IFromRawJson<QueueCall>
{
    /// <inheritdoc/>
    public QueueCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    QueueCall
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "queue_call"=>RecordType.QueueCall, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.QueueCall=>"queue_call",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}