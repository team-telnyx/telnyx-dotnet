using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WebhookDeliveries;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Webhooks operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookDeliveryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookDeliveryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookDeliveryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Provides webhook_delivery debug data, such as timestamps, delivery status and
/// attempts.
/// </summary>
    Task<WebhookDeliveryRetrieveResponse> Retrieve(
        WebhookDeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WebhookDeliveryRetrieveParams, CancellationToken)"/>
    Task<WebhookDeliveryRetrieveResponse> Retrieve(
        string id,
        WebhookDeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists webhook_deliveries for the authenticated user
/// </summary>
    Task<WebhookDeliveryListPage> List(
        WebhookDeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWebhookDeliveryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookDeliveryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookDeliveryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /webhook_deliveries/{id}</c>, but is otherwise the
/// same as <see cref="IWebhookDeliveryService.Retrieve(WebhookDeliveryRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WebhookDeliveryRetrieveResponse>> Retrieve(
        WebhookDeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WebhookDeliveryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WebhookDeliveryRetrieveResponse>> Retrieve(
        string id,
        WebhookDeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /webhook_deliveries</c>, but is otherwise the
/// same as <see cref="IWebhookDeliveryService.List(WebhookDeliveryListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WebhookDeliveryListPage>> List(
        WebhookDeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}