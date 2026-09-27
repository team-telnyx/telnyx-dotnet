using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CountryCoverage;

[JsonConverter(typeof(JsonModelConverter<CountryCoverageRetrieveCountryResponse, CountryCoverageRetrieveCountryResponseFromRaw>))]
public sealed record class CountryCoverageRetrieveCountryResponse : JsonModel
{
    public CountryCoverageCountryCoverage? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CountryCoverageCountryCoverage>(
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

    public CountryCoverageRetrieveCountryResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryCoverageRetrieveCountryResponse (
        CountryCoverageRetrieveCountryResponse countryCoverageRetrieveCountryResponse
    ) : base(countryCoverageRetrieveCountryResponse)
    {  }
    #pragma warning restore CS8618

    public CountryCoverageRetrieveCountryResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryCoverageRetrieveCountryResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CountryCoverageRetrieveCountryResponseFromRaw.FromRawUnchecked"/>
    public static CountryCoverageRetrieveCountryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CountryCoverageRetrieveCountryResponseFromRaw : IFromRawJson<CountryCoverageRetrieveCountryResponse>
{
    /// <inheritdoc/>
    public CountryCoverageRetrieveCountryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CountryCoverageRetrieveCountryResponse.FromRawUnchecked(rawData);
}