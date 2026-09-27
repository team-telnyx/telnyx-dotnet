using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportRetrieveResponse, ReportRetrieveResponseFromRaw>))]
public sealed record class ReportRetrieveResponse : JsonModel
{
    public PortoutReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortoutReport>(
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

    public ReportRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportRetrieveResponse (
        ReportRetrieveResponse reportRetrieveResponse
    ) : base(reportRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ReportRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportRetrieveResponseFromRaw : IFromRawJson<ReportRetrieveResponse>
{
    /// <inheritdoc/>
    public ReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportRetrieveResponse.FromRawUnchecked(rawData);
}