using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Settings;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces;

/// <summary>
/// How a namespace's summaries are written.
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
/// What is currently set for this namespace. `instructions: null` means none are
/// set and summaries use the neutral default.
/// </summary>
    Task<NamespaceSettingsResponse> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SettingListParams, CancellationToken)"/>
    Task<NamespaceSettingsResponse> List(
        string namespace_,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Only the fields you send are changed; anything omitted is left as it is, so `{}`
/// changes nothing. Sending `instructions: null`, or an empty or whitespace-only
/// string, clears them and returns summaries to the neutral default.
/// 
/// <para>Instructions are capped at 2000 characters. A longer note is refused
/// rather than truncated, because a note cut mid-sentence is a worse steer than
/// none. A change reaches each summary the next time that summary is regenerated,
/// not immediately.</para>
/// </summary>
    Task<NamespaceSettingsResponse> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(SettingPatchAllParams, CancellationToken)"/>
    Task<NamespaceSettingsResponse> PatchAll(
        string namespace_,
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
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.List(SettingListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NamespaceSettingsResponse>> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SettingListParams, CancellationToken)"/>
    Task<HttpResponse<NamespaceSettingsResponse>> List(
        string namespace_,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/memory/namespaces/{namespace}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.PatchAll(SettingPatchAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NamespaceSettingsResponse>> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(SettingPatchAllParams, CancellationToken)"/>
    Task<HttpResponse<NamespaceSettingsResponse>> PatchAll(
        string namespace_,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}