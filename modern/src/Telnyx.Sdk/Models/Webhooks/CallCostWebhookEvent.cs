using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallCostWebhookEvent, CallCostWebhookEventFromRaw>))]
public sealed record class CallCostWebhookEvent : JsonModel
{
    public CallCostWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallCostWebhookEventData>(
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

    public CallCostWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCostWebhookEvent (
        CallCostWebhookEvent callCostWebhookEvent
    ) : base(callCostWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallCostWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCostWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallCostWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallCostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallCostWebhookEventFromRaw : IFromRawJson<CallCostWebhookEvent>
{
    /// <inheritdoc/>
    public CallCostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallCostWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallCostWebhookEventData, CallCostWebhookEventDataFromRaw>))]
public sealed record class CallCostWebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier of the event.
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
    public ApiEnum<string, CallCostWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallCostWebhookEventDataEventType>>(
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

    public CallCostWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallCostWebhookEventDataPayload>(
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
    public ApiEnum<string, CallCostWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallCostWebhookEventDataRecordType>>(
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

    public CallCostWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCostWebhookEventData (
        CallCostWebhookEventData callCostWebhookEventData
    ) : base(callCostWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallCostWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCostWebhookEventData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallCostWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallCostWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallCostWebhookEventDataFromRaw : IFromRawJson<CallCostWebhookEventData>
{
    /// <inheritdoc/>
    public CallCostWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallCostWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallCostWebhookEventDataEventTypeConverter))]
public enum CallCostWebhookEventDataEventType
{
    CallCost
}sealed class CallCostWebhookEventDataEventTypeConverter : JsonConverter<CallCostWebhookEventDataEventType>
{
    public override CallCostWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.cost"=>CallCostWebhookEventDataEventType.CallCost,
            _ =>(CallCostWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallCostWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallCostWebhookEventDataEventType.CallCost=>"call.cost",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallCostWebhookEventDataPayload, CallCostWebhookEventDataPayloadFromRaw>))]
public sealed record class CallCostWebhookEventDataPayload : JsonModel
{
    /// <summary>
    /// The longest billed duration across all cost parts, in seconds.
    /// </summary>
    public long? BilledDurationSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "billed_duration_secs"
            );
        }
        init { this._rawData.Set("billed_duration_secs", value); }
    }

    /// <summary>
    /// Identifies the billing group associated with the call.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init { this._rawData.Set("billing_group_id", value); }
    }

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
    /// State received from a command. Base64-encoded.
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
    /// Breakdown of costs by call part.
    /// </summary>
    public IReadOnlyList<CostPart>? CostParts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CostPart>>(
                "cost_parts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CostPart>?>(
                "cost_parts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// The status of the cost calculation (`success` or `error`).
    /// </summary>
    public ApiEnum<string, CallCostWebhookEventDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallCostWebhookEventDataPayloadStatus>>(
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
    /// The total cost of the call.
    /// </summary>
    public string? TotalCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "total_cost"
            );
        }
        init { this._rawData.Set("total_cost", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledDurationSecs;
        _ = this.BillingGroupID;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        foreach (var item in this.CostParts ?? [])
        {
            item.Validate();
        }
        _ = this.OccurredAt;
        this.Status?.Validate();
        _ = this.TotalCost;
    }

    public CallCostWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCostWebhookEventDataPayload (
        CallCostWebhookEventDataPayload callCostWebhookEventDataPayload
    ) : base(callCostWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallCostWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCostWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallCostWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallCostWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallCostWebhookEventDataPayloadFromRaw : IFromRawJson<CallCostWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallCostWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallCostWebhookEventDataPayload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CostPart, CostPartFromRaw>))]
public sealed record class CostPart : JsonModel
{
    /// <summary>
    /// The billed duration in seconds for this part of the call.
    /// </summary>
    public long? BilledDurationSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "billed_duration_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billed_duration_secs", value);
        }
    }

    /// <summary>
    /// The product component this cost applies to. Values are determined by the
    /// billing system (e.g. sip-trunking, call-control, call-recording). Not a fixed
    /// set — new values may appear as products evolve.
    /// </summary>
    public string? CallPart {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_part"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_part", value);
        }
    }

    /// <summary>
    /// The cost for this part of the call.
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// The currency of the cost.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// The per-minute rate applied.
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledDurationSecs;
        _ = this.CallPart;
        _ = this.Cost;
        _ = this.Currency;
        _ = this.Rate;
    }

    public CostPart ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostPart (CostPart costPart) : base(costPart)
    {  }
    #pragma warning restore CS8618

    public CostPart (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CostPart (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostPartFromRaw.FromRawUnchecked"/>
    public static CostPart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostPartFromRaw : IFromRawJson<CostPart>
{
    /// <inheritdoc/>
    public CostPart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CostPart.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the cost calculation (`success` or `error`).
/// </summary>
[JsonConverter(typeof(CallCostWebhookEventDataPayloadStatusConverter))]
public enum CallCostWebhookEventDataPayloadStatus
{
    Success, Error
}sealed class CallCostWebhookEventDataPayloadStatusConverter : JsonConverter<CallCostWebhookEventDataPayloadStatus>
{
    public override CallCostWebhookEventDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success"=>CallCostWebhookEventDataPayloadStatus.Success,
            "error"=>CallCostWebhookEventDataPayloadStatus.Error,
            _ =>(CallCostWebhookEventDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallCostWebhookEventDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallCostWebhookEventDataPayloadStatus.Success=>"success",
            CallCostWebhookEventDataPayloadStatus.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallCostWebhookEventDataRecordTypeConverter))]
public enum CallCostWebhookEventDataRecordType
{
    Event
}sealed class CallCostWebhookEventDataRecordTypeConverter : JsonConverter<CallCostWebhookEventDataRecordType>
{
    public override CallCostWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallCostWebhookEventDataRecordType.Event,
            _ =>(CallCostWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallCostWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallCostWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}