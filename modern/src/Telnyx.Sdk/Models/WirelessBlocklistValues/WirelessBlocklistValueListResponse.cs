using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WirelessBlocklistValues;

[JsonConverter(typeof(JsonModelConverter<WirelessBlocklistValueListResponse, WirelessBlocklistValueListResponseFromRaw>))]
public sealed record class WirelessBlocklistValueListResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public WirelessBlocklistValueListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistValueListResponse (
        WirelessBlocklistValueListResponse wirelessBlocklistValueListResponse
    ) : base(wirelessBlocklistValueListResponse)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistValueListResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistValueListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessBlocklistValueListResponseFromRaw.FromRawUnchecked"/>
    public static WirelessBlocklistValueListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WirelessBlocklistValueListResponse (Data data) : this()
    { this.Data = data; }
}

class WirelessBlocklistValueListResponseFromRaw : IFromRawJson<WirelessBlocklistValueListResponse>
{
    /// <inheritdoc/>
    public WirelessBlocklistValueListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessBlocklistValueListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Data (
        Generic::IReadOnlyList<WirelessCountry> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Data (
        Generic::IReadOnlyList<WirelessMcc> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Data (
        Generic::IReadOnlyList<WirelessPlmn> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Data (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>WirelessCountry</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCountry(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;WirelessCountry&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCountry(
        [NotNullWhen(true)] out Generic::IReadOnlyList<WirelessCountry>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<WirelessCountry> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>WirelessMcc</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMcc(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;WirelessMcc&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMcc(
        [NotNullWhen(true)] out Generic::IReadOnlyList<WirelessMcc>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<WirelessMcc> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>WirelessPlmn</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPlmn(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;WirelessPlmn&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPlmn(
        [NotNullWhen(true)] out Generic::IReadOnlyList<WirelessPlmn>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<WirelessPlmn> ;
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
///     (Generic::IReadOnlyList&lt;WirelessCountry&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;WirelessMcc&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;WirelessPlmn&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<WirelessCountry>> country,
        System::Action<Generic::IReadOnlyList<WirelessMcc>> mcc,
        System::Action<Generic::IReadOnlyList<WirelessPlmn>> plmn
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<WirelessCountry> value:
                country(value);
                break;
            case Generic::IReadOnlyList<WirelessMcc> value:
                mcc(value);
                break;
            case Generic::IReadOnlyList<WirelessPlmn> value:
                plmn(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Data");

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
///     (Generic::IReadOnlyList&lt;WirelessCountry&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;WirelessMcc&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;WirelessPlmn&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<WirelessCountry>, T> country,
        System::Func<Generic::IReadOnlyList<WirelessMcc>, T> mcc,
        System::Func<Generic::IReadOnlyList<WirelessPlmn>, T> plmn
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<WirelessCountry> value=>country(value),
            Generic::IReadOnlyList<WirelessMcc> value=>mcc(value),
            Generic::IReadOnlyList<WirelessPlmn> value=>plmn(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Data")
        } ;
    }

    public static implicit operator Data (
        Generic::List<WirelessCountry> value
    )=> new((Generic::IReadOnlyList<WirelessCountry>)value) ;

    public static implicit operator Data (
        Generic::List<WirelessMcc> value
    )=> new((Generic::IReadOnlyList<WirelessMcc>)value) ;

    public static implicit operator Data (
        Generic::List<WirelessPlmn> value
    )=> new((Generic::IReadOnlyList<WirelessPlmn>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch((country) => {foreach (var item in country)
        {
            item.Validate();
        }},
        (mcc) => {foreach (var item in mcc)
        {
            item.Validate();
        }},
        (plmn) => {foreach (var item in plmn)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(Data? other)
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
        {
            Generic::IReadOnlyList<WirelessCountry> _=>0,
            Generic::IReadOnlyList<WirelessMcc> _=>1,
            Generic::IReadOnlyList<WirelessPlmn> _=>2,
            _ =>-1
        } ;
    }
}sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<WirelessCountry>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<WirelessMcc>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<WirelessPlmn>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
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
        Utf8JsonWriter writer, Data value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<WirelessCountry, WirelessCountryFromRaw>))]
public sealed record class WirelessCountry : JsonModel
{
    /// <summary>
    /// ISO 3166-1 Alpha-2 Country Code.
    /// </summary>
    public required string CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.CountryCode; }

    public WirelessCountry ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessCountry (WirelessCountry wirelessCountry) : base(
        wirelessCountry
    )
    {  }
    #pragma warning restore CS8618

    public WirelessCountry (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessCountry (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessCountryFromRaw.FromRawUnchecked"/>
    public static WirelessCountry FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WirelessCountry (string countryCode) : this()
    { this.CountryCode = countryCode; }
}class WirelessCountryFromRaw : IFromRawJson<WirelessCountry>
{
    /// <inheritdoc/>
    public WirelessCountry FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessCountry.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WirelessMcc, WirelessMccFromRaw>))]
public sealed record class WirelessMcc : JsonModel
{
    /// <summary>
    /// Mobile Country Code.
    /// </summary>
    public required string Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "mcc"
            );
        }
        init { this._rawData.Set("mcc", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Mcc; }

    public WirelessMcc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessMcc (WirelessMcc wirelessMcc) : base(wirelessMcc)
    {  }
    #pragma warning restore CS8618

    public WirelessMcc (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessMcc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessMccFromRaw.FromRawUnchecked"/>
    public static WirelessMcc FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WirelessMcc (string mcc) : this()
    { this.Mcc = mcc; }
}class WirelessMccFromRaw : IFromRawJson<WirelessMcc>
{
    /// <inheritdoc/>
    public WirelessMcc FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessMcc.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WirelessPlmn, WirelessPlmnFromRaw>))]
public sealed record class WirelessPlmn : JsonModel
{
    /// <summary>
    /// Public land mobile network code (MCC + MNC).
    /// </summary>
    public required string Plmn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "plmn"
            );
        }
        init { this._rawData.Set("plmn", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Plmn; }

    public WirelessPlmn ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessPlmn (WirelessPlmn wirelessPlmn) : base(wirelessPlmn)
    {  }
    #pragma warning restore CS8618

    public WirelessPlmn (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessPlmn (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessPlmnFromRaw.FromRawUnchecked"/>
    public static WirelessPlmn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WirelessPlmn (string plmn) : this()
    { this.Plmn = plmn; }
}class WirelessPlmnFromRaw : IFromRawJson<WirelessPlmn>
{
    /// <inheritdoc/>
    public WirelessPlmn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessPlmn.FromRawUnchecked(rawData);
}