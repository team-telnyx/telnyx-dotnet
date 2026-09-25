using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// A default prompt string or an ordered list of qualified prompts.
/// </summary>
[JsonConverter(typeof(PayPromptValueConverter))]
public record class PayPromptValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public PayPromptValue (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PayPromptValue (
        Generic::IReadOnlyList<PayPrompt> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public PayPromptValue (JsonElement element)
    { this._element = element; }

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
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>PayPrompt</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;PayPrompt&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<PayPrompt>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<PayPrompt> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;PayPrompt&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<PayPrompt>> payPromptList
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<PayPrompt> value:
                payPromptList(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of PayPromptValue");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;PayPrompt&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<PayPrompt>, T> payPromptList
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<PayPrompt> value=>payPromptList(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of PayPromptValue")
        } ;
    }

    public static implicit operator PayPromptValue (string value)=> new(value) ;

    public static implicit operator PayPromptValue (
        Generic::List<PayPrompt> value
    )=> new((Generic::IReadOnlyList<PayPrompt>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of PayPromptValue");
        }
        this.Switch((_) => {},
        (payPromptList) => {foreach (var item in payPromptList)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(PayPromptValue? other)
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
        { string _=>0, Generic::IReadOnlyList<PayPrompt> _=>1, _ =>-1 } ;
    }
}

sealed class PayPromptValueConverter : JsonConverter<PayPromptValue>
{
    public override PayPromptValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<PayPrompt>>(element, options);
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
        PayPromptValue value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// A text-to-speech prompt with optional matching qualifiers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PayPrompt, PayPromptFromRaw>))]
public sealed record class PayPrompt : JsonModel
{
    /// <summary>
    /// Text spoken for the payment collection step.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Space-separated 1-based attempt numbers for which this prompt applies.
    /// </summary>
    public string? Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "attempt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempt", value);
        }
    }

    /// <summary>
    /// Lowercase, case-sensitive detected card type for which this prompt applies.
    /// </summary>
    public ApiEnum<string, CardType>? CardType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardType>>(
                "card_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("card_type", value);
        }
    }

    /// <summary>
    /// Step error for which this prompt applies.
    /// </summary>
    public ApiEnum<string, ErrorType>? ErrorType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ErrorType>>(
                "error_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Attempt;
        this.CardType?.Validate();
        this.ErrorType?.Validate();
    }

    public PayPrompt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayPrompt (PayPrompt payPrompt) : base(payPrompt)
    {  }
    #pragma warning restore CS8618

    public PayPrompt (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PayPrompt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayPromptFromRaw.FromRawUnchecked"/>
    public static PayPrompt FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PayPrompt (string text) : this()
    { this.Text = text; }
}class PayPromptFromRaw : IFromRawJson<PayPrompt>
{
    /// <inheritdoc/>
    public PayPrompt FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PayPrompt.FromRawUnchecked(rawData);
}/// <summary>
/// Lowercase, case-sensitive detected card type for which this prompt applies.
/// </summary>
[JsonConverter(typeof(CardTypeConverter))]
public enum CardType
{
    Visa, Mastercard, Amex, Optima, Discover, DinersClub, Jcb, Maestro, Enroute
}sealed class CardTypeConverter : JsonConverter<CardType>
{
    public override CardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa"=>CardType.Visa,
            "mastercard"=>CardType.Mastercard,
            "amex"=>CardType.Amex,
            "optima"=>CardType.Optima,
            "discover"=>CardType.Discover,
            "diners-club"=>CardType.DinersClub,
            "jcb"=>CardType.Jcb,
            "maestro"=>CardType.Maestro,
            "enroute"=>CardType.Enroute,
            _ =>(CardType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CardType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CardType.Visa=>"visa",
            CardType.Mastercard=>"mastercard",
            CardType.Amex=>"amex",
            CardType.Optima=>"optima",
            CardType.Discover=>"discover",
            CardType.DinersClub=>"diners-club",
            CardType.Jcb=>"jcb",
            CardType.Maestro=>"maestro",
            CardType.Enroute=>"enroute",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Step error for which this prompt applies.
/// </summary>
[JsonConverter(typeof(ErrorTypeConverter))]
public enum ErrorType
{
    Timeout,
    InvalidCardNumber,
    InvalidCardType,
    InvalidDate,
    InvalidSecurityCode,
    InvalidPostalCode,
    InvalidBankRoutingNumber,
    InvalidBankAccountNumber,
    InputMatchingFailed
}sealed class ErrorTypeConverter : JsonConverter<ErrorType>
{
    public override ErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "timeout"=>ErrorType.Timeout,
            "invalid-card-number"=>ErrorType.InvalidCardNumber,
            "invalid-card-type"=>ErrorType.InvalidCardType,
            "invalid-date"=>ErrorType.InvalidDate,
            "invalid-security-code"=>ErrorType.InvalidSecurityCode,
            "invalid-postal-code"=>ErrorType.InvalidPostalCode,
            "invalid-bank-routing-number"=>ErrorType.InvalidBankRoutingNumber,
            "invalid-bank-account-number"=>ErrorType.InvalidBankAccountNumber,
            "input-matching-failed"=>ErrorType.InputMatchingFailed,
            _ =>(ErrorType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ErrorType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ErrorType.Timeout=>"timeout",
            ErrorType.InvalidCardNumber=>"invalid-card-number",
            ErrorType.InvalidCardType=>"invalid-card-type",
            ErrorType.InvalidDate=>"invalid-date",
            ErrorType.InvalidSecurityCode=>"invalid-security-code",
            ErrorType.InvalidPostalCode=>"invalid-postal-code",
            ErrorType.InvalidBankRoutingNumber=>"invalid-bank-routing-number",
            ErrorType.InvalidBankAccountNumber=>"invalid-bank-account-number",
            ErrorType.InputMatchingFailed=>"input-matching-failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}