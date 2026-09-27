using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// Creates up to 1,000 email messages in a single request. Request-wide admission
/// checks run first and can reject the whole batch before message creation. After
/// those checks pass, each message is validated and sent independently; item-level
/// failures do not affect other messages, and the processed batch returns 207 Multi-Status.
/// Per-message failures include validation errors; when a template has `strict_variables`
/// enabled, a missing required variable produces a per-item `unprocessable_entity`
/// error naming that variable while the other messages continue.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailMessageBatchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of email messages to send. Up to 1,000 messages per batch request. Each
    /// message is validated and sent independently; per-message failures do not
    /// affect other messages in the batch.
    /// </summary>
    public required IReadOnlyList<Message> Messages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Message>>(
                "messages"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<Message>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Applies sandbox mode to all messages in the batch and overrides any per-message
    /// `sandbox_mode` value — each message's effective `sandbox_mode` is exactly
    /// this envelope value. Reserved recipients at `test.telnyx.com` produce the
    /// deterministic event chains documented on CreateEmailRequest.sandbox_mode;
    /// no batch item is injected into the MTA or outbound Kafka path. Sandbox batch
    /// items are non-billable, consume no daily-send-limit quota, and feed no delivery-reputation signals.
    /// </summary>
    public bool? SandboxMode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "sandbox_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sandbox_mode", value);
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public EmailMessageBatchParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageBatchParams (
        EmailMessageBatchParams emailMessageBatchParams
    ) : base(emailMessageBatchParams)
    { this._rawBodyData = new(emailMessageBatchParams._rawBodyData); }
    #pragma warning restore CS8618

    public EmailMessageBatchParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageBatchParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailMessageBatchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailMessageBatchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/email_messages/batch"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// A single message in a batch create request. This schema mirrors `CreateEmailRequest`
/// EXCEPT it does not accept the reply/forward threading parameters (`in_reply_to_message_id`,
/// `reply_to_all`, `forward_of_message_id`) — those are single-send-only in Phase
/// 1 (MSG-1491) and are not yet implemented on the batch endpoint. Recipient email
/// addresses must be unique across `to`, `cc`, and `bcc` after case-insensitive
/// normalization. Duplicate recipients return `400`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public required EmailAddressInput From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailAddressInput>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    public required IReadOnlyList<EmailAddressInput> To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailAddressInput>>(
                "to"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailAddressInput>>(
                "to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<AttachmentRequest>? Attachments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttachmentRequest>>(
                "attachments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AttachmentRequest>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddressInput>?>(
                "bcc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddressInput>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional display name for string `from`; overrides `from.name` when provided.
    /// </summary>
    public string? FromName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_name", value);
        }
    }

    /// <summary>
    /// Optional unsubscribe-group UUID used for group-scoped suppression checks
    /// and unsubscribe handling.
    /// </summary>
    public string? GroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "group_id"
            );
        }
        init { this._rawData.Set("group_id", value); }
    }

    /// <summary>
    /// Custom email headers. Write-only; not returned in responses.
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

    /// <summary>
    /// HTML email body. Returned only by `GET /email_messages/{id}`; omitted from
    /// create and list responses.
    /// </summary>
    public string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("html_body", value);
        }
    }

    /// <summary>
    /// When true, allows delivery to recipients whose suppressions explicitly permit
    /// an override. Hard bounces, spam complaints, and invalid-address suppressions
    /// cannot be overridden. Requires the `email:override` API scope.
    /// </summary>
    public bool? IgnoreSuppression {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ignore_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ignore_suppression", value);
        }
    }

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
    /// Custom metadata key/value pairs. Stored on the message, returned on message
    /// responses, and propagated to Email Detail Records. Usable in `filter[metadata]`
    /// when listing messages.
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

    /// <summary>
    /// Reply-to address. If provided as an object with a name, only the email is
    /// stored; the name is ignored.
    /// </summary>
    public EmailAddressInput? ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailAddressInput>(
                "reply_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reply_to", value);
        }
    }

    /// <summary>
    /// Per-message sandbox flag. The batch-level `sandbox_mode` envelope value is
    /// authoritative: it overwrites every message's `sandbox_mode` before processing,
    /// including the `false` default when the envelope omits the field. A per-item
    /// `sandbox_mode: true` inside a non-sandbox batch is therefore a real send.
    /// Set the envelope field to run any batch item in sandbox mode.
    /// </summary>
    public bool? SandboxMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "sandbox_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sandbox_mode", value);
        }
    }

    /// <summary>
    /// Future ISO 8601 delivery time. Invalid or non-future timestamps are rejected.
    /// Single sends return HTTP 422; in batch sends the invalid item is reported
    /// in the 207 per-item errors while other items continue. `send_at` remains a
    /// deprecated request alias. A non-null `scheduled_at` takes precedence over
    /// `send_at`; when `scheduled_at` is omitted or null, `send_at` is used.
    /// </summary>
    public DateTimeOffset? ScheduledAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "scheduled_at"
            );
        }
        init { this._rawData.Set("scheduled_at", value); }
    }

    /// <summary>
    /// Deprecated alias for `scheduled_at`.
    /// </summary>
    [Obsolete("Use scheduled_at instead.")]
    public DateTimeOffset? SendAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "send_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("send_at", value);
        }
    }

    /// <summary>
    /// Required unless `template_id` is supplied. When using a template, the template's
    /// subject is rendered; if the template has no subject or renders empty, the
    /// request returns 400.
    /// </summary>
    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subject", value);
        }
    }

    /// <summary>
    /// Tags for categorization and filtering. Stored on the message, returned on
    /// message responses, and propagated to Email Detail Records. Usable in `filter[tags]`
    /// when listing messages.
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

    public string? TemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    /// <summary>
    /// Variables for Liquid template rendering. Non-object values may cause a 422
    /// validation error on message creation, but are silently treated as an empty
    /// object for template rendering. When the template enables `strict_variables`,
    /// a missing required variable fails the request with 422 (single send) or a
    /// per-item `unprocessable_entity` error (batch) naming the variable; no message
    /// is persisted for the failed item.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? TemplateVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "template_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "template_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Plain text email body. Returned only by `GET /email_messages/{id}`; omitted
    /// from create and list responses.
    /// </summary>
    public string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text_body", value);
        }
    }

    /// <summary>
    /// Per-send open and click tracking overrides. Omitted properties inherit the
    /// sender domain's tracking settings.
    /// </summary>
    public TrackingSettings? TrackingSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrackingSettings>(
                "tracking_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tracking_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.From.Validate();
        foreach (var item in this.To)
        {
            item.Validate();
        }
        foreach (var item in this.Attachments ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Bcc ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Cc ?? [])
        {
            item.Validate();
        }
        _ = this.FromName;
        _ = this.GroupID;
        _ = this.Headers;
        _ = this.HtmlBody;
        _ = this.IgnoreSuppression;
        _ = this.InlineCss;
        _ = this.Metadata;
        this.ReplyTo?.Validate();
        _ = this.SandboxMode;
        _ = this.ScheduledAt;
        _ = this.SendAt;
        _ = this.Subject;
        _ = this.Tags;
        _ = this.TemplateID;
        _ = this.TemplateVariables;
        _ = this.TextBody;
        this.TrackingSettings?.Validate();
    }

    public Message ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message (Message message) : base(message)
    {  }
    #pragma warning restore CS8618

    public Message (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Message (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Message.FromRawUnchecked(rawData);
}