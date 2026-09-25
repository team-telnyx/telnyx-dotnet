using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

[JsonConverter(typeof(JsonModelConverter<TelnyxAgentData, TelnyxAgentDataFromRaw>))]
public sealed record class TelnyxAgentData : JsonModel
{
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
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

    public required string TelnyxAgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "telnyx_agent_id"
            );
        }
        init { this._rawData.Set("telnyx_agent_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.RunID;
        _ = this.TelnyxAgentID;
    }

    public TelnyxAgentData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxAgentData (TelnyxAgentData telnyxAgentData) : base(
        telnyxAgentData
    )
    {  }
    #pragma warning restore CS8618

    public TelnyxAgentData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxAgentData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxAgentDataFromRaw.FromRawUnchecked"/>
    public static TelnyxAgentData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxAgentDataFromRaw : IFromRawJson<TelnyxAgentData>
{
    /// <inheritdoc/>
    public TelnyxAgentData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxAgentData.FromRawUnchecked(rawData);
}