using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailDomains.Webhooks;

namespace Telnyx.Sdk.Services.EmailDomains;

/// <summary>
/// Per-domain webhook endpoints with event subscriptions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a webhook endpoint subscribed to a specific allowlist of event types.
/// Both `email.*` events (published by email-api) and `email_domain.*` events
/// (published by this service) flow through the same webhooks.
/// </summary>
    Task<EmailWebhookResponse> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(WebhookCreateParams, CancellationToken)"/>
    Task<EmailWebhookResponse> Create(
        string domainID,
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the webhook subscription identified by ID within the specified email
/// domain.
/// </summary>
    Task<EmailWebhookResponse> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<EmailWebhookResponse> Retrieve(
        string id,
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update a webhook's URL and/or event subscription. A webhook is bound to its
/// domain — `domain_id` is not mutable.
/// </summary>
    Task<EmailWebhookResponse> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<EmailWebhookResponse> Update(
        string id,
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of webhook subscriptions scoped to the email domain.
/// Results can be sorted by creation time.
/// </summary>
    Task<WebhookListPage> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(WebhookListParams, CancellationToken)"/>
    Task<WebhookListPage> List(
        string domainID,
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the webhook subscription identified by ID within the specified email
/// domain and returns the deleted subscription.
/// </summary>
    Task<EmailWebhookResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<EmailWebhookResponse> Delete(
        string id,
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_domains/{domain_id}/webhooks</c>, but is otherwise the
/// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailWebhookResponse>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(WebhookCreateParams, CancellationToken)"/>
    Task<HttpResponse<EmailWebhookResponse>> Create(
        string domainID,
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains/{domain_id}/webhooks/{id}</c>, but is otherwise the
/// same as <see cref="IWebhookService.Retrieve(WebhookRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailWebhookResponse>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailWebhookResponse>> Retrieve(
        string id,
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_domains/{domain_id}/webhooks/{id}</c>, but is otherwise the
/// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailWebhookResponse>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EmailWebhookResponse>> Update(
        string id,
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains/{domain_id}/webhooks</c>, but is otherwise the
/// same as <see cref="IWebhookService.List(WebhookListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WebhookListPage>> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(WebhookListParams, CancellationToken)"/>
    Task<HttpResponse<WebhookListPage>> List(
        string domainID,
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_domains/{domain_id}/webhooks/{id}</c>, but is otherwise the
/// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailWebhookResponse>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse<EmailWebhookResponse>> Delete(
        string id,
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}