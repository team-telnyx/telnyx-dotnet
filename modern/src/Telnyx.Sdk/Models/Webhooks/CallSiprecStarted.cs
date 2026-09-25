using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSiprecStarted, CallSiprecStartedFromRaw>))]
public sealed record class CallSiprecStarted : JsonModel
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
    public ApiEnum<string, CallSiprecStartedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSiprecStartedEventType>>(
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

    public CallSiprecStartedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSiprecStartedPayload>(
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
    public ApiEnum<string, CallSiprecStartedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSiprecStartedRecordType>>(
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

    public CallSiprecStarted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecStarted (CallSiprecStarted callSiprecStarted) : base(
        callSiprecStarted
    )
    {  }
    #pragma warning restore CS8618

    public CallSiprecStarted (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecStarted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecStartedFromRaw.FromRawUnchecked"/>
    public static CallSiprecStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSiprecStartedFromRaw : IFromRawJson<CallSiprecStarted>
{
    /// <inheritdoc/>
    public CallSiprecStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecStarted.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallSiprecStartedEventTypeConverter))]
public enum CallSiprecStartedEventType
{
    SiprecStarted
}sealed class CallSiprecStartedEventTypeConverter : JsonConverter<CallSiprecStartedEventType>
{
    public override CallSiprecStartedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "siprec.started"=>CallSiprecStartedEventType.SiprecStarted,
            _ =>(CallSiprecStartedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSiprecStartedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSiprecStartedEventType.SiprecStarted=>"siprec.started",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallSiprecStartedPayload, CallSiprecStartedPayloadFromRaw>))]
public sealed record class CallSiprecStartedPayload : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
    }

    public CallSiprecStartedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecStartedPayload (
        CallSiprecStartedPayload callSiprecStartedPayload
    ) : base(callSiprecStartedPayload)
    {  }
    #pragma warning restore CS8618

    public CallSiprecStartedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecStartedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecStartedPayloadFromRaw.FromRawUnchecked"/>
    public static CallSiprecStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallSiprecStartedPayloadFromRaw : IFromRawJson<CallSiprecStartedPayload>
{
    /// <inheritdoc/>
    public CallSiprecStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecStartedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallSiprecStartedRecordTypeConverter))]
public enum CallSiprecStartedRecordType
{
    Event
}sealed class CallSiprecStartedRecordTypeConverter : JsonConverter<CallSiprecStartedRecordType>
{
    public override CallSiprecStartedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallSiprecStartedRecordType.Event,
            _ =>(CallSiprecStartedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSiprecStartedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSiprecStartedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}