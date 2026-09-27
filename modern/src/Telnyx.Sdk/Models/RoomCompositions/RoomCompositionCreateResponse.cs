using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomCompositions;

[JsonConverter(typeof(JsonModelConverter<RoomCompositionCreateResponse, RoomCompositionCreateResponseFromRaw>))]
public sealed record class RoomCompositionCreateResponse : JsonModel
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

    public RoomCompositionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomCompositionCreateResponse (
        RoomCompositionCreateResponse roomCompositionCreateResponse
    ) : base(roomCompositionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public RoomCompositionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomCompositionCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomCompositionCreateResponseFromRaw.FromRawUnchecked"/>
    public static RoomCompositionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomCompositionCreateResponseFromRaw : IFromRawJson<RoomCompositionCreateResponse>
{
    /// <inheritdoc/>
    public RoomCompositionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomCompositionCreateResponse.FromRawUnchecked(rawData);
}