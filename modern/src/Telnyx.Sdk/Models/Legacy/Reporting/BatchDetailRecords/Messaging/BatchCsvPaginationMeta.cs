using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

[JsonConverter(typeof(JsonModelConverter<BatchCsvPaginationMeta, BatchCsvPaginationMetaFromRaw>))]
public sealed record class BatchCsvPaginationMeta : JsonModel
{
    public required int PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required int TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    public int? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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

    public int? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
        _ = this.TotalPages;
        _ = this.PageSize;
        _ = this.TotalResults;
    }

    public BatchCsvPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCsvPaginationMeta (
        BatchCsvPaginationMeta batchCsvPaginationMeta
    ) : base(batchCsvPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public BatchCsvPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCsvPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BatchCsvPaginationMetaFromRaw.FromRawUnchecked"/>
    public static BatchCsvPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BatchCsvPaginationMetaFromRaw : IFromRawJson<BatchCsvPaginationMeta>
{
    /// <inheritdoc/>
    public BatchCsvPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BatchCsvPaginationMeta.FromRawUnchecked(rawData);
}