using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallAIGatherPartialResults, CallAIGatherPartialResultsFromRaw>))]
public sealed record class CallAIGatherPartialResults : JsonModel
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
    public ApiEnum<string, CallAIGatherPartialResultsEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherPartialResultsEventType>>(
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

    public CallAIGatherPartialResultsPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAIGatherPartialResultsPayload>(
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
    public ApiEnum<string, CallAIGatherPartialResultsRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherPartialResultsRecordType>>(
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

    public CallAIGatherPartialResults ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherPartialResults (
        CallAIGatherPartialResults callAIGatherPartialResults
    ) : base(callAIGatherPartialResults)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherPartialResults (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherPartialResults (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherPartialResultsFromRaw.FromRawUnchecked"/>
    public static CallAIGatherPartialResults FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAIGatherPartialResultsFromRaw : IFromRawJson<CallAIGatherPartialResults>
{
    /// <inheritdoc/>
    public CallAIGatherPartialResults FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherPartialResults.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallAIGatherPartialResultsEventTypeConverter))]
public enum CallAIGatherPartialResultsEventType
{
    CallAIGatherPartialResults
}sealed class CallAIGatherPartialResultsEventTypeConverter : JsonConverter<CallAIGatherPartialResultsEventType>
{
    public override CallAIGatherPartialResultsEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.ai_gather.partial_results"=>CallAIGatherPartialResultsEventType.CallAIGatherPartialResults,
            _ =>(CallAIGatherPartialResultsEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherPartialResultsEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherPartialResultsEventType.CallAIGatherPartialResults=>"call.ai_gather.partial_results",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallAIGatherPartialResultsPayload, CallAIGatherPartialResultsPayloadFromRaw>))]
public sealed record class CallAIGatherPartialResultsPayload : JsonModel
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
    /// Telnyx connection ID used in the call.
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
    /// Number or SIP URI placing the call.
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
    /// The history of the messages exchanged during the AI gather
    /// </summary>
    public IReadOnlyList<CallAIGatherPartialResultsPayloadMessageHistory>? MessageHistory {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallAIGatherPartialResultsPayloadMessageHistory>>(
                "message_history"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallAIGatherPartialResultsPayloadMessageHistory>?>(
                "message_history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The partial result of the AI gather, its type depends of the `parameters`
    /// provided in the command
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? PartialResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "partial_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "partial_results",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Destination number or SIP URI of the call.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.From;
        foreach (var item in this.MessageHistory ?? [])
        {
            item.Validate();
        }
        _ = this.PartialResults;
        _ = this.To;
    }

    public CallAIGatherPartialResultsPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherPartialResultsPayload (
        CallAIGatherPartialResultsPayload callAIGatherPartialResultsPayload
    ) : base(callAIGatherPartialResultsPayload)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherPartialResultsPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherPartialResultsPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherPartialResultsPayloadFromRaw.FromRawUnchecked"/>
    public static CallAIGatherPartialResultsPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallAIGatherPartialResultsPayloadFromRaw : IFromRawJson<CallAIGatherPartialResultsPayload>
{
    /// <inheritdoc/>
    public CallAIGatherPartialResultsPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherPartialResultsPayload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CallAIGatherPartialResultsPayloadMessageHistory, CallAIGatherPartialResultsPayloadMessageHistoryFromRaw>))]
public sealed record class CallAIGatherPartialResultsPayloadMessageHistory : JsonModel
{
    /// <summary>
    /// The content of the message
    /// </summary>
    public string? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// The role of the message sender
    /// </summary>
    public ApiEnum<string, CallAIGatherPartialResultsPayloadMessageHistoryRole>? Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherPartialResultsPayloadMessageHistoryRole>>(
                "role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("role", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role?.Validate();
    }

    public CallAIGatherPartialResultsPayloadMessageHistory ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherPartialResultsPayloadMessageHistory (
        CallAIGatherPartialResultsPayloadMessageHistory callAIGatherPartialResultsPayloadMessageHistory
    ) : base(callAIGatherPartialResultsPayloadMessageHistory)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherPartialResultsPayloadMessageHistory (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherPartialResultsPayloadMessageHistory (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherPartialResultsPayloadMessageHistoryFromRaw.FromRawUnchecked"/>
    public static CallAIGatherPartialResultsPayloadMessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallAIGatherPartialResultsPayloadMessageHistoryFromRaw : IFromRawJson<CallAIGatherPartialResultsPayloadMessageHistory>
{
    /// <inheritdoc/>
    public CallAIGatherPartialResultsPayloadMessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherPartialResultsPayloadMessageHistory.FromRawUnchecked(rawData);
}/// <summary>
/// The role of the message sender
/// </summary>
[JsonConverter(typeof(CallAIGatherPartialResultsPayloadMessageHistoryRoleConverter))]
public enum CallAIGatherPartialResultsPayloadMessageHistoryRole
{
    Assistant, User
}sealed class CallAIGatherPartialResultsPayloadMessageHistoryRoleConverter : JsonConverter<CallAIGatherPartialResultsPayloadMessageHistoryRole>
{
    public override CallAIGatherPartialResultsPayloadMessageHistoryRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "assistant"=>CallAIGatherPartialResultsPayloadMessageHistoryRole.Assistant,
            "user"=>CallAIGatherPartialResultsPayloadMessageHistoryRole.User,
            _ =>(CallAIGatherPartialResultsPayloadMessageHistoryRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherPartialResultsPayloadMessageHistoryRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherPartialResultsPayloadMessageHistoryRole.Assistant=>"assistant",
            CallAIGatherPartialResultsPayloadMessageHistoryRole.User=>"user",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallAIGatherPartialResultsRecordTypeConverter))]
public enum CallAIGatherPartialResultsRecordType
{
    Event
}sealed class CallAIGatherPartialResultsRecordTypeConverter : JsonConverter<CallAIGatherPartialResultsRecordType>
{
    public override CallAIGatherPartialResultsRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallAIGatherPartialResultsRecordType.Event,
            _ =>(CallAIGatherPartialResultsRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherPartialResultsRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherPartialResultsRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}