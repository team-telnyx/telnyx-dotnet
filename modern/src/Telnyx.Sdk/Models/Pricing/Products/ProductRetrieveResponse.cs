using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Pricing.Products;

/// <summary>
/// A single pricing entry. Standard products include rate, unit, currency, type,
/// country_iso, direction, and tiers. Inference products include model, input_rate,
/// output_rate, cached_input_rate, and their respective tier arrays. Rate-deck products
/// include pricing_type and note fields with null rate and empty tiers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProductRetrieveResponse, ProductRetrieveResponseFromRaw>))]
public sealed record class ProductRetrieveResponse : JsonModel
{
    /// <summary>
    /// Cached input token rate. Present only on inference product entries.
    /// </summary>
    public string? CachedInputRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cached_input_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cached_input_rate", value);
        }
    }

    /// <summary>
    /// Cached input token tiered pricing. Present only on inference product entries.
    /// </summary>
    public IReadOnlyList<PricingTier>? CachedInputTiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingTier>>(
                "cached_input_tiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingTier>?>(
                "cached_input_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO country code. Null for non-geographic products.
    /// </summary>
    public string? CountryIso {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_iso"
            );
        }
        init { this._rawData.Set("country_iso", value); }
    }

    /// <summary>
    /// ISO currency code (e.g., USD).
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
    /// Direction (e.g., termination). Null for non-directional products.
    /// </summary>
    public string? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "direction"
            );
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// Input token rate. Present only on inference product entries.
    /// </summary>
    public string? InputRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "input_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("input_rate", value);
        }
    }

    /// <summary>
    /// Input token tiered pricing. Present only on inference product entries.
    /// </summary>
    public IReadOnlyList<PricingTier>? InputTiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingTier>>(
                "input_tiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingTier>?>(
                "input_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Model identifier. Present only on inference product entries.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Human-readable name describing the pricing entry.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Additional note for rate-deck products (e.g., "Pricing is determined by the
    /// WhatsApp rate deck.").
    /// </summary>
    public string? Note {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "note"
            );
        }
        init { this._rawData.Set("note", value); }
    }

    /// <summary>
    /// Output token rate. Present only on inference product entries.
    /// </summary>
    public string? OutputRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "output_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("output_rate", value);
        }
    }

    /// <summary>
    /// Output token tiered pricing. Present only on inference product entries.
    /// </summary>
    public IReadOnlyList<PricingTier>? OutputTiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingTier>>(
                "output_tiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingTier>?>(
                "output_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pricing type for non-standard products (e.g., rate_deck). Absent on standard products.
    /// </summary>
    public string? PricingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pricing_type"
            );
        }
        init { this._rawData.Set("pricing_type", value); }
    }

    /// <summary>
    /// Per-unit rate. Numeric for standard products, string for inference products.
    /// Null for rate-deck products.
    /// </summary>
    public ProductRetrieveResponseRate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductRetrieveResponseRate>(
                "rate"
            );
        }
        init { this._rawData.Set("rate", value); }
    }

    /// <summary>
    /// Volume-based tiered pricing. Empty for rate-deck products.
    /// </summary>
    public IReadOnlyList<PricingTier>? Tiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingTier>>(
                "tiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pricing type (e.g., usage).
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

    /// <summary>
    /// Unit of measurement (e.g., part, message, GB, per_1k_tokens).
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CachedInputRate;
        foreach (var item in this.CachedInputTiers ?? [])
        {
            item.Validate();
        }
        _ = this.CountryIso;
        _ = this.Currency;
        _ = this.Direction;
        _ = this.InputRate;
        foreach (var item in this.InputTiers ?? [])
        {
            item.Validate();
        }
        _ = this.Model;
        _ = this.Name;
        _ = this.Note;
        _ = this.OutputRate;
        foreach (var item in this.OutputTiers ?? [])
        {
            item.Validate();
        }
        _ = this.PricingType;
        this.Rate?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
        _ = this.Type;
        _ = this.Unit;
    }

    public ProductRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductRetrieveResponse (
        ProductRetrieveResponse productRetrieveResponse
    ) : base(productRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ProductRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProductRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProductRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProductRetrieveResponseFromRaw : IFromRawJson<ProductRetrieveResponse>
{
    /// <inheritdoc/>
    public ProductRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProductRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-unit rate. Numeric for standard products, string for inference products.
/// Null for rate-deck products.
/// </summary>
[JsonConverter(typeof(ProductRetrieveResponseRateConverter))]
public record class ProductRetrieveResponseRate : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ProductRetrieveResponseRate (
        double value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductRetrieveResponseRate (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductRetrieveResponseRate (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of ProductRetrieveResponseRate");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ProductRetrieveResponseRate")
        } ;
    }

    public static implicit operator ProductRetrieveResponseRate (
        double value
    )=> new(value) ;

    public static implicit operator ProductRetrieveResponseRate (
        string value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ProductRetrieveResponseRate");
        }
    }

    public virtual bool Equals(ProductRetrieveResponseRate? other)
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
}sealed class ProductRetrieveResponseRateConverter : JsonConverter<ProductRetrieveResponseRate?>
{
    public override ProductRetrieveResponseRate? Read(
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
        Utf8JsonWriter writer,
        ProductRetrieveResponseRate? value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}