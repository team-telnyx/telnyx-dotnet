using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.InexplicitNumberOrders;

[JsonConverter(typeof(JsonModelConverter<InexplicitNumberOrderRetrieveResponse, InexplicitNumberOrderRetrieveResponseFromRaw>))]
public sealed record class InexplicitNumberOrderRetrieveResponse : JsonModel
{
    public InexplicitNumberOrderResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InexplicitNumberOrderResponse>(
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

    public InexplicitNumberOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderRetrieveResponse (
        InexplicitNumberOrderRetrieveResponse inexplicitNumberOrderRetrieveResponse
    ) : base(inexplicitNumberOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public InexplicitNumberOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InexplicitNumberOrderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InexplicitNumberOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InexplicitNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InexplicitNumberOrderRetrieveResponseFromRaw : IFromRawJson<InexplicitNumberOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public InexplicitNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InexplicitNumberOrderRetrieveResponse.FromRawUnchecked(rawData);
}