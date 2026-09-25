using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<RoomUpdateResponse, RoomUpdateResponseFromRaw>))]
public sealed record class RoomUpdateResponse : JsonModel
{
    public Room? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Room>(
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

    public RoomUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomUpdateResponse (RoomUpdateResponse roomUpdateResponse) : base(
        roomUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public RoomUpdateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomUpdateResponseFromRaw.FromRawUnchecked"/>
    public static RoomUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomUpdateResponseFromRaw : IFromRawJson<RoomUpdateResponse>
{
    /// <inheritdoc/>
    public RoomUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomUpdateResponse.FromRawUnchecked(rawData);
}