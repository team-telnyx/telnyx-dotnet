using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrders;

[JsonConverter(typeof(JsonModelConverter<NumberOrderRetrieveResponse, NumberOrderRetrieveResponseFromRaw>))]
public sealed record class NumberOrderRetrieveResponse : JsonModel
{
    public NumberOrderWithPhoneNumbers? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberOrderWithPhoneNumbers>(
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

    public NumberOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderRetrieveResponse (
        NumberOrderRetrieveResponse numberOrderRetrieveResponse
    ) : base(numberOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderRetrieveResponseFromRaw : IFromRawJson<NumberOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderRetrieveResponse.FromRawUnchecked(rawData);
}