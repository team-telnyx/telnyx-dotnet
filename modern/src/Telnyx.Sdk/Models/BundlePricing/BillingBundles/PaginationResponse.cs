using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.BillingBundles;

[JsonConverter(typeof(JsonModelConverter<PaginationResponse, PaginationResponseFromRaw>))]
public sealed record class PaginationResponse : JsonModel
{
    /// <summary>
    /// The current page number.
    /// </summary>
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// The number of results per page.
    /// </summary>
    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    /// <summary>
    /// Total number of pages from the results.
    /// </summary>
    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <summary>
    /// Total number of results returned.
    /// </summary>
    public required long TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_results"
            );
        }
        init { this._rawData.Set("total_results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public PaginationResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationResponse (PaginationResponse paginationResponse) : base(
        paginationResponse
    )
    {  }
    #pragma warning restore CS8618

    public PaginationResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaginationResponseFromRaw.FromRawUnchecked"/>
    public static PaginationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaginationResponseFromRaw : IFromRawJson<PaginationResponse>
{
    /// <inheritdoc/>
    public PaginationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaginationResponse.FromRawUnchecked(rawData);
}