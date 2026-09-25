using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(JsonModelConverter<PlanStepResponse, PlanStepResponseFromRaw>))]
public sealed record class PlanStepResponse : JsonModel
{
    public required PlanStepData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlanStepData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public PlanStepResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanStepResponse (PlanStepResponse planStepResponse) : base(
        planStepResponse
    )
    {  }
    #pragma warning restore CS8618

    public PlanStepResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanStepResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PlanStepResponseFromRaw.FromRawUnchecked"/>
    public static PlanStepResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PlanStepResponse (PlanStepData data) : this()
    { this.Data = data; }
}

class PlanStepResponseFromRaw : IFromRawJson<PlanStepResponse>
{
    /// <inheritdoc/>
    public PlanStepResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PlanStepResponse.FromRawUnchecked(rawData);
}