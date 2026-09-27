using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FunctionsObservabilityPaginationMeta, FunctionsObservabilityPaginationMetaFromRaw>))]
public sealed record class FunctionsObservabilityPaginationMeta : JsonModel
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

    public FunctionsObservabilityPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionsObservabilityPaginationMeta (
        FunctionsObservabilityPaginationMeta functionsObservabilityPaginationMeta
    ) : base(functionsObservabilityPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public FunctionsObservabilityPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionsObservabilityPaginationMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FunctionsObservabilityPaginationMetaFromRaw.FromRawUnchecked"/>
    public static FunctionsObservabilityPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FunctionsObservabilityPaginationMetaFromRaw : IFromRawJson<FunctionsObservabilityPaginationMeta>
{
    /// <inheritdoc/>
    public FunctionsObservabilityPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FunctionsObservabilityPaginationMeta.FromRawUnchecked(rawData);
}