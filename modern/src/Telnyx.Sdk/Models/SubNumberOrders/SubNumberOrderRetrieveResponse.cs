using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderRetrieveResponse, SubNumberOrderRetrieveResponseFromRaw>))]
public sealed record class SubNumberOrderRetrieveResponse : JsonModel
{
    public NumbersSubNumberOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumbersSubNumberOrder>(
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

    public SubNumberOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderRetrieveResponse (
        SubNumberOrderRetrieveResponse subNumberOrderRetrieveResponse
    ) : base(subNumberOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderRetrieveResponseFromRaw : IFromRawJson<SubNumberOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public SubNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderRetrieveResponse.FromRawUnchecked(rawData);
}