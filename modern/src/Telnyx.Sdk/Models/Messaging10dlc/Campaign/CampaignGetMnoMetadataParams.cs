using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

/// <summary>
/// Get the campaign metadata for each MNO it was submitted to.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CampaignGetMnoMetadataParams : ParamsBase
{
    public string? CampaignID { get; init; }

    public CampaignGetMnoMetadataParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignGetMnoMetadataParams (
        CampaignGetMnoMetadataParams campaignGetMnoMetadataParams
    ) : base(campaignGetMnoMetadataParams)
    { this.CampaignID = campaignGetMnoMetadataParams.CampaignID; }
    #pragma warning restore CS8618

    public CampaignGetMnoMetadataParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignGetMnoMetadataParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string campaignID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CampaignID = campaignID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CampaignGetMnoMetadataParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string campaignID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            campaignID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CampaignID"] = JsonSerializer.SerializeToElement(this.CampaignID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CampaignGetMnoMetadataParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CampaignID?.Equals(other.CampaignID) ?? other.CampaignID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/campaign/{0}/mnoMetadata",
            EncodePathSegment(this.CampaignID))
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