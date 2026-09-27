using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BundlePricing.BillingBundles;

namespace Telnyx.Sdk.Services.BundlePricing;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBillingBundleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBillingBundleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillingBundleService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the details of a single billing bundle by its ID, so you can inspect its
/// contents before purchasing a user bundle.
/// </summary>
    Task<BillingBundleRetrieveResponse> Retrieve(
        BillingBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BillingBundleRetrieveParams, CancellationToken)"/>
    Task<BillingBundleRetrieveResponse> Retrieve(
        string bundleID,
        BillingBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the billing bundles available to your account, with
/// support for filtering.
/// </summary>
    Task<BillingBundleListPage> List(
        BillingBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBillingBundleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBillingBundleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillingBundleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/billing_bundles/{bundle_id}</c>, but is otherwise the
/// same as <see cref="IBillingBundleService.Retrieve(BillingBundleRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingBundleRetrieveResponse>> Retrieve(
        BillingBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BillingBundleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BillingBundleRetrieveResponse>> Retrieve(
        string bundleID,
        BillingBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/billing_bundles</c>, but is otherwise the
/// same as <see cref="IBillingBundleService.List(BillingBundleListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingBundleListPage>> List(
        BillingBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}