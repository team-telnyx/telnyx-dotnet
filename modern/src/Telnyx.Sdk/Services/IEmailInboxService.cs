using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes;
using EmailInboxes = Telnyx.Sdk.Services.EmailInboxes;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Create and manage agent inboxes, retrieve inbound messages and threads, and reply
/// to or forward messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailInboxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailInboxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailInboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    EmailInboxes::IDraftService Drafts { get; }

    EmailInboxes::IFilterService Filters { get; }

    EmailInboxes::IMessageService Messages { get; }

    EmailInboxes::IThreadService Threads { get; }

    /// <summary>
/// Creates an inbox on an inbound-enabled domain. When `domain_id` is omitted,
/// Telnyx allocates the account's shared inbound subdomain so the inbox is
/// immediately usable without customer DNS setup. When `username` is omitted, a
/// unique username is generated.
/// </summary>
    Task<EmailInboxResponse> Create(
        EmailInboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns an account-scoped, non-deleted inbox. Missing and foreign inboxes are
/// indistinguishable.
/// </summary>
    Task<EmailInboxResponse> Retrieve(
        EmailInboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailInboxRetrieveParams, CancellationToken)"/>
    Task<EmailInboxResponse> Retrieve(
        string id,
        EmailInboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the account's non-deleted inboxes newest first using stable cursor
/// pagination.
/// </summary>
    Task<EmailInboxListPage> List(
        EmailInboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Soft-deletes an account-scoped inbox. Its address remains reserved and the inbox
/// is no longer returned by list or get operations.
/// </summary>
    Task Delete(
        EmailInboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailInboxDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EmailInboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailInboxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailInboxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailInboxServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    EmailInboxes::IDraftServiceWithRawResponse Drafts { get; }

    EmailInboxes::IFilterServiceWithRawResponse Filters { get; }

    EmailInboxes::IMessageServiceWithRawResponse Messages { get; }

    EmailInboxes::IThreadServiceWithRawResponse Threads { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes</c>, but is otherwise the
/// same as <see cref="IEmailInboxService.Create(EmailInboxCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailInboxResponse>> Create(
        EmailInboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{id}</c>, but is otherwise the
/// same as <see cref="IEmailInboxService.Retrieve(EmailInboxRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailInboxResponse>> Retrieve(
        EmailInboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailInboxRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailInboxResponse>> Retrieve(
        string id,
        EmailInboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes</c>, but is otherwise the
/// same as <see cref="IEmailInboxService.List(EmailInboxListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailInboxListPage>> List(
        EmailInboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_inboxes/{id}</c>, but is otherwise the
/// same as <see cref="IEmailInboxService.Delete(EmailInboxDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        EmailInboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailInboxDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EmailInboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}