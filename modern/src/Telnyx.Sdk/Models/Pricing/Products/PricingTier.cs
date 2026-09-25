using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Pricing.Products;

[JsonConverter(typeof(JsonModelConverter<PricingTier, PricingTierFromRaw>))]
public sealed record class PricingTier : JsonModel
{
    /// <summary>
    /// Upper bound of the tier (exclusive). Null means no upper limit.
    /// </summary>
    public required long? Max {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max"
            );
        }
        init { this._rawData.Set("max", value); }
    }

    /// <summary>
    /// Lower bound of the tier (inclusive).
    /// </summary>
    public required long Min {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "min"
            );
        }
        init { this._rawData.Set("min", value); }
    }

    /// <summary>
    /// Rate for this tier. Numeric for standard products, string for inference products.
    /// </summary>
    public required Rate Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Rate>(
                "rate"
            );
        }
        init { this._rawData.Set("rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Max;
        _ = this.Min;
        this.Rate.Validate();
    }

    public PricingTier ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingTier (PricingTier pricingTier) : base(pricingTier)
    {  }
    #pragma warning restore CS8618

    public PricingTier (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingTier (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PricingTierFromRaw.FromRawUnchecked"/>
    public static PricingTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PricingTierFromRaw : IFromRawJson<PricingTier>
{
    /// <inheritdoc/>
    public PricingTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PricingTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Rate for this tier. Numeric for standard products, string for inference products.
/// </summary>
[JsonConverter(typeof(RateConverter))]
public record class Rate : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Rate (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rate (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rate (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
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
///     (double value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<double> @double, System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Rate");

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
///     (double value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<double, T> @double, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            double value=>@double(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Rate")
        } ;
    }

    public static implicit operator Rate (double value)=> new(value) ;

    public static implicit operator Rate (string value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Rate");
        }
    }

    public virtual bool Equals(Rate? other)
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
        { double _=>0, string _=>1, _ =>-1 } ;
    }
}sealed class RateConverter : JsonConverter<Rate>
{
    public override Rate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Rate value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}