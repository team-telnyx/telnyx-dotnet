using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPAssignmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPAssignmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAssignmentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Assigns a Global IP to a WireGuard peer so traffic destined for the IP is
/// delivered over that peer's tunnel. Assignment is asynchronous, so the request is
/// accepted and completes in the background.
/// </summary>
    Task<GlobalIPAssignmentCreateResponse> Create(
        GlobalIPAssignmentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single Global IP assignment, including the Global IP
/// and WireGuard peer it links.
/// </summary>
    Task<GlobalIPAssignmentRetrieveResponse> Retrieve(
        GlobalIPAssignmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPAssignmentRetrieveParams, CancellationToken)"/>
    Task<GlobalIPAssignmentRetrieveResponse> Retrieve(
        string id,
        GlobalIPAssignmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified Global IP assignment with the provided fields and returns
/// the updated assignment.
/// </summary>
    Task<GlobalIPAssignmentUpdateResponse> Update(
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(GlobalIPAssignmentUpdateParams, CancellationToken)"/>
    Task<GlobalIPAssignmentUpdateResponse> Update(
        string globalIPAssignmentID,
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your Global IP assignments, the links between Global
/// IPs and the WireGuard peers that receive their traffic.
/// </summary>
    Task<GlobalIPAssignmentListPage> List(
        GlobalIPAssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified Global IP assignment, detaching the Global IP from its
/// WireGuard peer.
/// </summary>
    Task<GlobalIPAssignmentDeleteResponse> Delete(
        GlobalIPAssignmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPAssignmentDeleteParams, CancellationToken)"/>
    Task<GlobalIPAssignmentDeleteResponse> Delete(
        string id,
        GlobalIPAssignmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPAssignmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPAssignmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAssignmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /global_ip_assignments</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentService.Create(GlobalIPAssignmentCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentCreateResponse>> Create(
        GlobalIPAssignmentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_assignments/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentService.Retrieve(GlobalIPAssignmentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentRetrieveResponse>> Retrieve(
        GlobalIPAssignmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPAssignmentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPAssignmentRetrieveResponse>> Retrieve(
        string id,
        GlobalIPAssignmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /global_ip_assignments/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentService.Update(GlobalIPAssignmentUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentUpdateResponse>> Update(
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(GlobalIPAssignmentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPAssignmentUpdateResponse>> Update(
        string globalIPAssignmentID,
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_assignments</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentService.List(GlobalIPAssignmentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentListPage>> List(
        GlobalIPAssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /global_ip_assignments/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentService.Delete(GlobalIPAssignmentDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentDeleteResponse>> Delete(
        GlobalIPAssignmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPAssignmentDeleteParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPAssignmentDeleteResponse>> Delete(
        string id,
        GlobalIPAssignmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}