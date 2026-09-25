using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomParticipants;

[JsonConverter(typeof(JsonModelConverter<RoomParticipantRetrieveResponse, RoomParticipantRetrieveResponseFromRaw>))]
public sealed record class RoomParticipantRetrieveResponse : JsonModel
{
    public RoomParticipant? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomParticipant>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public RoomParticipantRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomParticipantRetrieveResponse (
        RoomParticipantRetrieveResponse roomParticipantRetrieveResponse
    ) : base(roomParticipantRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RoomParticipantRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomParticipantRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomParticipantRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RoomParticipantRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomParticipantRetrieveResponseFromRaw : IFromRawJson<RoomParticipantRetrieveResponse>
{
    /// <inheritdoc/>
    public RoomParticipantRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomParticipantRetrieveResponse.FromRawUnchecked(rawData);
}