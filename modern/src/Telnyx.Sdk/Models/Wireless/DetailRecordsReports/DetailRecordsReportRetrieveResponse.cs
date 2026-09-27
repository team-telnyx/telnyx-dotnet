using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

[JsonConverter(typeof(JsonModelConverter<DetailRecordsReportRetrieveResponse, DetailRecordsReportRetrieveResponseFromRaw>))]
public sealed record class DetailRecordsReportRetrieveResponse : JsonModel
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

    public DetailRecordsReportRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordsReportRetrieveResponse (
        DetailRecordsReportRetrieveResponse detailRecordsReportRetrieveResponse
    ) : base(detailRecordsReportRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public DetailRecordsReportRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordsReportRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetailRecordsReportRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DetailRecordsReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DetailRecordsReportRetrieveResponseFromRaw : IFromRawJson<DetailRecordsReportRetrieveResponse>
{
    /// <inheritdoc/>
    public DetailRecordsReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetailRecordsReportRetrieveResponse.FromRawUnchecked(rawData);
}