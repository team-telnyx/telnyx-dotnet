using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// Create/update request body. Accepts: - ``rules`` — canonical ordered list of routing rules
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CanaryDeploy, CanaryDeployFromRaw>))]
public sealed record class CanaryDeploy : JsonModel
{
    public IReadOnlyList<RuleInput>? Rules {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RuleInput>>(
                "rules"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RuleInput>?>(
                "rules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
    }

    public CanaryDeploy ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CanaryDeploy (CanaryDeploy canaryDeploy) : base(canaryDeploy)
    {  }
    #pragma warning restore CS8618

    public CanaryDeploy (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CanaryDeploy (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CanaryDeployFromRaw.FromRawUnchecked"/>
    public static CanaryDeploy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CanaryDeployFromRaw : IFromRawJson<CanaryDeploy>
{
    /// <inheritdoc/>
    public CanaryDeploy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CanaryDeploy.FromRawUnchecked(rawData);
}