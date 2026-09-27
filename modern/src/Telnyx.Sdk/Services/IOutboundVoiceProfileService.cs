using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OutboundVoiceProfiles;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Outbound voice profiles operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOutboundVoiceProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOutboundVoiceProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOutboundVoiceProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new outbound voice profile defining calling permissions, destinations,
/// and limits for outbound calls, and returns the created profile.
/// </summary>
    Task<OutboundVoiceProfileCreateResponse> Create(
        OutboundVoiceProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing outbound voice profile.
/// </summary>
    Task<OutboundVoiceProfileRetrieveResponse> Retrieve(
        OutboundVoiceProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OutboundVoiceProfileRetrieveParams, CancellationToken)"/>
    Task<OutboundVoiceProfileRetrieveResponse> Retrieve(
        string id,
        OutboundVoiceProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates an existing outbound voice profile.
/// </summary>
    Task<OutboundVoiceProfileUpdateResponse> Update(
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(OutboundVoiceProfileUpdateParams, CancellationToken)"/>
    Task<OutboundVoiceProfileUpdateResponse> Update(
        string id,
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all outbound voice profiles belonging to the user that match the given
/// filters.
/// </summary>
    Task<OutboundVoiceProfileListPage> List(
        OutboundVoiceProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an existing outbound voice profile.
/// </summary>
    Task<OutboundVoiceProfileDeleteResponse> Delete(
        OutboundVoiceProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OutboundVoiceProfileDeleteParams, CancellationToken)"/>
    Task<OutboundVoiceProfileDeleteResponse> Delete(
        string id,
        OutboundVoiceProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOutboundVoiceProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOutboundVoiceProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOutboundVoiceProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /outbound_voice_profiles</c>, but is otherwise the
/// same as <see cref="IOutboundVoiceProfileService.Create(OutboundVoiceProfileCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OutboundVoiceProfileCreateResponse>> Create(
        OutboundVoiceProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /outbound_voice_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IOutboundVoiceProfileService.Retrieve(OutboundVoiceProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OutboundVoiceProfileRetrieveResponse>> Retrieve(
        OutboundVoiceProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OutboundVoiceProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OutboundVoiceProfileRetrieveResponse>> Retrieve(
        string id,
        OutboundVoiceProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /outbound_voice_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IOutboundVoiceProfileService.Update(OutboundVoiceProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OutboundVoiceProfileUpdateResponse>> Update(
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(OutboundVoiceProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<OutboundVoiceProfileUpdateResponse>> Update(
        string id,
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /outbound_voice_profiles</c>, but is otherwise the
/// same as <see cref="IOutboundVoiceProfileService.List(OutboundVoiceProfileListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OutboundVoiceProfileListPage>> List(
        OutboundVoiceProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /outbound_voice_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IOutboundVoiceProfileService.Delete(OutboundVoiceProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OutboundVoiceProfileDeleteResponse>> Delete(
        OutboundVoiceProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OutboundVoiceProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<OutboundVoiceProfileDeleteResponse>> Delete(
        string id,
        OutboundVoiceProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}