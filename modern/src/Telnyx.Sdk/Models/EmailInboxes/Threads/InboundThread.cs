using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<InboundThread, InboundThreadFromRaw>))]
public sealed record class InboundThread : JsonModel
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

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string InboxID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "inbox_id"
            );
        }
        init { this._rawData.Set("inbox_id", value); }
    }

    /// <summary>
    /// Mutable thread labels used for agent workflow state. Independent of the labels
    /// on the thread's messages, and distinct from the send-time `tags` on outbound messages.
    /// </summary>
    public required IReadOnlyList<string> Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "labels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required System::DateTimeOffset LastMessageAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "last_message_at"
            );
        }
        init { this._rawData.Set("last_message_at", value); }
    }

    public required string LastMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "last_message_id"
            );
        }
        init { this._rawData.Set("last_message_id", value); }
    }

    /// <summary>
    /// Total inbound and outbound messages in the thread.
    /// </summary>
    public required long MessageCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "message_count"
            );
        }
        init { this._rawData.Set("message_count", value); }
    }

    public required string? Preview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "preview"
            );
        }
        init { this._rawData.Set("preview", value); }
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

    public required string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Unread inbound messages; outbound messages never increment this count.
    /// </summary>
    public required long UnreadCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "unread_count"
            );
        }
        init { this._rawData.Set("unread_count", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.InboxID;
        _ = this.Labels;
        _ = this.LastMessageAt;
        _ = this.LastMessageID;
        _ = this.MessageCount;
        _ = this.Preview;
        this.RecordType.Validate();
        _ = this.Subject;
        _ = this.UnreadCount;
        _ = this.UpdatedAt;
    }

    public InboundThread ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundThread (InboundThread inboundThread) : base(inboundThread)
    {  }
    #pragma warning restore CS8618

    public InboundThread (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundThread (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundThreadFromRaw.FromRawUnchecked"/>
    public static InboundThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundThreadFromRaw : IFromRawJson<InboundThread>
{
    /// <inheritdoc/>
    public InboundThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundThread.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailThread
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_thread"=>RecordType.EmailThread, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailThread=>"email_thread",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}