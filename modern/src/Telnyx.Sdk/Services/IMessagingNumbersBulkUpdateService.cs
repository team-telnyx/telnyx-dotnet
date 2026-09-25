using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingNumbersBulkUpdates;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Configure your phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingNumbersBulkUpdateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingNumbersBulkUpdateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingNumbersBulkUpdateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Starts a bulk update of messaging-profile assignments for the supplied phone
/// numbers. The response identifies the order used to monitor processing.
/// </summary>
    Task<MessagingNumbersBulkUpdateCreateResponse> Create(
        MessagingNumbersBulkUpdateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns processing status and results for a bulk messaging-settings update
/// order.
/// </summary>
    Task<MessagingNumbersBulkUpdateRetrieveResponse> Retrieve(
        MessagingNumbersBulkUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingNumbersBulkUpdateRetrieveParams, CancellationToken)"/>
    Task<MessagingNumbersBulkUpdateRetrieveResponse> Retrieve(
        string orderID,
        MessagingNumbersBulkUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingNumbersBulkUpdateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingNumbersBulkUpdateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingNumbersBulkUpdateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_numbers_bulk_updates</c>, but is otherwise the
/// same as <see cref="IMessagingNumbersBulkUpdateService.Create(MessagingNumbersBulkUpdateCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingNumbersBulkUpdateCreateResponse>> Create(
        MessagingNumbersBulkUpdateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_numbers_bulk_updates/{order_id}</c>, but is otherwise the
/// same as <see cref="IMessagingNumbersBulkUpdateService.Retrieve(MessagingNumbersBulkUpdateRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingNumbersBulkUpdateRetrieveResponse>> Retrieve(
        MessagingNumbersBulkUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingNumbersBulkUpdateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingNumbersBulkUpdateRetrieveResponse>> Retrieve(
        string orderID,
        MessagingNumbersBulkUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}