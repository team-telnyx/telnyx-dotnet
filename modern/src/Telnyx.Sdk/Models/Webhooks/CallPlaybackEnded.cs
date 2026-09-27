using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPlaybackEnded, CallPlaybackEndedFromRaw>))]
public sealed record class CallPlaybackEnded : JsonModel
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
    public ApiEnum<string, CallPlaybackEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPlaybackEndedEventType>>(
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

    public CallPlaybackEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPlaybackEndedPayload>(
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
    public ApiEnum<string, CallPlaybackEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPlaybackEndedRecordType>>(
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

    public CallPlaybackEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackEnded (CallPlaybackEnded callPlaybackEnded) : base(
        callPlaybackEnded
    )
    {  }
    #pragma warning restore CS8618

    public CallPlaybackEnded (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackEndedFromRaw.FromRawUnchecked"/>
    public static CallPlaybackEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPlaybackEndedFromRaw : IFromRawJson<CallPlaybackEnded>
{
    /// <inheritdoc/>
    public CallPlaybackEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallPlaybackEndedEventTypeConverter))]
public enum CallPlaybackEndedEventType
{
    CallPlaybackEnded
}sealed class CallPlaybackEndedEventTypeConverter : JsonConverter<CallPlaybackEndedEventType>
{
    public override CallPlaybackEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.playback.ended"=>CallPlaybackEndedEventType.CallPlaybackEnded,
            _ =>(CallPlaybackEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPlaybackEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPlaybackEndedEventType.CallPlaybackEnded=>"call.playback.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallPlaybackEndedPayload, CallPlaybackEndedPayloadFromRaw>))]
public sealed record class CallPlaybackEndedPayload : JsonModel
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
    /// The name of the audio media file being played back, if media_name has been
    /// used to start.
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_name", value);
        }
    }

    /// <summary>
    /// The audio URL being played back, if audio_url has been used to start.
    /// </summary>
    public string? MediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_url", value);
        }
    }

    /// <summary>
    /// Whether the stopped audio was in overlay mode or not.
    /// </summary>
    public bool? Overlay {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "overlay"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("overlay", value);
        }
    }

    /// <summary>
    /// Reflects how command ended.
    /// </summary>
    public ApiEnum<string, CallPlaybackEndedPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPlaybackEndedPayloadStatus>>(
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
    /// Provides details in case of failure.
    /// </summary>
    public string? StatusDetail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status_detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status_detail", value);
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
        _ = this.MediaName;
        _ = this.MediaUrl;
        _ = this.Overlay;
        this.Status?.Validate();
        _ = this.StatusDetail;
    }

    public CallPlaybackEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackEndedPayload (
        CallPlaybackEndedPayload callPlaybackEndedPayload
    ) : base(callPlaybackEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallPlaybackEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackEndedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallPlaybackEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPlaybackEndedPayloadFromRaw : IFromRawJson<CallPlaybackEndedPayload>
{
    /// <inheritdoc/>
    public CallPlaybackEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Reflects how command ended.
/// </summary>
[JsonConverter(typeof(CallPlaybackEndedPayloadStatusConverter))]
public enum CallPlaybackEndedPayloadStatus
{
    FileNotFound,
    CallHangup,
    Unknown,
    Cancelled,
    CancelledAmd,
    Completed,
    Failed
}sealed class CallPlaybackEndedPayloadStatusConverter : JsonConverter<CallPlaybackEndedPayloadStatus>
{
    public override CallPlaybackEndedPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_not_found"=>CallPlaybackEndedPayloadStatus.FileNotFound,
            "call_hangup"=>CallPlaybackEndedPayloadStatus.CallHangup,
            "unknown"=>CallPlaybackEndedPayloadStatus.Unknown,
            "cancelled"=>CallPlaybackEndedPayloadStatus.Cancelled,
            "cancelled_amd"=>CallPlaybackEndedPayloadStatus.CancelledAmd,
            "completed"=>CallPlaybackEndedPayloadStatus.Completed,
            "failed"=>CallPlaybackEndedPayloadStatus.Failed,
            _ =>(CallPlaybackEndedPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPlaybackEndedPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPlaybackEndedPayloadStatus.FileNotFound=>"file_not_found",
            CallPlaybackEndedPayloadStatus.CallHangup=>"call_hangup",
            CallPlaybackEndedPayloadStatus.Unknown=>"unknown",
            CallPlaybackEndedPayloadStatus.Cancelled=>"cancelled",
            CallPlaybackEndedPayloadStatus.CancelledAmd=>"cancelled_amd",
            CallPlaybackEndedPayloadStatus.Completed=>"completed",
            CallPlaybackEndedPayloadStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallPlaybackEndedRecordTypeConverter))]
public enum CallPlaybackEndedRecordType
{
    Event
}sealed class CallPlaybackEndedRecordTypeConverter : JsonConverter<CallPlaybackEndedRecordType>
{
    public override CallPlaybackEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallPlaybackEndedRecordType.Event,
            _ =>(CallPlaybackEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPlaybackEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPlaybackEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}