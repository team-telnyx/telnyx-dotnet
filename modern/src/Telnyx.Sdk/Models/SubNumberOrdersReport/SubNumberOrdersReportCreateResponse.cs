using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SubNumberOrdersReport;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrdersReportCreateResponse, SubNumberOrdersReportCreateResponseFromRaw>))]
public sealed record class SubNumberOrdersReportCreateResponse : JsonModel
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

    public SubNumberOrdersReportCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrdersReportCreateResponse (
        SubNumberOrdersReportCreateResponse subNumberOrdersReportCreateResponse
    ) : base(subNumberOrdersReportCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrdersReportCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrdersReportCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrdersReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrdersReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrdersReportCreateResponseFromRaw : IFromRawJson<SubNumberOrdersReportCreateResponse>
{
    /// <inheritdoc/>
    public SubNumberOrdersReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrdersReportCreateResponse.FromRawUnchecked(rawData);
}