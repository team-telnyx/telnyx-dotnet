using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallForkStopped, CallForkStoppedFromRaw>))]
public sealed record class CallForkStopped : JsonModel
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
    public ApiEnum<string, CallForkStoppedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallForkStoppedEventType>>(
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

    public CallForkStoppedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallForkStoppedPayload>(
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
    public ApiEnum<string, CallForkStoppedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallForkStoppedRecordType>>(
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

    public CallForkStopped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStopped (CallForkStopped callForkStopped) : base(
        callForkStopped
    )
    {  }
    #pragma warning restore CS8618

    public CallForkStopped (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStopped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStoppedFromRaw.FromRawUnchecked"/>
    public static CallForkStopped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallForkStoppedFromRaw : IFromRawJson<CallForkStopped>
{
    /// <inheritdoc/>
    public CallForkStopped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStopped.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallForkStoppedEventTypeConverter))]
public enum CallForkStoppedEventType
{
    CallForkStopped
}sealed class CallForkStoppedEventTypeConverter : JsonConverter<CallForkStoppedEventType>
{
    public override CallForkStoppedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.fork.stopped"=>CallForkStoppedEventType.CallForkStopped,
            _ =>(CallForkStoppedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallForkStoppedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallForkStoppedEventType.CallForkStopped=>"call.fork.stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallForkStoppedPayload, CallForkStoppedPayloadFromRaw>))]
public sealed record class CallForkStoppedPayload : JsonModel
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
    public ApiEnum<string, CallForkStoppedPayloadStreamType>? StreamType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallForkStoppedPayloadStreamType>>(
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

    public CallForkStoppedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStoppedPayload (
        CallForkStoppedPayload callForkStoppedPayload
    ) : base(callForkStoppedPayload)
    {  }
    #pragma warning restore CS8618

    public CallForkStoppedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStoppedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStoppedPayloadFromRaw.FromRawUnchecked"/>
    public static CallForkStoppedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallForkStoppedPayloadFromRaw : IFromRawJson<CallForkStoppedPayload>
{
    /// <inheritdoc/>
    public CallForkStoppedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStoppedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Type of media streamed. It can be either 'raw' or 'decrypted'.
/// </summary>
[JsonConverter(typeof(CallForkStoppedPayloadStreamTypeConverter))]
public enum CallForkStoppedPayloadStreamType
{
    Decrypted
}sealed class CallForkStoppedPayloadStreamTypeConverter : JsonConverter<CallForkStoppedPayloadStreamType>
{
    public override CallForkStoppedPayloadStreamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "decrypted"=>CallForkStoppedPayloadStreamType.Decrypted,
            _ =>(CallForkStoppedPayloadStreamType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallForkStoppedPayloadStreamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallForkStoppedPayloadStreamType.Decrypted=>"decrypted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallForkStoppedRecordTypeConverter))]
public enum CallForkStoppedRecordType
{
    Event
}sealed class CallForkStoppedRecordTypeConverter : JsonConverter<CallForkStoppedRecordType>
{
    public override CallForkStoppedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallForkStoppedRecordType.Event,
            _ =>(CallForkStoppedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallForkStoppedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallForkStoppedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}