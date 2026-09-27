using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderCancelResponse, SubNumberOrderCancelResponseFromRaw>))]
public sealed record class SubNumberOrderCancelResponse : JsonModel
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

    public SubNumberOrderCancelResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderCancelResponse (
        SubNumberOrderCancelResponse subNumberOrderCancelResponse
    ) : base(subNumberOrderCancelResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderCancelResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderCancelResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderCancelResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderCancelResponseFromRaw : IFromRawJson<SubNumberOrderCancelResponse>
{
    /// <inheritdoc/>
    public SubNumberOrderCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderCancelResponse.FromRawUnchecked(rawData);
}