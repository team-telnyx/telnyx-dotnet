using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VoiceClones;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Capture and manage voice identities as clones for use in text-to-speech synthesis.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceCloneService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceCloneServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceCloneService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new voice clone by capturing the voice identity of an existing voice
/// design. The clone can then be used for text-to-speech synthesis.
/// </summary>
    Task<VoiceCloneResponse> Create(
        VoiceCloneCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the name, language, or gender of a voice clone.
/// </summary>
    Task<VoiceCloneResponse> Update(
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoiceCloneUpdateParams, CancellationToken)"/>
    Task<VoiceCloneResponse> Update(
        string id,
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of voice clones belonging to the authenticated account.
/// </summary>
    Task<VoiceCloneListPage> List(
        VoiceCloneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a voice clone. This action cannot be undone.
/// </summary>
    Task Delete(
        VoiceCloneDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceCloneDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        VoiceCloneDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a new voice clone by uploading an audio file directly. Supported
/// formats: WAV, MP3, FLAC, OGG, M4A. For best results, provide 5–60 seconds of
/// clear speech (Ultra accepts up to 60 seconds; Qwen3TTS auto-trims to 10 seconds;
/// Minimax accepts up to 5 minutes). Maximum file size: 5MB for Telnyx, 20MB for
/// Minimax.
/// </summary>
    Task<VoiceCloneResponse> CreateFromUpload(
        VoiceCloneCreateFromUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Downloads the WAV audio sample that was used to create the voice clone.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> DownloadSample(
        VoiceCloneDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DownloadSample(VoiceCloneDownloadSampleParams, CancellationToken)"/>
    Task<HttpResponse> DownloadSample(
        string id,
        VoiceCloneDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoiceCloneService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceCloneServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceCloneServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /voice_clones</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.Create(VoiceCloneCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceCloneResponse>> Create(
        VoiceCloneCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /voice_clones/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.Update(VoiceCloneUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceCloneResponse>> Update(
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoiceCloneUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VoiceCloneResponse>> Update(
        string id,
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_clones</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.List(VoiceCloneListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceCloneListPage>> List(
        VoiceCloneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /voice_clones/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.Delete(VoiceCloneDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        VoiceCloneDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceCloneDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        VoiceCloneDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /voice_clones/from_upload</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.CreateFromUpload(VoiceCloneCreateFromUploadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceCloneResponse>> CreateFromUpload(
        VoiceCloneCreateFromUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_clones/{id}/sample</c>, but is otherwise the
/// same as <see cref="IVoiceCloneService.DownloadSample(VoiceCloneDownloadSampleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DownloadSample(
        VoiceCloneDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DownloadSample(VoiceCloneDownloadSampleParams, CancellationToken)"/>
    Task<HttpResponse> DownloadSample(
        string id,
        VoiceCloneDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}