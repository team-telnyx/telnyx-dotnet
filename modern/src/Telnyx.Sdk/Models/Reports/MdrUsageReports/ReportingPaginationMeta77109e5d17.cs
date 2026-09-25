using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<ReportingPaginationMeta77109e5d17, ReportingPaginationMeta77109e5d17FromRaw>))]
public sealed record class ReportingPaginationMeta77109e5d17 : JsonModel
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

    public ReportingPaginationMeta77109e5d17 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportingPaginationMeta77109e5d17 (
        ReportingPaginationMeta77109e5d17 reportingPaginationMeta77109e5d17
    ) : base(reportingPaginationMeta77109e5d17)
    {  }
    #pragma warning restore CS8618

    public ReportingPaginationMeta77109e5d17 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportingPaginationMeta77109e5d17 (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportingPaginationMeta77109e5d17FromRaw.FromRawUnchecked"/>
    public static ReportingPaginationMeta77109e5d17 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportingPaginationMeta77109e5d17FromRaw : IFromRawJson<ReportingPaginationMeta77109e5d17>
{
    /// <inheritdoc/>
    public ReportingPaginationMeta77109e5d17 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportingPaginationMeta77109e5d17.FromRawUnchecked(rawData);
}