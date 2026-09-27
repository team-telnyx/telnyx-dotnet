using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(JsonModelConverter<PlanRetrieveResponse, PlanRetrieveResponseFromRaw>))]
public sealed record class PlanRetrieveResponse : JsonModel
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

    public PlanRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRetrieveResponse (
        PlanRetrieveResponse planRetrieveResponse
    ) : base(planRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PlanRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PlanRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PlanRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PlanRetrieveResponse (IReadOnlyList<PlanStepData> data) : this()
    { this.Data = data; }
}

class PlanRetrieveResponseFromRaw : IFromRawJson<PlanRetrieveResponse>
{
    /// <inheritdoc/>
    public PlanRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PlanRetrieveResponse.FromRawUnchecked(rawData);
}