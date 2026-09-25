using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallForkStarted, CallForkStartedFromRaw>))]
public sealed record class CallForkStarted : JsonModel
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
    public ApiEnum<string, CallForkStartedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallForkStartedEventType>>(
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

    public CallForkStartedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallForkStartedPayload>(
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
    public ApiEnum<string, CallForkStartedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallForkStartedRecordType>>(
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

    public CallForkStarted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStarted (CallForkStarted callForkStarted) : base(
        callForkStarted
    )
    {  }
    #pragma warning restore CS8618

    public CallForkStarted (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStarted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStartedFromRaw.FromRawUnchecked"/>
    public static CallForkStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallForkStartedFromRaw : IFromRawJson<CallForkStarted>
{
    /// <inheritdoc/>
    public CallForkStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStarted.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallForkStartedEventTypeConverter))]
public enum CallForkStartedEventType
{
    CallForkStarted
}sealed class CallForkStartedEventTypeConverter : JsonConverter<CallForkStartedEventType>
{
    public override CallForkStartedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.fork.started"=>CallForkStartedEventType.CallForkStarted,
            _ =>(CallForkStartedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallForkStartedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallForkStartedEventType.CallForkStarted=>"call.fork.started",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallForkStartedPayload, CallForkStartedPayloadFromRaw>))]
public sealed record class CallForkStartedPayload : JsonModel
{
    /// <summary>
    /// Unique ID for controlling the call.
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
    /// Type of media streamed. It can be either 'raw' or 'decrypted'.
    /// </summary>
    public ApiEnum<string, StreamType>? StreamType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StreamType>>(
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
        this.StreamType?.Validate();
    }

    public CallForkStartedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStartedPayload (
        CallForkStartedPayload callForkStartedPayload
    ) : base(callForkStartedPayload)
    {  }
    #pragma warning restore CS8618

    public CallForkStartedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStartedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStartedPayloadFromRaw.FromRawUnchecked"/>
    public static CallForkStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallForkStartedPayloadFromRaw : IFromRawJson<CallForkStartedPayload>
{
    /// <inheritdoc/>
    public CallForkStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStartedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Type of media streamed. It can be either 'raw' or 'decrypted'.
/// </summary>
[JsonConverter(typeof(StreamTypeConverter))]
public enum StreamType
{
    Decrypted
}sealed class StreamTypeConverter : JsonConverter<StreamType>
{
    public override StreamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "decrypted"=>StreamType.Decrypted, _ =>(StreamType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, StreamType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamType.Decrypted=>"decrypted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallForkStartedRecordTypeConverter))]
public enum CallForkStartedRecordType
{
    Event
}sealed class CallForkStartedRecordTypeConverter : JsonConverter<CallForkStartedRecordType>
{
    public override CallForkStartedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallForkStartedRecordType.Event,
            _ =>(CallForkStartedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallForkStartedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallForkStartedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}