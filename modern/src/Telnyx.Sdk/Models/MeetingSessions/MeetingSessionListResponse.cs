using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionListResponse, MeetingSessionListResponseFromRaw>))]
public sealed record class MeetingSessionListResponse : JsonModel
{
    public required IReadOnlyList<MeetingSession> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeetingSession>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MeetingSession>>(
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

    public MeetingSessionListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionListResponse (
        MeetingSessionListResponse meetingSessionListResponse
    ) : base(meetingSessionListResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionListResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionListResponse (
        IReadOnlyList<MeetingSession> data
    ) : this()
    { this.Data = data; }
}

class MeetingSessionListResponseFromRaw : IFromRawJson<MeetingSessionListResponse>
{
    /// <inheritdoc/>
    public MeetingSessionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionListResponse.FromRawUnchecked(rawData);
}