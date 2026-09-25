using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReportFetchSyncResponse, MdrUsageReportFetchSyncResponseFromRaw>))]
public sealed record class MdrUsageReportFetchSyncResponse : JsonModel
{
    public MdrUsageReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MdrUsageReport>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public MdrUsageReportFetchSyncResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportFetchSyncResponse (
        MdrUsageReportFetchSyncResponse mdrUsageReportFetchSyncResponse
    ) : base(mdrUsageReportFetchSyncResponse)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportFetchSyncResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportFetchSyncResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportFetchSyncResponseFromRaw.FromRawUnchecked"/>
    public static MdrUsageReportFetchSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportFetchSyncResponseFromRaw : IFromRawJson<MdrUsageReportFetchSyncResponse>
{
    /// <inheritdoc/>
    public MdrUsageReportFetchSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReportFetchSyncResponse.FromRawUnchecked(rawData);
}