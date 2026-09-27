using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrders;

[JsonConverter(typeof(JsonModelConverter<NumberOrderUpdateResponse, NumberOrderUpdateResponseFromRaw>))]
public sealed record class NumberOrderUpdateResponse : JsonModel
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

    public NumberOrderUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderUpdateResponse (
        NumberOrderUpdateResponse numberOrderUpdateResponse
    ) : base(numberOrderUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderUpdateResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderUpdateResponseFromRaw : IFromRawJson<NumberOrderUpdateResponse>
{
    /// <inheritdoc/>
    public NumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderUpdateResponse.FromRawUnchecked(rawData);
}