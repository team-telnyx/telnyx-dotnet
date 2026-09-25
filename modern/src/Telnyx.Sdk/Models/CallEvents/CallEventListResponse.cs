using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CallEvents;

[JsonConverter(typeof(JsonModelConverter<CallEventListResponse, CallEventListResponseFromRaw>))]
public sealed record class CallEventListResponse : JsonModel
{
    /// <summary>
    /// Uniquely identifies an individual call leg.
    /// </summary>
    public required string CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_leg_id"
            );
        }
        init { this._rawData.Set("call_leg_id", value); }
    }

    /// <summary>
    /// Uniquely identifies the call control session. A session may include multiple
    /// call leg events.
    /// </summary>
    public required string CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_session_id"
            );
        }
        init { this._rawData.Set("call_session_id", value); }
    }

    /// <summary>
    /// Event timestamp
    /// </summary>
    public required string EventTimestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_timestamp"
            );
        }
        init { this._rawData.Set("event_timestamp", value); }
    }

    /// <summary>
    /// Event metadata, which includes raw event, and extra information based on event type
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Event name
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Event type
    /// </summary>
    public required ApiEnum<string, CallEventListResponseType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallEventListResponseType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.EventTimestamp;
        _ = this.Metadata;
        _ = this.Name;
        this.RecordType.Validate();
        this.Type.Validate();
    }

    public CallEventListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEventListResponse (
        CallEventListResponse callEventListResponse
    ) : base(callEventListResponse)
    {  }
    #pragma warning restore CS8618

    public CallEventListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEventListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallEventListResponseFromRaw.FromRawUnchecked"/>
    public static CallEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallEventListResponseFromRaw : IFromRawJson<CallEventListResponse>
{
    /// <inheritdoc/>
    public CallEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallEventListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    CallEvent
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "call_event"=>RecordType.CallEvent, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.CallEvent=>"call_event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Event type
/// </summary>
[JsonConverter(typeof(CallEventListResponseTypeConverter))]
public enum CallEventListResponseType
{
    Command, Webhook
}sealed class CallEventListResponseTypeConverter : JsonConverter<CallEventListResponseType>
{
    public override CallEventListResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "command"=>CallEventListResponseType.Command,
            "webhook"=>CallEventListResponseType.Webhook,
            _ =>(CallEventListResponseType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallEventListResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallEventListResponseType.Command=>"command",
            CallEventListResponseType.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}