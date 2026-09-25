using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Fqdns;

namespace Telnyx.Sdk.Services;

/// <summary>
/// FQDN operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFqdnService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFqdnServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new FQDN record and attaches it to the specified connection.
/// </summary>
    Task<FqdnCreateResponse> Create(
        FqdnCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the details regarding a specific FQDN.
/// </summary>
    Task<FqdnRetrieveResponse> Retrieve(
        FqdnRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FqdnRetrieveParams, CancellationToken)"/>
    Task<FqdnRetrieveResponse> Retrieve(
        string id,
        FqdnRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the details of the specified FQDN record and returns the updated FQDN.
/// </summary>
    Task<FqdnUpdateResponse> Update(
        FqdnUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FqdnUpdateParams, CancellationToken)"/>
    Task<FqdnUpdateResponse> Update(
        string id,
        FqdnUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all FQDNs belonging to the user that match the given filters.
/// </summary>
    Task<FqdnListPage> List(
        FqdnListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified FQDN record from its connection.
/// </summary>
    Task<FqdnDeleteResponse> Delete(
        FqdnDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FqdnDeleteParams, CancellationToken)"/>
    Task<FqdnDeleteResponse> Delete(
        string id,
        FqdnDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFqdnService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFqdnServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /fqdns</c>, but is otherwise the
/// same as <see cref="IFqdnService.Create(FqdnCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnCreateResponse>> Create(
        FqdnCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fqdns/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnService.Retrieve(FqdnRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnRetrieveResponse>> Retrieve(
        FqdnRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FqdnRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FqdnRetrieveResponse>> Retrieve(
        string id,
        FqdnRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /fqdns/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnService.Update(FqdnUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnUpdateResponse>> Update(
        FqdnUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FqdnUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FqdnUpdateResponse>> Update(
        string id,
        FqdnUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fqdns</c>, but is otherwise the
/// same as <see cref="IFqdnService.List(FqdnListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnListPage>> List(
        FqdnListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /fqdns/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnService.Delete(FqdnDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnDeleteResponse>> Delete(
        FqdnDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FqdnDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FqdnDeleteResponse>> Delete(
        string id,
        FqdnDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}