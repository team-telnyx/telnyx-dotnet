using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardOrderPreview;

[JsonConverter(typeof(JsonModelConverter<SimCardOrderPreviewPreviewResponse, SimCardOrderPreviewPreviewResponseFromRaw>))]
public sealed record class SimCardOrderPreviewPreviewResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public SimCardOrderPreviewPreviewResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardOrderPreviewPreviewResponse (
        SimCardOrderPreviewPreviewResponse simCardOrderPreviewPreviewResponse
    ) : base(simCardOrderPreviewPreviewResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardOrderPreviewPreviewResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardOrderPreviewPreviewResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardOrderPreviewPreviewResponseFromRaw.FromRawUnchecked"/>
    public static SimCardOrderPreviewPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardOrderPreviewPreviewResponseFromRaw : IFromRawJson<SimCardOrderPreviewPreviewResponse>
{
    /// <inheritdoc/>
    public SimCardOrderPreviewPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardOrderPreviewPreviewResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The amount of SIM cards requested in the SIM card order.
    /// </summary>
    public long? Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "quantity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public ShippingCost? ShippingCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShippingCost>(
                "shipping_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shipping_cost", value);
        }
    }

    public SimCardsCost? SimCardsCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardsCost>(
                "sim_cards_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_cards_cost", value);
        }
    }

    public TotalCost? TotalCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TotalCost>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.RecordType;
        this.ShippingCost?.Validate();
        this.SimCardsCost?.Validate();
        this.TotalCost?.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ShippingCost, ShippingCostFromRaw>))]
public sealed record class ShippingCost : JsonModel
{
    /// <summary>
    /// A string representing the cost amount.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// ISO 4217 currency string.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public ShippingCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShippingCost (ShippingCost shippingCost) : base(shippingCost)
    {  }
    #pragma warning restore CS8618

    public ShippingCost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ShippingCost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ShippingCostFromRaw.FromRawUnchecked"/>
    public static ShippingCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ShippingCostFromRaw : IFromRawJson<ShippingCost>
{
    /// <inheritdoc/>
    public ShippingCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ShippingCost.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SimCardsCost, SimCardsCostFromRaw>))]
public sealed record class SimCardsCost : JsonModel
{
    /// <summary>
    /// A string representing the cost amount.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// ISO 4217 currency string.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public SimCardsCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardsCost (SimCardsCost simCardsCost) : base(simCardsCost)
    {  }
    #pragma warning restore CS8618

    public SimCardsCost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardsCost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardsCostFromRaw.FromRawUnchecked"/>
    public static SimCardsCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardsCostFromRaw : IFromRawJson<SimCardsCost>
{
    /// <inheritdoc/>
    public SimCardsCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardsCost.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<TotalCost, TotalCostFromRaw>))]
public sealed record class TotalCost : JsonModel
{
    /// <summary>
    /// A string representing the cost amount.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// ISO 4217 currency string.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public TotalCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TotalCost (TotalCost totalCost) : base(totalCost)
    {  }
    #pragma warning restore CS8618

    public TotalCost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TotalCost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TotalCostFromRaw.FromRawUnchecked"/>
    public static TotalCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TotalCostFromRaw : IFromRawJson<TotalCost>
{
    /// <inheritdoc/>
    public TotalCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TotalCost.FromRawUnchecked(rawData);
}