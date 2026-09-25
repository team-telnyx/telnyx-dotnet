using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs;

[JsonConverter(typeof(JsonModelConverter<MissionRunResponse, MissionRunResponseFromRaw>))]
public sealed record class MissionRunResponse : JsonModel
{
    public required MissionRunData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MissionRunData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MissionRunResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MissionRunResponse (MissionRunResponse missionRunResponse) : base(
        missionRunResponse
    )
    {  }
    #pragma warning restore CS8618

    public MissionRunResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MissionRunResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MissionRunResponseFromRaw.FromRawUnchecked"/>
    public static MissionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MissionRunResponse (MissionRunData data) : this()
    { this.Data = data; }
}

class MissionRunResponseFromRaw : IFromRawJson<MissionRunResponse>
{
    /// <inheritdoc/>
    public MissionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MissionRunResponse.FromRawUnchecked(rawData);
}