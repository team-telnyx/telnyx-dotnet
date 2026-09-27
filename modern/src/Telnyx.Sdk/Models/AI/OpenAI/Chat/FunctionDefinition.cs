using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.OpenAI.Chat;

[JsonConverter(typeof(JsonModelConverter<FunctionDefinition, FunctionDefinitionFromRaw>))]
public sealed record class FunctionDefinition : JsonModel
{
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Parameters;
    }

    public FunctionDefinition ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionDefinition (FunctionDefinition functionDefinition) : base(
        functionDefinition
    )
    {  }
    #pragma warning restore CS8618

    public FunctionDefinition (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionDefinition (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FunctionDefinitionFromRaw.FromRawUnchecked"/>
    public static FunctionDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FunctionDefinition (string name) : this()
    { this.Name = name; }
}

class FunctionDefinitionFromRaw : IFromRawJson<FunctionDefinition>
{
    /// <inheritdoc/>
    public FunctionDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FunctionDefinition.FromRawUnchecked(rawData);
}