using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailBlocks;

[JsonConverter(typeof(JsonModelConverter<EmailBlockRetrieveEventsResponse, EmailBlockRetrieveEventsResponseFromRaw>))]
public sealed record class EmailBlockRetrieveEventsResponse : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Free-text (`user_id`/`org_id`/`api_key`/`dev_bypass`/`system`/`manual`).
    /// </summary>
    public required string Actor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "actor"
            );
        }
        init { this._rawData.Set("actor", value); }
    }

    public required ApiEnum<string, EventType> EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// Free-text snapshot of the block's reason at event time.
    /// </summary>
    public required string Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// View-only.
    /// </summary>
    public required ApiEnum<string, EmailBlockRetrieveEventsResponseRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailBlockRetrieveEventsResponseRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Free-text snapshot of the block's source at event time.
    /// </summary>
    public required string Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// `null` when the schema field is nil (the context usually sets it to `{}`).
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "meta"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "meta",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Actor;
        this.EventType.Validate();
        _ = this.OccurredAt;
        _ = this.Reason;
        this.RecordType.Validate();
        _ = this.Source;
        _ = this.Meta;
    }

    public EmailBlockRetrieveEventsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockRetrieveEventsResponse (
        EmailBlockRetrieveEventsResponse emailBlockRetrieveEventsResponse
    ) : base(emailBlockRetrieveEventsResponse)
    {  }
    #pragma warning restore CS8618

    public EmailBlockRetrieveEventsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockRetrieveEventsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockRetrieveEventsResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockRetrieveEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailBlockRetrieveEventsResponseFromRaw : IFromRawJson<EmailBlockRetrieveEventsResponse>
{
    /// <inheritdoc/>
    public EmailBlockRetrieveEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockRetrieveEventsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    Created, Removed, Expired, OverrideUsed
}sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>EventType.Created,
            "removed"=>EventType.Removed,
            "expired"=>EventType.Expired,
            "override_used"=>EventType.OverrideUsed,
            _ =>(EventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EventType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EventType.Created=>"created",
            EventType.Removed=>"removed",
            EventType.Expired=>"expired",
            EventType.OverrideUsed=>"override_used",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// View-only.
/// </summary>
[JsonConverter(typeof(EmailBlockRetrieveEventsResponseRecordTypeConverter))]
public enum EmailBlockRetrieveEventsResponseRecordType
{
    EmailBlockEvent
}sealed class EmailBlockRetrieveEventsResponseRecordTypeConverter : JsonConverter<EmailBlockRetrieveEventsResponseRecordType>
{
    public override EmailBlockRetrieveEventsResponseRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_block_event"=>EmailBlockRetrieveEventsResponseRecordType.EmailBlockEvent,
            _ =>(EmailBlockRetrieveEventsResponseRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailBlockRetrieveEventsResponseRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailBlockRetrieveEventsResponseRecordType.EmailBlockEvent=>"email_block_event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}