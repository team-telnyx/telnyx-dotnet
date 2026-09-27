using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions.Artifacts;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionArtifactResponse, MeetingSessionArtifactResponseFromRaw>))]
public sealed record class MeetingSessionArtifactResponse : JsonModel
{
    public required MeetingSessionArtifact Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MeetingSessionArtifact>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MeetingSessionArtifactResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionArtifactResponse (
        MeetingSessionArtifactResponse meetingSessionArtifactResponse
    ) : base(meetingSessionArtifactResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionArtifactResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionArtifactResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionArtifactResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionArtifactResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionArtifactResponse (MeetingSessionArtifact data) : this()
    { this.Data = data; }
}

class MeetingSessionArtifactResponseFromRaw : IFromRawJson<MeetingSessionArtifactResponse>
{
    /// <inheritdoc/>
    public MeetingSessionArtifactResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionArtifactResponse.FromRawUnchecked(rawData);
}