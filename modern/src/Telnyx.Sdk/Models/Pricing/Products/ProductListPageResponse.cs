using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Pricing.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListPageResponse, ProductListPageResponseFromRaw>))]
public sealed record class ProductListPageResponse : JsonModel
{
    public required IReadOnlyList<ProductListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ProductListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PricingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PricingPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public ProductListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListPageResponse (
        ProductListPageResponse productListPageResponse
    ) : base(productListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ProductListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProductListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProductListPageResponseFromRaw : IFromRawJson<ProductListPageResponse>
{
    /// <inheritdoc/>
    public ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProductListPageResponse.FromRawUnchecked(rawData);
}