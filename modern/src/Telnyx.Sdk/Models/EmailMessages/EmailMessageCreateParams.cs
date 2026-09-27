using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// Queues, schedules, or sandbox-sends an email message. The legacy `/v2/emails`
/// POST route is a backward-compatible alias for this operation.
///
/// <para>`subject` is required unless `template_id` is supplied. When using `template_id`,
/// do not also provide `subject`, `html_body`, or `text_body`; the template is rendered
/// with `template_variables`.</para>
///
/// <para>Note: template lookup failures (not found, wrong account) return 400, not 404.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailMessageCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required EmailAddressInput From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<EmailAddressInput>(
                "from"
            );
        }
        init { this._rawBodyData.Set("from", value); }
    }

    public required IReadOnlyList<EmailAddressInput> To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<EmailAddressInput>>(
                "to"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<EmailAddressInput>>(
                "to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<AttachmentRequest>? Attachments {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AttachmentRequest>>(
                "attachments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AttachmentRequest>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Bcc {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EmailAddressInput>?>(
                "bcc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Cc {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EmailAddressInput>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Telnyx message UUID of the message this send forwards. Forwarded messages
    /// start a NEW thread per RFC 5322 — NO `In-Reply-To` or `References` headers
    /// are set on the outbound MIME. The id is recorded in the message's metadata
    /// for EDR provenance only.
    ///
    /// <para>The id is validated as a UUID but is NOT looked up against the message
    /// store — existence is the caller's responsibility (the forward is pure metadata;
    /// it does not affect delivery). Cannot be combined with `in_reply_to_message_id` (422).</para>
    /// </summary>
    public string? ForwardOfMessageID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "forward_of_message_id"
            );
        }
        init { this._rawBodyData.Set("forward_of_message_id", value); }
    }

    /// <summary>
    /// Optional display name for string `from`; overrides `from.name` when provided.
    /// </summary>
    public string? FromName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "from_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("from_name", value);
        }
    }

    /// <summary>
    /// Optional unsubscribe-group UUID used for group-scoped suppression checks
    /// and unsubscribe handling.
    /// </summary>
    public string? GroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "group_id"
            );
        }
        init { this._rawBodyData.Set("group_id", value); }
    }

    /// <summary>
    /// Custom email headers. Write-only; not returned in responses.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "html_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("html_body", value);
        }
    }

    /// <summary>
    /// When true, allows delivery to recipients whose suppressions explicitly permit
    /// an override. Hard bounces, spam complaints, and invalid-address suppressions
    /// cannot be overridden. Requires the `email:override` API scope.
    /// </summary>
    public bool? IgnoreSuppression {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "ignore_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ignore_suppression", value);
        }
    }

    /// <summary>
    /// Telnyx message UUID of the message this send replies to. When provided, the
    /// API sets RFC 5322 `In-Reply-To` and `References` headers on the outbound
    /// MIME so the recipient's mailbox (Gmail/Outlook) threads it correctly. The
    /// parent is looked up under the caller's account scope; a UUID belonging to
    /// another account yields a non-enumerating 404.
    ///
    /// <para>Wire-only (Phase 1): the API sets the headers and does NOT resolve
    /// or mutate `thread_id` on the server side. Messages sent without this parameter
    /// are standalone (no threading headers injected).</para>
    ///
    /// <para>Cannot be combined with `forward_of_message_id` (422).</para>
    /// </summary>
    public string? InReplyToMessageID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "in_reply_to_message_id"
            );
        }
        init { this._rawBodyData.Set("in_reply_to_message_id", value); }
    }

    public bool? InlineCss {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "inline_css"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inline_css", value);
        }
    }

    /// <summary>
    /// Custom metadata key/value pairs. Stored on the message, returned on message
    /// responses, and propagated to Email Detail Records. Usable in `filter[metadata]`
    /// when listing messages.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EmailAddressInput>(
                "reply_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("reply_to", value);
        }
    }

    /// <summary>
    /// Indicates a reply-all intent. In Phase 1 (wire-only) this does not change
    /// the threading headers — recipient selection is customer- controlled (`to`/`cc`),
    /// and a thread is not defined by its audience. When the referenced message has
    /// no thread context, reply-all degrades to a plain reply (parent ID only in
    /// `References`). The resolution engine (separate work) will expand the ancestor
    /// chain at a later phase with no API change.
    ///
    /// <para>Only meaningful alongside `in_reply_to_message_id`.</para>
    /// </summary>
    public bool? ReplyToAll {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "reply_to_all"
            );
        }
        init { this._rawBodyData.Set("reply_to_all", value); }
    }

    /// <summary>
    /// Validates and accepts the message without injecting it into the MTA or outbound
    /// Kafka path. Nothing is delivered: sandbox records are non-billable, consume
    /// no daily-send-limit quota, and feed no delivery-reputation signals.
    ///
    /// <para>The reserved sandbox test-recipient domain is `test.telnyx.com`. In
    /// sandbox mode, these addresses produce deterministic recipient-scoped lifecycle events:</para>
    ///
    /// <para>- `delivered@test.telnyx.com`: queued -&gt; sending -&gt; sent -&gt;
    /// delivered - `hard-bounce@test.telnyx.com`: queued -&gt; sending -&gt; sent
    /// -&gt; bounced (permanent) - `soft-bounce@test.telnyx.com`: queued -&gt; sending
    /// -&gt; sent -&gt; bounced (transient) - `complaint@test.telnyx.com`: queued
    /// -&gt; sending -&gt; sent -&gt; complained - `suppressed@test.telnyx.com`:
    /// queued -&gt; suppressed - `invalid@test.telnyx.com`: queued -&gt; sending
    /// -&gt; failed (invalid recipient) - `dkim-fail@test.telnyx.com`: queued -&gt;
    /// sending -&gt; failed (DKIM unavailable) - `rate-limit@test.telnyx.com`: queued
    /// -&gt; sending -&gt; failed (rate limit exceeded)</para>
    ///
    /// <para>Matching is case-insensitive for both the local part and the domain
    /// and requires the exact domain `test.telnyx.com` — subdomains and other domains
    /// do not match. Mixed sandbox sends simulate only reserved test recipients;
    /// other recipients retain ordinary sandbox behavior (accepted, no delivery
    /// attempted). Hard-bounce and complaint outcomes also use the normal automatic-suppression
    /// pipeline. Non-sandbox sends to these addresses use the normal delivery path.</para>
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

    /// <summary>
    /// Future ISO 8601 delivery time. Invalid or non-future timestamps are rejected.
    /// Single sends return HTTP 422; in batch sends the invalid item is reported
    /// in the 207 per-item errors while other items continue. `send_at` remains a
    /// deprecated request alias. A non-null `scheduled_at` takes precedence over
    /// `send_at`; when `scheduled_at` is omitted or null, `send_at` is used.
    /// </summary>
    public DateTimeOffset? ScheduledAt {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>(
                "scheduled_at"
            );
        }
        init { this._rawBodyData.Set("scheduled_at", value); }
    }

    /// <summary>
    /// Deprecated alias for `scheduled_at`.
    /// </summary>
    [Obsolete("Use scheduled_at instead.")]
    public DateTimeOffset? SendAt {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>(
                "send_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_at", value);
        }
    }

    /// <summary>
    /// Required unless `template_id` is supplied. When using a template, the template's
    /// subject is rendered; if the template has no subject or renders empty, the
    /// request returns 400.
    /// </summary>
    public string? Subject {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "subject"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("subject", value);
        }
    }

    /// <summary>
    /// Tags for categorization and filtering. Stored on the message, returned on
    /// message responses, and propagated to Email Detail Records. Usable in `filter[tags]`
    /// when listing messages.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TemplateID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("template_id", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "template_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "text_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("text_body", value);
        }
    }

    /// <summary>
    /// Per-send open and click tracking overrides. Omitted properties inherit the
    /// sender domain's tracking settings.
    /// </summary>
    public TrackingSettings? TrackingSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TrackingSettings>(
                "tracking_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tracking_settings", value);
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

    public EmailMessageCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageCreateParams (
        EmailMessageCreateParams emailMessageCreateParams
    ) : base(emailMessageCreateParams)
    { this._rawBodyData = new(emailMessageCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public EmailMessageCreateParams (
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
    EmailMessageCreateParams (
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
    public static EmailMessageCreateParams FromRawUnchecked(
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

    public virtual bool Equals(EmailMessageCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/email_messages"
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