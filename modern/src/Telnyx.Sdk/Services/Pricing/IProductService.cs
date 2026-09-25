using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Pricing.Products;

namespace Telnyx.Sdk.Services.Pricing;

/// <summary>
/// Public pricing operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProductServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns pricing entries for a single product. Most products return standard rate
/// entries with fields like rate, unit, country_iso, direction, and tiers.
/// Inference products return model-specific fields (model, input_rate, output_rate,
/// cached_input_rate) with tiered pricing. Some products use rate decks
/// (pricing_type: rate_deck) where rates are determined dynamically.
/// </summary>
    Task<ProductRetrievePage> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ProductRetrieveParams, CancellationToken)"/>
    Task<ProductRetrievePage> Retrieve(
        string slug,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the full product catalog with pagination. Each entry contains a slug,
/// display name, and description. Use the slug to fetch per-product pricing via GET
/// /pricing/products/{slug}.
/// </summary>
    Task<ProductListPage> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IProductService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProductServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /pricing/products/{slug}</c>, but is otherwise the
/// same as <see cref="IProductService.Retrieve(ProductRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProductRetrievePage>> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ProductRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ProductRetrievePage>> Retrieve(
        string slug,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /pricing/products</c>, but is otherwise the
/// same as <see cref="IProductService.List(ProductListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProductListPage>> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}