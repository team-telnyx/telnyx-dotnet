using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// One slot in a percentage rollout.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RolloutSlot, RolloutSlotFromRaw>))]
public sealed record class RolloutSlot : JsonModel
{
    public required string VersionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "version_id"
            );
        }
        init { this._rawData.Set("version_id", value); }
    }

    public required double Weight {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "weight"
            );
        }
        init { this._rawData.Set("weight", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.VersionID;
        _ = this.Weight;
    }

    public RolloutSlot ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RolloutSlot (RolloutSlot rolloutSlot) : base(rolloutSlot)
    {  }
    #pragma warning restore CS8618

    public RolloutSlot (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RolloutSlot (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RolloutSlotFromRaw.FromRawUnchecked"/>
    public static RolloutSlot FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RolloutSlotFromRaw : IFromRawJson<RolloutSlot>
{
    /// <inheritdoc/>
    public RolloutSlot FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RolloutSlot.FromRawUnchecked(rawData);
}