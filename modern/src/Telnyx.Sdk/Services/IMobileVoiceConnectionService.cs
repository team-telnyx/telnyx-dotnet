using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobileVoiceConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Mobile voice connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMobileVoiceConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMobileVoiceConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobileVoiceConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new mobile voice connection with the provided configuration and
/// returns the created connection.
/// </summary>
    Task<MobileVoiceConnectionCreateResponse> Create(
        MobileVoiceConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a specific mobile voice connection.
/// </summary>
    Task<MobileVoiceConnectionRetrieveResponse> Retrieve(
        MobileVoiceConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobileVoiceConnectionRetrieveParams, CancellationToken)"/>
    Task<MobileVoiceConnectionRetrieveResponse> Retrieve(
        string id,
        MobileVoiceConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the settings of a specific mobile voice connection.
/// </summary>
    Task<MobileVoiceConnectionUpdateResponse> Update(
        MobileVoiceConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MobileVoiceConnectionUpdateParams, CancellationToken)"/>
    Task<MobileVoiceConnectionUpdateResponse> Update(
        string id,
        MobileVoiceConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of mobile voice connections on your account.
/// </summary>
    Task<MobileVoiceConnectionListPage> List(
        MobileVoiceConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a mobile voice connection from your account.
/// </summary>
    Task<MobileVoiceConnectionDeleteResponse> Delete(
        MobileVoiceConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MobileVoiceConnectionDeleteParams, CancellationToken)"/>
    Task<MobileVoiceConnectionDeleteResponse> Delete(
        string id,
        MobileVoiceConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMobileVoiceConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMobileVoiceConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobileVoiceConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/mobile_voice_connections</c>, but is otherwise the
/// same as <see cref="IMobileVoiceConnectionService.Create(MobileVoiceConnectionCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileVoiceConnectionCreateResponse>> Create(
        MobileVoiceConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/mobile_voice_connections/{id}</c>, but is otherwise the
/// same as <see cref="IMobileVoiceConnectionService.Retrieve(MobileVoiceConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileVoiceConnectionRetrieveResponse>> Retrieve(
        MobileVoiceConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobileVoiceConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MobileVoiceConnectionRetrieveResponse>> Retrieve(
        string id,
        MobileVoiceConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/mobile_voice_connections/{id}</c>, but is otherwise the
/// same as <see cref="IMobileVoiceConnectionService.Update(MobileVoiceConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileVoiceConnectionUpdateResponse>> Update(
        MobileVoiceConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MobileVoiceConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MobileVoiceConnectionUpdateResponse>> Update(
        string id,
        MobileVoiceConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/mobile_voice_connections</c>, but is otherwise the
/// same as <see cref="IMobileVoiceConnectionService.List(MobileVoiceConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileVoiceConnectionListPage>> List(
        MobileVoiceConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /v2/mobile_voice_connections/{id}</c>, but is otherwise the
/// same as <see cref="IMobileVoiceConnectionService.Delete(MobileVoiceConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileVoiceConnectionDeleteResponse>> Delete(
        MobileVoiceConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MobileVoiceConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MobileVoiceConnectionDeleteResponse>> Delete(
        string id,
        MobileVoiceConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}