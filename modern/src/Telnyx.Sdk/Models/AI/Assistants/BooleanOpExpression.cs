using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Combine sub-expressions with a logical operator (`and` / `or` / `not`).
///
/// <para>`and` and `or` accept two or more operands; `not` accepts exactly one.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BooleanOpExpression, BooleanOpExpressionFromRaw>))]
public sealed record class BooleanOpExpression : JsonModel
{
    /// <summary>
    /// Logical operator. `not` is unary; `and`/`or` are n-ary (&gt;=2).
    /// </summary>
    public required ApiEnum<string, BooleanOpExpressionOp> Op {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BooleanOpExpressionOp>>(
                "op"
            );
        }
        init { this._rawData.Set("op", value); }
    }

    /// <summary>
    /// Operand sub-expressions. Length must be exactly 1 for `not` and &gt;= 2 for `and`/`or`.
    /// </summary>
    public required IReadOnlyList<Expression> Operands {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Expression>>(
                "operands"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Expression>>(
                "operands",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this.Op.Validate();
        foreach (var item in this.Operands)
        {
            item.Validate();
        }
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("bool_op")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public BooleanOpExpression ()
    { this.Type = JsonSerializer.SerializeToElement("bool_op"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BooleanOpExpression (BooleanOpExpression booleanOpExpression) : base(
        booleanOpExpression
    )
    {  }
    #pragma warning restore CS8618

    public BooleanOpExpression (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bool_op");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BooleanOpExpression (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BooleanOpExpressionFromRaw.FromRawUnchecked"/>
    public static BooleanOpExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BooleanOpExpressionFromRaw : IFromRawJson<BooleanOpExpression>
{
    /// <inheritdoc/>
    public BooleanOpExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BooleanOpExpression.FromRawUnchecked(rawData);
}

/// <summary>
/// Logical operator. `not` is unary; `and`/`or` are n-ary (&gt;=2).
/// </summary>
[JsonConverter(typeof(BooleanOpExpressionOpConverter))]
public enum BooleanOpExpressionOp
{
    And, Or, Not
}sealed class BooleanOpExpressionOpConverter : JsonConverter<BooleanOpExpressionOp>
{
    public override BooleanOpExpressionOp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and"=>BooleanOpExpressionOp.And,
            "or"=>BooleanOpExpressionOp.Or,
            "not"=>BooleanOpExpressionOp.Not,
            _ =>(BooleanOpExpressionOp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BooleanOpExpressionOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BooleanOpExpressionOp.And=>"and",
            BooleanOpExpressionOp.Or=>"or",
            BooleanOpExpressionOp.Not=>"not",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}