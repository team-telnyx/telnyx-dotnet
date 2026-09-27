using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Pricing.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListResponse, ProductListResponseFromRaw>))]
public sealed record class ProductListResponse : JsonModel
{
    /// <summary>
    /// Human-readable description of the product.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Display name of the product.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Product identifier used in the per-product pricing endpoint.
    /// </summary>
    public required string Slug {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "slug"
            );
        }
        init { this._rawData.Set("slug", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.Slug;
    }

    public ProductListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponse (ProductListResponse productListResponse) : base(
        productListResponse
    )
    {  }
    #pragma warning restore CS8618

    public ProductListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseFromRaw.FromRawUnchecked"/>
    public static ProductListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProductListResponseFromRaw : IFromRawJson<ProductListResponse>
{
    /// <inheritdoc/>
    public ProductListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProductListResponse.FromRawUnchecked(rawData);
}