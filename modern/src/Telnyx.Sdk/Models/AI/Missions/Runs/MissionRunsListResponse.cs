using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Missions.Runs;

[JsonConverter(typeof(JsonModelConverter<MissionRunsListResponse, MissionRunsListResponseFromRaw>))]
public sealed record class MissionRunsListResponse : JsonModel
{
    public required IReadOnlyList<MissionRunData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MissionRunData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MissionRunData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public MissionRunsListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MissionRunsListResponse (
        MissionRunsListResponse missionRunsListResponse
    ) : base(missionRunsListResponse)
    {  }
    #pragma warning restore CS8618

    public MissionRunsListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MissionRunsListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MissionRunsListResponseFromRaw.FromRawUnchecked"/>
    public static MissionRunsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MissionRunsListResponseFromRaw : IFromRawJson<MissionRunsListResponse>
{
    /// <inheritdoc/>
    public MissionRunsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MissionRunsListResponse.FromRawUnchecked(rawData);
}