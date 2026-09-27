using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.NumberBlockOrders;

[JsonConverter(typeof(JsonModelConverter<NumberBlockOrderListPageResponse, NumberBlockOrderListPageResponseFromRaw>))]
public sealed record class NumberBlockOrderListPageResponse : JsonModel
{
    public IReadOnlyList<NumberBlockOrder>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NumberBlockOrder>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NumberBlockOrder>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public NumberBlockOrderListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberBlockOrderListPageResponse (
        NumberBlockOrderListPageResponse numberBlockOrderListPageResponse
    ) : base(numberBlockOrderListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NumberBlockOrderListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberBlockOrderListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberBlockOrderListPageResponseFromRaw.FromRawUnchecked"/>
    public static NumberBlockOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberBlockOrderListPageResponseFromRaw : IFromRawJson<NumberBlockOrderListPageResponse>
{
    /// <inheritdoc/>
    public NumberBlockOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberBlockOrderListPageResponse.FromRawUnchecked(rawData);
}