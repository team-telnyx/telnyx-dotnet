using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging;

namespace Telnyx.Sdk.Services.MobilePhoneNumbers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
/// Returns the messaging configuration for the specified mobile phone number.
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
/// Returns mobile phone numbers with their current messaging configuration.
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
/// Returns a raw HTTP response for <c>get /mobile_phone_numbers/{id}/messaging</c>, but is otherwise the
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
/// Returns a raw HTTP response for <c>get /mobile_phone_numbers/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.List(MessagingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingListPage>> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}