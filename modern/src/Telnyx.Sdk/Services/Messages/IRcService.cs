using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messages.Rcs;

namespace Telnyx.Sdk.Services.Messages;

/// <summary>
/// Send RCS messages
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Generate a deeplink URL that can be used to start an RCS conversation with a
/// specific agent.
/// </summary>
    Task<RcGenerateDeeplinkResponse> GenerateDeeplink(
        RcGenerateDeeplinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateDeeplink(RcGenerateDeeplinkParams, CancellationToken)"/>
    Task<RcGenerateDeeplinkResponse> GenerateDeeplink(
        string agentID,
        RcGenerateDeeplinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Queues an outbound RCS message through the selected RCS agent. Check recipient
/// capabilities before sending features that require RCS support.
/// </summary>
    Task<RcSendResponse> Send(
        RcSendParams parameters, CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messages/rcs/deeplinks/{agent_id}</c>, but is otherwise the
/// same as <see cref="IRcService.GenerateDeeplink(RcGenerateDeeplinkParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RcGenerateDeeplinkResponse>> GenerateDeeplink(
        RcGenerateDeeplinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateDeeplink(RcGenerateDeeplinkParams, CancellationToken)"/>
    Task<HttpResponse<RcGenerateDeeplinkResponse>> GenerateDeeplink(
        string agentID,
        RcGenerateDeeplinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/rcs</c>, but is otherwise the
/// same as <see cref="IRcService.Send(RcSendParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RcSendResponse>> Send(
        RcSendParams parameters, CancellationToken cancellationToken = default
    )
    ;
}