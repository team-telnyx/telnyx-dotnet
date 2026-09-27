using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingOptouts;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Opt-Out Management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingOptoutService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingOptoutServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingOptoutService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a paginated list of opt-out blocks created when message recipients opt
/// out. Supports filtering and optional redaction of recipient numbers.
/// </summary>
    Task<MessagingOptoutListPage> List(
        MessagingOptoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingOptoutService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingOptoutServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingOptoutServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_optouts</c>, but is otherwise the
/// same as <see cref="IMessagingOptoutService.List(MessagingOptoutListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingOptoutListPage>> List(
        MessagingOptoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}