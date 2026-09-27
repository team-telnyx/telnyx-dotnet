using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(JsonModelConverter<StockSymbolBrandIdentifier, StockSymbolBrandIdentifierFromRaw>))]
public sealed record class StockSymbolBrandIdentifier : JsonModel
{
    public JsonElement IdentifierType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "identifier_type"
            );
        }
        init { this._rawData.Set("identifier_type", value); }
    }

    /// <summary>
    /// A stock symbol using EXCHANGE:SYMBOL.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.IdentifierType, JsonSerializer.SerializeToElement("STOCK_SYMBOL")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public StockSymbolBrandIdentifier ()
    { this.IdentifierType = JsonSerializer.SerializeToElement("STOCK_SYMBOL"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StockSymbolBrandIdentifier (
        StockSymbolBrandIdentifier stockSymbolBrandIdentifier
    ) : base(stockSymbolBrandIdentifier)
    {  }
    #pragma warning restore CS8618

    public StockSymbolBrandIdentifier (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.IdentifierType = JsonSerializer.SerializeToElement("STOCK_SYMBOL");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StockSymbolBrandIdentifier (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StockSymbolBrandIdentifierFromRaw.FromRawUnchecked"/>
    public static StockSymbolBrandIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public StockSymbolBrandIdentifier (string value) : this()
    { this.Value = value; }
}

class StockSymbolBrandIdentifierFromRaw : IFromRawJson<StockSymbolBrandIdentifier>
{
    /// <inheritdoc/>
    public StockSymbolBrandIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StockSymbolBrandIdentifier.FromRawUnchecked(rawData);
}