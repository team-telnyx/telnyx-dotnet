using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Messaging;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// Configure your phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the messaging product and messaging-profile assignment for the specified
/// phone number.
/// </summary>
    Task<MessagingRetrieveResponse> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<MessagingRetrieveResponse> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the messaging product, messaging profile, or both for the specified
/// phone number.
/// </summary>
    Task<MessagingUpdateResponse> Update(
        MessagingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingUpdateParams, CancellationToken)"/>
    Task<MessagingUpdateResponse> Update(
        string id,
        MessagingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns phone numbers with their current messaging product and messaging-profile
/// assignments.
/// </summary>
    Task<MessagingListPage> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/{id}/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.Retrieve(MessagingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /phone_numbers/{id}/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.Update(MessagingUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingUpdateResponse>> Update(
        MessagingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MessagingUpdateResponse>> Update(
        string id,
        MessagingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.List(MessagingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingListPage>> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}