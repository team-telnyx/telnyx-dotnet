using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs;

[JsonConverter(typeof(JsonModelConverter<MissionRunData, MissionRunDataFromRaw>))]
public sealed record class MissionRunData : JsonModel
{
    public required string MissionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "mission_id"
            );
        }
        init { this._rawData.Set("mission_id", value); }
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

    public required DateTimeOffset StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "started_at"
            );
        }
        init { this._rawData.Set("started_at", value); }
    }

    public required ApiEnum<string, RunStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RunStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? Error {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    public DateTimeOffset? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "finished_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("finished_at", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Input {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "input"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "input",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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

    public IReadOnlyDictionary<string, JsonElement>? ResultPayload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "result_payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "result_payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ResultSummary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "result_summary"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result_summary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MissionID;
        _ = this.RunID;
        _ = this.StartedAt;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.Error;
        _ = this.FinishedAt;
        _ = this.Input;
        _ = this.Metadata;
        _ = this.ResultPayload;
        _ = this.ResultSummary;
    }

    public MissionRunData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MissionRunData (MissionRunData missionRunData) : base(missionRunData)
    {  }
    #pragma warning restore CS8618

    public MissionRunData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MissionRunData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MissionRunDataFromRaw.FromRawUnchecked"/>
    public static MissionRunData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MissionRunDataFromRaw : IFromRawJson<MissionRunData>
{
    /// <inheritdoc/>
    public MissionRunData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MissionRunData.FromRawUnchecked(rawData);
}