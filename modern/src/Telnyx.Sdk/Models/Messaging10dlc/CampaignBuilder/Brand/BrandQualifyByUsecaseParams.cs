using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder.Brand;

/// <summary>
/// This endpoint allows you to see whether or not the supplied brand is suitable
/// for your desired campaign use case.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandQualifyByUsecaseParams : ParamsBase
{
    public required string BrandID { get; init; }

    public string? Usecase { get; init; }

    public BrandQualifyByUsecaseParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandQualifyByUsecaseParams (
        BrandQualifyByUsecaseParams brandQualifyByUsecaseParams
    ) : base(brandQualifyByUsecaseParams)
    {
        this.BrandID = brandQualifyByUsecaseParams.BrandID;
        this.Usecase = brandQualifyByUsecaseParams.Usecase;
    }
    #pragma warning restore CS8618

    public BrandQualifyByUsecaseParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandQualifyByUsecaseParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string brandID,
        string usecase
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BrandID = brandID;
        this.Usecase = usecase;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandQualifyByUsecaseParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string brandID,
        string usecase
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            brandID,
            usecase
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["BrandID"] = JsonSerializer.SerializeToElement(this.BrandID),
        ["Usecase"] = JsonSerializer.SerializeToElement(this.Usecase),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BrandQualifyByUsecaseParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.BrandID.Equals(other.BrandID)&&(this.Usecase?.Equals(other.Usecase) ?? other.Usecase == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/campaignBuilder/brand/{0}/usecase/{1}",
            EncodePathSegment(this.BrandID),
            EncodePathSegment(this.Usecase))
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