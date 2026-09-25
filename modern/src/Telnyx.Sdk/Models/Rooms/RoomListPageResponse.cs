using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<RoomListPageResponse, RoomListPageResponseFromRaw>))]
public sealed record class RoomListPageResponse : JsonModel
{
    public IReadOnlyList<Room>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Room>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Room>?>(
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

    public RoomListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomListPageResponse (
        RoomListPageResponse roomListPageResponse
    ) : base(roomListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RoomListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomListPageResponseFromRaw.FromRawUnchecked"/>
    public static RoomListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomListPageResponseFromRaw : IFromRawJson<RoomListPageResponse>
{
    /// <inheritdoc/>
    public RoomListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomListPageResponse.FromRawUnchecked(rawData);
}