using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachineDetectionEnded, CallMachineDetectionEndedFromRaw>))]
public sealed record class CallMachineDetectionEnded : JsonModel
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
    public ApiEnum<string, CallMachineDetectionEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachineDetectionEndedEventType>>(
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

    public CallMachineDetectionEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachineDetectionEndedPayload>(
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
    public ApiEnum<string, CallMachineDetectionEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachineDetectionEndedRecordType>>(
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

    public CallMachineDetectionEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachineDetectionEnded (
        CallMachineDetectionEnded callMachineDetectionEnded
    ) : base(callMachineDetectionEnded)
    {  }
    #pragma warning restore CS8618

    public CallMachineDetectionEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachineDetectionEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachineDetectionEndedFromRaw.FromRawUnchecked"/>
    public static CallMachineDetectionEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachineDetectionEndedFromRaw : IFromRawJson<CallMachineDetectionEnded>
{
    /// <inheritdoc/>
    public CallMachineDetectionEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachineDetectionEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallMachineDetectionEndedEventTypeConverter))]
public enum CallMachineDetectionEndedEventType
{
    CallMachineDetectionEnded
}sealed class CallMachineDetectionEndedEventTypeConverter : JsonConverter<CallMachineDetectionEndedEventType>
{
    public override CallMachineDetectionEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.machine.detection.ended"=>CallMachineDetectionEndedEventType.CallMachineDetectionEnded,
            _ =>(CallMachineDetectionEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachineDetectionEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachineDetectionEndedEventType.CallMachineDetectionEnded=>"call.machine.detection.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallMachineDetectionEndedPayload, CallMachineDetectionEndedPayloadFromRaw>))]
public sealed record class CallMachineDetectionEndedPayload : JsonModel
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
    /// Answering machine detection result.
    /// </summary>
    public ApiEnum<string, CallMachineDetectionEndedPayloadResult>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachineDetectionEndedPayloadResult>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
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
        _ = this.From;
        this.Result?.Validate();
        _ = this.To;
    }

    public CallMachineDetectionEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachineDetectionEndedPayload (
        CallMachineDetectionEndedPayload callMachineDetectionEndedPayload
    ) : base(callMachineDetectionEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallMachineDetectionEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachineDetectionEndedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachineDetectionEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallMachineDetectionEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallMachineDetectionEndedPayloadFromRaw : IFromRawJson<CallMachineDetectionEndedPayload>
{
    /// <inheritdoc/>
    public CallMachineDetectionEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachineDetectionEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Answering machine detection result.
/// </summary>
[JsonConverter(typeof(CallMachineDetectionEndedPayloadResultConverter))]
public enum CallMachineDetectionEndedPayloadResult
{
    Human, Machine, NotSure
}sealed class CallMachineDetectionEndedPayloadResultConverter : JsonConverter<CallMachineDetectionEndedPayloadResult>
{
    public override CallMachineDetectionEndedPayloadResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "human"=>CallMachineDetectionEndedPayloadResult.Human,
            "machine"=>CallMachineDetectionEndedPayloadResult.Machine,
            "not_sure"=>CallMachineDetectionEndedPayloadResult.NotSure,
            _ =>(CallMachineDetectionEndedPayloadResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachineDetectionEndedPayloadResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachineDetectionEndedPayloadResult.Human=>"human",
            CallMachineDetectionEndedPayloadResult.Machine=>"machine",
            CallMachineDetectionEndedPayloadResult.NotSure=>"not_sure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallMachineDetectionEndedRecordTypeConverter))]
public enum CallMachineDetectionEndedRecordType
{
    Event
}sealed class CallMachineDetectionEndedRecordTypeConverter : JsonConverter<CallMachineDetectionEndedRecordType>
{
    public override CallMachineDetectionEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallMachineDetectionEndedRecordType.Event,
            _ =>(CallMachineDetectionEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachineDetectionEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachineDetectionEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}