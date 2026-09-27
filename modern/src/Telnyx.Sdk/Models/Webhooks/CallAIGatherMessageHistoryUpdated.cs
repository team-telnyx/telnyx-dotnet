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

[JsonConverter(typeof(JsonModelConverter<CallAIGatherMessageHistoryUpdated, CallAIGatherMessageHistoryUpdatedFromRaw>))]
public sealed record class CallAIGatherMessageHistoryUpdated : JsonModel
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
    public ApiEnum<string, CallAIGatherMessageHistoryUpdatedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherMessageHistoryUpdatedEventType>>(
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

    public CallAIGatherMessageHistoryUpdatedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAIGatherMessageHistoryUpdatedPayload>(
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
    public ApiEnum<string, CallAIGatherMessageHistoryUpdatedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherMessageHistoryUpdatedRecordType>>(
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

    public CallAIGatherMessageHistoryUpdated ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherMessageHistoryUpdated (
        CallAIGatherMessageHistoryUpdated callAIGatherMessageHistoryUpdated
    ) : base(callAIGatherMessageHistoryUpdated)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherMessageHistoryUpdated (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherMessageHistoryUpdated (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherMessageHistoryUpdatedFromRaw.FromRawUnchecked"/>
    public static CallAIGatherMessageHistoryUpdated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAIGatherMessageHistoryUpdatedFromRaw : IFromRawJson<CallAIGatherMessageHistoryUpdated>
{
    /// <inheritdoc/>
    public CallAIGatherMessageHistoryUpdated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherMessageHistoryUpdated.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallAIGatherMessageHistoryUpdatedEventTypeConverter))]
public enum CallAIGatherMessageHistoryUpdatedEventType
{
    CallAIGatherMessageHistoryUpdated
}sealed class CallAIGatherMessageHistoryUpdatedEventTypeConverter : JsonConverter<CallAIGatherMessageHistoryUpdatedEventType>
{
    public override CallAIGatherMessageHistoryUpdatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.ai_gather.message_history_updated"=>CallAIGatherMessageHistoryUpdatedEventType.CallAIGatherMessageHistoryUpdated,
            _ =>(CallAIGatherMessageHistoryUpdatedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherMessageHistoryUpdatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherMessageHistoryUpdatedEventType.CallAIGatherMessageHistoryUpdated=>"call.ai_gather.message_history_updated",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallAIGatherMessageHistoryUpdatedPayload, CallAIGatherMessageHistoryUpdatedPayloadFromRaw>))]
public sealed record class CallAIGatherMessageHistoryUpdatedPayload : JsonModel
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
    public IReadOnlyList<CallAIGatherMessageHistoryUpdatedPayloadMessageHistory>? MessageHistory {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallAIGatherMessageHistoryUpdatedPayloadMessageHistory>>(
                "message_history"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallAIGatherMessageHistoryUpdatedPayloadMessageHistory>?>(
                "message_history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
        _ = this.To;
    }

    public CallAIGatherMessageHistoryUpdatedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherMessageHistoryUpdatedPayload (
        CallAIGatherMessageHistoryUpdatedPayload callAIGatherMessageHistoryUpdatedPayload
    ) : base(callAIGatherMessageHistoryUpdatedPayload)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherMessageHistoryUpdatedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherMessageHistoryUpdatedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherMessageHistoryUpdatedPayloadFromRaw.FromRawUnchecked"/>
    public static CallAIGatherMessageHistoryUpdatedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallAIGatherMessageHistoryUpdatedPayloadFromRaw : IFromRawJson<CallAIGatherMessageHistoryUpdatedPayload>
{
    /// <inheritdoc/>
    public CallAIGatherMessageHistoryUpdatedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherMessageHistoryUpdatedPayload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CallAIGatherMessageHistoryUpdatedPayloadMessageHistory, CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryFromRaw>))]
public sealed record class CallAIGatherMessageHistoryUpdatedPayloadMessageHistory : JsonModel
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
    public ApiEnum<string, CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole>? Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole>>(
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

    public CallAIGatherMessageHistoryUpdatedPayloadMessageHistory ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherMessageHistoryUpdatedPayloadMessageHistory (
        CallAIGatherMessageHistoryUpdatedPayloadMessageHistory callAIGatherMessageHistoryUpdatedPayloadMessageHistory
    ) : base(callAIGatherMessageHistoryUpdatedPayloadMessageHistory)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherMessageHistoryUpdatedPayloadMessageHistory (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherMessageHistoryUpdatedPayloadMessageHistory (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryFromRaw.FromRawUnchecked"/>
    public static CallAIGatherMessageHistoryUpdatedPayloadMessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryFromRaw : IFromRawJson<CallAIGatherMessageHistoryUpdatedPayloadMessageHistory>
{
    /// <inheritdoc/>
    public CallAIGatherMessageHistoryUpdatedPayloadMessageHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherMessageHistoryUpdatedPayloadMessageHistory.FromRawUnchecked(rawData);
}/// <summary>
/// The role of the message sender
/// </summary>
[JsonConverter(typeof(CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRoleConverter))]
public enum CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole
{
    Assistant, User
}sealed class CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRoleConverter : JsonConverter<CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole>
{
    public override CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "assistant"=>CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole.Assistant,
            "user"=>CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole.User,
            _ =>(CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole.Assistant=>"assistant",
            CallAIGatherMessageHistoryUpdatedPayloadMessageHistoryRole.User=>"user",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallAIGatherMessageHistoryUpdatedRecordTypeConverter))]
public enum CallAIGatherMessageHistoryUpdatedRecordType
{
    Event
}sealed class CallAIGatherMessageHistoryUpdatedRecordTypeConverter : JsonConverter<CallAIGatherMessageHistoryUpdatedRecordType>
{
    public override CallAIGatherMessageHistoryUpdatedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallAIGatherMessageHistoryUpdatedRecordType.Event,
            _ =>(CallAIGatherMessageHistoryUpdatedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallAIGatherMessageHistoryUpdatedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallAIGatherMessageHistoryUpdatedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}