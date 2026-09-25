using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReportListPageResponse, MdrUsageReportListPageResponseFromRaw>))]
public sealed record class MdrUsageReportListPageResponse : JsonModel
{
    public IReadOnlyList<MdrUsageReport>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MdrUsageReport>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MdrUsageReport>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ReportingPaginationMeta77109e5d17? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReportingPaginationMeta77109e5d17>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public MdrUsageReportListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportListPageResponse (
        MdrUsageReportListPageResponse mdrUsageReportListPageResponse
    ) : base(mdrUsageReportListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportListPageResponseFromRaw.FromRawUnchecked"/>
    public static MdrUsageReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportListPageResponseFromRaw : IFromRawJson<MdrUsageReportListPageResponse>
{
    /// <inheritdoc/>
    public MdrUsageReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReportListPageResponse.FromRawUnchecked(rawData);
}