using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Tools;

/// <summary>
/// Configuration for an update_dynamic_variables tool.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UpdateDynamicVariablesToolParams, UpdateDynamicVariablesToolParamsFromRaw>))]
public sealed record class UpdateDynamicVariablesToolParams : JsonModel
{
    /// <summary>
    /// Description of the tool passed to the assistant, guiding when to call it and
    /// which variables to update.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The function name surfaced to the LLM. Must match the OpenAI function-name
    /// pattern `^[a-zA-Z0-9_-]+$` and be unique across the assistant's function,
    /// webhook, and client_side tools.
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

    /// <summary>
    /// The dynamic variables the assistant is allowed to write. At least one is required.
    /// </summary>
    public required IReadOnlyList<UpdatableVariable> UpdatableVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UpdatableVariable>>(
                "updatable_variables"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UpdatableVariable>>(
                "updatable_variables",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        foreach (var item in this.UpdatableVariables)
        {
            item.Validate();
        }
    }

    public UpdateDynamicVariablesToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateDynamicVariablesToolParams (
        UpdateDynamicVariablesToolParams updateDynamicVariablesToolParams
    ) : base(updateDynamicVariablesToolParams)
    {  }
    #pragma warning restore CS8618

    public UpdateDynamicVariablesToolParams (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateDynamicVariablesToolParams (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateDynamicVariablesToolParamsFromRaw.FromRawUnchecked"/>
    public static UpdateDynamicVariablesToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateDynamicVariablesToolParamsFromRaw : IFromRawJson<UpdateDynamicVariablesToolParams>
{
    /// <inheritdoc/>
    public UpdateDynamicVariablesToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateDynamicVariablesToolParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdatableVariable, UpdatableVariableFromRaw>))]
public sealed record class UpdatableVariable : JsonModel
{
    /// <summary>
    /// The dynamic-variable key to update. Must match `^[a-zA-Z0-9._-]+$` and may
    /// not start with the reserved `telnyx_` prefix (reserved for system variables).
    /// The `pattern` encodes both rules via a negative lookahead.
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

    /// <summary>
    /// Optional description of the variable, guiding the assistant on what value
    /// to capture.
    /// </summary>
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

    /// <summary>
    /// Optional hint for the variable's value type (e.g. `string`).
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Type;
    }

    public UpdatableVariable ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdatableVariable (UpdatableVariable updatableVariable) : base(
        updatableVariable
    )
    {  }
    #pragma warning restore CS8618

    public UpdatableVariable (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdatableVariable (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdatableVariableFromRaw.FromRawUnchecked"/>
    public static UpdatableVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UpdatableVariable (string name) : this()
    { this.Name = name; }
}class UpdatableVariableFromRaw : IFromRawJson<UpdatableVariable>
{
    /// <inheritdoc/>
    public UpdatableVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdatableVariable.FromRawUnchecked(rawData);
}