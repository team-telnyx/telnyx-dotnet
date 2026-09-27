using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReportDeleteResponse, MdrUsageReportDeleteResponseFromRaw>))]
public sealed record class MdrUsageReportDeleteResponse : JsonModel
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

    public MdrUsageReportDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportDeleteResponse (
        MdrUsageReportDeleteResponse mdrUsageReportDeleteResponse
    ) : base(mdrUsageReportDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MdrUsageReportDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportDeleteResponseFromRaw : IFromRawJson<MdrUsageReportDeleteResponse>
{
    /// <inheritdoc/>
    public MdrUsageReportDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReportDeleteResponse.FromRawUnchecked(rawData);
}