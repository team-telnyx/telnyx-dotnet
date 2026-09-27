using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ChargesSummary;

[JsonConverter(typeof(JsonModelConverter<MonthDetail, MonthDetailFromRaw>))]
public sealed record class MonthDetail : JsonModel
{
    /// <summary>
    /// Monthly recurring charge amount as decimal string
    /// </summary>
    public required string Mrc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "mrc"
            );
        }
        init { this._rawData.Set("mrc", value); }
    }

    /// <summary>
    /// Number of items
    /// </summary>
    public required long Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "quantity"
            );
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// One-time charge amount as decimal string
    /// </summary>
    public string? Otc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "otc"
            );
        }
        init { this._rawData.Set("otc", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mrc;
        _ = this.Quantity;
        _ = this.Otc;
    }

    public MonthDetail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonthDetail (MonthDetail monthDetail) : base(monthDetail)
    {  }
    #pragma warning restore CS8618

    public MonthDetail (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MonthDetail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MonthDetailFromRaw.FromRawUnchecked"/>
    public static MonthDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MonthDetailFromRaw : IFromRawJson<MonthDetail>
{
    /// <inheritdoc/>
    public MonthDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MonthDetail.FromRawUnchecked(rawData);
}