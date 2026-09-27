using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberReservations;

[JsonConverter(typeof(JsonModelConverter<NumberReservationRetrieveResponse, NumberReservationRetrieveResponseFromRaw>))]
public sealed record class NumberReservationRetrieveResponse : JsonModel
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

    public NumberReservationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberReservationRetrieveResponse (
        NumberReservationRetrieveResponse numberReservationRetrieveResponse
    ) : base(numberReservationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberReservationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberReservationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberReservationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberReservationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberReservationRetrieveResponseFromRaw : IFromRawJson<NumberReservationRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberReservationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberReservationRetrieveResponse.FromRawUnchecked(rawData);
}