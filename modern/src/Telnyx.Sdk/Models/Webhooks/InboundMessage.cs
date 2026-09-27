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
using Threads = Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<InboundMessage, InboundMessageFromRaw>))]
public sealed record class InboundMessage : JsonModel
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

    public required IReadOnlyList<Threads::InboundEmailAddress> Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Threads::InboundEmailAddress>>(
                "bcc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Threads::InboundEmailAddress>>(
                "bcc",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<Threads::InboundEmailAddress> Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Threads::InboundEmailAddress>>(
                "cc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Threads::InboundEmailAddress>>(
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

    public required ApiEnum<string, Threads::Direction> Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Threads::Direction>>(
                "direction"
            );
        }
        init { this._rawData.Set("direction", value); }
    }

    public required Threads::InboundEmailAddress From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Threads::InboundEmailAddress>(
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

    public required ApiEnum<string, Threads::ThreadMessageRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Threads::ThreadMessageRecordType>>(
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

    public required IReadOnlyList<Threads::InboundEmailAddress> ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Threads::InboundEmailAddress>>(
                "reply_to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Threads::InboundEmailAddress>>(
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

    public required IReadOnlyList<Threads::InboundEmailAddress> To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Threads::InboundEmailAddress>>(
                "to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Threads::InboundEmailAddress>>(
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

    public static implicit operator Threads::ThreadMessage (
        InboundMessage inboundMessage
    )=> new() {
        ID = inboundMessage.ID,
        Attachments = inboundMessage.Attachments,
        Bcc = inboundMessage.Bcc,
        Cc = inboundMessage.Cc,
        CreatedAt = inboundMessage.CreatedAt,
        Direction = inboundMessage.Direction,
        From = inboundMessage.From,
        HasQuotedText = inboundMessage.HasQuotedText,
        Headers = inboundMessage.Headers,
        HtmlBodyUrl = inboundMessage.HtmlBodyUrl,
        InReplyTo = inboundMessage.InReplyTo,
        InboxID = inboundMessage.InboxID,
        InlineFiles = inboundMessage.InlineFiles,
        Labels = inboundMessage.Labels,
        MessageID = inboundMessage.MessageID,
        ReadAt = inboundMessage.ReadAt,
        ReceivedAt = inboundMessage.ReceivedAt,
        RecordType = inboundMessage.RecordType,
        References = inboundMessage.References,
        ReplyText = inboundMessage.ReplyText,
        ReplyTo = inboundMessage.ReplyTo,
        SentAt = inboundMessage.SentAt,
        Status = inboundMessage.Status,
        Subject = inboundMessage.Subject,
        TextBodyUrl = inboundMessage.TextBodyUrl,
        ThreadID = inboundMessage.ThreadID,
        To = inboundMessage.To,
        UpdatedAt = inboundMessage.UpdatedAt
    } ;

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

    public InboundMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMessage (InboundMessage inboundMessage) : base(inboundMessage)
    {  }
    #pragma warning restore CS8618

    public InboundMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundMessageFromRaw.FromRawUnchecked"/>
    public static InboundMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundMessageFromRaw : IFromRawJson<InboundMessage>
{
    /// <inheritdoc/>
    public InboundMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public ApiEnum<string, IntersectionMember1Direction>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntersectionMember1Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public ApiEnum<string, IntersectionMember1Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntersectionMember1Status>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Direction?.Validate();
        this.Status?.Validate();
    }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}[JsonConverter(typeof(IntersectionMember1DirectionConverter))]
public enum IntersectionMember1Direction
{
    Inbound
}sealed class IntersectionMember1DirectionConverter : JsonConverter<IntersectionMember1Direction>
{
    public override IntersectionMember1Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>IntersectionMember1Direction.Inbound,
            _ =>(IntersectionMember1Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntersectionMember1Direction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IntersectionMember1Direction.Inbound=>"inbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(IntersectionMember1StatusConverter))]
public enum IntersectionMember1Status
{
    Received
}sealed class IntersectionMember1StatusConverter : JsonConverter<IntersectionMember1Status>
{
    public override IntersectionMember1Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "received"=>IntersectionMember1Status.Received,
            _ =>(IntersectionMember1Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntersectionMember1Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IntersectionMember1Status.Received=>"received",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}