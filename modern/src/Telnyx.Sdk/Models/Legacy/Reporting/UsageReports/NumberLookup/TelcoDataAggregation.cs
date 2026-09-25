using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

[JsonConverter(typeof(JsonModelConverter<TelcoDataAggregation, TelcoDataAggregationFromRaw>))]
public sealed record class TelcoDataAggregation : JsonModel
{
    /// <summary>
    /// Currency code
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

    /// <summary>
    /// Total cost for this aggregation
    /// </summary>
    public double? TotalCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "total_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_cost", value);
        }
    }

    /// <summary>
    /// Total number of lookups performed
    /// </summary>
    public long? TotalDips {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_dips"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_dips", value);
        }
    }

    /// <summary>
    /// Type of telco data lookup
    /// </summary>
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.TotalCost;
        _ = this.TotalDips;
        _ = this.Type;
    }

    public TelcoDataAggregation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelcoDataAggregation (
        TelcoDataAggregation telcoDataAggregation
    ) : base(telcoDataAggregation)
    {  }
    #pragma warning restore CS8618

    public TelcoDataAggregation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelcoDataAggregation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelcoDataAggregationFromRaw.FromRawUnchecked"/>
    public static TelcoDataAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelcoDataAggregationFromRaw : IFromRawJson<TelcoDataAggregation>
{
    /// <inheritdoc/>
    public TelcoDataAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelcoDataAggregation.FromRawUnchecked(rawData);
}