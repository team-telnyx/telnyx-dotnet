using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(JsonModelConverter<PlanStepData, PlanStepDataFromRaw>))]
public sealed record class PlanStepData : JsonModel
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

    public required string RunID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "run_id"
            );
        }
        init { this._rawData.Set("run_id", value); }
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

    public required ApiEnum<string, StepStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StepStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
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

    public DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "completed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
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

    public DateTimeOffset? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.RunID;
        _ = this.Sequence;
        this.Status.Validate();
        _ = this.StepID;
        _ = this.CompletedAt;
        _ = this.Metadata;
        _ = this.ParentStepID;
        _ = this.StartedAt;
    }

    public PlanStepData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanStepData (PlanStepData planStepData) : base(planStepData)
    {  }
    #pragma warning restore CS8618

    public PlanStepData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanStepData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PlanStepDataFromRaw.FromRawUnchecked"/>
    public static PlanStepData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PlanStepDataFromRaw : IFromRawJson<PlanStepData>
{
    /// <inheritdoc/>
    public PlanStepData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PlanStepData.FromRawUnchecked(rawData);
}