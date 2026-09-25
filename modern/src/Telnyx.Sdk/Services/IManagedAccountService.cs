using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ManagedAccounts;
using ManagedAccounts = Telnyx.Sdk.Services.ManagedAccounts;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Managed Accounts operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IManagedAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IManagedAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IManagedAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ManagedAccounts::IActionService Actions { get; }

    /// <summary>
/// Create a new managed account owned by the authenticated user. You need to be
/// explictly approved by Telnyx in order to become a manager account.
/// </summary>
    Task<ManagedAccountCreateResponse> Create(
        ManagedAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of a single managed account.
/// </summary>
    Task<ManagedAccountRetrieveResponse> Retrieve(
        ManagedAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ManagedAccountRetrieveParams, CancellationToken)"/>
    Task<ManagedAccountRetrieveResponse> Retrieve(
        string id,
        ManagedAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified managed account's attributes and returns the updated
/// account.
/// </summary>
    Task<ManagedAccountUpdateResponse> Update(
        ManagedAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ManagedAccountUpdateParams, CancellationToken)"/>
    Task<ManagedAccountUpdateResponse> Update(
        string id,
        ManagedAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the accounts managed by the current user. Users need to be explictly
/// approved by Telnyx in order to become manager accounts.
/// </summary>
    Task<ManagedAccountListPage> List(
        ManagedAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Display information about allocatable global outbound channels for the current
/// user. Only usable by account managers.
/// </summary>
    Task<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse> GetAllocatableGlobalOutboundChannels(
        ManagedAccountGetAllocatableGlobalOutboundChannelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the amount of allocatable global outbound channels allocated to a
/// specific managed account.
/// </summary>
    Task<ManagedAccountUpdateGlobalChannelLimitResponse> UpdateGlobalChannelLimit(
        ManagedAccountUpdateGlobalChannelLimitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateGlobalChannelLimit(ManagedAccountUpdateGlobalChannelLimitParams, CancellationToken)"/>
    Task<ManagedAccountUpdateGlobalChannelLimitResponse> UpdateGlobalChannelLimit(
        string id,
        ManagedAccountUpdateGlobalChannelLimitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IManagedAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IManagedAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IManagedAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ManagedAccounts::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /managed_accounts</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.Create(ManagedAccountCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountCreateResponse>> Create(
        ManagedAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /managed_accounts/{id}</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.Retrieve(ManagedAccountRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountRetrieveResponse>> Retrieve(
        ManagedAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ManagedAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ManagedAccountRetrieveResponse>> Retrieve(
        string id,
        ManagedAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /managed_accounts/{id}</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.Update(ManagedAccountUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountUpdateResponse>> Update(
        ManagedAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ManagedAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ManagedAccountUpdateResponse>> Update(
        string id,
        ManagedAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /managed_accounts</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.List(ManagedAccountListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountListPage>> List(
        ManagedAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /managed_accounts/allocatable_global_outbound_channels</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.GetAllocatableGlobalOutboundChannels(ManagedAccountGetAllocatableGlobalOutboundChannelsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse>> GetAllocatableGlobalOutboundChannels(
        ManagedAccountGetAllocatableGlobalOutboundChannelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /managed_accounts/{id}/update_global_channel_limit</c>, but is otherwise the
/// same as <see cref="IManagedAccountService.UpdateGlobalChannelLimit(ManagedAccountUpdateGlobalChannelLimitParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ManagedAccountUpdateGlobalChannelLimitResponse>> UpdateGlobalChannelLimit(
        ManagedAccountUpdateGlobalChannelLimitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateGlobalChannelLimit(ManagedAccountUpdateGlobalChannelLimitParams, CancellationToken)"/>
    Task<HttpResponse<ManagedAccountUpdateGlobalChannelLimitResponse>> UpdateGlobalChannelLimit(
        string id,
        ManagedAccountUpdateGlobalChannelLimitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}