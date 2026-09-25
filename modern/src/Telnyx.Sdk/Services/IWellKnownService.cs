using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WellKnown;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWellKnownService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWellKnownServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWellKnownService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// OAuth 2.0 Authorization Server Metadata (RFC 8414)
/// </summary>
    Task<WellKnownRetrieveAuthorizationServerMetadataResponse> RetrieveAuthorizationServerMetadata(
        WellKnownRetrieveAuthorizationServerMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// OAuth 2.0 Protected Resource Metadata for resource discovery
/// </summary>
    Task<WellKnownRetrieveProtectedResourceMetadataResponse> RetrieveProtectedResourceMetadata(
        WellKnownRetrieveProtectedResourceMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWellKnownService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWellKnownServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWellKnownServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /.well-known/oauth-authorization-server</c>, but is otherwise the
/// same as <see cref="IWellKnownService.RetrieveAuthorizationServerMetadata(WellKnownRetrieveAuthorizationServerMetadataParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WellKnownRetrieveAuthorizationServerMetadataResponse>> RetrieveAuthorizationServerMetadata(
        WellKnownRetrieveAuthorizationServerMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /.well-known/oauth-protected-resource</c>, but is otherwise the
/// same as <see cref="IWellKnownService.RetrieveProtectedResourceMetadata(WellKnownRetrieveProtectedResourceMetadataParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WellKnownRetrieveProtectedResourceMetadataResponse>> RetrieveProtectedResourceMetadata(
        WellKnownRetrieveProtectedResourceMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}