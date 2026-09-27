using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BotSessions;

/// <summary>
/// Consumes the one-time portal redirect (magic link) token emailed during bot signup
/// and returns an API session. The token is a UUIDv7 that encodes its creation time;
/// it expires after a configurable validity window (15 minutes by default) and is
/// cleared on first use. Although the action creates a session, the route uses the
/// GET verb because it is opened from an email link. On first use the account is
/// also initialized. For bot signup (freemium) accounts the response is a minimal
/// envelope containing only the `api_v2_token`; accounts that are permitted to use
/// magic links but are not freemium accounts may instead receive an extended session
/// payload when additional steps (such as two-factor authentication or identity
/// verification) are required. This endpoint is public; the magic link token in
/// the query string is the credential.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BotSessionListParams : ParamsBase
{
    /// <summary>
    /// Email address associated with the magic link token.
    /// </summary>
    public required string Email {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawQueryData.Set("email", value); }
    }

    /// <summary>
    /// Single-use portal redirect (magic link) token, a UUIDv7 sent to the account
    /// owner's email.
    /// </summary>
    public required string PortalRedirectToken {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "portal_redirect_token"
            );
        }
        init { this._rawQueryData.Set("portal_redirect_token", value); }
    }

    public BotSessionListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BotSessionListParams (
        BotSessionListParams botSessionListParams
    ) : base(botSessionListParams)
    {  }
    #pragma warning restore CS8618

    public BotSessionListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BotSessionListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BotSessionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BotSessionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/bot_sessions"
        )
        {
            Query = this.QueryString(options, new())
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(request, options, new());
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