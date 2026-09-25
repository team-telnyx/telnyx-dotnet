using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingError, CallRecordingErrorFromRaw>))]
public sealed record class CallRecordingError : JsonModel
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
    public ApiEnum<string, CallRecordingErrorEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingErrorEventType>>(
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

    public CallRecordingErrorPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingErrorPayload>(
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
    public ApiEnum<string, CallRecordingErrorRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingErrorRecordType>>(
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

    public CallRecordingError ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingError (CallRecordingError callRecordingError) : base(
        callRecordingError
    )
    {  }
    #pragma warning restore CS8618

    public CallRecordingError (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingError (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingErrorFromRaw.FromRawUnchecked"/>
    public static CallRecordingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingErrorFromRaw : IFromRawJson<CallRecordingError>
{
    /// <inheritdoc/>
    public CallRecordingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingError.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallRecordingErrorEventTypeConverter))]
public enum CallRecordingErrorEventType
{
    CallRecordingError
}sealed class CallRecordingErrorEventTypeConverter : JsonConverter<CallRecordingErrorEventType>
{
    public override CallRecordingErrorEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.recording.error"=>CallRecordingErrorEventType.CallRecordingError,
            _ =>(CallRecordingErrorEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingErrorEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingErrorEventType.CallRecordingError=>"call.recording.error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallRecordingErrorPayload, CallRecordingErrorPayloadFromRaw>))]
public sealed record class CallRecordingErrorPayload : JsonModel
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
    /// Indication that there was a problem recording the call.
    /// </summary>
    public ApiEnum<string, CallRecordingErrorPayloadReason>? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingErrorPayloadReason>>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
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
        this.Reason?.Validate();
    }

    public CallRecordingErrorPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingErrorPayload (
        CallRecordingErrorPayload callRecordingErrorPayload
    ) : base(callRecordingErrorPayload)
    {  }
    #pragma warning restore CS8618

    public CallRecordingErrorPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingErrorPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingErrorPayloadFromRaw.FromRawUnchecked"/>
    public static CallRecordingErrorPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallRecordingErrorPayloadFromRaw : IFromRawJson<CallRecordingErrorPayload>
{
    /// <inheritdoc/>
    public CallRecordingErrorPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingErrorPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Indication that there was a problem recording the call.
/// </summary>
[JsonConverter(typeof(CallRecordingErrorPayloadReasonConverter))]
public enum CallRecordingErrorPayloadReason
{
    FailedToAuthorizeWithStorageUsingCustomCredentials,
    InvalidCredentialsJson,
    UnsupportedBackend,
    InternalServerError
}sealed class CallRecordingErrorPayloadReasonConverter : JsonConverter<CallRecordingErrorPayloadReason>
{
    public override CallRecordingErrorPayloadReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Failed to authorize with storage using custom credentials"=>CallRecordingErrorPayloadReason.FailedToAuthorizeWithStorageUsingCustomCredentials,
            "Invalid credentials json"=>CallRecordingErrorPayloadReason.InvalidCredentialsJson,
            "Unsupported backend"=>CallRecordingErrorPayloadReason.UnsupportedBackend,
            "Internal server error"=>CallRecordingErrorPayloadReason.InternalServerError,
            _ =>(CallRecordingErrorPayloadReason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingErrorPayloadReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingErrorPayloadReason.FailedToAuthorizeWithStorageUsingCustomCredentials=>"Failed to authorize with storage using custom credentials",
            CallRecordingErrorPayloadReason.InvalidCredentialsJson=>"Invalid credentials json",
            CallRecordingErrorPayloadReason.UnsupportedBackend=>"Unsupported backend",
            CallRecordingErrorPayloadReason.InternalServerError=>"Internal server error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallRecordingErrorRecordTypeConverter))]
public enum CallRecordingErrorRecordType
{
    Event
}sealed class CallRecordingErrorRecordTypeConverter : JsonConverter<CallRecordingErrorRecordType>
{
    public override CallRecordingErrorRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallRecordingErrorRecordType.Event,
            _ =>(CallRecordingErrorRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingErrorRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingErrorRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}