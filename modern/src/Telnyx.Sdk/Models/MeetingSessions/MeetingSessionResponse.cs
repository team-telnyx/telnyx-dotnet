using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionResponse, MeetingSessionResponseFromRaw>))]
public sealed record class MeetingSessionResponse : JsonModel
{
    /// <summary>
    /// Represents a meeting session. All serializer fields are present and required;
    /// nullable fields use null when absent. No actor, provider-bot, idempotency,
    /// routing, key, or internal fields are exposed.
    /// </summary>
    public required MeetingSession Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MeetingSession>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MeetingSessionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionResponse (
        MeetingSessionResponse meetingSessionResponse
    ) : base(meetingSessionResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionResponse (MeetingSession data) : this()
    { this.Data = data; }
}

class MeetingSessionResponseFromRaw : IFromRawJson<MeetingSessionResponse>
{
    /// <inheritdoc/>
    public MeetingSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionResponse.FromRawUnchecked(rawData);
}