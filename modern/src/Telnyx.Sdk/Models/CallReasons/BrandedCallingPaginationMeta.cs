using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallReasons;

/// <summary>
/// JSON:API pagination metadata returned with every paginated list response. Page
/// numbering is 1-based. `page_size` reports the number of items actually returned
/// in `data` for this page; the requested size is taken from the `page[size]` query parameter.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandedCallingPaginationMeta, BrandedCallingPaginationMetaFromRaw>))]
public sealed record class BrandedCallingPaginationMeta : JsonModel
{
    /// <summary>
    /// 1-based index of this page. Echoes the `page[number]` query parameter (default `1`).
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
    /// Number of items returned in this page's `data` array. Capped at 250.
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
    /// Total number of pages available given the current `page_size`.
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
    /// Total number of items across all pages (excludes soft-deleted rows).
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

    public BrandedCallingPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandedCallingPaginationMeta (
        BrandedCallingPaginationMeta brandedCallingPaginationMeta
    ) : base(brandedCallingPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public BrandedCallingPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandedCallingPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandedCallingPaginationMetaFromRaw.FromRawUnchecked"/>
    public static BrandedCallingPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandedCallingPaginationMetaFromRaw : IFromRawJson<BrandedCallingPaginationMeta>
{
    /// <inheritdoc/>
    public BrandedCallingPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandedCallingPaginationMeta.FromRawUnchecked(rawData);
}