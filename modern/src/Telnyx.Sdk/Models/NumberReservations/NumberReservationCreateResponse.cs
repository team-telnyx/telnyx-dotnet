using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberReservations;

[JsonConverter(typeof(JsonModelConverter<NumberReservationCreateResponse, NumberReservationCreateResponseFromRaw>))]
public sealed record class NumberReservationCreateResponse : JsonModel
{
    public NumberReservation? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberReservation>(
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

    public NumberReservationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberReservationCreateResponse (
        NumberReservationCreateResponse numberReservationCreateResponse
    ) : base(numberReservationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NumberReservationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberReservationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberReservationCreateResponseFromRaw.FromRawUnchecked"/>
    public static NumberReservationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberReservationCreateResponseFromRaw : IFromRawJson<NumberReservationCreateResponse>
{
    /// <inheritdoc/>
    public NumberReservationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberReservationCreateResponse.FromRawUnchecked(rawData);
}