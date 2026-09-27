using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberBlockOrders;

[JsonConverter(typeof(JsonModelConverter<NumberBlockOrderRetrieveResponse, NumberBlockOrderRetrieveResponseFromRaw>))]
public sealed record class NumberBlockOrderRetrieveResponse : JsonModel
{
    public NumberBlockOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberBlockOrder>(
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

    public NumberBlockOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberBlockOrderRetrieveResponse (
        NumberBlockOrderRetrieveResponse numberBlockOrderRetrieveResponse
    ) : base(numberBlockOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberBlockOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberBlockOrderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberBlockOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberBlockOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberBlockOrderRetrieveResponseFromRaw : IFromRawJson<NumberBlockOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberBlockOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberBlockOrderRetrieveResponse.FromRawUnchecked(rawData);
}