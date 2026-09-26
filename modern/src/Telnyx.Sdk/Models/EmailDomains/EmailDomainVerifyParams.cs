using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains;

/// <summary>
/// Checks the published DNS records against the records required for the email domain
/// and returns the latest verification results.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailDomainVerifyParams : ParamsBase
{
    public string? DomainID { get; init; }

    public EmailDomainVerifyParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainVerifyParams (
        EmailDomainVerifyParams emailDomainVerifyParams
    ) : base(emailDomainVerifyParams)
    { this.DomainID = emailDomainVerifyParams.DomainID; }
    #pragma warning restore CS8618

    public EmailDomainVerifyParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainVerifyParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string domainID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.DomainID = domainID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailDomainVerifyParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string domainID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            domainID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["DomainID"] = JsonSerializer.SerializeToElement(this.DomainID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailDomainVerifyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DomainID?.Equals(other.DomainID) ?? other.DomainID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_domains/{0}/verify",
            EncodePathSegment(this.DomainID))
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