using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingUrlDomains;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Messaging URL Domains
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingUrlDomainService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingUrlDomainServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingUrlDomainService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the URL domains available to the authenticated account for message URL
/// shortening.
/// </summary>
    Task<MessagingUrlDomainListPage> List(
        MessagingUrlDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingUrlDomainService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingUrlDomainServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingUrlDomainServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_url_domains</c>, but is otherwise the
/// same as <see cref="IMessagingUrlDomainService.List(MessagingUrlDomainListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingUrlDomainListPage>> List(
        MessagingUrlDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}