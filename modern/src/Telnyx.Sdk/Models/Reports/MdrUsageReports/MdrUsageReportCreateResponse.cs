using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReportCreateResponse, MdrUsageReportCreateResponseFromRaw>))]
public sealed record class MdrUsageReportCreateResponse : JsonModel
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

    public MdrUsageReportCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportCreateResponse (
        MdrUsageReportCreateResponse mdrUsageReportCreateResponse
    ) : base(mdrUsageReportCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static MdrUsageReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportCreateResponseFromRaw : IFromRawJson<MdrUsageReportCreateResponse>
{
    /// <inheritdoc/>
    public MdrUsageReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReportCreateResponse.FromRawUnchecked(rawData);
}