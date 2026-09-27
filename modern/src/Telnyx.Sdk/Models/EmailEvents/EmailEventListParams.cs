using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailEvents;

/// <summary>
/// Lists account-level email events sorted oldest first by `occurred_at asc, id asc`.
/// Each row contains a legacy email.-prefixed event_type and an additive canonical_event_type.
/// Gateway rejection renders email.failed with canonical email.gw_reject; ambiguous
/// injection timeout renders email.injection_timeout in both; MTA expiration renders
/// email.bounced with canonical email.expired. Message-scoped queued, sending, sandbox,
/// cancelled, and daily_limit_exceeded rows fan out per durable recipient with stable
/// derived IDs matching webhook delivery. Scheduled is the cardinality exception:
/// account polling retains one message-scoped scheduled row with its stored event
/// ID, while scheduled webhook publication fans out per recipient with derived IDs;
/// reconcile scheduled events by message ID, event type, and occurrence time rather
/// than event UUID. Recipient-scoped stored rows retain their stored UUIDs across
/// polling and webhook delivery. Legacy names are derived from stored rows; an AdminBounce
/// row stored as failed renders email.failed in polling while its webhook retains
/// email.bounced, both with canonical email.failed.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailEventListParams : ParamsBase
{
    /// <summary>
    /// Filter events for a specific email message UUID. Invalid UUID values are
    /// silently ignored (no filter applied).
    /// </summary>
    public string? EmailID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "email_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("email_id", value);
        }
    }

    /// <summary>
    /// Comma-separated list of event types to include. Also accepts repeated query
    /// parameters (e.g. event_type=delivered&amp;event_type=bounced). Unknown values
    /// return no matches.
    ///
    /// <para>Dual-name compatibility: values are accepted bare or `email.`-prefixed.
    /// A legacy value keeps matching the rows it matched pre-rename — no widening:
    /// `failed` also matches the rows that now store the canonical names of the
    /// outcomes it covered (`gw_reject`, `injection_timeout`, `expired`); `bounced`
    /// matches stored `bounced` rows only (recipient-scoped Expirations stored `failed`
    /// pre-rename and never matched `bounced`, so `expired` is deliberately not
    /// a `bounced` expansion). A canonical value matches its own rows plus legacy
    /// rows whose recorded payload evidence proves that outcome (`expired` also
    /// surfaces legacy `bounced` rows with `bounce_category: transient`). The additive
    /// `canonical_event_type` field in each response row names the canonical outcome. </para>
    /// </summary>
    public EventType? EventType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<EventType>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("event_type", value);
        }
    }

    /// <summary>
    /// Inclusive ISO 8601 start timestamp. Defaults to 30 days ago when omitted.
    /// </summary>
    public System::DateTimeOffset? From {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("from", value);
        }
    }

    /// <summary>
    /// Number of results to return. Defaults to 25; maximum is 100. Invalid values
    /// are clamped to the valid range.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Opaque URL-safe Base64 cursor returned by a previous event list response.
    /// The legacy `page[after]` and flat `page_cursor` forms are also accepted.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[cursor]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[cursor]", value);
        }
    }

    /// <summary>
    /// Inclusive ISO 8601 end timestamp. When `from` is provided without `to`, defaults
    /// to `from + 30 days`.
    /// </summary>
    public System::DateTimeOffset? To {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("to", value);
        }
    }

    public EmailEventListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailEventListParams (
        EmailEventListParams emailEventListParams
    ) : base(emailEventListParams)
    {  }
    #pragma warning restore CS8618

    public EmailEventListParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailEventListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailEventListParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailEventListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/email_events"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Comma-separated list of event types to include. Also accepts repeated query parameters
/// (e.g. event_type=delivered&amp;event_type=bounced). Unknown values return no matches.
///
/// <para>Dual-name compatibility: values are accepted bare or `email.`-prefixed.
/// A legacy value keeps matching the rows it matched pre-rename — no widening: `failed`
/// also matches the rows that now store the canonical names of the outcomes it covered
/// (`gw_reject`, `injection_timeout`, `expired`); `bounced` matches stored `bounced`
/// rows only (recipient-scoped Expirations stored `failed` pre-rename and never matched
/// `bounced`, so `expired` is deliberately not a `bounced` expansion). A canonical
/// value matches its own rows plus legacy rows whose recorded payload evidence proves
/// that outcome (`expired` also surfaces legacy `bounced` rows with `bounce_category:
/// transient`). The additive `canonical_event_type` field in each response row names
/// the canonical outcome. </para>
/// </summary>
[JsonConverter(typeof(EventTypeConverter))]
public record class EventType : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public EventType (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventType (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public EventType (JsonElement element)
    { this._element = element; }

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
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of EventType");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of EventType")
        } ;
    }

    public static implicit operator EventType (string value)=> new(value) ;

    public static implicit operator EventType (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of EventType");
        }
    }

    public virtual bool Equals(EventType? other)
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
        { string _=>0, Generic::IReadOnlyList<string> _=>1, _ =>-1 } ;
    }
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
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
        Utf8JsonWriter writer, EventType value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}