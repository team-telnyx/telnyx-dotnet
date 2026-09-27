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
/// Compare two sub-expressions with a relational or membership operator.
///
/// <para>Evaluates to a boolean. Used in edge conditions to gate transitions on
/// runtime values, e.g. `user_age &gt;= 18` or `tier == "gold"`.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonExpression, ComparisonExpressionFromRaw>))]
public sealed record class ComparisonExpression : JsonModel
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
    /// Relational/membership operator. `contains` / `not_contains` apply to strings
    /// (substring) and arrays (membership).
    /// </summary>
    public required ApiEnum<string, ComparisonExpressionOp> Op {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ComparisonExpressionOp>>(
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
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("comparison")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public ComparisonExpression ()
    { this.Type = JsonSerializer.SerializeToElement("comparison"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonExpression (
        ComparisonExpression comparisonExpression
    ) : base(comparisonExpression)
    {  }
    #pragma warning restore CS8618

    public ComparisonExpression (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("comparison");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonExpression (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonExpressionFromRaw.FromRawUnchecked"/>
    public static ComparisonExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ComparisonExpressionFromRaw : IFromRawJson<ComparisonExpression>
{
    /// <inheritdoc/>
    public ComparisonExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ComparisonExpression.FromRawUnchecked(rawData);
}

/// <summary>
/// Relational/membership operator. `contains` / `not_contains` apply to strings
/// (substring) and arrays (membership).
/// </summary>
[JsonConverter(typeof(ComparisonExpressionOpConverter))]
public enum ComparisonExpressionOp
{
    Eq, Ne, Lt, Lte, Gt, Gte, Contains, NotContains
}sealed class ComparisonExpressionOpConverter : JsonConverter<ComparisonExpressionOp>
{
    public override ComparisonExpressionOp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "=="=>ComparisonExpressionOp.Eq,
            "!="=>ComparisonExpressionOp.Ne,
            "<"=>ComparisonExpressionOp.Lt,
            "<="=>ComparisonExpressionOp.Lte,
            ">"=>ComparisonExpressionOp.Gt,
            ">="=>ComparisonExpressionOp.Gte,
            "contains"=>ComparisonExpressionOp.Contains,
            "not_contains"=>ComparisonExpressionOp.NotContains,
            _ =>(ComparisonExpressionOp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComparisonExpressionOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ComparisonExpressionOp.Eq=>"==",
            ComparisonExpressionOp.Ne=>"!=",
            ComparisonExpressionOp.Lt=>"<",
            ComparisonExpressionOp.Lte=>"<=",
            ComparisonExpressionOp.Gt=>">",
            ComparisonExpressionOp.Gte=>">=",
            ComparisonExpressionOp.Contains=>"contains",
            ComparisonExpressionOp.NotContains=>"not_contains",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}