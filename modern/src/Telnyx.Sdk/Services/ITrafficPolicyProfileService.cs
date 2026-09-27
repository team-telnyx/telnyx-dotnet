using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TrafficPolicyProfiles;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Traffic Policy Profiles operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITrafficPolicyProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITrafficPolicyProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrafficPolicyProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new traffic policy profile. At least one of `services`, `ip_ranges`, or
/// `domains` must be provided.
/// </summary>
    Task<TrafficPolicyProfileCreateResponse> Create(
        TrafficPolicyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details regarding a specific traffic policy profile.
/// </summary>
    Task<TrafficPolicyProfileRetrieveResponse> Retrieve(
        TrafficPolicyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TrafficPolicyProfileRetrieveParams, CancellationToken)"/>
    Task<TrafficPolicyProfileRetrieveResponse> Retrieve(
        string id,
        TrafficPolicyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified traffic policy profile and returns the updated profile.
/// </summary>
    Task<TrafficPolicyProfileUpdateResponse> Update(
        TrafficPolicyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TrafficPolicyProfileUpdateParams, CancellationToken)"/>
    Task<TrafficPolicyProfileUpdateResponse> Update(
        string id,
        TrafficPolicyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all traffic policy profiles belonging to the user that match the given
/// filters.
/// </summary>
    Task<TrafficPolicyProfileListPage> List(
        TrafficPolicyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified traffic policy profile from your account.
/// </summary>
    Task<TrafficPolicyProfileDeleteResponse> Delete(
        TrafficPolicyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TrafficPolicyProfileDeleteParams, CancellationToken)"/>
    Task<TrafficPolicyProfileDeleteResponse> Delete(
        string id,
        TrafficPolicyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all available PCEF services that can be used in traffic policy profiles.
/// </summary>
    Task<TrafficPolicyProfileListServicesPage> ListServices(
        TrafficPolicyProfileListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITrafficPolicyProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITrafficPolicyProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrafficPolicyProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /traffic_policy_profiles</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.Create(TrafficPolicyProfileCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileCreateResponse>> Create(
        TrafficPolicyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /traffic_policy_profiles/{id}</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.Retrieve(TrafficPolicyProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileRetrieveResponse>> Retrieve(
        TrafficPolicyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TrafficPolicyProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TrafficPolicyProfileRetrieveResponse>> Retrieve(
        string id,
        TrafficPolicyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /traffic_policy_profiles/{id}</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.Update(TrafficPolicyProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileUpdateResponse>> Update(
        TrafficPolicyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TrafficPolicyProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TrafficPolicyProfileUpdateResponse>> Update(
        string id,
        TrafficPolicyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /traffic_policy_profiles</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.List(TrafficPolicyProfileListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileListPage>> List(
        TrafficPolicyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /traffic_policy_profiles/{id}</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.Delete(TrafficPolicyProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileDeleteResponse>> Delete(
        TrafficPolicyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TrafficPolicyProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<TrafficPolicyProfileDeleteResponse>> Delete(
        string id,
        TrafficPolicyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /traffic_policy_profiles/services</c>, but is otherwise the
/// same as <see cref="ITrafficPolicyProfileService.ListServices(TrafficPolicyProfileListServicesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TrafficPolicyProfileListServicesPage>> ListServices(
        TrafficPolicyProfileListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}