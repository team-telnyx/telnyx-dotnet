using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Media;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Media Storage operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMediaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMediaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the information about a stored media file.
/// </summary>
    Task<MediaRetrieveResponse> Retrieve(
        MediaRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MediaRetrieveParams, CancellationToken)"/>
    Task<MediaRetrieveResponse> Retrieve(
        string mediaName,
        MediaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified stored media file and returns the updated resource.
/// </summary>
    Task<MediaUpdateResponse> Update(
        MediaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MediaUpdateParams, CancellationToken)"/>
    Task<MediaUpdateResponse> Update(
        string mediaName,
        MediaUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of the media files stored on your account, with support for
/// filtering.
/// </summary>
    Task<MediaListResponse> List(
        MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified media file from storage.
/// </summary>
    Task Delete(
        MediaDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MediaDeleteParams, CancellationToken)"/>
    Task Delete(
        string mediaName,
        MediaDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Downloads the raw content of the specified stored media file.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Download(
        MediaDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(MediaDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string mediaName,
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Upload media file to Telnyx so it can be used with other Telnyx services
/// </summary>
    Task<MediaUploadResponse> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMediaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMediaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /media/{media_name}</c>, but is otherwise the
/// same as <see cref="IMediaService.Retrieve(MediaRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MediaRetrieveResponse>> Retrieve(
        MediaRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MediaRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MediaRetrieveResponse>> Retrieve(
        string mediaName,
        MediaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /media/{media_name}</c>, but is otherwise the
/// same as <see cref="IMediaService.Update(MediaUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MediaUpdateResponse>> Update(
        MediaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MediaUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MediaUpdateResponse>> Update(
        string mediaName,
        MediaUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /media</c>, but is otherwise the
/// same as <see cref="IMediaService.List(MediaListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MediaListResponse>> List(
        MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /media/{media_name}</c>, but is otherwise the
/// same as <see cref="IMediaService.Delete(MediaDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        MediaDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MediaDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string mediaName,
        MediaDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /media/{media_name}/download</c>, but is otherwise the
/// same as <see cref="IMediaService.Download(MediaDownloadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Download(
        MediaDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(MediaDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string mediaName,
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /media</c>, but is otherwise the
/// same as <see cref="IMediaService.Upload(MediaUploadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MediaUploadResponse>> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}