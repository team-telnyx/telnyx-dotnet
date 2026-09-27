using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BillingGroups;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Billing groups operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBillingGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBillingGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillingGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new billing group, which can be used to organize resources for billing
/// purposes.
/// </summary>
    Task<BillingGroupCreateResponse> Create(
        BillingGroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a specific billing group.
/// </summary>
    Task<BillingGroupRetrieveResponse> Retrieve(
        BillingGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BillingGroupRetrieveParams, CancellationToken)"/>
    Task<BillingGroupRetrieveResponse> Retrieve(
        string id,
        BillingGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the properties of an existing billing group.
/// </summary>
    Task<BillingGroupUpdateResponse> Update(
        BillingGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BillingGroupUpdateParams, CancellationToken)"/>
    Task<BillingGroupUpdateResponse> Update(
        string id,
        BillingGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of billing groups on your account.
/// </summary>
    Task<BillingGroupListPage> List(
        BillingGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a billing group from your account.
/// </summary>
    Task<BillingGroupDeleteResponse> Delete(
        BillingGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BillingGroupDeleteParams, CancellationToken)"/>
    Task<BillingGroupDeleteResponse> Delete(
        string id,
        BillingGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBillingGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBillingGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillingGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /billing_groups</c>, but is otherwise the
/// same as <see cref="IBillingGroupService.Create(BillingGroupCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingGroupCreateResponse>> Create(
        BillingGroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /billing_groups/{id}</c>, but is otherwise the
/// same as <see cref="IBillingGroupService.Retrieve(BillingGroupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingGroupRetrieveResponse>> Retrieve(
        BillingGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BillingGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BillingGroupRetrieveResponse>> Retrieve(
        string id,
        BillingGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /billing_groups/{id}</c>, but is otherwise the
/// same as <see cref="IBillingGroupService.Update(BillingGroupUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingGroupUpdateResponse>> Update(
        BillingGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BillingGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BillingGroupUpdateResponse>> Update(
        string id,
        BillingGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /billing_groups</c>, but is otherwise the
/// same as <see cref="IBillingGroupService.List(BillingGroupListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingGroupListPage>> List(
        BillingGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /billing_groups/{id}</c>, but is otherwise the
/// same as <see cref="IBillingGroupService.Delete(BillingGroupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BillingGroupDeleteResponse>> Delete(
        BillingGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BillingGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BillingGroupDeleteResponse>> Delete(
        string id,
        BillingGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}