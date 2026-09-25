using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// A targeting rule: ``match`` clauses (AND) gate ``serve``.
///
/// <para>An empty ``match`` is a catch-all (always fires).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RuleOutput, RuleOutputFromRaw>))]
public sealed record class RuleOutput : JsonModel
{
    /// <summary>
    /// What a rule serves when matched.
    ///
    /// <para>Exactly one of: - ``version_id`` — serve a specific version - ``rollout``
    /// — weighted random across versions; weights must sum to   less than 100, with
    /// the leftover routing to the main version</para>
    /// </summary>
    public required Serve Serve {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Serve>(
                "serve"
            );
        }
        init { this._rawData.Set("serve", value); }
    }

    public IReadOnlyList<Clause>? Match {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Clause>>(
                "match"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Clause>?>(
                "match",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Serve.Validate();
        foreach (var item in this.Match ?? [])
        {
            item.Validate();
        }
    }

    public RuleOutput ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleOutput (RuleOutput ruleOutput) : base(ruleOutput)
    {  }
    #pragma warning restore CS8618

    public RuleOutput (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleOutput (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RuleOutputFromRaw.FromRawUnchecked"/>
    public static RuleOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public RuleOutput (Serve serve) : this()
    { this.Serve = serve; }
}

class RuleOutputFromRaw : IFromRawJson<RuleOutput>
{
    /// <inheritdoc/>
    public RuleOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RuleOutput.FromRawUnchecked(rawData);
}