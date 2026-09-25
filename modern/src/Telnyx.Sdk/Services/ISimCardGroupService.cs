using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardGroups;
using SimCardGroups = Telnyx.Sdk.Services.SimCardGroups;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIM Card Groups operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISimCardGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimCardGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    SimCardGroups::IActionService Actions { get; }

    /// <summary>
/// Creates a new SIM card group and returns it. Groups let you apply shared
/// settings to a set of SIM cards.
/// </summary>
    Task<SimCardGroupCreateResponse> Create(
        SimCardGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details regarding a specific SIM card group
/// </summary>
    Task<SimCardGroupRetrieveResponse> Retrieve(
        SimCardGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardGroupRetrieveParams, CancellationToken)"/>
    Task<SimCardGroupRetrieveResponse> Retrieve(
        string id,
        SimCardGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified SIM card group's attributes and returns the updated group.
/// </summary>
    Task<SimCardGroupUpdateResponse> Update(
        SimCardGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardGroupUpdateParams, CancellationToken)"/>
    Task<SimCardGroupUpdateResponse> Update(
        string id,
        SimCardGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all SIM card groups belonging to the user that match the given filters.
/// </summary>
    Task<SimCardGroupListPage> List(
        SimCardGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified SIM card group from your account.
/// </summary>
    Task<SimCardGroupDeleteResponse> Delete(
        SimCardGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardGroupDeleteParams, CancellationToken)"/>
    Task<SimCardGroupDeleteResponse> Delete(
        string id,
        SimCardGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISimCardGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimCardGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    SimCardGroups::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_groups</c>, but is otherwise the
/// same as <see cref="ISimCardGroupService.Create(SimCardGroupCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGroupCreateResponse>> Create(
        SimCardGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_groups/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardGroupService.Retrieve(SimCardGroupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGroupRetrieveResponse>> Retrieve(
        SimCardGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGroupRetrieveResponse>> Retrieve(
        string id,
        SimCardGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /sim_card_groups/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardGroupService.Update(SimCardGroupUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGroupUpdateResponse>> Update(
        SimCardGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGroupUpdateResponse>> Update(
        string id,
        SimCardGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_groups</c>, but is otherwise the
/// same as <see cref="ISimCardGroupService.List(SimCardGroupListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGroupListPage>> List(
        SimCardGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /sim_card_groups/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardGroupService.Delete(SimCardGroupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGroupDeleteResponse>> Delete(
        SimCardGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGroupDeleteResponse>> Delete(
        string id,
        SimCardGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}