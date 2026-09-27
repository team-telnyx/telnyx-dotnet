using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Collections.Settings;

namespace Telnyx.Sdk.Services.AI.Collections;

/// <summary>
/// Create and manage logical collections of your Telnyx data, tune retrieval settings,
/// manage sources, and run collection-scoped semantic search.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Replaces the collection's retrieval settings.
/// </summary>
    Task<SettingsEnvelope> Create(
        SettingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SettingCreateParams, CancellationToken)"/>
    Task<SettingsEnvelope> Create(
        string uuid,
        SettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the retrieval settings for a collection.
/// </summary>
    Task<SettingsEnvelope> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SettingListParams, CancellationToken)"/>
    Task<SettingsEnvelope> List(
        string uuid,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Partially updates the collection's retrieval settings.
/// </summary>
    Task<SettingsEnvelope> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(SettingPatchAllParams, CancellationToken)"/>
    Task<SettingsEnvelope> PatchAll(
        string uuid,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/collections/{uuid}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.Create(SettingCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SettingsEnvelope>> Create(
        SettingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SettingCreateParams, CancellationToken)"/>
    Task<HttpResponse<SettingsEnvelope>> Create(
        string uuid,
        SettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/collections/{uuid}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.List(SettingListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SettingsEnvelope>> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SettingListParams, CancellationToken)"/>
    Task<HttpResponse<SettingsEnvelope>> List(
        string uuid,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/collections/{uuid}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.PatchAll(SettingPatchAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SettingsEnvelope>> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(SettingPatchAllParams, CancellationToken)"/>
    Task<HttpResponse<SettingsEnvelope>> PatchAll(
        string uuid,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}