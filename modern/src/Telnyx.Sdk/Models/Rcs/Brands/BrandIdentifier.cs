using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(BrandIdentifierConverter))]
public record class BrandIdentifier : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement IdentifierType {
        get {
            return Match(ein: ( x )=>x.IdentifierType,
            stockSymbol: ( x )=>x.IdentifierType);
        }
    }

    public string ValueValue {
        get {
            return Match(ein: ( x )=>x.ValueValue, stockSymbol: ( x )=>x.Value);
        }
    }

    public BrandIdentifier (
        EinBrandIdentifier value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BrandIdentifier (
        StockSymbolBrandIdentifier value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BrandIdentifier (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EinBrandIdentifier"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEin(out var value)) {
///     // `value` is of type `EinBrandIdentifier`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEin([NotNullWhen(true)] out EinBrandIdentifier? value)
    {
        value =this.Value as EinBrandIdentifier ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="StockSymbolBrandIdentifier"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStockSymbol(out var value)) {
///     // `value` is of type `StockSymbolBrandIdentifier`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStockSymbol(
        [NotNullWhen(true)] out StockSymbolBrandIdentifier? value
    )
    {
        value =this.Value as StockSymbolBrandIdentifier ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (EinBrandIdentifier value) =&gt; {...},
///     (StockSymbolBrandIdentifier value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<EinBrandIdentifier> ein,
        System::Action<StockSymbolBrandIdentifier> stockSymbol
    )
    {
        switch (this.Value)
        {
            case EinBrandIdentifier value:
                ein(value);
                break;
            case StockSymbolBrandIdentifier value:
                stockSymbol(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of BrandIdentifier");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (EinBrandIdentifier value) =&gt; {...},
///     (StockSymbolBrandIdentifier value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<EinBrandIdentifier, T> ein,
        System::Func<StockSymbolBrandIdentifier, T> stockSymbol
    )
    {
        return this.Value switch
        {
            EinBrandIdentifier value=>ein(value),
            StockSymbolBrandIdentifier value=>stockSymbol(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of BrandIdentifier")
        } ;
    }

    public static implicit operator BrandIdentifier (
        EinBrandIdentifier value
    )=> new(value) ;

    public static implicit operator BrandIdentifier (
        StockSymbolBrandIdentifier value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of BrandIdentifier");
        }
        this.Switch((ein) => ein.Validate(),
        (stockSymbol) => stockSymbol.Validate());
    }

    public virtual bool Equals(BrandIdentifier? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { EinBrandIdentifier _=>0, StockSymbolBrandIdentifier _=>1, _ =>-1 } ;
    }
}

sealed class BrandIdentifierConverter : JsonConverter<BrandIdentifier>
{
    public override BrandIdentifier? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? identifierType;
        try {
            identifierType = element.GetProperty("identifier_type").GetString();
        } catch {
            identifierType = null;
        }

        switch (identifierType)
        {
            case "EIN":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EinBrandIdentifier>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "STOCK_SYMBOL":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<StockSymbolBrandIdentifier>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new BrandIdentifier(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandIdentifier value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}