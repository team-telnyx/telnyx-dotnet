using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

/// <summary>
/// Where a listing's page sits in the whole.
///
/// <para>A page is a snapshot: the counts it reports and the order it is drawn in
/// both move as writes land, so paging through a busy namespace can repeat or miss
/// an entry at a page boundary.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PageMeta, PageMetaFromRaw>))]
public sealed record class PageMeta : JsonModel
{
    /// <summary>
    /// The page returned, counting from 1.
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
    /// How many results a page holds.
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
    /// Pages that can be requested; 0 when nothing matched. Page until `page_number`
    /// reaches it rather than until a page comes back short: a page can hold fewer
    /// than `page_size` results without being the last. Capped at the deepest page
    /// served, so on a very large listing it covers fewer results than `total_results`.
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
    /// Results the request matched, including any past the deepest page.
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

    public PageMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageMeta (PageMeta pageMeta) : base(pageMeta)
    {  }
    #pragma warning restore CS8618

    public PageMeta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PageMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PageMetaFromRaw.FromRawUnchecked"/>
    public static PageMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PageMetaFromRaw : IFromRawJson<PageMeta>
{
    /// <inheritdoc/>
    public PageMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PageMeta.FromRawUnchecked(rawData);
}