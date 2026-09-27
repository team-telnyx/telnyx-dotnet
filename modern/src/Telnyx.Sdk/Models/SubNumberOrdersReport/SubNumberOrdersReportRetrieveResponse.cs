using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SubNumberOrdersReport;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrdersReportRetrieveResponse, SubNumberOrdersReportRetrieveResponseFromRaw>))]
public sealed record class SubNumberOrdersReportRetrieveResponse : JsonModel
{
    public SubNumberOrdersReportSubNumberOrdersReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubNumberOrdersReportSubNumberOrdersReport>(
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

    public SubNumberOrdersReportRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrdersReportRetrieveResponse (
        SubNumberOrdersReportRetrieveResponse subNumberOrdersReportRetrieveResponse
    ) : base(subNumberOrdersReportRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrdersReportRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrdersReportRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrdersReportRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrdersReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrdersReportRetrieveResponseFromRaw : IFromRawJson<SubNumberOrdersReportRetrieveResponse>
{
    /// <inheritdoc/>
    public SubNumberOrdersReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrdersReportRetrieveResponse.FromRawUnchecked(rawData);
}