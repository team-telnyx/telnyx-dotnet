using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomCompositions;

[JsonConverter(typeof(JsonModelConverter<RoomCompositionRetrieveResponse, RoomCompositionRetrieveResponseFromRaw>))]
public sealed record class RoomCompositionRetrieveResponse : JsonModel
{
    public RoomComposition? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomComposition>(
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

    public RoomCompositionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomCompositionRetrieveResponse (
        RoomCompositionRetrieveResponse roomCompositionRetrieveResponse
    ) : base(roomCompositionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RoomCompositionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomCompositionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomCompositionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RoomCompositionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomCompositionRetrieveResponseFromRaw : IFromRawJson<RoomCompositionRetrieveResponse>
{
    /// <inheritdoc/>
    public RoomCompositionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomCompositionRetrieveResponse.FromRawUnchecked(rawData);
}