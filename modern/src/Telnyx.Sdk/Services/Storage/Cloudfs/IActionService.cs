using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Cloudfs;
using Telnyx.Sdk.Models.Storage.Cloudfs.Actions;

namespace Telnyx.Sdk.Services.Storage.Cloudfs;

/// <summary>
/// Manage CloudFS filesystems — JuiceFS-compatible filesystems backed by Telnyx Cloud Storage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Issues a new metadata access token for the filesystem and returns the full
/// filesystem, including the new `meta_token` and credential-bearing `meta_url`.
/// The previous token stops authenticating immediately; the metadata database and
/// S3 bucket are unchanged. The request takes no body. Allowed while the filesystem
/// is `ready` or `needs_format`; otherwise returns a `409`. Retrying with the same
/// `Idempotency-Key` within 24 hours replays the original response — including the
/// same token — instead of rotating again.
/// </summary>
    Task<CloudfsFilesystemResponseWrapper> RotateMetaToken(
        ActionRotateMetaTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RotateMetaToken(ActionRotateMetaTokenParams, CancellationToken)"/>
    Task<CloudfsFilesystemResponseWrapper> RotateMetaToken(
        string id,
        ActionRotateMetaTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/cloudfs/{id}/actions/rotate-meta-token</c>, but is otherwise the
/// same as <see cref="IActionService.RotateMetaToken(ActionRotateMetaTokenParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfsFilesystemResponseWrapper>> RotateMetaToken(
        ActionRotateMetaTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RotateMetaToken(ActionRotateMetaTokenParams, CancellationToken)"/>
    Task<HttpResponse<CloudfsFilesystemResponseWrapper>> RotateMetaToken(
        string id,
        ActionRotateMetaTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}