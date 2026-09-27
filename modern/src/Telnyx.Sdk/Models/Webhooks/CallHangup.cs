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

[JsonConverter(typeof(JsonModelConverter<CallHangup, CallHangupFromRaw>))]
public sealed record class CallHangup : JsonModel
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
    public ApiEnum<string, CallHangupEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallHangupEventType>>(
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

    public CallHangupPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallHangupPayload>(
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
    public ApiEnum<string, CallHangupRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallHangupRecordType>>(
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

    public CallHangup ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallHangup (CallHangup callHangup) : base(callHangup)
    {  }
    #pragma warning restore CS8618

    public CallHangup (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallHangup (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallHangupFromRaw.FromRawUnchecked"/>
    public static CallHangup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallHangupFromRaw : IFromRawJson<CallHangup>
{
    /// <inheritdoc/>
    public CallHangup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallHangup.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallHangupEventTypeConverter))]
public enum CallHangupEventType
{
    CallHangup
}sealed class CallHangupEventTypeConverter : JsonConverter<CallHangupEventType>
{
    public override CallHangupEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.hangup"=>CallHangupEventType.CallHangup,
            _ =>(CallHangupEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallHangupEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallHangupEventType.CallHangup=>"call.hangup",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallHangupPayload, CallHangupPayloadFromRaw>))]
public sealed record class CallHangupPayload : JsonModel
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
    /// Call quality statistics aggregated from the CHANNEL_HANGUP_COMPLETE event.
    /// Only includes metrics that are available (filters out nil values). Returns
    /// nil if no metrics are available.
    /// </summary>
    public CallQualityStats? CallQualityStats {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallQualityStats>(
                "call_quality_stats"
            );
        }
        init { this._rawData.Set("call_quality_stats", value); }
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
    /// Custom headers set on answer command
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
    /// The reason the call was ended (`call_rejected`, `normal_clearing`, `originator_cancel`,
    /// `timeout`, `time_limit`, `user_busy`, `not_found`, `no_answer` or `unspecified`).
    /// </summary>
    public ApiEnum<string, HangupCause>? HangupCause {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HangupCause>>(
                "hangup_cause"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hangup_cause", value);
        }
    }

    /// <summary>
    /// The party who ended the call (`callee`, `caller`, `unknown`).
    /// </summary>
    public ApiEnum<string, HangupSource>? HangupSource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HangupSource>>(
                "hangup_source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hangup_source", value);
        }
    }

    /// <summary>
    /// The reason the call was ended (SIP response code). If the SIP response is
    /// unavailable (in inbound calls for example) this is set to `unspecified`.
    /// </summary>
    public string? SipHangupCause {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_hangup_cause"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_hangup_cause", value);
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
    public ApiEnum<string, CallHangupPayloadState>? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallHangupPayloadState>>(
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
        this.CallQualityStats?.Validate();
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        _ = this.From;
        this.HangupCause?.Validate();
        this.HangupSource?.Validate();
        _ = this.SipHangupCause;
        foreach (var item in this.SipHeaders ?? [])
        {
            item.Validate();
        }
        _ = this.StartTime;
        this.State?.Validate();
        _ = this.Tags;
        _ = this.To;
    }

    public CallHangupPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallHangupPayload (CallHangupPayload callHangupPayload) : base(
        callHangupPayload
    )
    {  }
    #pragma warning restore CS8618

    public CallHangupPayload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallHangupPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallHangupPayloadFromRaw.FromRawUnchecked"/>
    public static CallHangupPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallHangupPayloadFromRaw : IFromRawJson<CallHangupPayload>
{
    /// <inheritdoc/>
    public CallHangupPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallHangupPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Call quality statistics aggregated from the CHANNEL_HANGUP_COMPLETE event. Only
/// includes metrics that are available (filters out nil values). Returns nil if no
/// metrics are available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallQualityStats, CallQualityStatsFromRaw>))]
public sealed record class CallQualityStats : JsonModel
{
    /// <summary>
    /// Inbound call quality statistics.
    /// </summary>
    public Inbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Inbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound", value);
        }
    }

    /// <summary>
    /// Outbound call quality statistics.
    /// </summary>
    public Outbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Outbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Inbound?.Validate();
        this.Outbound?.Validate();
    }

    public CallQualityStats ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallQualityStats (CallQualityStats callQualityStats) : base(
        callQualityStats
    )
    {  }
    #pragma warning restore CS8618

    public CallQualityStats (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallQualityStats (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallQualityStatsFromRaw.FromRawUnchecked"/>
    public static CallQualityStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallQualityStatsFromRaw : IFromRawJson<CallQualityStats>
{
    /// <inheritdoc/>
    public CallQualityStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallQualityStats.FromRawUnchecked(rawData);
}/// <summary>
/// Inbound call quality statistics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
{
    /// <summary>
    /// Maximum jitter variance for inbound audio.
    /// </summary>
    public string? JitterMaxVariance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "jitter_max_variance"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jitter_max_variance", value);
        }
    }

    /// <summary>
    /// Number of packets used for jitter calculation on inbound audio.
    /// </summary>
    public string? JitterPacketCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "jitter_packet_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jitter_packet_count", value);
        }
    }

    /// <summary>
    /// Mean Opinion Score (MOS) for inbound audio quality.
    /// </summary>
    public string? Mos {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mos"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mos", value);
        }
    }

    /// <summary>
    /// Total number of inbound audio packets.
    /// </summary>
    public string? PacketCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "packet_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("packet_count", value);
        }
    }

    /// <summary>
    /// Number of skipped inbound packets (packet loss).
    /// </summary>
    public string? SkipPacketCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "skip_packet_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("skip_packet_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JitterMaxVariance;
        _ = this.JitterPacketCount;
        _ = this.Mos;
        _ = this.PacketCount;
        _ = this.SkipPacketCount;
    }

    public Inbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Inbound (Inbound inbound) : base(inbound)
    {  }
    #pragma warning restore CS8618

    public Inbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Inbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundFromRaw.FromRawUnchecked"/>
    public static Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Inbound.FromRawUnchecked(rawData);
}/// <summary>
/// Outbound call quality statistics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Outbound, OutboundFromRaw>))]
public sealed record class Outbound : JsonModel
{
    /// <summary>
    /// Total number of outbound audio packets.
    /// </summary>
    public string? PacketCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "packet_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("packet_count", value);
        }
    }

    /// <summary>
    /// Number of skipped outbound packets (packet loss).
    /// </summary>
    public string? SkipPacketCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "skip_packet_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("skip_packet_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PacketCount;
        _ = this.SkipPacketCount;
    }

    public Outbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Outbound (Outbound outbound) : base(outbound)
    {  }
    #pragma warning restore CS8618

    public Outbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Outbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundFromRaw.FromRawUnchecked"/>
    public static Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundFromRaw : IFromRawJson<Outbound>
{
    /// <inheritdoc/>
    public Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Outbound.FromRawUnchecked(rawData);
}/// <summary>
/// The reason the call was ended (`call_rejected`, `normal_clearing`, `originator_cancel`,
/// `timeout`, `time_limit`, `user_busy`, `not_found`, `no_answer` or `unspecified`).
/// </summary>
[JsonConverter(typeof(HangupCauseConverter))]
public enum HangupCause
{
    CallRejected,
    NormalClearing,
    OriginatorCancel,
    Timeout,
    TimeLimit,
    UserBusy,
    NotFound,
    NoAnswer,
    Unspecified
}sealed class HangupCauseConverter : JsonConverter<HangupCause>
{
    public override HangupCause Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call_rejected"=>HangupCause.CallRejected,
            "normal_clearing"=>HangupCause.NormalClearing,
            "originator_cancel"=>HangupCause.OriginatorCancel,
            "timeout"=>HangupCause.Timeout,
            "time_limit"=>HangupCause.TimeLimit,
            "user_busy"=>HangupCause.UserBusy,
            "not_found"=>HangupCause.NotFound,
            "no_answer"=>HangupCause.NoAnswer,
            "unspecified"=>HangupCause.Unspecified,
            _ =>(HangupCause)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, HangupCause value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HangupCause.CallRejected=>"call_rejected",
            HangupCause.NormalClearing=>"normal_clearing",
            HangupCause.OriginatorCancel=>"originator_cancel",
            HangupCause.Timeout=>"timeout",
            HangupCause.TimeLimit=>"time_limit",
            HangupCause.UserBusy=>"user_busy",
            HangupCause.NotFound=>"not_found",
            HangupCause.NoAnswer=>"no_answer",
            HangupCause.Unspecified=>"unspecified",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The party who ended the call (`callee`, `caller`, `unknown`).
/// </summary>
[JsonConverter(typeof(HangupSourceConverter))]
public enum HangupSource
{
    Caller, Callee, Unknown
}sealed class HangupSourceConverter : JsonConverter<HangupSource>
{
    public override HangupSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "caller"=>HangupSource.Caller,
            "callee"=>HangupSource.Callee,
            "unknown"=>HangupSource.Unknown,
            _ =>(HangupSource)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, HangupSource value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HangupSource.Caller=>"caller",
            HangupSource.Callee=>"callee",
            HangupSource.Unknown=>"unknown",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// State received from a command.
/// </summary>
[JsonConverter(typeof(CallHangupPayloadStateConverter))]
public enum CallHangupPayloadState
{
    Hangup
}sealed class CallHangupPayloadStateConverter : JsonConverter<CallHangupPayloadState>
{
    public override CallHangupPayloadState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hangup"=>CallHangupPayloadState.Hangup,
            _ =>(CallHangupPayloadState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallHangupPayloadState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallHangupPayloadState.Hangup=>"hangup",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallHangupRecordTypeConverter))]
public enum CallHangupRecordType
{
    Event
}sealed class CallHangupRecordTypeConverter : JsonConverter<CallHangupRecordType>
{
    public override CallHangupRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "event"=>CallHangupRecordType.Event, _ =>(CallHangupRecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallHangupRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallHangupRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}