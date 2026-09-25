using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions;

[JsonConverter(typeof(JsonModelConverter<MissionResponse, MissionResponseFromRaw>))]
public sealed record class MissionResponse : JsonModel
{
    public required MissionData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MissionData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MissionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MissionResponse (MissionResponse missionResponse) : base(
        missionResponse
    )
    {  }
    #pragma warning restore CS8618

    public MissionResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MissionResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MissionResponseFromRaw.FromRawUnchecked"/>
    public static MissionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MissionResponse (MissionData data) : this()
    { this.Data = data; }
}

class MissionResponseFromRaw : IFromRawJson<MissionResponse>
{
    /// <inheritdoc/>
    public MissionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MissionResponse.FromRawUnchecked(rawData);
}