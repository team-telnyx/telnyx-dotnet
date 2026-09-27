using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<EmailMessageDetailResponse, EmailMessageDetailResponseFromRaw>))]
public sealed record class EmailMessageDetailResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailMessageDetailResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageDetailResponse (
        EmailMessageDetailResponse emailMessageDetailResponse
    ) : base(emailMessageDetailResponse)
    {  }
    #pragma warning restore CS8618

    public EmailMessageDetailResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageDetailResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageDetailResponseFromRaw.FromRawUnchecked"/>
    public static EmailMessageDetailResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailMessageDetailResponse (Data data) : this()
    { this.Data = data; }
}

class EmailMessageDetailResponseFromRaw : IFromRawJson<EmailMessageDetailResponse>
{
    /// <inheritdoc/>
    public EmailMessageDetailResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessageDetailResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
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
    public DateTimeOffset? ScheduledAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <summary>
    /// HTML body submitted for the message.
    /// </summary>
    public required string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawData.Set("html_body", value); }
    }

    /// <summary>
    /// Plain-text body submitted for the message.
    /// </summary>
    public required string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawData.Set("text_body", value); }
    }

    public static implicit operator EmailMessage (Data data)=> new() {
        ID = data.ID,
        Attachments = data.Attachments,
        Bcc = data.Bcc,
        Cc = data.Cc,
        CreatedAt = data.CreatedAt,
        Events = data.Events,
        From = data.From,
        Metadata = data.Metadata,
        RecordType = data.RecordType,
        ReplyTo = data.ReplyTo,
        Status = data.Status,
        Subject = data.Subject,
        Tags = data.Tags,
        TemplateID = data.TemplateID,
        TemplateVariables = data.TemplateVariables,
        To = data.To,
        InlineCss = data.InlineCss,
        RecipientStatuses = data.RecipientStatuses,
        Sandbox = data.Sandbox,
        ScheduledAt = data.ScheduledAt,
        Suppressed = data.Suppressed
    } ;

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
        _ = this.HtmlBody;
        _ = this.TextBody;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// HTML body submitted for the message.
    /// </summary>
    public required string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawData.Set("html_body", value); }
    }

    /// <summary>
    /// Plain-text body submitted for the message.
    /// </summary>
    public required string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawData.Set("text_body", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HtmlBody;
        _ = this.TextBody;
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
}