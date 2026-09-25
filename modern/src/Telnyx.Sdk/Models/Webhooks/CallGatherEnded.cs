using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallGatherEnded, CallGatherEndedFromRaw>))]
public sealed record class CallGatherEnded : JsonModel
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
    public ApiEnum<string, CallGatherEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallGatherEndedEventType>>(
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

    public CallGatherEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallGatherEndedPayload>(
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
    public ApiEnum<string, CallGatherEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallGatherEndedRecordType>>(
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

    public CallGatherEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallGatherEnded (CallGatherEnded callGatherEnded) : base(
        callGatherEnded
    )
    {  }
    #pragma warning restore CS8618

    public CallGatherEnded (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallGatherEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallGatherEndedFromRaw.FromRawUnchecked"/>
    public static CallGatherEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallGatherEndedFromRaw : IFromRawJson<CallGatherEnded>
{
    /// <inheritdoc/>
    public CallGatherEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallGatherEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallGatherEndedEventTypeConverter))]
public enum CallGatherEndedEventType
{
    CallGatherEnded
}sealed class CallGatherEndedEventTypeConverter : JsonConverter<CallGatherEndedEventType>
{
    public override CallGatherEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.gather.ended"=>CallGatherEndedEventType.CallGatherEnded,
            _ =>(CallGatherEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallGatherEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallGatherEndedEventType.CallGatherEnded=>"call.gather.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallGatherEndedPayload, CallGatherEndedPayloadFromRaw>))]
public sealed record class CallGatherEndedPayload : JsonModel
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
    /// The received DTMF digit or symbol.
    /// </summary>
    public string? Digits {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("digits", value);
        }
    }

    /// <summary>
    /// Number or SIP URI placing the call.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// Reflects how command ended.
    /// </summary>
    public ApiEnum<string, CallGatherEndedPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallGatherEndedPayloadStatus>>(
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

    /// <summary>
    /// Destination number or SIP URI of the call.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
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
        _ = this.Digits;
        _ = this.From;
        this.Status?.Validate();
        _ = this.To;
    }

    public CallGatherEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallGatherEndedPayload (
        CallGatherEndedPayload callGatherEndedPayload
    ) : base(callGatherEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallGatherEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallGatherEndedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallGatherEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallGatherEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallGatherEndedPayloadFromRaw : IFromRawJson<CallGatherEndedPayload>
{
    /// <inheritdoc/>
    public CallGatherEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallGatherEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Reflects how command ended.
/// </summary>
[JsonConverter(typeof(CallGatherEndedPayloadStatusConverter))]
public enum CallGatherEndedPayloadStatus
{
    Valid, Invalid, CallHangup, Cancelled, CancelledAmd, Timeout
}sealed class CallGatherEndedPayloadStatusConverter : JsonConverter<CallGatherEndedPayloadStatus>
{
    public override CallGatherEndedPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid"=>CallGatherEndedPayloadStatus.Valid,
            "invalid"=>CallGatherEndedPayloadStatus.Invalid,
            "call_hangup"=>CallGatherEndedPayloadStatus.CallHangup,
            "cancelled"=>CallGatherEndedPayloadStatus.Cancelled,
            "cancelled_amd"=>CallGatherEndedPayloadStatus.CancelledAmd,
            "timeout"=>CallGatherEndedPayloadStatus.Timeout,
            _ =>(CallGatherEndedPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallGatherEndedPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallGatherEndedPayloadStatus.Valid=>"valid",
            CallGatherEndedPayloadStatus.Invalid=>"invalid",
            CallGatherEndedPayloadStatus.CallHangup=>"call_hangup",
            CallGatherEndedPayloadStatus.Cancelled=>"cancelled",
            CallGatherEndedPayloadStatus.CancelledAmd=>"cancelled_amd",
            CallGatherEndedPayloadStatus.Timeout=>"timeout",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallGatherEndedRecordTypeConverter))]
public enum CallGatherEndedRecordType
{
    Event
}sealed class CallGatherEndedRecordTypeConverter : JsonConverter<CallGatherEndedRecordType>
{
    public override CallGatherEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallGatherEndedRecordType.Event,
            _ =>(CallGatherEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallGatherEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallGatherEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}