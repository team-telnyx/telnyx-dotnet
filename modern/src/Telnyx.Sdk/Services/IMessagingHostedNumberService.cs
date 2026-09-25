using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingHostedNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessagingHostedNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingHostedNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingHostedNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve a specific messaging hosted number by its ID or phone number.
/// </summary>
    Task<MessagingHostedNumberRetrieveResponse> Retrieve(
        MessagingHostedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingHostedNumberRetrieveParams, CancellationToken)"/>
    Task<MessagingHostedNumberRetrieveResponse> Retrieve(
        string id,
        MessagingHostedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the messaging settings for a hosted number.
/// </summary>
    Task<MessagingHostedNumberUpdateResponse> Update(
        MessagingHostedNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingHostedNumberUpdateParams, CancellationToken)"/>
    Task<MessagingHostedNumberUpdateResponse> Update(
        string id,
        MessagingHostedNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all hosted numbers associated with the authenticated user.
/// </summary>
    Task<MessagingHostedNumberListPage> List(
        MessagingHostedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified hosted number from Telnyx messaging management.
/// </summary>
    Task<MessagingHostedNumberDeleteResponse> Delete(
        MessagingHostedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingHostedNumberDeleteParams, CancellationToken)"/>
    Task<MessagingHostedNumberDeleteResponse> Delete(
        string id,
        MessagingHostedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingHostedNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingHostedNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingHostedNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_hosted_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberService.Retrieve(MessagingHostedNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberRetrieveResponse>> Retrieve(
        MessagingHostedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingHostedNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberRetrieveResponse>> Retrieve(
        string id,
        MessagingHostedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /messaging_hosted_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberService.Update(MessagingHostedNumberUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberUpdateResponse>> Update(
        MessagingHostedNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingHostedNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberUpdateResponse>> Update(
        string id,
        MessagingHostedNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_hosted_numbers</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberService.List(MessagingHostedNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberListPage>> List(
        MessagingHostedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messaging_hosted_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberService.Delete(MessagingHostedNumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberDeleteResponse>> Delete(
        MessagingHostedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingHostedNumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberDeleteResponse>> Delete(
        string id,
        MessagingHostedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}