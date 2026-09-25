using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections.LogMessages;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <summary>
/// External Connections operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILogMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILogMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve a log message for an external connection associated with your account.
/// </summary>
    Task<LogMessageRetrieveResponse> Retrieve(
        LogMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LogMessageRetrieveParams, CancellationToken)"/>
    Task<LogMessageRetrieveResponse> Retrieve(
        string id,
        LogMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of log messages for all external connections associated with
/// your account.
/// </summary>
    Task<LogMessageListPage> List(
        LogMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Dismiss a log message for an external connection associated with your account.
/// </summary>
    Task<LogMessageDismissResponse> Dismiss(
        LogMessageDismissParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Dismiss(LogMessageDismissParams, CancellationToken)"/>
    Task<LogMessageDismissResponse> Dismiss(
        string id,
        LogMessageDismissParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ILogMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILogMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/log_messages/{id}</c>, but is otherwise the
/// same as <see cref="ILogMessageService.Retrieve(LogMessageRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LogMessageRetrieveResponse>> Retrieve(
        LogMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LogMessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LogMessageRetrieveResponse>> Retrieve(
        string id,
        LogMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/log_messages</c>, but is otherwise the
/// same as <see cref="ILogMessageService.List(LogMessageListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LogMessageListPage>> List(
        LogMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /external_connections/log_messages/{id}</c>, but is otherwise the
/// same as <see cref="ILogMessageService.Dismiss(LogMessageDismissParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LogMessageDismissResponse>> Dismiss(
        LogMessageDismissParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Dismiss(LogMessageDismissParams, CancellationToken)"/>
    Task<HttpResponse<LogMessageDismissResponse>> Dismiss(
        string id,
        LogMessageDismissParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}