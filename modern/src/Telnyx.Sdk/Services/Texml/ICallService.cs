using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Calls;

namespace Telnyx.Sdk.Services.Texml;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Initiate an outbound TeXML call using a TeXML application connection ID, not an
/// account SID. Request parameter names are case-sensitive. From and To are
/// required; Texml supplies inline instructions and Url overrides the application
/// XML request URL. When neither is supplied, the application configuration
/// supplies the instructions. The response is a flat call object without a data
/// wrapper.
/// </summary>
    Task<CallCreateResponse> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CallCreateParams, CancellationToken)"/>
    Task<CallCreateResponse> Create(
        string connectionID,
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/calls/{connection_id}</c>, but is otherwise the
/// same as <see cref="ICallService.Create(CallCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallCreateResponse>> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CallCreateParams, CancellationToken)"/>
    Task<HttpResponse<CallCreateResponse>> Create(
        string connectionID,
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}