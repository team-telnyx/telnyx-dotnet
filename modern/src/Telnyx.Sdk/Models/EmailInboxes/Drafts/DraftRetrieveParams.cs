using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

/// <summary>
/// Returns a single draft. Drafts that have been sent remain retrievable, so the
/// exact content that was sent stays auditable.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DraftRetrieveParams : ParamsBase
{
    public required string InboxID { get; init; }

    public string? DraftID { get; init; }

    public DraftRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftRetrieveParams (DraftRetrieveParams draftRetrieveParams) : base(
        draftRetrieveParams
    )
    {
        this.InboxID = draftRetrieveParams.InboxID;
        this.DraftID = draftRetrieveParams.DraftID;
    }
    #pragma warning restore CS8618

    public DraftRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string inboxID,
        string draftID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.InboxID = inboxID;
        this.DraftID = draftID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DraftRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string inboxID,
        string draftID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            inboxID,
            draftID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
        ["DraftID"] = JsonSerializer.SerializeToElement(this.DraftID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DraftRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InboxID.Equals(other.InboxID)&&(this.DraftID?.Equals(other.DraftID) ?? other.DraftID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_inboxes/{0}/drafts/{1}",
            EncodePathSegment(this.InboxID),
            EncodePathSegment(this.DraftID))
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