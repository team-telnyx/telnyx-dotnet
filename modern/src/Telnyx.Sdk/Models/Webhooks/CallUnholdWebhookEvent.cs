using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallUnholdWebhookEvent, CallUnholdWebhookEventFromRaw>))]
public sealed record class CallUnholdWebhookEvent : JsonModel
{
    public CallUnholdWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallUnholdWebhookEventData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CallUnholdWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallUnholdWebhookEvent (
        CallUnholdWebhookEvent callUnholdWebhookEvent
    ) : base(callUnholdWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallUnholdWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallUnholdWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallUnholdWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallUnholdWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallUnholdWebhookEventFromRaw : IFromRawJson<CallUnholdWebhookEvent>
{
    /// <inheritdoc/>
    public CallUnholdWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallUnholdWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallUnholdWebhookEventData, CallUnholdWebhookEventDataFromRaw>))]
public sealed record class CallUnholdWebhookEventData : JsonModel
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
    public ApiEnum<string, CallUnholdWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallUnholdWebhookEventDataEventType>>(
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

    public CallUnholdWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallUnholdWebhookEventDataPayload>(
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
    public ApiEnum<string, CallUnholdWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallUnholdWebhookEventDataRecordType>>(
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

    public CallUnholdWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallUnholdWebhookEventData (
        CallUnholdWebhookEventData callUnholdWebhookEventData
    ) : base(callUnholdWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallUnholdWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallUnholdWebhookEventData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallUnholdWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallUnholdWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallUnholdWebhookEventDataFromRaw : IFromRawJson<CallUnholdWebhookEventData>
{
    /// <inheritdoc/>
    public CallUnholdWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallUnholdWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallUnholdWebhookEventDataEventTypeConverter))]
public enum CallUnholdWebhookEventDataEventType
{
    CallUnhold
}sealed class CallUnholdWebhookEventDataEventTypeConverter : JsonConverter<CallUnholdWebhookEventDataEventType>
{
    public override CallUnholdWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.unhold"=>CallUnholdWebhookEventDataEventType.CallUnhold,
            _ =>(CallUnholdWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallUnholdWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallUnholdWebhookEventDataEventType.CallUnhold=>"call.unhold",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallUnholdWebhookEventDataPayload, CallUnholdWebhookEventDataPayloadFromRaw>))]
public sealed record class CallUnholdWebhookEventDataPayload : JsonModel
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
        _ = this.To;
    }

    public CallUnholdWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallUnholdWebhookEventDataPayload (
        CallUnholdWebhookEventDataPayload callUnholdWebhookEventDataPayload
    ) : base(callUnholdWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallUnholdWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallUnholdWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallUnholdWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallUnholdWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallUnholdWebhookEventDataPayloadFromRaw : IFromRawJson<CallUnholdWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallUnholdWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallUnholdWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallUnholdWebhookEventDataRecordTypeConverter))]
public enum CallUnholdWebhookEventDataRecordType
{
    Event
}sealed class CallUnholdWebhookEventDataRecordTypeConverter : JsonConverter<CallUnholdWebhookEventDataRecordType>
{
    public override CallUnholdWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallUnholdWebhookEventDataRecordType.Event,
            _ =>(CallUnholdWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallUnholdWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallUnholdWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}