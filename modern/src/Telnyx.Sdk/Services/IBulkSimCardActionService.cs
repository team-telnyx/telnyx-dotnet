using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BulkSimCardActions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// View SIM card actions, their progress and timestamps using the SIM Card Actions API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBulkSimCardActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBulkSimCardActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkSimCardActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// This API fetches information about a bulk SIM card action. A bulk SIM card
/// action contains details about a collection of individual SIM card actions.
/// </summary>
    Task<BulkSimCardActionRetrieveResponse> Retrieve(
        BulkSimCardActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BulkSimCardActionRetrieveParams, CancellationToken)"/>
    Task<BulkSimCardActionRetrieveResponse> Retrieve(
        string id,
        BulkSimCardActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API lists a paginated collection of bulk SIM card actions. A bulk SIM card
/// action contains details about a collection of individual SIM card actions.
/// </summary>
    Task<BulkSimCardActionListPage> List(
        BulkSimCardActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBulkSimCardActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBulkSimCardActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkSimCardActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bulk_sim_card_actions/{id}</c>, but is otherwise the
/// same as <see cref="IBulkSimCardActionService.Retrieve(BulkSimCardActionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BulkSimCardActionRetrieveResponse>> Retrieve(
        BulkSimCardActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BulkSimCardActionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BulkSimCardActionRetrieveResponse>> Retrieve(
        string id,
        BulkSimCardActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /bulk_sim_card_actions</c>, but is otherwise the
/// same as <see cref="IBulkSimCardActionService.List(BulkSimCardActionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BulkSimCardActionListPage>> List(
        BulkSimCardActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}