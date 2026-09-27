using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumDetectionEnded, CallMachinePremiumDetectionEndedFromRaw>))]
public sealed record class CallMachinePremiumDetectionEnded : JsonModel
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
    public ApiEnum<string, CallMachinePremiumDetectionEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumDetectionEndedEventType>>(
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

    public CallMachinePremiumDetectionEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachinePremiumDetectionEndedPayload>(
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
    public ApiEnum<string, CallMachinePremiumDetectionEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumDetectionEndedRecordType>>(
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

    public CallMachinePremiumDetectionEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumDetectionEnded (
        CallMachinePremiumDetectionEnded callMachinePremiumDetectionEnded
    ) : base(callMachinePremiumDetectionEnded)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumDetectionEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumDetectionEnded (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumDetectionEndedFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumDetectionEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachinePremiumDetectionEndedFromRaw : IFromRawJson<CallMachinePremiumDetectionEnded>
{
    /// <inheritdoc/>
    public CallMachinePremiumDetectionEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumDetectionEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumDetectionEndedEventTypeConverter))]
public enum CallMachinePremiumDetectionEndedEventType
{
    CallMachinePremiumDetectionEnded
}sealed class CallMachinePremiumDetectionEndedEventTypeConverter : JsonConverter<CallMachinePremiumDetectionEndedEventType>
{
    public override CallMachinePremiumDetectionEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.machine.premium.detection.ended"=>CallMachinePremiumDetectionEndedEventType.CallMachinePremiumDetectionEnded,
            _ =>(CallMachinePremiumDetectionEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumDetectionEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumDetectionEndedEventType.CallMachinePremiumDetectionEnded=>"call.machine.premium.detection.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumDetectionEndedPayload, CallMachinePremiumDetectionEndedPayloadFromRaw>))]
public sealed record class CallMachinePremiumDetectionEndedPayload : JsonModel
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
    /// Premium Answering Machine Detection result.
    /// </summary>
    public ApiEnum<string, CallMachinePremiumDetectionEndedPayloadResult>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumDetectionEndedPayloadResult>>(
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

    public CallMachinePremiumDetectionEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumDetectionEndedPayload (
        CallMachinePremiumDetectionEndedPayload callMachinePremiumDetectionEndedPayload
    ) : base(callMachinePremiumDetectionEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumDetectionEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumDetectionEndedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumDetectionEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumDetectionEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallMachinePremiumDetectionEndedPayloadFromRaw : IFromRawJson<CallMachinePremiumDetectionEndedPayload>
{
    /// <inheritdoc/>
    public CallMachinePremiumDetectionEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumDetectionEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Premium Answering Machine Detection result.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumDetectionEndedPayloadResultConverter))]
public enum CallMachinePremiumDetectionEndedPayloadResult
{
    HumanResidence, HumanBusiness, Machine, Silence, FaxDetected, NotSure
}sealed class CallMachinePremiumDetectionEndedPayloadResultConverter : JsonConverter<CallMachinePremiumDetectionEndedPayloadResult>
{
    public override CallMachinePremiumDetectionEndedPayloadResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "human_residence"=>CallMachinePremiumDetectionEndedPayloadResult.HumanResidence,
            "human_business"=>CallMachinePremiumDetectionEndedPayloadResult.HumanBusiness,
            "machine"=>CallMachinePremiumDetectionEndedPayloadResult.Machine,
            "silence"=>CallMachinePremiumDetectionEndedPayloadResult.Silence,
            "fax_detected"=>CallMachinePremiumDetectionEndedPayloadResult.FaxDetected,
            "not_sure"=>CallMachinePremiumDetectionEndedPayloadResult.NotSure,
            _ =>(CallMachinePremiumDetectionEndedPayloadResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumDetectionEndedPayloadResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumDetectionEndedPayloadResult.HumanResidence=>"human_residence",
            CallMachinePremiumDetectionEndedPayloadResult.HumanBusiness=>"human_business",
            CallMachinePremiumDetectionEndedPayloadResult.Machine=>"machine",
            CallMachinePremiumDetectionEndedPayloadResult.Silence=>"silence",
            CallMachinePremiumDetectionEndedPayloadResult.FaxDetected=>"fax_detected",
            CallMachinePremiumDetectionEndedPayloadResult.NotSure=>"not_sure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumDetectionEndedRecordTypeConverter))]
public enum CallMachinePremiumDetectionEndedRecordType
{
    Event
}sealed class CallMachinePremiumDetectionEndedRecordTypeConverter : JsonConverter<CallMachinePremiumDetectionEndedRecordType>
{
    public override CallMachinePremiumDetectionEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallMachinePremiumDetectionEndedRecordType.Event,
            _ =>(CallMachinePremiumDetectionEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumDetectionEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumDetectionEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}