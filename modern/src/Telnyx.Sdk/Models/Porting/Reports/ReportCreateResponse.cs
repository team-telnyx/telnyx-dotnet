using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportCreateResponse, ReportCreateResponseFromRaw>))]
public sealed record class ReportCreateResponse : JsonModel
{
    public PortingReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingReport>(
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

    public ReportCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportCreateResponse (
        ReportCreateResponse reportCreateResponse
    ) : base(reportCreateResponse)
    {  }
    #pragma warning restore CS8618

    public ReportCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static ReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportCreateResponseFromRaw : IFromRawJson<ReportCreateResponse>
{
    /// <inheritdoc/>
    public ReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportCreateResponse.FromRawUnchecked(rawData);
}