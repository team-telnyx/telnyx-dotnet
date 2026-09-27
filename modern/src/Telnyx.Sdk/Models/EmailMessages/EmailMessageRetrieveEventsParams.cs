using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// Lists events for a single message sorted oldest first by `occurred_at asc, id
/// asc`. The legacy `/v2/emails/{id}/events` GET route is a backward-compatible alias.
///
/// <para>For compatibility, each event carries the legacy customer-visible `event_type`
/// (`email.`-prefixed), the additive `canonical_event_type` (`email.`-prefixed),
/// and the deprecated `type` duplicate — whose value keeps the exact legacy format:
/// the bare stored event name, never `email.`-prefixed. Gateway rejections render
/// `email.failed` + canonical `email.gw_reject`; MTA expirations render `email.bounced`
/// + canonical `email.expired`; every unchanged outcome carries identical `event_type`
/// and `canonical_event_type` values (and `type` keeps the stored name).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailMessageRetrieveEventsParams : ParamsBase
{
    public string? EmailID { get; init; }

    /// <summary>
    /// Opaque URL-safe Base64 cursor returned by a previous list response.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_cursor", value);
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

    public EmailMessageRetrieveEventsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageRetrieveEventsParams (
        EmailMessageRetrieveEventsParams emailMessageRetrieveEventsParams
    ) : base(emailMessageRetrieveEventsParams)
    { this.EmailID = emailMessageRetrieveEventsParams.EmailID; }
    #pragma warning restore CS8618

    public EmailMessageRetrieveEventsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageRetrieveEventsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string emailID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EmailID = emailID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailMessageRetrieveEventsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string emailID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            emailID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EmailID"] = JsonSerializer.SerializeToElement(this.EmailID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailMessageRetrieveEventsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EmailID?.Equals(other.EmailID) ?? other.EmailID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_messages/{0}/events",
            EncodePathSegment(this.EmailID))
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