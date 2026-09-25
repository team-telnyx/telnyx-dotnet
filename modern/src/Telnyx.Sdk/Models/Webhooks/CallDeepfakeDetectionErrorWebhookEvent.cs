using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionErrorWebhookEvent, CallDeepfakeDetectionErrorWebhookEventFromRaw>))]
public sealed record class CallDeepfakeDetectionErrorWebhookEvent : JsonModel
{
    public CallDeepfakeDetectionErrorWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallDeepfakeDetectionErrorWebhookEventData>(
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

    public CallDeepfakeDetectionErrorWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionErrorWebhookEvent (
        CallDeepfakeDetectionErrorWebhookEvent callDeepfakeDetectionErrorWebhookEvent
    ) : base(callDeepfakeDetectionErrorWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionErrorWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionErrorWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionErrorWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionErrorWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallDeepfakeDetectionErrorWebhookEventFromRaw : IFromRawJson<CallDeepfakeDetectionErrorWebhookEvent>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionErrorWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionErrorWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionErrorWebhookEventData, CallDeepfakeDetectionErrorWebhookEventDataFromRaw>))]
public sealed record class CallDeepfakeDetectionErrorWebhookEventData : JsonModel
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
    public ApiEnum<string, CallDeepfakeDetectionErrorWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallDeepfakeDetectionErrorWebhookEventDataEventType>>(
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

    public CallDeepfakeDetectionErrorWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallDeepfakeDetectionErrorWebhookEventDataPayload>(
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
    public ApiEnum<string, CallDeepfakeDetectionErrorWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallDeepfakeDetectionErrorWebhookEventDataRecordType>>(
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

    public CallDeepfakeDetectionErrorWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionErrorWebhookEventData (
        CallDeepfakeDetectionErrorWebhookEventData callDeepfakeDetectionErrorWebhookEventData
    ) : base(callDeepfakeDetectionErrorWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionErrorWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionErrorWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionErrorWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionErrorWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallDeepfakeDetectionErrorWebhookEventDataFromRaw : IFromRawJson<CallDeepfakeDetectionErrorWebhookEventData>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionErrorWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionErrorWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallDeepfakeDetectionErrorWebhookEventDataEventTypeConverter))]
public enum CallDeepfakeDetectionErrorWebhookEventDataEventType
{
    CallDeepfakeDetectionError
}sealed class CallDeepfakeDetectionErrorWebhookEventDataEventTypeConverter : JsonConverter<CallDeepfakeDetectionErrorWebhookEventDataEventType>
{
    public override CallDeepfakeDetectionErrorWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.deepfake_detection.error"=>CallDeepfakeDetectionErrorWebhookEventDataEventType.CallDeepfakeDetectionError,
            _ =>(CallDeepfakeDetectionErrorWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDeepfakeDetectionErrorWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDeepfakeDetectionErrorWebhookEventDataEventType.CallDeepfakeDetectionError=>"call.deepfake_detection.error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionErrorWebhookEventDataPayload, CallDeepfakeDetectionErrorWebhookEventDataPayloadFromRaw>))]
public sealed record class CallDeepfakeDetectionErrorWebhookEventDataPayload : JsonModel
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
        init { this._rawData.Set("client_state", value); }
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
    /// The error that occurred. 'detection_timeout' = no DFD response received,
    /// 'rtp_timeout' = no RTP audio received, 'dfd_connection_error'/'dfd_stream_error'
    /// = service connectivity issues.
    /// </summary>
    public ApiEnum<string, ErrorMessage>? ErrorMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ErrorMessage>>(
                "error_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_message", value);
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
        this.ErrorMessage?.Validate();
    }

    public CallDeepfakeDetectionErrorWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionErrorWebhookEventDataPayload (
        CallDeepfakeDetectionErrorWebhookEventDataPayload callDeepfakeDetectionErrorWebhookEventDataPayload
    ) : base(callDeepfakeDetectionErrorWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionErrorWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionErrorWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionErrorWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionErrorWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallDeepfakeDetectionErrorWebhookEventDataPayloadFromRaw : IFromRawJson<CallDeepfakeDetectionErrorWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionErrorWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionErrorWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The error that occurred. 'detection_timeout' = no DFD response received, 'rtp_timeout'
/// = no RTP audio received, 'dfd_connection_error'/'dfd_stream_error' = service connectivity issues.
/// </summary>
[JsonConverter(typeof(ErrorMessageConverter))]
public enum ErrorMessage
{
    DetectionTimeout, RtpTimeout, DfdConnectionError, DfdStreamError
}sealed class ErrorMessageConverter : JsonConverter<ErrorMessage>
{
    public override ErrorMessage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "detection_timeout"=>ErrorMessage.DetectionTimeout,
            "rtp_timeout"=>ErrorMessage.RtpTimeout,
            "dfd_connection_error"=>ErrorMessage.DfdConnectionError,
            "dfd_stream_error"=>ErrorMessage.DfdStreamError,
            _ =>(ErrorMessage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ErrorMessage value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ErrorMessage.DetectionTimeout=>"detection_timeout",
            ErrorMessage.RtpTimeout=>"rtp_timeout",
            ErrorMessage.DfdConnectionError=>"dfd_connection_error",
            ErrorMessage.DfdStreamError=>"dfd_stream_error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallDeepfakeDetectionErrorWebhookEventDataRecordTypeConverter))]
public enum CallDeepfakeDetectionErrorWebhookEventDataRecordType
{
    Event
}sealed class CallDeepfakeDetectionErrorWebhookEventDataRecordTypeConverter : JsonConverter<CallDeepfakeDetectionErrorWebhookEventDataRecordType>
{
    public override CallDeepfakeDetectionErrorWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallDeepfakeDetectionErrorWebhookEventDataRecordType.Event,
            _ =>(CallDeepfakeDetectionErrorWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDeepfakeDetectionErrorWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDeepfakeDetectionErrorWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}