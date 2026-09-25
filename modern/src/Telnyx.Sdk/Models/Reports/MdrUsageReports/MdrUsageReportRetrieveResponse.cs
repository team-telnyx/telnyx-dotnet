using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReportRetrieveResponse, MdrUsageReportRetrieveResponseFromRaw>))]
public sealed record class MdrUsageReportRetrieveResponse : JsonModel
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

    public MdrUsageReportRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportRetrieveResponse (
        MdrUsageReportRetrieveResponse mdrUsageReportRetrieveResponse
    ) : base(mdrUsageReportRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MdrUsageReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportRetrieveResponseFromRaw : IFromRawJson<MdrUsageReportRetrieveResponse>
{
    /// <inheritdoc/>
    public MdrUsageReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReportRetrieveResponse.FromRawUnchecked(rawData);
}