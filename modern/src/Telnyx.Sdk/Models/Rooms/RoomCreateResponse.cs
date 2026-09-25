using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<RoomCreateResponse, RoomCreateResponseFromRaw>))]
public sealed record class RoomCreateResponse : JsonModel
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

    public RoomCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomCreateResponse (RoomCreateResponse roomCreateResponse) : base(
        roomCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public RoomCreateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomCreateResponseFromRaw.FromRawUnchecked"/>
    public static RoomCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomCreateResponseFromRaw : IFromRawJson<RoomCreateResponse>
{
    /// <inheritdoc/>
    public RoomCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomCreateResponse.FromRawUnchecked(rawData);
}