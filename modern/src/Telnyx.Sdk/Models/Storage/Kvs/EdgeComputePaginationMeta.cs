using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Kvs;

[JsonConverter(typeof(JsonModelConverter<EdgeComputePaginationMeta, EdgeComputePaginationMetaFromRaw>))]
public sealed record class EdgeComputePaginationMeta : JsonModel
{
    public long? PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_number", value);
        }
    }

    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    public long? TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_pages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_pages", value);
        }
    }

    public long? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public EdgeComputePaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EdgeComputePaginationMeta (
        EdgeComputePaginationMeta edgeComputePaginationMeta
    ) : base(edgeComputePaginationMeta)
    {  }
    #pragma warning restore CS8618

    public EdgeComputePaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EdgeComputePaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EdgeComputePaginationMetaFromRaw.FromRawUnchecked"/>
    public static EdgeComputePaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EdgeComputePaginationMetaFromRaw : IFromRawJson<EdgeComputePaginationMeta>
{
    /// <inheritdoc/>
    public EdgeComputePaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EdgeComputePaginationMeta.FromRawUnchecked(rawData);
}