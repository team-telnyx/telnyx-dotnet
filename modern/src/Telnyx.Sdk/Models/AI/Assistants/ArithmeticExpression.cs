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
/// Numeric expression: applies an arithmetic operator to two sub-expressions.
///
/// <para>Useful for derived numeric checks, e.g. `cart_total + shipping &gt; 50`.
/// Both operands should resolve to numbers at runtime.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ArithmeticExpression, ArithmeticExpressionFromRaw>))]
public sealed record class ArithmeticExpression : JsonModel
{
    /// <summary>
    /// Operand sub-expression (Expression AST node). Typed as free-form JSON to
    /// support arbitrary recursion depth without an uncompilable by-value self-reference;
    /// see the Expression schema for the variant structure.
    /// </summary>
    public required JsonElement Left {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotAbsentElement(
                "left"
            );
        }
        init { this._rawData.Set("left", value); }
    }

    /// <summary>
    /// Arithmetic operator applied to `left` and `right`.
    /// </summary>
    public required ApiEnum<string, Op> Op {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Op>>(
                "op"
            );
        }
        init { this._rawData.Set("op", value); }
    }

    /// <summary>
    /// Operand sub-expression (Expression AST node). Typed as free-form JSON to
    /// support arbitrary recursion depth without an uncompilable by-value self-reference;
    /// see the Expression schema for the variant structure.
    /// </summary>
    public required JsonElement Right {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotAbsentElement(
                "right"
            );
        }
        init { this._rawData.Set("right", value); }
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
        _ = this.Left;
        this.Op.Validate();
        _ = this.Right;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("arithmetic")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public ArithmeticExpression ()
    { this.Type = JsonSerializer.SerializeToElement("arithmetic"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArithmeticExpression (
        ArithmeticExpression arithmeticExpression
    ) : base(arithmeticExpression)
    {  }
    #pragma warning restore CS8618

    public ArithmeticExpression (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("arithmetic");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArithmeticExpression (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArithmeticExpressionFromRaw.FromRawUnchecked"/>
    public static ArithmeticExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ArithmeticExpressionFromRaw : IFromRawJson<ArithmeticExpression>
{
    /// <inheritdoc/>
    public ArithmeticExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArithmeticExpression.FromRawUnchecked(rawData);
}

/// <summary>
/// Arithmetic operator applied to `left` and `right`.
/// </summary>
[JsonConverter(typeof(OpConverter))]
public enum Op
{
    Plus, Minus, Multiply, Divide, Modulo
}sealed class OpConverter : JsonConverter<Op>
{
    public override Op Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+"=>Op.Plus,
            "-"=>Op.Minus,
            "*"=>Op.Multiply,
            "/"=>Op.Divide,
            "%"=>Op.Modulo,
            _ =>(Op)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Op value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Op.Plus=>"+",
            Op.Minus=>"-",
            Op.Multiply=>"*",
            Op.Divide=>"/",
            Op.Modulo=>"%",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}