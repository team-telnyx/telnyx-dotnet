using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<Transcription, TranscriptionFromRaw>))]
public sealed record class Transcription : JsonModel
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
    public ApiEnum<string, TranscriptionEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEventType>>(
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

    public TranscriptionPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionPayload>(
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
    public ApiEnum<string, TranscriptionRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionRecordType>>(
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

    public Transcription ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transcription (Transcription transcription) : base(transcription)
    {  }
    #pragma warning restore CS8618

    public Transcription (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Transcription (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionFromRaw.FromRawUnchecked"/>
    public static Transcription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionFromRaw : IFromRawJson<Transcription>
{
    /// <inheritdoc/>
    public Transcription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Transcription.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(TranscriptionEventTypeConverter))]
public enum TranscriptionEventType
{
    CallTranscription
}sealed class TranscriptionEventTypeConverter : JsonConverter<TranscriptionEventType>
{
    public override TranscriptionEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.transcription"=>TranscriptionEventType.CallTranscription,
            _ =>(TranscriptionEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEventType.CallTranscription=>"call.transcription",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<TranscriptionPayload, TranscriptionPayloadFromRaw>))]
public sealed record class TranscriptionPayload : JsonModel
{
    /// <summary>
    /// Unique identifier and token for controlling the call.
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
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
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

    public TranscriptionData? TranscriptionData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionData>(
                "transcription_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_data", value);
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
        this.TranscriptionData?.Validate();
    }

    public TranscriptionPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionPayload (
        TranscriptionPayload transcriptionPayload
    ) : base(transcriptionPayload)
    {  }
    #pragma warning restore CS8618

    public TranscriptionPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionPayloadFromRaw.FromRawUnchecked"/>
    public static TranscriptionPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TranscriptionPayloadFromRaw : IFromRawJson<TranscriptionPayload>
{
    /// <inheritdoc/>
    public TranscriptionPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionPayload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<TranscriptionData, TranscriptionDataFromRaw>))]
public sealed record class TranscriptionData : JsonModel
{
    /// <summary>
    /// Speech recognition confidence level. `cohere/ar-stt` returns `null` here
    /// rather than omitting the field.
    /// </summary>
    public float? Confidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "confidence"
            );
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// When false, it means that this is an interim result.
    /// </summary>
    public bool? IsFinal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_final"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_final", value);
        }
    }

    /// <summary>
    /// Recognized text.
    /// </summary>
    public string? Transcript {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcript"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcript", value);
        }
    }

    /// <summary>
    /// Indicates which leg of the call has been transcribed. This is only available
    /// when `transcription_engine` is set to `B`.
    /// </summary>
    public ApiEnum<string, TranscriptionTrack>? TranscriptionTrack {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionTrack>>(
                "transcription_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.IsFinal;
        _ = this.Transcript;
        this.TranscriptionTrack?.Validate();
    }

    public TranscriptionData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionData (TranscriptionData transcriptionData) : base(
        transcriptionData
    )
    {  }
    #pragma warning restore CS8618

    public TranscriptionData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionDataFromRaw.FromRawUnchecked"/>
    public static TranscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TranscriptionDataFromRaw : IFromRawJson<TranscriptionData>
{
    /// <inheritdoc/>
    public TranscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionData.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates which leg of the call has been transcribed. This is only available when
/// `transcription_engine` is set to `B`.
/// </summary>
[JsonConverter(typeof(TranscriptionTrackConverter))]
public enum TranscriptionTrack
{
    Inbound, Outbound
}sealed class TranscriptionTrackConverter : JsonConverter<TranscriptionTrack>
{
    public override TranscriptionTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>TranscriptionTrack.Inbound,
            "outbound"=>TranscriptionTrack.Outbound,
            _ =>(TranscriptionTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionTrack.Inbound=>"inbound",
            TranscriptionTrack.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(TranscriptionRecordTypeConverter))]
public enum TranscriptionRecordType
{
    Event
}sealed class TranscriptionRecordTypeConverter : JsonConverter<TranscriptionRecordType>
{
    public override TranscriptionRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>TranscriptionRecordType.Event,
            _ =>(TranscriptionRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}