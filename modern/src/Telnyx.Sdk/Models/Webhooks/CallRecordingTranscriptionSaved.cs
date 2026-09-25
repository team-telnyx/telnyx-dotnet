using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingTranscriptionSaved, CallRecordingTranscriptionSavedFromRaw>))]
public sealed record class CallRecordingTranscriptionSaved : JsonModel
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
    public ApiEnum<string, CallRecordingTranscriptionSavedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingTranscriptionSavedEventType>>(
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

    public CallRecordingTranscriptionSavedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingTranscriptionSavedPayload>(
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
    public ApiEnum<string, CallRecordingTranscriptionSavedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingTranscriptionSavedRecordType>>(
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

    public CallRecordingTranscriptionSaved ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingTranscriptionSaved (
        CallRecordingTranscriptionSaved callRecordingTranscriptionSaved
    ) : base(callRecordingTranscriptionSaved)
    {  }
    #pragma warning restore CS8618

    public CallRecordingTranscriptionSaved (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingTranscriptionSaved (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingTranscriptionSavedFromRaw.FromRawUnchecked"/>
    public static CallRecordingTranscriptionSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingTranscriptionSavedFromRaw : IFromRawJson<CallRecordingTranscriptionSaved>
{
    /// <inheritdoc/>
    public CallRecordingTranscriptionSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingTranscriptionSaved.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallRecordingTranscriptionSavedEventTypeConverter))]
public enum CallRecordingTranscriptionSavedEventType
{
    CallRecordingTranscriptionSaved
}sealed class CallRecordingTranscriptionSavedEventTypeConverter : JsonConverter<CallRecordingTranscriptionSavedEventType>
{
    public override CallRecordingTranscriptionSavedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.recording.transcription.saved"=>CallRecordingTranscriptionSavedEventType.CallRecordingTranscriptionSaved,
            _ =>(CallRecordingTranscriptionSavedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingTranscriptionSavedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingTranscriptionSavedEventType.CallRecordingTranscriptionSaved=>"call.recording.transcription.saved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallRecordingTranscriptionSavedPayload, CallRecordingTranscriptionSavedPayloadFromRaw>))]
public sealed record class CallRecordingTranscriptionSavedPayload : JsonModel
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
    /// The type of calling party connection.
    /// </summary>
    public ApiEnum<string, CallRecordingTranscriptionSavedPayloadCallingPartyType>? CallingPartyType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingTranscriptionSavedPayloadCallingPartyType>>(
                "calling_party_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("calling_party_type", value);
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
    /// ID that is unique to the recording session and can be used to correlate webhook events.
    /// </summary>
    public string? RecordingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the transcription process and can be used to correlate
    /// webhook events.
    /// </summary>
    public string? RecordingTranscriptionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_transcription_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_transcription_id", value);
        }
    }

    /// <summary>
    /// The transcription status.
    /// </summary>
    public ApiEnum<string, CallRecordingTranscriptionSavedPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingTranscriptionSavedPayloadStatus>>(
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
    /// The transcribed text
    /// </summary>
    public string? TranscriptionText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcription_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        this.CallingPartyType?.Validate();
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.RecordingID;
        _ = this.RecordingTranscriptionID;
        this.Status?.Validate();
        _ = this.TranscriptionText;
    }

    public CallRecordingTranscriptionSavedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingTranscriptionSavedPayload (
        CallRecordingTranscriptionSavedPayload callRecordingTranscriptionSavedPayload
    ) : base(callRecordingTranscriptionSavedPayload)
    {  }
    #pragma warning restore CS8618

    public CallRecordingTranscriptionSavedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingTranscriptionSavedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingTranscriptionSavedPayloadFromRaw.FromRawUnchecked"/>
    public static CallRecordingTranscriptionSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallRecordingTranscriptionSavedPayloadFromRaw : IFromRawJson<CallRecordingTranscriptionSavedPayload>
{
    /// <inheritdoc/>
    public CallRecordingTranscriptionSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingTranscriptionSavedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The type of calling party connection.
/// </summary>
[JsonConverter(typeof(CallRecordingTranscriptionSavedPayloadCallingPartyTypeConverter))]
public enum CallRecordingTranscriptionSavedPayloadCallingPartyType
{
    Pstn, Sip
}sealed class CallRecordingTranscriptionSavedPayloadCallingPartyTypeConverter : JsonConverter<CallRecordingTranscriptionSavedPayloadCallingPartyType>
{
    public override CallRecordingTranscriptionSavedPayloadCallingPartyType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pstn"=>CallRecordingTranscriptionSavedPayloadCallingPartyType.Pstn,
            "sip"=>CallRecordingTranscriptionSavedPayloadCallingPartyType.Sip,
            _ =>(CallRecordingTranscriptionSavedPayloadCallingPartyType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingTranscriptionSavedPayloadCallingPartyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingTranscriptionSavedPayloadCallingPartyType.Pstn=>"pstn",
            CallRecordingTranscriptionSavedPayloadCallingPartyType.Sip=>"sip",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The transcription status.
/// </summary>
[JsonConverter(typeof(CallRecordingTranscriptionSavedPayloadStatusConverter))]
public enum CallRecordingTranscriptionSavedPayloadStatus
{
    Completed
}sealed class CallRecordingTranscriptionSavedPayloadStatusConverter : JsonConverter<CallRecordingTranscriptionSavedPayloadStatus>
{
    public override CallRecordingTranscriptionSavedPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed"=>CallRecordingTranscriptionSavedPayloadStatus.Completed,
            _ =>(CallRecordingTranscriptionSavedPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingTranscriptionSavedPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingTranscriptionSavedPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallRecordingTranscriptionSavedRecordTypeConverter))]
public enum CallRecordingTranscriptionSavedRecordType
{
    Event
}sealed class CallRecordingTranscriptionSavedRecordTypeConverter : JsonConverter<CallRecordingTranscriptionSavedRecordType>
{
    public override CallRecordingTranscriptionSavedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallRecordingTranscriptionSavedRecordType.Event,
            _ =>(CallRecordingTranscriptionSavedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingTranscriptionSavedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingTranscriptionSavedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}