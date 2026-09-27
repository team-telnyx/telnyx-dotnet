using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardOrders;

[JsonConverter(typeof(JsonModelConverter<SimCardOrderRetrieveResponse, SimCardOrderRetrieveResponseFromRaw>))]
public sealed record class SimCardOrderRetrieveResponse : JsonModel
{
    public SimCardOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardOrder>(
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

    public SimCardOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardOrderRetrieveResponse (
        SimCardOrderRetrieveResponse simCardOrderRetrieveResponse
    ) : base(simCardOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardOrderRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SimCardOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardOrderRetrieveResponseFromRaw : IFromRawJson<SimCardOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public SimCardOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardOrderRetrieveResponse.FromRawUnchecked(rawData);
}