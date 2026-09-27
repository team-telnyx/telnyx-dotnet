using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Pricing.Products;

[JsonConverter(typeof(JsonModelConverter<ProductRetrievePageResponse, ProductRetrievePageResponseFromRaw>))]
public sealed record class ProductRetrievePageResponse : JsonModel
{
    public required IReadOnlyList<ProductRetrieveResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductRetrieveResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ProductRetrieveResponse>>(
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

    public ProductRetrievePageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductRetrievePageResponse (
        ProductRetrievePageResponse productRetrievePageResponse
    ) : base(productRetrievePageResponse)
    {  }
    #pragma warning restore CS8618

    public ProductRetrievePageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductRetrievePageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProductRetrievePageResponseFromRaw.FromRawUnchecked"/>
    public static ProductRetrievePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProductRetrievePageResponseFromRaw : IFromRawJson<ProductRetrievePageResponse>
{
    /// <inheritdoc/>
    public ProductRetrievePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProductRetrievePageResponse.FromRawUnchecked(rawData);
}