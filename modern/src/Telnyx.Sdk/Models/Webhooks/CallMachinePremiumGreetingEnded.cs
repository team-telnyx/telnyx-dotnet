using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumGreetingEnded, CallMachinePremiumGreetingEndedFromRaw>))]
public sealed record class CallMachinePremiumGreetingEnded : JsonModel
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
    public ApiEnum<string, CallMachinePremiumGreetingEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumGreetingEndedEventType>>(
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

    public CallMachinePremiumGreetingEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachinePremiumGreetingEndedPayload>(
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
    public ApiEnum<string, CallMachinePremiumGreetingEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumGreetingEndedRecordType>>(
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

    public CallMachinePremiumGreetingEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumGreetingEnded (
        CallMachinePremiumGreetingEnded callMachinePremiumGreetingEnded
    ) : base(callMachinePremiumGreetingEnded)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumGreetingEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumGreetingEnded (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumGreetingEndedFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumGreetingEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachinePremiumGreetingEndedFromRaw : IFromRawJson<CallMachinePremiumGreetingEnded>
{
    /// <inheritdoc/>
    public CallMachinePremiumGreetingEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumGreetingEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumGreetingEndedEventTypeConverter))]
public enum CallMachinePremiumGreetingEndedEventType
{
    CallMachinePremiumGreetingEnded
}sealed class CallMachinePremiumGreetingEndedEventTypeConverter : JsonConverter<CallMachinePremiumGreetingEndedEventType>
{
    public override CallMachinePremiumGreetingEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.machine.premium.greeting.ended"=>CallMachinePremiumGreetingEndedEventType.CallMachinePremiumGreetingEnded,
            _ =>(CallMachinePremiumGreetingEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumGreetingEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumGreetingEndedEventType.CallMachinePremiumGreetingEnded=>"call.machine.premium.greeting.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumGreetingEndedPayload, CallMachinePremiumGreetingEndedPayloadFromRaw>))]
public sealed record class CallMachinePremiumGreetingEndedPayload : JsonModel
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
    /// Premium Answering Machine Greeting Ended result.
    /// </summary>
    public ApiEnum<string, CallMachinePremiumGreetingEndedPayloadResult>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallMachinePremiumGreetingEndedPayloadResult>>(
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

    public CallMachinePremiumGreetingEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumGreetingEndedPayload (
        CallMachinePremiumGreetingEndedPayload callMachinePremiumGreetingEndedPayload
    ) : base(callMachinePremiumGreetingEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumGreetingEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumGreetingEndedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumGreetingEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumGreetingEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallMachinePremiumGreetingEndedPayloadFromRaw : IFromRawJson<CallMachinePremiumGreetingEndedPayload>
{
    /// <inheritdoc/>
    public CallMachinePremiumGreetingEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumGreetingEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Premium Answering Machine Greeting Ended result.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumGreetingEndedPayloadResultConverter))]
public enum CallMachinePremiumGreetingEndedPayloadResult
{
    BeepDetected, NoBeepDetected
}sealed class CallMachinePremiumGreetingEndedPayloadResultConverter : JsonConverter<CallMachinePremiumGreetingEndedPayloadResult>
{
    public override CallMachinePremiumGreetingEndedPayloadResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "beep_detected"=>CallMachinePremiumGreetingEndedPayloadResult.BeepDetected,
            "no_beep_detected"=>CallMachinePremiumGreetingEndedPayloadResult.NoBeepDetected,
            _ =>(CallMachinePremiumGreetingEndedPayloadResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumGreetingEndedPayloadResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumGreetingEndedPayloadResult.BeepDetected=>"beep_detected",
            CallMachinePremiumGreetingEndedPayloadResult.NoBeepDetected=>"no_beep_detected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallMachinePremiumGreetingEndedRecordTypeConverter))]
public enum CallMachinePremiumGreetingEndedRecordType
{
    Event
}sealed class CallMachinePremiumGreetingEndedRecordTypeConverter : JsonConverter<CallMachinePremiumGreetingEndedRecordType>
{
    public override CallMachinePremiumGreetingEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallMachinePremiumGreetingEndedRecordType.Event,
            _ =>(CallMachinePremiumGreetingEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallMachinePremiumGreetingEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallMachinePremiumGreetingEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}