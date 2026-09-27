using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAlphanumericSenderIDService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAlphanumericSenderIDServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlphanumericSenderIDService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new alphanumeric sender ID associated with a messaging profile.
/// </summary>
    Task<AlphanumericSenderIDCreateResponse> Create(
        AlphanumericSenderIDCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a specific alphanumeric sender ID.
/// </summary>
    Task<AlphanumericSenderIDRetrieveResponse> Retrieve(
        AlphanumericSenderIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AlphanumericSenderIDRetrieveParams, CancellationToken)"/>
    Task<AlphanumericSenderIDRetrieveResponse> Retrieve(
        string id,
        AlphanumericSenderIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all alphanumeric sender IDs for the authenticated user.
/// </summary>
    Task<AlphanumericSenderIDListPage> List(
        AlphanumericSenderIDListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete an alphanumeric sender ID and disassociate it from its messaging profile.
/// </summary>
    Task<AlphanumericSenderIDDeleteResponse> Delete(
        AlphanumericSenderIDDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AlphanumericSenderIDDeleteParams, CancellationToken)"/>
    Task<AlphanumericSenderIDDeleteResponse> Delete(
        string id,
        AlphanumericSenderIDDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAlphanumericSenderIDService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAlphanumericSenderIDServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlphanumericSenderIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /alphanumeric_sender_ids</c>, but is otherwise the
/// same as <see cref="IAlphanumericSenderIDService.Create(AlphanumericSenderIDCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AlphanumericSenderIDCreateResponse>> Create(
        AlphanumericSenderIDCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /alphanumeric_sender_ids/{id}</c>, but is otherwise the
/// same as <see cref="IAlphanumericSenderIDService.Retrieve(AlphanumericSenderIDRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AlphanumericSenderIDRetrieveResponse>> Retrieve(
        AlphanumericSenderIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AlphanumericSenderIDRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AlphanumericSenderIDRetrieveResponse>> Retrieve(
        string id,
        AlphanumericSenderIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /alphanumeric_sender_ids</c>, but is otherwise the
/// same as <see cref="IAlphanumericSenderIDService.List(AlphanumericSenderIDListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AlphanumericSenderIDListPage>> List(
        AlphanumericSenderIDListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /alphanumeric_sender_ids/{id}</c>, but is otherwise the
/// same as <see cref="IAlphanumericSenderIDService.Delete(AlphanumericSenderIDDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AlphanumericSenderIDDeleteResponse>> Delete(
        AlphanumericSenderIDDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AlphanumericSenderIDDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AlphanumericSenderIDDeleteResponse>> Delete(
        string id,
        AlphanumericSenderIDDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}