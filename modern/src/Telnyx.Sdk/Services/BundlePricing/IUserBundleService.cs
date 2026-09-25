using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BundlePricing.UserBundles;

namespace Telnyx.Sdk.Services.BundlePricing;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserBundleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserBundleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserBundleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates multiple user bundles for the user.
/// </summary>
    Task<UserBundleCreateResponse> Create(
        UserBundleCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single user bundle on your account by its ID.
/// </summary>
    Task<UserBundleRetrieveResponse> Retrieve(
        UserBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserBundleRetrieveParams, CancellationToken)"/>
    Task<UserBundleRetrieveResponse> Retrieve(
        string userBundleID,
        UserBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the bundles active on your account, with support for
/// filtering.
/// </summary>
    Task<UserBundleListPage> List(
        UserBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deactivates the specified user bundle on your account and returns the
/// deactivated bundle.
/// </summary>
    Task<UserBundleDeactivateResponse> Deactivate(
        UserBundleDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Deactivate(UserBundleDeactivateParams, CancellationToken)"/>
    Task<UserBundleDeactivateResponse> Deactivate(
        string userBundleID,
        UserBundleDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the resources of a user bundle by its ID.
/// </summary>
    Task<UserBundleListResourcesResponse> ListResources(
        UserBundleListResourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListResources(UserBundleListResourcesParams, CancellationToken)"/>
    Task<UserBundleListResourcesResponse> ListResources(
        string userBundleID,
        UserBundleListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns all user bundles that aren't in use.
/// </summary>
    Task<UserBundleListUnusedResponse> ListUnused(
        UserBundleListUnusedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUserBundleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserBundleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserBundleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /bundle_pricing/user_bundles/bulk</c>, but is otherwise the
/// same as <see cref="IUserBundleService.Create(UserBundleCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleCreateResponse>> Create(
        UserBundleCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/user_bundles/{user_bundle_id}</c>, but is otherwise the
/// same as <see cref="IUserBundleService.Retrieve(UserBundleRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleRetrieveResponse>> Retrieve(
        UserBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserBundleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserBundleRetrieveResponse>> Retrieve(
        string userBundleID,
        UserBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/user_bundles</c>, but is otherwise the
/// same as <see cref="IUserBundleService.List(UserBundleListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleListPage>> List(
        UserBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /bundle_pricing/user_bundles/{user_bundle_id}</c>, but is otherwise the
/// same as <see cref="IUserBundleService.Deactivate(UserBundleDeactivateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleDeactivateResponse>> Deactivate(
        UserBundleDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Deactivate(UserBundleDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<UserBundleDeactivateResponse>> Deactivate(
        string userBundleID,
        UserBundleDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/user_bundles/{user_bundle_id}/resources</c>, but is otherwise the
/// same as <see cref="IUserBundleService.ListResources(UserBundleListResourcesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleListResourcesResponse>> ListResources(
        UserBundleListResourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListResources(UserBundleListResourcesParams, CancellationToken)"/>
    Task<HttpResponse<UserBundleListResourcesResponse>> ListResources(
        string userBundleID,
        UserBundleListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bundle_pricing/user_bundles/unused</c>, but is otherwise the
/// same as <see cref="IUserBundleService.ListUnused(UserBundleListUnusedParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserBundleListUnusedResponse>> ListUnused(
        UserBundleListUnusedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}