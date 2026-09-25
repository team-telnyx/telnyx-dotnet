using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// What a rule serves when matched.
///
/// <para>Exactly one of: - ``version_id`` — serve a specific version - ``rollout``
/// — weighted random across versions; weights must sum to   less than 100, with the
/// leftover routing to the main version</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Serve, ServeFromRaw>))]
public sealed record class Serve : JsonModel
{
    public IReadOnlyList<RolloutSlot>? Rollout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RolloutSlot>>(
                "rollout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RolloutSlot>?>(
                "rollout",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? VersionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Rollout ?? [])
        {
            item.Validate();
        }
        _ = this.VersionID;
    }

    public Serve ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Serve (Serve serve) : base(serve)
    {  }
    #pragma warning restore CS8618

    public Serve (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Serve (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ServeFromRaw.FromRawUnchecked"/>
    public static Serve FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ServeFromRaw : IFromRawJson<Serve>
{
    /// <inheritdoc/>
    public Serve FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Serve.FromRawUnchecked(rawData);
}