using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<CostInformation, CostInformationFromRaw>))]
public sealed record class CostInformation : JsonModel
{
    /// <summary>
    /// The ISO 4217 code for the currency.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    public string? MonthlyCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "monthly_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("monthly_cost", value);
        }
    }

    public string? UpfrontCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "upfront_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("upfront_cost", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.MonthlyCost;
        _ = this.UpfrontCost;
    }

    public CostInformation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostInformation (CostInformation costInformation) : base(
        costInformation
    )
    {  }
    #pragma warning restore CS8618

    public CostInformation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CostInformation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostInformationFromRaw.FromRawUnchecked"/>
    public static CostInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CostInformationFromRaw : IFromRawJson<CostInformation>
{
    /// <inheritdoc/>
    public CostInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CostInformation.FromRawUnchecked(rawData);
}