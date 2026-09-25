using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <summary>
/// Phone-number reputation monitoring (spam-score lookup and tracking).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRemediationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRemediationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRemediationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Submit a batch of phone numbers belonging to this enterprise for reputation
/// remediation. The request is accepted asynchronously: this endpoint returns `202`
/// with the persisted request id, then the request transitions through processing
/// states until completion. Use the GET endpoints to poll status and per-number
/// results.
/// 
/// <para>Each phone number must be in E.164 format and belong to this enterprise. A
/// number that already has an in-flight remediation request is rejected.</para>
/// </summary>
    Task<RemediationRequestWrapped> Create(
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(RemediationCreateParams, CancellationToken)"/>
    Task<RemediationRequestWrapped> Create(
        string enterpriseID,
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the full detail of a remediation request, including current status,
/// per-number results (once available), and submission metadata.
/// </summary>
    Task<RemediationRequestWrapped> Retrieve(
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RemediationRetrieveParams, CancellationToken)"/>
    Task<RemediationRequestWrapped> Retrieve(
        string remediationID,
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Paginated list of remediation requests for this enterprise. List items omit
/// per-number results and webhook URLs to keep the response small; call GET by id
/// for full detail. Supports JSON:API pagination and optional filters on status and
/// created-at range.
/// </summary>
    Task<RemediationListPage> List(
        RemediationListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RemediationListParams, CancellationToken)"/>
    Task<RemediationListPage> List(
        string enterpriseID,
        RemediationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRemediationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRemediationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRemediationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/reputation/remediation</c>, but is otherwise the
/// same as <see cref="IRemediationService.Create(RemediationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RemediationRequestWrapped>> Create(
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(RemediationCreateParams, CancellationToken)"/>
    Task<HttpResponse<RemediationRequestWrapped>> Create(
        string enterpriseID,
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/reputation/remediation/{remediation_id}</c>, but is otherwise the
/// same as <see cref="IRemediationService.Retrieve(RemediationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RemediationRequestWrapped>> Retrieve(
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RemediationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RemediationRequestWrapped>> Retrieve(
        string remediationID,
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/reputation/remediation</c>, but is otherwise the
/// same as <see cref="IRemediationService.List(RemediationListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RemediationListPage>> List(
        RemediationListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RemediationListParams, CancellationToken)"/>
    Task<HttpResponse<RemediationListPage>> List(
        string enterpriseID,
        RemediationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}