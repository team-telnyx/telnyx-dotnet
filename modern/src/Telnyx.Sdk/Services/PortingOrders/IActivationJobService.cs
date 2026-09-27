using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.ActivationJobs;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActivationJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActivationJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActivationJobService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the details of a single activation job for the porting order, including
/// its current status.
/// </summary>
    Task<ActivationJobRetrieveResponse> Retrieve(
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ActivationJobRetrieveParams, CancellationToken)"/>
    Task<ActivationJobRetrieveResponse> Retrieve(
        string activationJobID,
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the activation time of a porting activation job.
/// </summary>
    Task<ActivationJobUpdateResponse> Update(
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ActivationJobUpdateParams, CancellationToken)"/>
    Task<ActivationJobUpdateResponse> Update(
        string activationJobID,
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your porting activation jobs.
/// </summary>
    Task<ActivationJobListPage> List(
        ActivationJobListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ActivationJobListParams, CancellationToken)"/>
    Task<ActivationJobListPage> List(
        string id,
        ActivationJobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActivationJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActivationJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActivationJobServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/activation_jobs/{activationJobId}</c>, but is otherwise the
/// same as <see cref="IActivationJobService.Retrieve(ActivationJobRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActivationJobRetrieveResponse>> Retrieve(
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ActivationJobRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ActivationJobRetrieveResponse>> Retrieve(
        string activationJobID,
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /porting_orders/{id}/activation_jobs/{activationJobId}</c>, but is otherwise the
/// same as <see cref="IActivationJobService.Update(ActivationJobUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActivationJobUpdateResponse>> Update(
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ActivationJobUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ActivationJobUpdateResponse>> Update(
        string activationJobID,
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/activation_jobs</c>, but is otherwise the
/// same as <see cref="IActivationJobService.List(ActivationJobListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActivationJobListPage>> List(
        ActivationJobListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ActivationJobListParams, CancellationToken)"/>
    Task<HttpResponse<ActivationJobListPage>> List(
        string id,
        ActivationJobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}