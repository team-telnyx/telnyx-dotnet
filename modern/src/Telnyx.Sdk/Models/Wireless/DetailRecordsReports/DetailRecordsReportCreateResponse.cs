using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

[JsonConverter(typeof(JsonModelConverter<DetailRecordsReportCreateResponse, DetailRecordsReportCreateResponseFromRaw>))]
public sealed record class DetailRecordsReportCreateResponse : JsonModel
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

    public DetailRecordsReportCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordsReportCreateResponse (
        DetailRecordsReportCreateResponse detailRecordsReportCreateResponse
    ) : base(detailRecordsReportCreateResponse)
    {  }
    #pragma warning restore CS8618

    public DetailRecordsReportCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordsReportCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetailRecordsReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static DetailRecordsReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DetailRecordsReportCreateResponseFromRaw : IFromRawJson<DetailRecordsReportCreateResponse>
{
    /// <inheritdoc/>
    public DetailRecordsReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetailRecordsReportCreateResponse.FromRawUnchecked(rawData);
}