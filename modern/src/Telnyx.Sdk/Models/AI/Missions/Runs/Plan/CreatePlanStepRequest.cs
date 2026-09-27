using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(JsonModelConverter<CreatePlanStepRequest, CreatePlanStepRequestFromRaw>))]
public sealed record class CreatePlanStepRequest : JsonModel
{
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    public required long Sequence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "sequence"
            );
        }
        init { this._rawData.Set("sequence", value); }
    }

    public required string StepID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "step_id"
            );
        }
        init { this._rawData.Set("step_id", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ParentStepID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parent_step_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parent_step_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Sequence;
        _ = this.StepID;
        _ = this.Metadata;
        _ = this.ParentStepID;
    }

    public CreatePlanStepRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatePlanStepRequest (
        CreatePlanStepRequest createPlanStepRequest
    ) : base(createPlanStepRequest)
    {  }
    #pragma warning restore CS8618

    public CreatePlanStepRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatePlanStepRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreatePlanStepRequestFromRaw.FromRawUnchecked"/>
    public static CreatePlanStepRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreatePlanStepRequestFromRaw : IFromRawJson<CreatePlanStepRequest>
{
    /// <inheritdoc/>
    public CreatePlanStepRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreatePlanStepRequest.FromRawUnchecked(rawData);
}