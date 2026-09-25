using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PronunciationDicts;

/// <summary>
/// A single pronunciation dictionary item. Use type 'alias' to replace matched text
/// with a spoken alias, or type 'phoneme' to specify exact pronunciation using IPA notation.
/// </summary>
[JsonConverter(typeof(PronunciationDictItemConverter))]
public record class PronunciationDictItem : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string Text {
        get { return Match(alias: ( x )=>x.Text, phoneme: ( x )=>x.Text); }
    }

    public PronunciationDictItem (
        PronunciationDictAliasItem value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PronunciationDictItem (
        PronunciationDictPhonemeItem value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PronunciationDictItem (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PronunciationDictAliasItem"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAlias(out var value)) {
///     // `value` is of type `PronunciationDictAliasItem`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAlias(
        [NotNullWhen(true)] out PronunciationDictAliasItem? value
    )
    {
        value =this.Value as PronunciationDictAliasItem ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PronunciationDictPhonemeItem"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPhoneme(out var value)) {
///     // `value` is of type `PronunciationDictPhonemeItem`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPhoneme(
        [NotNullWhen(true)] out PronunciationDictPhonemeItem? value
    )
    {
        value =this.Value as PronunciationDictPhonemeItem ;
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
///     (PronunciationDictAliasItem value) =&gt; {...},
///     (PronunciationDictPhonemeItem value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<PronunciationDictAliasItem> alias,
        System::Action<PronunciationDictPhonemeItem> phoneme
    )
    {
        switch (this.Value)
        {
            case PronunciationDictAliasItem value:
                alias(value);
                break;
            case PronunciationDictPhonemeItem value:
                phoneme(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of PronunciationDictItem");

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
///     (PronunciationDictAliasItem value) =&gt; {...},
///     (PronunciationDictPhonemeItem value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<PronunciationDictAliasItem, T> alias,
        System::Func<PronunciationDictPhonemeItem, T> phoneme
    )
    {
        return this.Value switch
        {
            PronunciationDictAliasItem value=>alias(value),
            PronunciationDictPhonemeItem value=>phoneme(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of PronunciationDictItem")
        } ;
    }

    public static implicit operator PronunciationDictItem (
        PronunciationDictAliasItem value
    )=> new(value) ;

    public static implicit operator PronunciationDictItem (
        PronunciationDictPhonemeItem value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of PronunciationDictItem");
        }
        this.Switch((alias) => alias.Validate(),
        (phoneme) => phoneme.Validate());
    }

    public virtual bool Equals(PronunciationDictItem? other)
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
            PronunciationDictAliasItem _=>0,
            PronunciationDictPhonemeItem _=>1,
            _ =>-1
        } ;
    }
}

sealed class PronunciationDictItemConverter : JsonConverter<PronunciationDictItem>
{
    public override PronunciationDictItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "alias":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PronunciationDictAliasItem>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "phoneme":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PronunciationDictPhonemeItem>(element, options);
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
                { return new PronunciationDictItem(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PronunciationDictItem value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}