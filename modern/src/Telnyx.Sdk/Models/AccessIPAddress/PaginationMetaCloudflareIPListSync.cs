using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AccessIPAddress;

[JsonConverter(typeof(JsonModelConverter<PaginationMetaCloudflareIPListSync, PaginationMetaCloudflareIPListSyncFromRaw>))]
public sealed record class PaginationMetaCloudflareIPListSync : JsonModel
{
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

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

    public PaginationMetaCloudflareIPListSync ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationMetaCloudflareIPListSync (
        PaginationMetaCloudflareIPListSync paginationMetaCloudflareIPListSync
    ) : base(paginationMetaCloudflareIPListSync)
    {  }
    #pragma warning restore CS8618

    public PaginationMetaCloudflareIPListSync (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMetaCloudflareIPListSync (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaginationMetaCloudflareIPListSyncFromRaw.FromRawUnchecked"/>
    public static PaginationMetaCloudflareIPListSync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaginationMetaCloudflareIPListSyncFromRaw : IFromRawJson<PaginationMetaCloudflareIPListSync>
{
    /// <inheritdoc/>
    public PaginationMetaCloudflareIPListSync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaginationMetaCloudflareIPListSync.FromRawUnchecked(rawData);
}