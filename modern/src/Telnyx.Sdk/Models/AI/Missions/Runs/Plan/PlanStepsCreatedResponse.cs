using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(JsonModelConverter<PlanStepsCreatedResponse, PlanStepsCreatedResponseFromRaw>))]
public sealed record class PlanStepsCreatedResponse : JsonModel
{
    public required IReadOnlyList<PlanStepData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanStepData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<PlanStepData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PlanStepsCreatedResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanStepsCreatedResponse (
        PlanStepsCreatedResponse planStepsCreatedResponse
    ) : base(planStepsCreatedResponse)
    {  }
    #pragma warning restore CS8618

    public PlanStepsCreatedResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanStepsCreatedResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PlanStepsCreatedResponseFromRaw.FromRawUnchecked"/>
    public static PlanStepsCreatedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PlanStepsCreatedResponse (IReadOnlyList<PlanStepData> data) : this()
    { this.Data = data; }
}

class PlanStepsCreatedResponseFromRaw : IFromRawJson<PlanStepsCreatedResponse>
{
    /// <inheritdoc/>
    public PlanStepsCreatedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PlanStepsCreatedResponse.FromRawUnchecked(rawData);
}