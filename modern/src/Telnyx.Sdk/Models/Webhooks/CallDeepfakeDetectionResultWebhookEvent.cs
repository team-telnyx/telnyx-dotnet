using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionResultWebhookEvent, CallDeepfakeDetectionResultWebhookEventFromRaw>))]
public sealed record class CallDeepfakeDetectionResultWebhookEvent : JsonModel
{
    public CallDeepfakeDetectionResultWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallDeepfakeDetectionResultWebhookEventData>(
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

    public CallDeepfakeDetectionResultWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionResultWebhookEvent (
        CallDeepfakeDetectionResultWebhookEvent callDeepfakeDetectionResultWebhookEvent
    ) : base(callDeepfakeDetectionResultWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionResultWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionResultWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionResultWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionResultWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallDeepfakeDetectionResultWebhookEventFromRaw : IFromRawJson<CallDeepfakeDetectionResultWebhookEvent>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionResultWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionResultWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionResultWebhookEventData, CallDeepfakeDetectionResultWebhookEventDataFromRaw>))]
public sealed record class CallDeepfakeDetectionResultWebhookEventData : JsonModel
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
    public ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataEventType>>(
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

    public CallDeepfakeDetectionResultWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallDeepfakeDetectionResultWebhookEventDataPayload>(
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
    public ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataRecordType>>(
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

    public CallDeepfakeDetectionResultWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionResultWebhookEventData (
        CallDeepfakeDetectionResultWebhookEventData callDeepfakeDetectionResultWebhookEventData
    ) : base(callDeepfakeDetectionResultWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionResultWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionResultWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionResultWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionResultWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallDeepfakeDetectionResultWebhookEventDataFromRaw : IFromRawJson<CallDeepfakeDetectionResultWebhookEventData>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionResultWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionResultWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallDeepfakeDetectionResultWebhookEventDataEventTypeConverter))]
public enum CallDeepfakeDetectionResultWebhookEventDataEventType
{
    CallDeepfakeDetectionResult
}sealed class CallDeepfakeDetectionResultWebhookEventDataEventTypeConverter : JsonConverter<CallDeepfakeDetectionResultWebhookEventDataEventType>
{
    public override CallDeepfakeDetectionResultWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.deepfake_detection.result"=>CallDeepfakeDetectionResultWebhookEventDataEventType.CallDeepfakeDetectionResult,
            _ =>(CallDeepfakeDetectionResultWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDeepfakeDetectionResultWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDeepfakeDetectionResultWebhookEventDataEventType.CallDeepfakeDetectionResult=>"call.deepfake_detection.result",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallDeepfakeDetectionResultWebhookEventDataPayload, CallDeepfakeDetectionResultWebhookEventDataPayloadFromRaw>))]
public sealed record class CallDeepfakeDetectionResultWebhookEventDataPayload : JsonModel
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
    /// Percentage (0-100) indicating how consistently the model classified the audio
    /// across frames. High consistency (&gt;90%) means confident classification
    /// throughout; low consistency suggests mixed signals. Null for silence_timeout.
    /// </summary>
    public float? Consistency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "consistency"
            );
        }
        init { this._rawData.Set("consistency", value); }
    }

    /// <summary>
    /// Detection outcome. 'real' = human voice, 'fake' = AI-generated voice, 'silence_timeout'
    /// = no analyzable speech detected before timeout.
    /// </summary>
    public ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataPayloadResult>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallDeepfakeDetectionResultWebhookEventDataPayloadResult>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <summary>
    /// Probability that the audio is AI-generated, from 0.0 (likely real) to 1.0
    /// (likely deepfake). Based on the model's aggregated confidence across analyzed
    /// audio frames. Null for silence_timeout.
    /// </summary>
    public float? Score {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "score"
            );
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.Consistency;
        this.Result?.Validate();
        _ = this.Score;
    }

    public CallDeepfakeDetectionResultWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDeepfakeDetectionResultWebhookEventDataPayload (
        CallDeepfakeDetectionResultWebhookEventDataPayload callDeepfakeDetectionResultWebhookEventDataPayload
    ) : base(callDeepfakeDetectionResultWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallDeepfakeDetectionResultWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDeepfakeDetectionResultWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDeepfakeDetectionResultWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallDeepfakeDetectionResultWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallDeepfakeDetectionResultWebhookEventDataPayloadFromRaw : IFromRawJson<CallDeepfakeDetectionResultWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallDeepfakeDetectionResultWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDeepfakeDetectionResultWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Detection outcome. 'real' = human voice, 'fake' = AI-generated voice, 'silence_timeout'
/// = no analyzable speech detected before timeout.
/// </summary>
[JsonConverter(typeof(CallDeepfakeDetectionResultWebhookEventDataPayloadResultConverter))]
public enum CallDeepfakeDetectionResultWebhookEventDataPayloadResult
{
    Real, Fake, SilenceTimeout
}sealed class CallDeepfakeDetectionResultWebhookEventDataPayloadResultConverter : JsonConverter<CallDeepfakeDetectionResultWebhookEventDataPayloadResult>
{
    public override CallDeepfakeDetectionResultWebhookEventDataPayloadResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "real"=>CallDeepfakeDetectionResultWebhookEventDataPayloadResult.Real,
            "fake"=>CallDeepfakeDetectionResultWebhookEventDataPayloadResult.Fake,
            "silence_timeout"=>CallDeepfakeDetectionResultWebhookEventDataPayloadResult.SilenceTimeout,
            _ =>(CallDeepfakeDetectionResultWebhookEventDataPayloadResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDeepfakeDetectionResultWebhookEventDataPayloadResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDeepfakeDetectionResultWebhookEventDataPayloadResult.Real=>"real",
            CallDeepfakeDetectionResultWebhookEventDataPayloadResult.Fake=>"fake",
            CallDeepfakeDetectionResultWebhookEventDataPayloadResult.SilenceTimeout=>"silence_timeout",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallDeepfakeDetectionResultWebhookEventDataRecordTypeConverter))]
public enum CallDeepfakeDetectionResultWebhookEventDataRecordType
{
    Event
}sealed class CallDeepfakeDetectionResultWebhookEventDataRecordTypeConverter : JsonConverter<CallDeepfakeDetectionResultWebhookEventDataRecordType>
{
    public override CallDeepfakeDetectionResultWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallDeepfakeDetectionResultWebhookEventDataRecordType.Event,
            _ =>(CallDeepfakeDetectionResultWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDeepfakeDetectionResultWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDeepfakeDetectionResultWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}