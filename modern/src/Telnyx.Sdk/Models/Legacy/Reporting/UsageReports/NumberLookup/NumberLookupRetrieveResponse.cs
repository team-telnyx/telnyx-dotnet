using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

[JsonConverter(typeof(JsonModelConverter<NumberLookupRetrieveResponse, NumberLookupRetrieveResponseFromRaw>))]
public sealed record class NumberLookupRetrieveResponse : JsonModel
{
    /// <summary>
    /// Telco data usage report response
    /// </summary>
    public TelcoDataUsageReportResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelcoDataUsageReportResponse>(
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

    public NumberLookupRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupRetrieveResponse (
        NumberLookupRetrieveResponse numberLookupRetrieveResponse
    ) : base(numberLookupRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberLookupRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberLookupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberLookupRetrieveResponseFromRaw : IFromRawJson<NumberLookupRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberLookupRetrieveResponse.FromRawUnchecked(rawData);
}