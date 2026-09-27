using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions.Artifacts;

[JsonConverter(typeof(JsonModelConverter<ArtifactListResponse, ArtifactListResponseFromRaw>))]
public sealed record class ArtifactListResponse : JsonModel
{
    public required IReadOnlyList<MeetingSessionArtifact> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeetingSessionArtifact>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MeetingSessionArtifact>>(
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

    public ArtifactListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactListResponse (
        ArtifactListResponse artifactListResponse
    ) : base(artifactListResponse)
    {  }
    #pragma warning restore CS8618

    public ArtifactListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactListResponseFromRaw.FromRawUnchecked"/>
    public static ArtifactListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ArtifactListResponse (
        IReadOnlyList<MeetingSessionArtifact> data
    ) : this()
    { this.Data = data; }
}

class ArtifactListResponseFromRaw : IFromRawJson<ArtifactListResponse>
{
    /// <inheritdoc/>
    public ArtifactListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArtifactListResponse.FromRawUnchecked(rawData);
}