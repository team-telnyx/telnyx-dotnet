using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AdvancedOrders;

[JsonConverter(typeof(JsonModelConverter<AdvancedOrderListResponse, AdvancedOrderListResponseFromRaw>))]
public sealed record class AdvancedOrderListResponse : JsonModel
{
    public IReadOnlyList<AdvancedOrder>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AdvancedOrder>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AdvancedOrder>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public AdvancedOrderListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdvancedOrderListResponse (
        AdvancedOrderListResponse advancedOrderListResponse
    ) : base(advancedOrderListResponse)
    {  }
    #pragma warning restore CS8618

    public AdvancedOrderListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedOrderListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdvancedOrderListResponseFromRaw.FromRawUnchecked"/>
    public static AdvancedOrderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdvancedOrderListResponseFromRaw : IFromRawJson<AdvancedOrderListResponse>
{
    /// <inheritdoc/>
    public AdvancedOrderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdvancedOrderListResponse.FromRawUnchecked(rawData);
}