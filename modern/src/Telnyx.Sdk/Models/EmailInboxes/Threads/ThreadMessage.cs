using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<ThreadMessage, ThreadMessageFromRaw>))]
public sealed record class ThreadMessage : JsonModel
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

    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> Attachments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "attachments"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "attachments",
                ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public required IReadOnlyList<InboundEmailAddress> Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundEmailAddress>>(
                "bcc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundEmailAddress>>(
                "bcc",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<InboundEmailAddress> Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundEmailAddress>>(
                "cc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundEmailAddress>>(
                "cc",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required ApiEnum<string, Direction> Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init { this._rawData.Set("direction", value); }
    }

    public required InboundEmailAddress From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboundEmailAddress>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Whether conservative plain-text extraction detected a quoted tail. False does
    /// not prove that the source contains no quoted content.
    /// </summary>
    public required bool HasQuotedText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "has_quoted_text"
            );
        }
        init { this._rawData.Set("has_quoted_text", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "headers"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "headers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// URL for an offloaded HTML body. Null means the body is not offloaded to a
    /// URL; an inline HTML body may still exist but is not returned on list reads.
    /// Reply extraction uses only the plain-text body during ingest.
    /// </summary>
    public required string? HtmlBodyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body_url"
            );
        }
        init { this._rawData.Set("html_body_url", value); }
    }

    public required string? InReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "in_reply_to"
            );
        }
        init { this._rawData.Set("in_reply_to", value); }
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

    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> InlineFiles {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "inline_files"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "inline_files",
                ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// Mutable message labels used for agent workflow state (for example `spam`,
    /// `needs_review`, `processed`). Distinct from the immutable send-time `tags`
    /// on outbound messages: labels are never propagated to Email Detail Records
    /// or Mission Control reporting. Always empty for outbound messages. Labels
    /// on a message are independent of the labels on its thread.
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

    /// <summary>
    /// RFC Message-ID header. Null is possible for legacy outbound messages.
    /// </summary>
    public required string? MessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_id"
            );
        }
        init { this._rawData.Set("message_id", value); }
    }

    /// <summary>
    /// Time the inbound message was marked read. Null means unread.
    /// </summary>
    public required System::DateTimeOffset? ReadAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "read_at"
            );
        }
        init { this._rawData.Set("read_at", value); }
    }

    /// <summary>
    /// Receipt time for inbound messages; null for outbound messages.
    /// </summary>
    public required System::DateTimeOffset? ReceivedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "received_at"
            );
        }
        init { this._rawData.Set("received_at", value); }
    }

    public required ApiEnum<string, ThreadMessageRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ThreadMessageRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Ordered RFC Message-ID values from the References header.
    /// </summary>
    public required IReadOnlyList<string> References {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "references"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "references",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Conservatively extracted new-reply content persisted from the plain-text
    /// body during ingest. Null means no plain-text extraction input was available
    /// or extraction was skipped or failed; HTML bodies are not parsed.
    /// </summary>
    public required string? ReplyText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reply_text"
            );
        }
        init { this._rawData.Set("reply_text", value); }
    }

    public required IReadOnlyList<InboundEmailAddress> ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundEmailAddress>>(
                "reply_to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundEmailAddress>>(
                "reply_to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Creation/send-acceptance time for outbound messages; null for inbound messages.
    /// </summary>
    public required System::DateTimeOffset? SentAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init { this._rawData.Set("sent_at", value); }
    }

    /// <summary>
    /// Received for inbound messages; the current send status for outbound messages.
    /// </summary>
    public required string Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
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
    /// URL for an offloaded plain-text body. Null means the body is not offloaded
    /// to a URL; an inline plain-text body may still exist but is not returned on
    /// list reads. `reply_text` and `has_quoted_text` are persisted during ingest
    /// before any body offload.
    /// </summary>
    public required string? TextBodyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body_url"
            );
        }
        init { this._rawData.Set("text_body_url", value); }
    }

    public required string ThreadID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "thread_id"
            );
        }
        init { this._rawData.Set("thread_id", value); }
    }

    public required IReadOnlyList<InboundEmailAddress> To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundEmailAddress>>(
                "to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundEmailAddress>>(
                "to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.Attachments;
        foreach (var item in this.Bcc)
        {
            item.Validate();
        }
        foreach (var item in this.Cc)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.Direction.Validate();
        this.From.Validate();
        _ = this.HasQuotedText;
        _ = this.Headers;
        _ = this.HtmlBodyUrl;
        _ = this.InReplyTo;
        _ = this.InboxID;
        _ = this.InlineFiles;
        _ = this.Labels;
        _ = this.MessageID;
        _ = this.ReadAt;
        _ = this.ReceivedAt;
        this.RecordType.Validate();
        _ = this.References;
        _ = this.ReplyText;
        foreach (var item in this.ReplyTo)
        {
            item.Validate();
        }
        _ = this.SentAt;
        _ = this.Status;
        _ = this.Subject;
        _ = this.TextBodyUrl;
        _ = this.ThreadID;
        foreach (var item in this.To)
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public ThreadMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadMessage (ThreadMessage threadMessage) : base(threadMessage)
    {  }
    #pragma warning restore CS8618

    public ThreadMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ThreadMessageFromRaw.FromRawUnchecked"/>
    public static ThreadMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ThreadMessageFromRaw : IFromRawJson<ThreadMessage>
{
    /// <inheritdoc/>
    public ThreadMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ThreadMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>Direction.Inbound,
            "outbound"=>Direction.Outbound,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"inbound",
            Direction.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(ThreadMessageRecordTypeConverter))]
public enum ThreadMessageRecordType
{
    EmailMessage
}sealed class ThreadMessageRecordTypeConverter : JsonConverter<ThreadMessageRecordType>
{
    public override ThreadMessageRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_message"=>ThreadMessageRecordType.EmailMessage,
            _ =>(ThreadMessageRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThreadMessageRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ThreadMessageRecordType.EmailMessage=>"email_message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}