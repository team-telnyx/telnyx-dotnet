using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

[JsonConverter(typeof(JsonModelConverter<BatchCsvPaginationMeta705dfa7312, BatchCsvPaginationMeta705dfa7312FromRaw>))]
public sealed record class BatchCsvPaginationMeta705dfa7312 : JsonModel
{
    public int? PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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

    public int? TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public BatchCsvPaginationMeta705dfa7312 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCsvPaginationMeta705dfa7312 (
        BatchCsvPaginationMeta705dfa7312 batchCsvPaginationMeta705dfa7312
    ) : base(batchCsvPaginationMeta705dfa7312)
    {  }
    #pragma warning restore CS8618

    public BatchCsvPaginationMeta705dfa7312 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCsvPaginationMeta705dfa7312 (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BatchCsvPaginationMeta705dfa7312FromRaw.FromRawUnchecked"/>
    public static BatchCsvPaginationMeta705dfa7312 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BatchCsvPaginationMeta705dfa7312FromRaw : IFromRawJson<BatchCsvPaginationMeta705dfa7312>
{
    /// <inheritdoc/>
    public BatchCsvPaginationMeta705dfa7312 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BatchCsvPaginationMeta705dfa7312.FromRawUnchecked(rawData);
}