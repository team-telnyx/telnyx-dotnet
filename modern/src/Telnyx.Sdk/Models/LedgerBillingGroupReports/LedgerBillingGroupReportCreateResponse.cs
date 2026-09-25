using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.LedgerBillingGroupReports;

[JsonConverter(typeof(JsonModelConverter<LedgerBillingGroupReportCreateResponse, LedgerBillingGroupReportCreateResponseFromRaw>))]
public sealed record class LedgerBillingGroupReportCreateResponse : JsonModel
{
    public LedgerBillingGroupReport? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LedgerBillingGroupReport>(
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

    public LedgerBillingGroupReportCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LedgerBillingGroupReportCreateResponse (
        LedgerBillingGroupReportCreateResponse ledgerBillingGroupReportCreateResponse
    ) : base(ledgerBillingGroupReportCreateResponse)
    {  }
    #pragma warning restore CS8618

    public LedgerBillingGroupReportCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerBillingGroupReportCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LedgerBillingGroupReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static LedgerBillingGroupReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LedgerBillingGroupReportCreateResponseFromRaw : IFromRawJson<LedgerBillingGroupReportCreateResponse>
{
    /// <inheritdoc/>
    public LedgerBillingGroupReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LedgerBillingGroupReportCreateResponse.FromRawUnchecked(rawData);
}