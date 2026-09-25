using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// A single attribute/operator/values check.
///
/// <para>A clause matches when the routing context's value for ``attribute`` satisfies
/// ``operator`` against any of ``values``.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Clause, ClauseFromRaw>))]
public sealed record class Clause : JsonModel
{
    /// <summary>
    /// Attribute name from the routing context
    /// </summary>
    public required string Attribute {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "attribute"
            );
        }
        init { this._rawData.Set("attribute", value); }
    }

    /// <summary>
    /// Match operator
    /// </summary>
    public required ApiEnum<string, Operator> Operator {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    public required IReadOnlyList<string> Values {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "values"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attribute;
        this.Operator.Validate();
        _ = this.Values;
    }

    public Clause ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Clause (Clause clause) : base(clause)
    {  }
    #pragma warning restore CS8618

    public Clause (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClauseFromRaw.FromRawUnchecked"/>
    public static Clause FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ClauseFromRaw : IFromRawJson<Clause>
{
    /// <inheritdoc/>
    public Clause FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Clause.FromRawUnchecked(rawData);
}

/// <summary>
/// Match operator
/// </summary>
[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    In, NotIn, StartsWith
}sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in"=>Operator.In,
            "not_in"=>Operator.NotIn,
            "starts_with"=>Operator.StartsWith,
            _ =>(Operator)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Operator value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Operator.In=>"in",
            Operator.NotIn=>"not_in",
            Operator.StartsWith=>"starts_with",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}