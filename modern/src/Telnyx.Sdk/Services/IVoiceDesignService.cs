using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VoiceDesigns;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Create and manage AI-generated voice designs using natural language prompts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceDesignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceDesignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceDesignService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new voice design (version 1) when `voice_design_id` is omitted. When
/// `voice_design_id` is provided, adds a new version to the existing design
/// instead. A design can have at most 50 versions.
/// </summary>
    Task<VoiceDesignResponse> Create(
        VoiceDesignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the latest version of a voice design, or a specific version when
/// `?version=N` is provided. The `id` parameter accepts either a UUID or the design
/// name.
/// </summary>
    Task<VoiceDesignResponse> Retrieve(
        VoiceDesignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceDesignRetrieveParams, CancellationToken)"/>
    Task<VoiceDesignResponse> Retrieve(
        string id,
        VoiceDesignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of voice designs belonging to the authenticated
/// account.
/// </summary>
    Task<VoiceDesignListPage> List(
        VoiceDesignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a voice design and all of its versions. This action cannot
/// be undone.
/// </summary>
    Task Delete(
        VoiceDesignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceDesignDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        VoiceDesignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a specific version of a voice design. The version number
/// must be a positive integer.
/// </summary>
    Task DeleteVersion(
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteVersion(VoiceDesignDeleteVersionParams, CancellationToken)"/>
    Task DeleteVersion(
        long version,
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Downloads the WAV audio sample for the voice design. Returns the latest
/// version's sample by default, or a specific version when `?version=N` is
/// provided. The `id` parameter accepts either a UUID or the design name.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> DownloadSample(
        VoiceDesignDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DownloadSample(VoiceDesignDownloadSampleParams, CancellationToken)"/>
    Task<HttpResponse> DownloadSample(
        string id,
        VoiceDesignDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the name of a voice design. All versions retain their other properties.
/// </summary>
    Task<VoiceDesignRenameResponse> Rename(
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Rename(VoiceDesignRenameParams, CancellationToken)"/>
    Task<VoiceDesignRenameResponse> Rename(
        string id,
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoiceDesignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceDesignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceDesignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /voice_designs</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.Create(VoiceDesignCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceDesignResponse>> Create(
        VoiceDesignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_designs/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.Retrieve(VoiceDesignRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceDesignResponse>> Retrieve(
        VoiceDesignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceDesignRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VoiceDesignResponse>> Retrieve(
        string id,
        VoiceDesignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_designs</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.List(VoiceDesignListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceDesignListPage>> List(
        VoiceDesignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /voice_designs/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.Delete(VoiceDesignDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        VoiceDesignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceDesignDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        VoiceDesignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /voice_designs/{id}/versions/{version}</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.DeleteVersion(VoiceDesignDeleteVersionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteVersion(
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteVersion(VoiceDesignDeleteVersionParams, CancellationToken)"/>
    Task<HttpResponse> DeleteVersion(
        long version,
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_designs/{id}/sample</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.DownloadSample(VoiceDesignDownloadSampleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DownloadSample(
        VoiceDesignDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DownloadSample(VoiceDesignDownloadSampleParams, CancellationToken)"/>
    Task<HttpResponse> DownloadSample(
        string id,
        VoiceDesignDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /voice_designs/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceDesignService.Rename(VoiceDesignRenameParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceDesignRenameResponse>> Rename(
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Rename(VoiceDesignRenameParams, CancellationToken)"/>
    Task<HttpResponse<VoiceDesignRenameResponse>> Rename(
        string id,
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}