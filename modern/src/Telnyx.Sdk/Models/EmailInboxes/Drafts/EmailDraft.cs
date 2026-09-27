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

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

/// <summary>
/// An unsent, mutable draft message belonging to an inbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDraft, EmailDraftFromRaw>))]
public sealed record class EmailDraft : JsonModel
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

    public required string InboxID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "inbox_id"
            );
        }
        init { this._rawData.Set("inbox_id", value); }
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
    /// `draft` until the draft is sent. A sent draft is retained for audit and becomes
    /// immutable.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Attachments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "attachments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public IReadOnlyList<EmailAddress>? Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddress>>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddress>?>(
                "bcc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddress>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddress>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddress>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Sender address. Defaults to the inbox address at send time when null.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    public string? FromName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_name"
            );
        }
        init { this._rawData.Set("from_name", value); }
    }

    /// <summary>
    /// Custom headers. Reply drafts carry `In-Reply-To` and `References`.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawData.Set("html_body", value); }
    }

    /// <summary>
    /// Mutable mailbox-state labels. Not propagated to Email Detail Records.
    /// </summary>
    public IReadOnlyList<string>? Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "labels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Arbitrary customer-defined metadata.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reply_to"
            );
        }
        init { this._rawData.Set("reply_to", value); }
    }

    /// <summary>
    /// Inbound message this draft replies to. Server-owned; set only on reply drafts.
    /// </summary>
    public string? ReplyToMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reply_to_message_id"
            );
        }
        init { this._rawData.Set("reply_to_message_id", value); }
    }

    public System::DateTimeOffset? SentAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init { this._rawData.Set("sent_at", value); }
    }

    /// <summary>
    /// The email message created when this draft was sent.
    /// </summary>
    public string? SentMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sent_message_id"
            );
        }
        init { this._rawData.Set("sent_message_id", value); }
    }

    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Transport/reporting attribution tags, propagated to Email Detail Records
    /// at send time.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawData.Set("text_body", value); }
    }

    /// <summary>
    /// Conversation thread inherited from the parent message.
    /// </summary>
    public string? ThreadID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "thread_id"
            );
        }
        init { this._rawData.Set("thread_id", value); }
    }

    public IReadOnlyList<EmailAddress>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddress>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddress>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.InboxID;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.Attachments;
        foreach (var item in this.Bcc ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Cc ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.From;
        _ = this.FromName;
        _ = this.Headers;
        _ = this.HtmlBody;
        _ = this.Labels;
        _ = this.Metadata;
        _ = this.ReplyTo;
        _ = this.ReplyToMessageID;
        _ = this.SentAt;
        _ = this.SentMessageID;
        _ = this.Subject;
        _ = this.Tags;
        _ = this.TextBody;
        _ = this.ThreadID;
        foreach (var item in this.To ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public EmailDraft ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDraft (EmailDraft emailDraft) : base(emailDraft)
    {  }
    #pragma warning restore CS8618

    public EmailDraft (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDraft (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDraftFromRaw.FromRawUnchecked"/>
    public static EmailDraft FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDraftFromRaw : IFromRawJson<EmailDraft>
{
    /// <inheritdoc/>
    public EmailDraft FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDraft.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailDraft
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_draft"=>RecordType.EmailDraft, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailDraft=>"email_draft",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// `draft` until the draft is sent. A sent draft is retained for audit and becomes
/// immutable.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft, Sending, Sent
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>Status.Draft,
            "sending"=>Status.Sending,
            "sent"=>Status.Sent,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Draft=>"draft",
            Status.Sending=>"sending",
            Status.Sent=>"sent",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}