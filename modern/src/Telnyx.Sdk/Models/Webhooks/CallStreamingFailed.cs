using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallStreamingFailed, CallStreamingFailedFromRaw>))]
public sealed record class CallStreamingFailed : JsonModel
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
    public ApiEnum<string, CallStreamingFailedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallStreamingFailedEventType>>(
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

    public CallStreamingFailedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallStreamingFailedPayload>(
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
    /// Identifies the resource.
    /// </summary>
    public ApiEnum<string, CallStreamingFailedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallStreamingFailedRecordType>>(
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

    public CallStreamingFailed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamingFailed (CallStreamingFailed callStreamingFailed) : base(
        callStreamingFailed
    )
    {  }
    #pragma warning restore CS8618

    public CallStreamingFailed (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamingFailed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamingFailedFromRaw.FromRawUnchecked"/>
    public static CallStreamingFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallStreamingFailedFromRaw : IFromRawJson<CallStreamingFailed>
{
    /// <inheritdoc/>
    public CallStreamingFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamingFailed.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallStreamingFailedEventTypeConverter))]
public enum CallStreamingFailedEventType
{
    StreamingFailed
}sealed class CallStreamingFailedEventTypeConverter : JsonConverter<CallStreamingFailedEventType>
{
    public override CallStreamingFailedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "streaming.failed"=>CallStreamingFailedEventType.StreamingFailed,
            _ =>(CallStreamingFailedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamingFailedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamingFailedEventType.StreamingFailed=>"streaming.failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallStreamingFailedPayload, CallStreamingFailedPayloadFromRaw>))]
public sealed record class CallStreamingFailedPayload : JsonModel
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
    /// A short description explaning why the media streaming failed.
    /// </summary>
    public string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failure_reason", value);
        }
    }

    /// <summary>
    /// Identifies the streaming.
    /// </summary>
    public string? StreamID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stream_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stream_id", value);
        }
    }

    /// <summary>
    /// Streaming parameters as they were originally given to the Call Control API.
    /// </summary>
    public StreamParams? StreamParams {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StreamParams>(
                "stream_params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stream_params", value);
        }
    }

    /// <summary>
    /// The type of stream connection the stream is performing.
    /// </summary>
    public ApiEnum<string, CallStreamingFailedPayloadStreamType>? StreamType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallStreamingFailedPayloadStreamType>>(
                "stream_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stream_type", value);
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
        _ = this.FailureReason;
        _ = this.StreamID;
        this.StreamParams?.Validate();
        this.StreamType?.Validate();
    }

    public CallStreamingFailedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamingFailedPayload (
        CallStreamingFailedPayload callStreamingFailedPayload
    ) : base(callStreamingFailedPayload)
    {  }
    #pragma warning restore CS8618

    public CallStreamingFailedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamingFailedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamingFailedPayloadFromRaw.FromRawUnchecked"/>
    public static CallStreamingFailedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallStreamingFailedPayloadFromRaw : IFromRawJson<CallStreamingFailedPayload>
{
    /// <inheritdoc/>
    public CallStreamingFailedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamingFailedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Streaming parameters as they were originally given to the Call Control API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StreamParams, StreamParamsFromRaw>))]
public sealed record class StreamParams : JsonModel
{
    /// <summary>
    /// The destination WebSocket address where the stream is going to be delivered.
    /// </summary>
    public string? StreamUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stream_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stream_url", value);
        }
    }

    /// <summary>
    /// Specifies which track should be streamed.
    /// </summary>
    public ApiEnum<string, Track>? Track {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Track>>(
                "track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StreamUrl;
        this.Track?.Validate();
    }

    public StreamParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamParams (StreamParams streamParams) : base(streamParams)
    {  }
    #pragma warning restore CS8618

    public StreamParams (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StreamParamsFromRaw.FromRawUnchecked"/>
    public static StreamParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class StreamParamsFromRaw : IFromRawJson<StreamParams>
{
    /// <inheritdoc/>
    public StreamParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StreamParams.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies which track should be streamed.
/// </summary>
[JsonConverter(typeof(TrackConverter))]
public enum Track
{
    InboundTrack, OutboundTrack, BothTracks
}sealed class TrackConverter : JsonConverter<Track>
{
    public override Track Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_track"=>Track.InboundTrack,
            "outbound_track"=>Track.OutboundTrack,
            "both_tracks"=>Track.BothTracks,
            _ =>(Track)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Track value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Track.InboundTrack=>"inbound_track",
            Track.OutboundTrack=>"outbound_track",
            Track.BothTracks=>"both_tracks",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of stream connection the stream is performing.
/// </summary>
[JsonConverter(typeof(CallStreamingFailedPayloadStreamTypeConverter))]
public enum CallStreamingFailedPayloadStreamType
{
    Websocket, Dialogflow
}sealed class CallStreamingFailedPayloadStreamTypeConverter : JsonConverter<CallStreamingFailedPayloadStreamType>
{
    public override CallStreamingFailedPayloadStreamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "websocket"=>CallStreamingFailedPayloadStreamType.Websocket,
            "dialogflow"=>CallStreamingFailedPayloadStreamType.Dialogflow,
            _ =>(CallStreamingFailedPayloadStreamType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamingFailedPayloadStreamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamingFailedPayloadStreamType.Websocket=>"websocket",
            CallStreamingFailedPayloadStreamType.Dialogflow=>"dialogflow",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the resource.
/// </summary>
[JsonConverter(typeof(CallStreamingFailedRecordTypeConverter))]
public enum CallStreamingFailedRecordType
{
    Event
}sealed class CallStreamingFailedRecordTypeConverter : JsonConverter<CallStreamingFailedRecordType>
{
    public override CallStreamingFailedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallStreamingFailedRecordType.Event,
            _ =>(CallStreamingFailedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamingFailedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamingFailedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}