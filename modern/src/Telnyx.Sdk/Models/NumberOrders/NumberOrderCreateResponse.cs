using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrders;

[JsonConverter(typeof(JsonModelConverter<NumberOrderCreateResponse, NumberOrderCreateResponseFromRaw>))]
public sealed record class NumberOrderCreateResponse : JsonModel
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

    public NumberOrderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderCreateResponse (
        NumberOrderCreateResponse numberOrderCreateResponse
    ) : base(numberOrderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderCreateResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderCreateResponseFromRaw : IFromRawJson<NumberOrderCreateResponse>
{
    /// <inheritdoc/>
    public NumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderCreateResponse.FromRawUnchecked(rawData);
}