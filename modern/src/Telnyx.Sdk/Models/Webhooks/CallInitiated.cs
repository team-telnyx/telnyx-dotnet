using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Calls;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallInitiated, CallInitiatedFromRaw>))]
public sealed record class CallInitiated : JsonModel
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
    public ApiEnum<string, CallInitiatedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallInitiatedEventType>>(
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

    public CallInitiatedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallInitiatedPayload>(
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
    public ApiEnum<string, CallInitiatedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallInitiatedRecordType>>(
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

    public CallInitiated ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallInitiated (CallInitiated callInitiated) : base(callInitiated)
    {  }
    #pragma warning restore CS8618

    public CallInitiated (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallInitiated (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallInitiatedFromRaw.FromRawUnchecked"/>
    public static CallInitiated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallInitiatedFromRaw : IFromRawJson<CallInitiated>
{
    /// <inheritdoc/>
    public CallInitiated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallInitiated.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallInitiatedEventTypeConverter))]
public enum CallInitiatedEventType
{
    CallInitiated
}sealed class CallInitiatedEventTypeConverter : JsonConverter<CallInitiatedEventType>
{
    public override CallInitiatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.initiated"=>CallInitiatedEventType.CallInitiated,
            _ =>(CallInitiatedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallInitiatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallInitiatedEventType.CallInitiated=>"call.initiated",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallInitiatedPayload, CallInitiatedPayloadFromRaw>))]
public sealed record class CallInitiatedPayload : JsonModel
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
    /// Call screening result.
    /// </summary>
    public string? CallScreeningResult {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_screening_result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_screening_result", value);
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
    /// Caller id.
    /// </summary>
    public string? CallerIDName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "caller_id_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caller_id_name", value);
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
    /// The list of comma-separated codecs enabled for the connection.
    /// </summary>
    public string? ConnectionCodecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_codecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_codecs", value);
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
    /// Custom headers from sip invite
    /// </summary>
    public IReadOnlyList<CustomSipHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomSipHeader>>(
                "custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomSipHeader>?>(
                "custom_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the call is `incoming` or `outgoing`.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
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
    /// The list of comma-separated codecs offered by caller.
    /// </summary>
    public string? OfferedCodecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "offered_codecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("offered_codecs", value);
        }
    }

    /// <summary>
    /// SHAKEN/STIR attestation level.
    /// </summary>
    public string? ShakenStirAttestation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "shaken_stir_attestation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shaken_stir_attestation", value);
        }
    }

    /// <summary>
    /// Whether attestation was successfully validated or not.
    /// </summary>
    public bool? ShakenStirValidated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shaken_stir_validated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shaken_stir_validated", value);
        }
    }

    /// <summary>
    /// User-to-User and Diversion headers from sip invite.
    /// </summary>
    public IReadOnlyList<InboundSipHeader>? SipHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InboundSipHeader>>(
                "sip_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InboundSipHeader>?>(
                "sip_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when the call started.
    /// </summary>
    public System::DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// State received from a command.
    /// </summary>
    public ApiEnum<string, CallInitiatedPayloadState>? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallInitiatedPayloadState>>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Array of tags associated to number.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.CallScreeningResult;
        _ = this.CallSessionID;
        _ = this.CallerIDName;
        _ = this.ClientState;
        _ = this.ConnectionCodecs;
        _ = this.ConnectionID;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        this.Direction?.Validate();
        _ = this.From;
        _ = this.OfferedCodecs;
        _ = this.ShakenStirAttestation;
        _ = this.ShakenStirValidated;
        foreach (var item in this.SipHeaders ?? [])
        {
            item.Validate();
        }
        _ = this.StartTime;
        this.State?.Validate();
        _ = this.Tags;
        _ = this.To;
    }

    public CallInitiatedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallInitiatedPayload (
        CallInitiatedPayload callInitiatedPayload
    ) : base(callInitiatedPayload)
    {  }
    #pragma warning restore CS8618

    public CallInitiatedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallInitiatedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallInitiatedPayloadFromRaw.FromRawUnchecked"/>
    public static CallInitiatedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallInitiatedPayloadFromRaw : IFromRawJson<CallInitiatedPayload>
{
    /// <inheritdoc/>
    public CallInitiatedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallInitiatedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Whether the call is `incoming` or `outgoing`.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Incoming, Outgoing
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incoming"=>Direction.Incoming,
            "outgoing"=>Direction.Outgoing,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Incoming=>"incoming",
            Direction.Outgoing=>"outgoing",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// State received from a command.
/// </summary>
[JsonConverter(typeof(CallInitiatedPayloadStateConverter))]
public enum CallInitiatedPayloadState
{
    Parked, Bridging
}sealed class CallInitiatedPayloadStateConverter : JsonConverter<CallInitiatedPayloadState>
{
    public override CallInitiatedPayloadState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parked"=>CallInitiatedPayloadState.Parked,
            "bridging"=>CallInitiatedPayloadState.Bridging,
            _ =>(CallInitiatedPayloadState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallInitiatedPayloadState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallInitiatedPayloadState.Parked=>"parked",
            CallInitiatedPayloadState.Bridging=>"bridging",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallInitiatedRecordTypeConverter))]
public enum CallInitiatedRecordType
{
    Event
}sealed class CallInitiatedRecordTypeConverter : JsonConverter<CallInitiatedRecordType>
{
    public override CallInitiatedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallInitiatedRecordType.Event,
            _ =>(CallInitiatedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallInitiatedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallInitiatedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}