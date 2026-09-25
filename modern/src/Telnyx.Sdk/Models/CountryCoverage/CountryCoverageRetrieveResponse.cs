using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CountryCoverage;

[JsonConverter(typeof(JsonModelConverter<CountryCoverageRetrieveResponse, CountryCoverageRetrieveResponseFromRaw>))]
public sealed record class CountryCoverageRetrieveResponse : JsonModel
{
    public IReadOnlyDictionary<string, CountryCoverageCountryCoverage>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, CountryCoverageCountryCoverage>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, CountryCoverageCountryCoverage>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                item.Validate();
            }
        }
    }

    public CountryCoverageRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryCoverageRetrieveResponse (
        CountryCoverageRetrieveResponse countryCoverageRetrieveResponse
    ) : base(countryCoverageRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CountryCoverageRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryCoverageRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CountryCoverageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CountryCoverageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CountryCoverageRetrieveResponseFromRaw : IFromRawJson<CountryCoverageRetrieveResponse>
{
    /// <inheritdoc/>
    public CountryCoverageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CountryCoverageRetrieveResponse.FromRawUnchecked(rawData);
}