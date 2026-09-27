using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailEvents;
using Telnyx.Sdk.Models.EmailMessages;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

[JsonConverter(typeof(JsonModelConverter<EmailMessage, EmailMessageFromRaw>))]
public sealed record class EmailMessage : JsonModel
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

    public required IReadOnlyList<Attachment> Attachments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Attachment>>(
                "attachments"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Attachment>>(
                "attachments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<EmailAddress> Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailAddress>>(
                "bcc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailAddress>>(
                "bcc",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<EmailAddress> Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailAddress>>(
                "cc"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailAddress>>(
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

    public required IReadOnlyList<Event> Events {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>(
                "events"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required EmailAddress From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailAddress>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Customer-supplied metadata stored with the message.
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

    public required ApiEnum<string, EmailMessageRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailMessageRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required string? ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reply_to"
            );
        }
        init { this._rawData.Set("reply_to", value); }
    }

    /// <summary>
    /// Current status of an email message. Lifecycle statuses (queued, scheduled,
    /// etc.) are set on creation. Delivery statuses (delivered, bounced, etc.) are
    /// updated by delivery event consumers.
    /// </summary>
    public required ApiEnum<string, EmailMessageStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailMessageStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Customer-supplied tags stored with the message.
    /// </summary>
    public required IReadOnlyList<string> Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string? TemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "template_id"
            );
        }
        init { this._rawData.Set("template_id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> TemplateVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "template_variables"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "template_variables",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<EmailAddress> To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailAddress>>(
                "to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailAddress>>(
                "to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Present when true in the immediate create response. Not persisted; absent
    /// on subsequent GET requests.
    /// </summary>
    public bool? InlineCss {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "inline_css"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inline_css", value);
        }
    }

    /// <summary>
    /// Per-status recipient counts for the message. Present only for outbound messages
    /// with recipient rows. Keys are recipient statuses, values are counts. Example:
    /// `{"delivered": 998, "bounced": 2}`.
    /// </summary>
    public IReadOnlyDictionary<string, long>? RecipientStatuses {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, long>>(
                "recipient_statuses"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, long>?>(
                "recipient_statuses",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Present when sandbox mode was used.
    /// </summary>
    public bool? Sandbox {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "sandbox"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// Present when a scheduled_at value was stored. Persists even after the scheduled
    /// send has been processed or cancelled.
    /// </summary>
    public System::DateTimeOffset? ScheduledAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "scheduled_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("scheduled_at", value);
        }
    }

    /// <summary>
    /// Recipients excluded from delivery by suppression checks, with reasons. On
    /// batch items, present when that item had suppressed recipients; all other recipients
    /// of the item still receive the message. For single sends this information
    /// appears at the top level of the response instead (see EmailMessageResponse.suppressed).
    /// </summary>
    public IReadOnlyList<SuppressedRecipient>? Suppressed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SuppressedRecipient>>(
                "suppressed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SuppressedRecipient>?>(
                "suppressed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Attachments)
        {
            item.Validate();
        }
        foreach (var item in this.Bcc)
        {
            item.Validate();
        }
        foreach (var item in this.Cc)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        this.From.Validate();
        _ = this.Metadata;
        this.RecordType.Validate();
        _ = this.ReplyTo;
        this.Status.Validate();
        _ = this.Subject;
        _ = this.Tags;
        _ = this.TemplateID;
        _ = this.TemplateVariables;
        foreach (var item in this.To)
        {
            item.Validate();
        }
        _ = this.InlineCss;
        _ = this.RecipientStatuses;
        _ = this.Sandbox;
        _ = this.ScheduledAt;
        foreach (var item in this.Suppressed ?? [])
        {
            item.Validate();
        }
    }

    public EmailMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessage (EmailMessage emailMessage) : base(emailMessage)
    {  }
    #pragma warning restore CS8618

    public EmailMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageFromRaw.FromRawUnchecked"/>
    public static EmailMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailMessageFromRaw : IFromRawJson<EmailMessage>
{
    /// <inheritdoc/>
    public EmailMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// EDR-aligned attachment metadata. The base64 `content` is never returned.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Attachment, AttachmentFromRaw>))]
public sealed record class Attachment : JsonModel
{
    /// <summary>
    /// MIME Content-ID for inline references.
    /// </summary>
    public required string? ContentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_id"
            );
        }
        init { this._rawData.Set("content_id", value); }
    }

    public required string ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content_type"
            );
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <summary>
    /// MIME disposition (e.g. `attachment` or `inline`). Runtime passes through the
    /// stored value without enforcing an enum.
    /// </summary>
    public required string Disposition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "disposition"
            );
        }
        init { this._rawData.Set("disposition", value); }
    }

    public required string Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "filename"
            );
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// SHA-256 hex digest of the attachment content.
    /// </summary>
    public required string? Sha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sha256"
            );
        }
        init { this._rawData.Set("sha256", value); }
    }

    /// <summary>
    /// Attachment size in bytes.
    /// </summary>
    public required long? SizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "size_bytes"
            );
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <summary>
    /// Telnyx-hosted public URL for the attachment content.
    /// </summary>
    public required string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContentID;
        _ = this.ContentType;
        _ = this.Disposition;
        _ = this.Filename;
        _ = this.Sha256;
        _ = this.SizeBytes;
        _ = this.Url;
    }

    public Attachment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attachment (Attachment attachment) : base(attachment)
    {  }
    #pragma warning restore CS8618

    public Attachment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Attachment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentFromRaw.FromRawUnchecked"/>
    public static Attachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AttachmentFromRaw : IFromRawJson<Attachment>
{
    /// <inheritdoc/>
    public Attachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Attachment.FromRawUnchecked(rawData);
}/// <summary>
/// An event embedded in a message response. The dedicated per-message events endpoint
/// additionally returns event_type and canonical_event_type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
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
    /// Bare stored event names returned by message history. In addition to the normal
    /// send and delivery lifecycle, polling can expose suppression, scan, and quarantine
    /// lifecycle rows. Sharp canonical names gw_reject, injection_timeout, and expired
    /// distinguish gateway rejection, ambiguous injection timeout, and MTA expiration.
    /// The failed and bounced names remain valid for system/admin failures and hard
    /// bounces respectively. Existing stored rows retain their original names.
    /// </summary>
    public required ApiEnum<string, EmailEventType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailEventType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.Payload;
    }

    public Event ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event (Event event_) : base(event_)
    {  }
    #pragma warning restore CS8618

    public Event (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Event (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Event.FromRawUnchecked(rawData);
}[JsonConverter(typeof(EmailMessageRecordTypeConverter))]
public enum EmailMessageRecordType
{
    EmailMessage
}sealed class EmailMessageRecordTypeConverter : JsonConverter<EmailMessageRecordType>
{
    public override EmailMessageRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_message"=>EmailMessageRecordType.EmailMessage,
            _ =>(EmailMessageRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailMessageRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailMessageRecordType.EmailMessage=>"email_message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current status of an email message. Lifecycle statuses (queued, scheduled, etc.)
/// are set on creation. Delivery statuses (delivered, bounced, etc.) are updated
/// by delivery event consumers.
/// </summary>
[JsonConverter(typeof(EmailMessageStatusConverter))]
public enum EmailMessageStatus
{
    Queued,
    Scheduled,
    Cancelled,
    Sandbox,
    Sending,
    Sent,
    Failed,
    Deferred,
    Delivered,
    Bounced,
    Complained,
    Rejected,
    Opened,
    Clicked,
    Unsubscribed
}sealed class EmailMessageStatusConverter : JsonConverter<EmailMessageStatus>
{
    public override EmailMessageStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>EmailMessageStatus.Queued,
            "scheduled"=>EmailMessageStatus.Scheduled,
            "cancelled"=>EmailMessageStatus.Cancelled,
            "sandbox"=>EmailMessageStatus.Sandbox,
            "sending"=>EmailMessageStatus.Sending,
            "sent"=>EmailMessageStatus.Sent,
            "failed"=>EmailMessageStatus.Failed,
            "deferred"=>EmailMessageStatus.Deferred,
            "delivered"=>EmailMessageStatus.Delivered,
            "bounced"=>EmailMessageStatus.Bounced,
            "complained"=>EmailMessageStatus.Complained,
            "rejected"=>EmailMessageStatus.Rejected,
            "opened"=>EmailMessageStatus.Opened,
            "clicked"=>EmailMessageStatus.Clicked,
            "unsubscribed"=>EmailMessageStatus.Unsubscribed,
            _ =>(EmailMessageStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailMessageStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailMessageStatus.Queued=>"queued",
            EmailMessageStatus.Scheduled=>"scheduled",
            EmailMessageStatus.Cancelled=>"cancelled",
            EmailMessageStatus.Sandbox=>"sandbox",
            EmailMessageStatus.Sending=>"sending",
            EmailMessageStatus.Sent=>"sent",
            EmailMessageStatus.Failed=>"failed",
            EmailMessageStatus.Deferred=>"deferred",
            EmailMessageStatus.Delivered=>"delivered",
            EmailMessageStatus.Bounced=>"bounced",
            EmailMessageStatus.Complained=>"complained",
            EmailMessageStatus.Rejected=>"rejected",
            EmailMessageStatus.Opened=>"opened",
            EmailMessageStatus.Clicked=>"clicked",
            EmailMessageStatus.Unsubscribed=>"unsubscribed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}