using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.RoomParticipants;

[JsonConverter(typeof(JsonModelConverter<RoomParticipantListPageResponse, RoomParticipantListPageResponseFromRaw>))]
public sealed record class RoomParticipantListPageResponse : JsonModel
{
    public IReadOnlyList<RoomParticipant>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RoomParticipant>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RoomParticipant>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public RoomParticipantListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomParticipantListPageResponse (
        RoomParticipantListPageResponse roomParticipantListPageResponse
    ) : base(roomParticipantListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RoomParticipantListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomParticipantListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomParticipantListPageResponseFromRaw.FromRawUnchecked"/>
    public static RoomParticipantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomParticipantListPageResponseFromRaw : IFromRawJson<RoomParticipantListPageResponse>
{
    /// <inheritdoc/>
    public RoomParticipantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomParticipantListPageResponse.FromRawUnchecked(rawData);
}