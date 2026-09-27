using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

[JsonConverter(typeof(JsonModelConverter<DetailRecordsReportListResponse, DetailRecordsReportListResponseFromRaw>))]
public sealed record class DetailRecordsReportListResponse : JsonModel
{
    public IReadOnlyList<WdrReport>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WdrReport>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WdrReport>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public DetailRecordsReportListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordsReportListResponse (
        DetailRecordsReportListResponse detailRecordsReportListResponse
    ) : base(detailRecordsReportListResponse)
    {  }
    #pragma warning restore CS8618

    public DetailRecordsReportListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordsReportListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetailRecordsReportListResponseFromRaw.FromRawUnchecked"/>
    public static DetailRecordsReportListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DetailRecordsReportListResponseFromRaw : IFromRawJson<DetailRecordsReportListResponse>
{
    /// <inheritdoc/>
    public DetailRecordsReportListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetailRecordsReportListResponse.FromRawUnchecked(rawData);
}