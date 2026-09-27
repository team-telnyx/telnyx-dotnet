using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallConversationEnded, CallConversationEndedFromRaw>))]
public sealed record class CallConversationEnded : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
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
    /// Timestamp when the event was created in the system.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, CallConversationEndedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallConversationEndedEventType>>(
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

    public CallConversationEndedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallConversationEndedPayload>(
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
    public ApiEnum<string, CallConversationEndedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallConversationEndedRecordType>>(
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
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public CallConversationEnded ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationEnded (
        CallConversationEnded callConversationEnded
    ) : base(callConversationEnded)
    {  }
    #pragma warning restore CS8618

    public CallConversationEnded (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationEnded (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationEndedFromRaw.FromRawUnchecked"/>
    public static CallConversationEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallConversationEndedFromRaw : IFromRawJson<CallConversationEnded>
{
    /// <inheritdoc/>
    public CallConversationEnded FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationEnded.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallConversationEndedEventTypeConverter))]
public enum CallConversationEndedEventType
{
    CallConversationEnded
}sealed class CallConversationEndedEventTypeConverter : JsonConverter<CallConversationEndedEventType>
{
    public override CallConversationEndedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.conversation.ended"=>CallConversationEndedEventType.CallConversationEnded,
            _ =>(CallConversationEndedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallConversationEndedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallConversationEndedEventType.CallConversationEnded=>"call.conversation.ended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallConversationEndedPayload, CallConversationEndedPayloadFromRaw>))]
public sealed record class CallConversationEndedPayload : JsonModel
{
    /// <summary>
    /// Unique identifier of the assistant involved in the call.
    /// </summary>
    public string? AssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "assistant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assistant_id", value);
        }
    }

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
    /// ID that is unique to the call leg.
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
    /// ID that is unique to the call session (group of related call legs).
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
    public ApiEnum<string, CallingPartyType>? CallingPartyType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallingPartyType>>(
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
    /// Base64-encoded state received from a command.
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
    /// ID unique to the conversation or insight group generated for the call.
    /// </summary>
    public string? ConversationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_id", value);
        }
    }

    /// <summary>
    /// Duration of the conversation in seconds.
    /// </summary>
    public long? DurationSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "duration_sec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_sec", value);
        }
    }

    /// <summary>
    /// The caller's number or identifier.
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
    /// The large language model used during the conversation.
    /// </summary>
    public string? LlmModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_model", value);
        }
    }

    /// <summary>
    /// Reason the conversation ended. For Conversation Relay, `customer_disconnect`
    /// indicates that the customer WebSocket disconnected.
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The speech-to-text model used in the conversation.
    /// </summary>
    public string? SttModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stt_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stt_model", value);
        }
    }

    /// <summary>
    /// The callee's number or SIP address.
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

    /// <summary>
    /// The model ID used for text-to-speech synthesis.
    /// </summary>
    public string? TtsModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tts_model_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tts_model_id", value);
        }
    }

    /// <summary>
    /// The text-to-speech provider used in the call.
    /// </summary>
    public string? TtsProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tts_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tts_provider", value);
        }
    }

    /// <summary>
    /// Voice ID used for TTS.
    /// </summary>
    public string? TtsVoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tts_voice_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tts_voice_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssistantID;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        this.CallingPartyType?.Validate();
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.ConversationID;
        _ = this.DurationSec;
        _ = this.From;
        _ = this.LlmModel;
        _ = this.Reason;
        _ = this.SttModel;
        _ = this.To;
        _ = this.TtsModelID;
        _ = this.TtsProvider;
        _ = this.TtsVoiceID;
    }

    public CallConversationEndedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationEndedPayload (
        CallConversationEndedPayload callConversationEndedPayload
    ) : base(callConversationEndedPayload)
    {  }
    #pragma warning restore CS8618

    public CallConversationEndedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationEndedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationEndedPayloadFromRaw.FromRawUnchecked"/>
    public static CallConversationEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallConversationEndedPayloadFromRaw : IFromRawJson<CallConversationEndedPayload>
{
    /// <inheritdoc/>
    public CallConversationEndedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationEndedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The type of calling party connection.
/// </summary>
[JsonConverter(typeof(CallingPartyTypeConverter))]
public enum CallingPartyType
{
    Pstn, Sip
}sealed class CallingPartyTypeConverter : JsonConverter<CallingPartyType>
{
    public override CallingPartyType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pstn"=>CallingPartyType.Pstn,
            "sip"=>CallingPartyType.Sip,
            _ =>(CallingPartyType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallingPartyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallingPartyType.Pstn=>"pstn",
            CallingPartyType.Sip=>"sip",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallConversationEndedRecordTypeConverter))]
public enum CallConversationEndedRecordType
{
    Event
}sealed class CallConversationEndedRecordTypeConverter : JsonConverter<CallConversationEndedRecordType>
{
    public override CallConversationEndedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallConversationEndedRecordType.Event,
            _ =>(CallConversationEndedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallConversationEndedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallConversationEndedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}