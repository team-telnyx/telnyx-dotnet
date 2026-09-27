using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

[JsonConverter(typeof(JsonModelConverter<DetailRecordsReportDeleteResponse, DetailRecordsReportDeleteResponseFromRaw>))]
public sealed record class DetailRecordsReportDeleteResponse : JsonModel
{
    public WdrReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WdrReport>(
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

    public DetailRecordsReportDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordsReportDeleteResponse (
        DetailRecordsReportDeleteResponse detailRecordsReportDeleteResponse
    ) : base(detailRecordsReportDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public DetailRecordsReportDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordsReportDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetailRecordsReportDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DetailRecordsReportDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DetailRecordsReportDeleteResponseFromRaw : IFromRawJson<DetailRecordsReportDeleteResponse>
{
    /// <inheritdoc/>
    public DetailRecordsReportDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetailRecordsReportDeleteResponse.FromRawUnchecked(rawData);
}