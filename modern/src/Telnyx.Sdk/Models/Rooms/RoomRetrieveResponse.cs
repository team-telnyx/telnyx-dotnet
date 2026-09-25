using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<RoomRetrieveResponse, RoomRetrieveResponseFromRaw>))]
public sealed record class RoomRetrieveResponse : JsonModel
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

    public RoomRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRetrieveResponse (
        RoomRetrieveResponse roomRetrieveResponse
    ) : base(roomRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RoomRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RoomRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRetrieveResponseFromRaw : IFromRawJson<RoomRetrieveResponse>
{
    /// <inheritdoc/>
    public RoomRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRetrieveResponse.FromRawUnchecked(rawData);
}