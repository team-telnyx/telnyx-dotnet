using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailEvents;

/// <summary>
/// An account-polling event. The envelope is webhook-shaped, but polling preserves
/// stored-event cardinality: queued, sending, sandbox, cancelled, and daily_limit_exceeded
/// message events fan out per recipient; scheduled remains one message-scoped row.
/// Payload fields vary among recipient-scoped, message-scoped, and minimal fallback rows.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailEventListResponse, EmailEventListResponseFromRaw>))]
public sealed record class EmailEventListResponse : JsonModel
{
    /// <summary>
    /// Event UUID.
    /// </summary>
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
    /// Additive canonical outcome name, prefixed with `email.`. Gateway rejection
    /// is `email.gw_reject`, ambiguous injection timeout is `email.injection_timeout`,
    /// and MTA expiration is `email.expired`. Unchanged outcomes retain their names.
    /// Existing stored rows are translated only when recorded payload evidence proves
    /// the outcome; a legacy failed row is not guessed or sharpened.
    /// </summary>
    public required string CanonicalEventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "canonical_event_type"
            );
        }
        init { this._rawData.Set("canonical_event_type", value); }
    }

    /// <summary>
    /// Legacy customer-visible event name, prefixed with `email.`. Gateway rejections
    /// render `email.failed`; MTA expirations render `email.bounced`. Webhook subscription
    /// allowlists match the legacy name.
    /// </summary>
    public required string EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
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
    /// Payload returned by GET /email_events. Every row includes id, status, and
    /// occurred_at. Recipient-scoped rows also include recipient_id, from, subject,
    /// and exactly one object-valued to, cc, or bcc field. Legacy or message-scoped
    /// rows can omit recipient_id and use object-valued or string-valued to/cc fields,
    /// including an empty string when no address exists; bcc is redacted. If the
    /// related message or recipient cannot be loaded, the minimal fallback can omit
    /// from, subject, and recipient fields. Additional persisted public evidence
    /// can be present.
    /// </summary>
    public required Payload Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payload>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    /// <summary>
    /// Durable email recipient UUID. Present for recipient-scoped events, including
    /// each queued, sending, sandbox, cancelled, and daily_limit_exceeded fan-out event.
    /// </summary>
    public string? RecipientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recipient_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recipient_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CanonicalEventType;
        _ = this.EventType;
        _ = this.OccurredAt;
        this.Payload.Validate();
        _ = this.RecipientID;
    }

    public EmailEventListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailEventListResponse (
        EmailEventListResponse emailEventListResponse
    ) : base(emailEventListResponse)
    {  }
    #pragma warning restore CS8618

    public EmailEventListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailEventListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailEventListResponseFromRaw.FromRawUnchecked"/>
    public static EmailEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailEventListResponseFromRaw : IFromRawJson<EmailEventListResponse>
{
    /// <inheritdoc/>
    public EmailEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailEventListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Payload returned by GET /email_events. Every row includes id, status, and occurred_at.
/// Recipient-scoped rows also include recipient_id, from, subject, and exactly one
/// object-valued to, cc, or bcc field. Legacy or message-scoped rows can omit recipient_id
/// and use object-valued or string-valued to/cc fields, including an empty string
/// when no address exists; bcc is redacted. If the related message or recipient cannot
/// be loaded, the minimal fallback can omit from, subject, and recipient fields.
/// Additional persisted public evidence can be present.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    /// <summary>
    /// Email message UUID.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
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
    /// Stored event outcome slug, not the authoritative recipient status. Account
    /// polling returns the stored name, including suppression, scan, and quarantine
    /// lifecycle names. Webhooks retain legacy payload names: gateway rejections
    /// use failed and MTA expirations use bounced. New sharp stored rows can expose
    /// gw_reject, injection_timeout, or expired. Use the envelope canonical_event_type
    /// to identify the outcome across surfaces.
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

    public Bcc? Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Bcc>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bcc", value);
        }
    }

    /// <summary>
    /// Legacy message-scoped address, or an empty string when absent.
    /// </summary>
    public Cc? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cc>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cc", value);
        }
    }

    /// <summary>
    /// Sender projection in account event polling. The display name is explicitly
    /// null when the message has no sender name.
    /// </summary>
    public From? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// Durable email recipient UUID. Present for recipient-scoped events.
    /// </summary>
    public string? RecipientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recipient_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recipient_id", value);
        }
    }

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
    /// Legacy message-scoped address, or an empty string when absent.
    /// </summary>
    public To? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.OccurredAt;
        this.Status.Validate();
        this.Bcc?.Validate();
        this.Cc?.Validate();
        this.From?.Validate();
        _ = this.RecipientID;
        _ = this.Subject;
        this.To?.Validate();
    }

    public Payload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payload (Payload payload) : base(payload)
    {  }
    #pragma warning restore CS8618

    public Payload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Payload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayloadFromRaw.FromRawUnchecked"/>
    public static Payload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PayloadFromRaw : IFromRawJson<Payload>
{
    /// <inheritdoc/>
    public Payload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Payload.FromRawUnchecked(rawData);
}/// <summary>
/// Stored event outcome slug, not the authoritative recipient status. Account polling
/// returns the stored name, including suppression, scan, and quarantine lifecycle
/// names. Webhooks retain legacy payload names: gateway rejections use failed and
/// MTA expirations use bounced. New sharp stored rows can expose gw_reject, injection_timeout,
/// or expired. Use the envelope canonical_event_type to identify the outcome across surfaces.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    Deferred,
    Scheduled,
    Cancelled,
    Sandbox,
    Sending,
    Sent,
    Failed,
    Delivered,
    Bounced,
    Complained,
    Suppressed,
    Rejected,
    Opened,
    Clicked,
    Unsubscribed,
    DailyLimitExceeded,
    ScanDeferred,
    Quarantined,
    QuarantineReleased,
    QuarantineReleaseDispatched,
    QuarantineRejected,
    QuarantineExpired,
    GwReject,
    InjectionTimeout,
    Expired
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
            "queued"=>Status.Queued,
            "deferred"=>Status.Deferred,
            "scheduled"=>Status.Scheduled,
            "cancelled"=>Status.Cancelled,
            "sandbox"=>Status.Sandbox,
            "sending"=>Status.Sending,
            "sent"=>Status.Sent,
            "failed"=>Status.Failed,
            "delivered"=>Status.Delivered,
            "bounced"=>Status.Bounced,
            "complained"=>Status.Complained,
            "suppressed"=>Status.Suppressed,
            "rejected"=>Status.Rejected,
            "opened"=>Status.Opened,
            "clicked"=>Status.Clicked,
            "unsubscribed"=>Status.Unsubscribed,
            "daily_limit_exceeded"=>Status.DailyLimitExceeded,
            "scan_deferred"=>Status.ScanDeferred,
            "quarantined"=>Status.Quarantined,
            "quarantine_released"=>Status.QuarantineReleased,
            "quarantine_release_dispatched"=>Status.QuarantineReleaseDispatched,
            "quarantine_rejected"=>Status.QuarantineRejected,
            "quarantine_expired"=>Status.QuarantineExpired,
            "gw_reject"=>Status.GwReject,
            "injection_timeout"=>Status.InjectionTimeout,
            "expired"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            Status.Deferred=>"deferred",
            Status.Scheduled=>"scheduled",
            Status.Cancelled=>"cancelled",
            Status.Sandbox=>"sandbox",
            Status.Sending=>"sending",
            Status.Sent=>"sent",
            Status.Failed=>"failed",
            Status.Delivered=>"delivered",
            Status.Bounced=>"bounced",
            Status.Complained=>"complained",
            Status.Suppressed=>"suppressed",
            Status.Rejected=>"rejected",
            Status.Opened=>"opened",
            Status.Clicked=>"clicked",
            Status.Unsubscribed=>"unsubscribed",
            Status.DailyLimitExceeded=>"daily_limit_exceeded",
            Status.ScanDeferred=>"scan_deferred",
            Status.Quarantined=>"quarantined",
            Status.QuarantineReleased=>"quarantine_released",
            Status.QuarantineReleaseDispatched=>"quarantine_release_dispatched",
            Status.QuarantineRejected=>"quarantine_rejected",
            Status.QuarantineExpired=>"quarantine_expired",
            Status.GwReject=>"gw_reject",
            Status.InjectionTimeout=>"injection_timeout",
            Status.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(BccConverter))]
public record class Bcc : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Bcc (EmailWebhookRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Bcc (
        ApiEnum<string, UnionMember1> value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Bcc (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailWebhookRecipient"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEmailWebhookRecipient(out var value)) {
///     // `value` is of type `EmailWebhookRecipient`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEmailWebhookRecipient(
        [NotNullWhen(true)] out EmailWebhookRecipient? value
    )
    {
        value =this.Value as EmailWebhookRecipient ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of UnionMember1>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnionMember1(out var value)) {
///     // `value` is of type `ApiEnum&lt;string, UnionMember1&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnionMember1(
        [NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value
    )
    {
        value =this.Value as ApiEnum<string, UnionMember1> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (ApiEnum&lt;string, UnionMember1&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<EmailWebhookRecipient> emailWebhookRecipient,
        System::Action<ApiEnum<string, UnionMember1>> unionMember1
    )
    {
        switch (this.Value)
        {
            case EmailWebhookRecipient value:
                emailWebhookRecipient(value);
                break;
            case ApiEnum<string, UnionMember1> value:
                unionMember1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Bcc");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (ApiEnum&lt;string, UnionMember1&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<EmailWebhookRecipient, T> emailWebhookRecipient,
        System::Func<ApiEnum<string, UnionMember1>, T> unionMember1
    )
    {
        return this.Value switch
        {
            EmailWebhookRecipient value=>emailWebhookRecipient(value),
            ApiEnum<string, UnionMember1> value=>unionMember1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Bcc")
        } ;
    }

    public static implicit operator Bcc (
        EmailWebhookRecipient value
    )=> new(value) ;

    public static implicit operator Bcc (
        ApiEnum<string, UnionMember1> value
    )=> new(value) ;

    public static implicit operator Bcc (UnionMember1 value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Bcc");
        }
        this.Switch((emailWebhookRecipient) => emailWebhookRecipient.Validate(),
        (unionMember1) => unionMember1.Validate());
    }

    public virtual bool Equals(Bcc? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            EmailWebhookRecipient _=>0,
            ApiEnum<string, UnionMember1> _=>1,
            _ =>-1
        } ;
    }
}sealed class BccConverter : JsonConverter<Bcc>
{
    public override Bcc? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<EmailWebhookRecipient>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Bcc value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(UnionMember1Converter))]
public enum UnionMember1
{
    Redacted
}sealed class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "redacted"=>UnionMember1.Redacted, _ =>(UnionMember1)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, UnionMember1 value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnionMember1.Redacted=>"redacted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Legacy message-scoped address, or an empty string when absent.
/// </summary>
[JsonConverter(typeof(CcConverter))]
public record class Cc : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Cc (EmailWebhookRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Cc (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Cc (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailWebhookRecipient"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEmailWebhookRecipient(out var value)) {
///     // `value` is of type `EmailWebhookRecipient`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEmailWebhookRecipient(
        [NotNullWhen(true)] out EmailWebhookRecipient? value
    )
    {
        value =this.Value as EmailWebhookRecipient ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<EmailWebhookRecipient> emailWebhookRecipient,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case EmailWebhookRecipient value:
                emailWebhookRecipient(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Cc");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<EmailWebhookRecipient, T> emailWebhookRecipient,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            EmailWebhookRecipient value=>emailWebhookRecipient(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Cc")
        } ;
    }

    public static implicit operator Cc (
        EmailWebhookRecipient value
    )=> new(value) ;

    public static implicit operator Cc (string value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Cc");
        }
        this.Switch((emailWebhookRecipient) => emailWebhookRecipient.Validate(),
        (_) => {});
    }

    public virtual bool Equals(Cc? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { EmailWebhookRecipient _=>0, string _=>1, _ =>-1 } ;
    }
}sealed class CcConverter : JsonConverter<Cc>
{
    public override Cc? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<EmailWebhookRecipient>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Cc value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Sender projection in account event polling. The display name is explicitly null
/// when the message has no sender name.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public required string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
    }

    public From ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public From (From from) : base(from)
    {  }
    #pragma warning restore CS8618

    public From (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    From (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}/// <summary>
/// Legacy message-scoped address, or an empty string when absent.
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public To (EmailWebhookRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailWebhookRecipient"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEmailWebhookRecipient(out var value)) {
///     // `value` is of type `EmailWebhookRecipient`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEmailWebhookRecipient(
        [NotNullWhen(true)] out EmailWebhookRecipient? value
    )
    {
        value =this.Value as EmailWebhookRecipient ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<EmailWebhookRecipient> emailWebhookRecipient,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case EmailWebhookRecipient value:
                emailWebhookRecipient(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of To");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (EmailWebhookRecipient value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<EmailWebhookRecipient, T> emailWebhookRecipient,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            EmailWebhookRecipient value=>emailWebhookRecipient(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of To")
        } ;
    }

    public static implicit operator To (
        EmailWebhookRecipient value
    )=> new(value) ;

    public static implicit operator To (string value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of To");
        }
        this.Switch((emailWebhookRecipient) => emailWebhookRecipient.Validate(),
        (_) => {});
    }

    public virtual bool Equals(To? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { EmailWebhookRecipient _=>0, string _=>1, _ =>-1 } ;
    }
}sealed class ToConverter : JsonConverter<To>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<EmailWebhookRecipient>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, To value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}