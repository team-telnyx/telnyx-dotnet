using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// A node in a deterministic expression AST. Exactly one variant is selected by the
/// `type` discriminator. Terminal variants (`number_literal`, `string_literal`,
/// `bool_literal`, `variable`) bottom out the recursion; `arithmetic`, `bool_op`,
/// and `comparison` nest further sub-expressions.
///
/// <para>Extracted into a single named schema so the recursive union is defined
/// once (was previously inlined at every operand site).</para>
/// </summary>
[JsonConverter(typeof(ExpressionConverter))]
public record class Expression : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement? Left {
        get {
            return Match<JsonElement?>(comparison: ( x )=>x.Left,
            booleanOp: ( _ )=>null,
            arithmetic: ( x )=>x.Left,
            variable: ( _ )=>null,
            stringLiteral: ( _ )=>null,
            numberLiteral: ( _ )=>null,
            boolLiteral: ( _ )=>null);
        }
    }

    public JsonElement? Right {
        get {
            return Match<JsonElement?>(comparison: ( x )=>x.Right,
            booleanOp: ( _ )=>null,
            arithmetic: ( x )=>x.Right,
            variable: ( _ )=>null,
            stringLiteral: ( _ )=>null,
            numberLiteral: ( _ )=>null,
            boolLiteral: ( _ )=>null);
        }
    }

    public JsonElement Type {
        get {
            return Match(comparison: ( x )=>x.Type,
            booleanOp: ( x )=>x.Type,
            arithmetic: ( x )=>x.Type,
            variable: ( x )=>x.Type,
            stringLiteral: ( x )=>x.Type,
            numberLiteral: ( x )=>x.Type,
            boolLiteral: ( x )=>x.Type);
        }
    }

    public Expression (ComparisonExpression value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (BooleanOpExpression value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (ArithmeticExpression value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (Variable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (StringLiteral value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (NumberLiteral value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (BoolLiteral value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Expression (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ComparisonExpression"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickComparison(out var value)) {
///     // `value` is of type `ComparisonExpression`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickComparison(
        [NotNullWhen(true)] out ComparisonExpression? value
    )
    {
        value =this.Value as ComparisonExpression ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="BooleanOpExpression"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBooleanOp(out var value)) {
///     // `value` is of type `BooleanOpExpression`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBooleanOp(
        [NotNullWhen(true)] out BooleanOpExpression? value
    )
    {
        value =this.Value as BooleanOpExpression ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ArithmeticExpression"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickArithmetic(out var value)) {
///     // `value` is of type `ArithmeticExpression`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickArithmetic(
        [NotNullWhen(true)] out ArithmeticExpression? value
    )
    {
        value =this.Value as ArithmeticExpression ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Variable"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickVariable(out var value)) {
///     // `value` is of type `Variable`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickVariable([NotNullWhen(true)] out Variable? value)
    {
        value =this.Value as Variable ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="StringLiteral"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStringLiteral(out var value)) {
///     // `value` is of type `StringLiteral`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStringLiteral(
        [NotNullWhen(true)] out StringLiteral? value
    )
    {
        value =this.Value as StringLiteral ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="NumberLiteral"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNumberLiteral(out var value)) {
///     // `value` is of type `NumberLiteral`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNumberLiteral(
        [NotNullWhen(true)] out NumberLiteral? value
    )
    {
        value =this.Value as NumberLiteral ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="BoolLiteral"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBoolLiteral(out var value)) {
///     // `value` is of type `BoolLiteral`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBoolLiteral([NotNullWhen(true)] out BoolLiteral? value)
    {
        value =this.Value as BoolLiteral ;
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
///     (ComparisonExpression value) =&gt; {...},
///     (BooleanOpExpression value) =&gt; {...},
///     (ArithmeticExpression value) =&gt; {...},
///     (Variable value) =&gt; {...},
///     (StringLiteral value) =&gt; {...},
///     (NumberLiteral value) =&gt; {...},
///     (BoolLiteral value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ComparisonExpression> comparison,
        System::Action<BooleanOpExpression> booleanOp,
        System::Action<ArithmeticExpression> arithmetic,
        System::Action<Variable> variable,
        System::Action<StringLiteral> stringLiteral,
        System::Action<NumberLiteral> numberLiteral,
        System::Action<BoolLiteral> boolLiteral
    )
    {
        switch (this.Value)
        {
            case ComparisonExpression value:
                comparison(value);
                break;
            case BooleanOpExpression value:
                booleanOp(value);
                break;
            case ArithmeticExpression value:
                arithmetic(value);
                break;
            case Variable value:
                variable(value);
                break;
            case StringLiteral value:
                stringLiteral(value);
                break;
            case NumberLiteral value:
                numberLiteral(value);
                break;
            case BoolLiteral value:
                boolLiteral(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Expression");

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
///     (ComparisonExpression value) =&gt; {...},
///     (BooleanOpExpression value) =&gt; {...},
///     (ArithmeticExpression value) =&gt; {...},
///     (Variable value) =&gt; {...},
///     (StringLiteral value) =&gt; {...},
///     (NumberLiteral value) =&gt; {...},
///     (BoolLiteral value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ComparisonExpression, T> comparison,
        System::Func<BooleanOpExpression, T> booleanOp,
        System::Func<ArithmeticExpression, T> arithmetic,
        System::Func<Variable, T> variable,
        System::Func<StringLiteral, T> stringLiteral,
        System::Func<NumberLiteral, T> numberLiteral,
        System::Func<BoolLiteral, T> boolLiteral
    )
    {
        return this.Value switch
        {
            ComparisonExpression value=>comparison(value),
            BooleanOpExpression value=>booleanOp(value),
            ArithmeticExpression value=>arithmetic(value),
            Variable value=>variable(value),
            StringLiteral value=>stringLiteral(value),
            NumberLiteral value=>numberLiteral(value),
            BoolLiteral value=>boolLiteral(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Expression")
        } ;
    }

    public static implicit operator Expression (
        ComparisonExpression value
    )=> new(value) ;

    public static implicit operator Expression (
        BooleanOpExpression value
    )=> new(value) ;

    public static implicit operator Expression (
        ArithmeticExpression value
    )=> new(value) ;

    public static implicit operator Expression (Variable value)=> new(value) ;

    public static implicit operator Expression (
        StringLiteral value
    )=> new(value) ;

    public static implicit operator Expression (
        NumberLiteral value
    )=> new(value) ;

    public static implicit operator Expression (
        BoolLiteral value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Expression");
        }
        this.Switch((comparison) => comparison.Validate(),
        (booleanOp) => booleanOp.Validate(),
        (arithmetic) => arithmetic.Validate(),
        (variable) => variable.Validate(),
        (stringLiteral) => stringLiteral.Validate(),
        (numberLiteral) => numberLiteral.Validate(),
        (boolLiteral) => boolLiteral.Validate());
    }

    public virtual bool Equals(Expression? other)
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
            ComparisonExpression _=>0,
            BooleanOpExpression _=>1,
            ArithmeticExpression _=>2,
            Variable _=>3,
            StringLiteral _=>4,
            NumberLiteral _=>5,
            BoolLiteral _=>6,
            _ =>-1
        } ;
    }
}

sealed class ExpressionConverter : JsonConverter<Expression>
{
    public override Expression? Read(
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
            case "comparison":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ComparisonExpression>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "bool_op":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BooleanOpExpression>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "arithmetic":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ArithmeticExpression>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "variable":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Variable>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "string_literal":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<StringLiteral>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "number_literal":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NumberLiteral>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "bool_literal":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BoolLiteral>(element, options);
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
                { return new Expression(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Expression value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Reference a dynamic variable by name.
///
/// <para>Resolved at runtime from the assistant's dynamic-variables context (see
/// `Assistant.dynamic_variables` and the dynamic-variables webhook).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Variable, VariableFromRaw>))]
public sealed record class Variable : JsonModel
{
    /// <summary>
    /// Variable name to look up in the runtime context.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("variable")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Variable ()
    { this.Type = JsonSerializer.SerializeToElement("variable"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Variable (Variable variable) : base(variable)
    {  }
    #pragma warning restore CS8618

    public Variable (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("variable");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Variable (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VariableFromRaw.FromRawUnchecked"/>
    public static Variable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Variable (string name) : this()
    { this.Name = name; }
}class VariableFromRaw : IFromRawJson<Variable>
{
    /// <inheritdoc/>
    public Variable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Variable.FromRawUnchecked(rawData);
}/// <summary>
/// Constant string value.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StringLiteral, StringLiteralFromRaw>))]
public sealed record class StringLiteral : JsonModel
{
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Literal string value.
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
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("string_literal")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public StringLiteral ()
    { this.Type = JsonSerializer.SerializeToElement("string_literal"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StringLiteral (StringLiteral stringLiteral) : base(stringLiteral)
    {  }
    #pragma warning restore CS8618

    public StringLiteral (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("string_literal");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StringLiteral (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StringLiteralFromRaw.FromRawUnchecked"/>
    public static StringLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public StringLiteral (string value) : this()
    { this.Value = value; }
}class StringLiteralFromRaw : IFromRawJson<StringLiteral>
{
    /// <inheritdoc/>
    public StringLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StringLiteral.FromRawUnchecked(rawData);
}/// <summary>
/// Constant numeric value (float; integers are accepted and stored as float).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumberLiteral, NumberLiteralFromRaw>))]
public sealed record class NumberLiteral : JsonModel
{
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Literal numeric value.
    /// </summary>
    public required double Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("number_literal")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public NumberLiteral ()
    { this.Type = JsonSerializer.SerializeToElement("number_literal"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLiteral (NumberLiteral numberLiteral) : base(numberLiteral)
    {  }
    #pragma warning restore CS8618

    public NumberLiteral (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("number_literal");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLiteral (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberLiteralFromRaw.FromRawUnchecked"/>
    public static NumberLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NumberLiteral (double value) : this()
    { this.Value = value; }
}class NumberLiteralFromRaw : IFromRawJson<NumberLiteral>
{
    /// <inheritdoc/>
    public NumberLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberLiteral.FromRawUnchecked(rawData);
}/// <summary>
/// Constant boolean value. Useful for unconditional ('always') edges.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BoolLiteral, BoolLiteralFromRaw>))]
public sealed record class BoolLiteral : JsonModel
{
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Literal boolean value.
    /// </summary>
    public required bool Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("bool_literal")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BoolLiteral ()
    { this.Type = JsonSerializer.SerializeToElement("bool_literal"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BoolLiteral (BoolLiteral boolLiteral) : base(boolLiteral)
    {  }
    #pragma warning restore CS8618

    public BoolLiteral (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bool_literal");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BoolLiteral (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BoolLiteralFromRaw.FromRawUnchecked"/>
    public static BoolLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BoolLiteral (bool value) : this()
    { this.Value = value; }
}class BoolLiteralFromRaw : IFromRawJson<BoolLiteral>
{
    /// <inheritdoc/>
    public BoolLiteral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BoolLiteral.FromRawUnchecked(rawData);
}