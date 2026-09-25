using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardGroups.Actions;

namespace Telnyx.Sdk.Services.SimCardGroups;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// This API allows fetching detailed information about a SIM card group action
/// resource to make follow-ups in an existing asynchronous operation.
/// </summary>
    Task<ActionRetrieveResponse> Retrieve(
        ActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ActionRetrieveParams, CancellationToken)"/>
    Task<ActionRetrieveResponse> Retrieve(
        string id,
        ActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API allows listing a paginated collection a SIM card group actions. It
/// allows to explore a collection of existing asynchronous operation using specific
/// filters.
/// </summary>
    Task<ActionListPage> List(
        ActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This action will asynchronously remove an existing Private Wireless Gateway
/// definition from a SIM card group. Completing this operation defines that all SIM
/// cards in the SIM card group will get their traffic handled by Telnyx's default
/// mobile network configuration.
/// </summary>
    Task<ActionRemovePrivateWirelessGatewayResponse> RemovePrivateWirelessGateway(
        ActionRemovePrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemovePrivateWirelessGateway(ActionRemovePrivateWirelessGatewayParams, CancellationToken)"/>
    Task<ActionRemovePrivateWirelessGatewayResponse> RemovePrivateWirelessGateway(
        string id,
        ActionRemovePrivateWirelessGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This action asynchronously removes the Wireless Blocklist assigned to a SIM Card
/// Group. The request returns `404` when the SIM Card Group does not exist and
/// `422` when no Wireless Blocklist is assigned.
/// </summary>
    Task<ActionRemoveWirelessBlocklistResponse> RemoveWirelessBlocklist(
        ActionRemoveWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemoveWirelessBlocklist(ActionRemoveWirelessBlocklistParams, CancellationToken)"/>
    Task<ActionRemoveWirelessBlocklistResponse> RemoveWirelessBlocklist(
        string id,
        ActionRemoveWirelessBlocklistParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This action will asynchronously assign a provisioned Private Wireless Gateway to
/// the SIM card group. Completing this operation defines that all SIM cards in the
/// SIM card group will get their traffic controlled by the associated Private
/// Wireless Gateway. This operation will also imply that new SIM cards assigned to
/// a group will inherit its network definitions. If it's moved to a different group
/// that doesn't have a Private Wireless Gateway, it'll use Telnyx's default mobile
/// network configuration.
/// </summary>
    Task<ActionSetPrivateWirelessGatewayResponse> SetPrivateWirelessGateway(
        ActionSetPrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetPrivateWirelessGateway(ActionSetPrivateWirelessGatewayParams, CancellationToken)"/>
    Task<ActionSetPrivateWirelessGatewayResponse> SetPrivateWirelessGateway(
        string id,
        ActionSetPrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This action asynchronously assigns a Wireless Blocklist to all SIMs in the SIM
/// Card Group. The request returns `404` when the SIM Card Group does not exist and
/// `422` when the Wireless Blocklist does not exist.
/// </summary>
    Task<ActionSetWirelessBlocklistResponse> SetWirelessBlocklist(
        ActionSetWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetWirelessBlocklist(ActionSetWirelessBlocklistParams, CancellationToken)"/>
    Task<ActionSetWirelessBlocklistResponse> SetWirelessBlocklist(
        string id,
        ActionSetWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_group_actions/{id}</c>, but is otherwise the
/// same as <see cref="IActionService.Retrieve(ActionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRetrieveResponse>> Retrieve(
        ActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ActionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ActionRetrieveResponse>> Retrieve(
        string id,
        ActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_group_actions</c>, but is otherwise the
/// same as <see cref="IActionService.List(ActionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionListPage>> List(
        ActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_groups/{id}/actions/remove_private_wireless_gateway</c>, but is otherwise the
/// same as <see cref="IActionService.RemovePrivateWirelessGateway(ActionRemovePrivateWirelessGatewayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRemovePrivateWirelessGatewayResponse>> RemovePrivateWirelessGateway(
        ActionRemovePrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemovePrivateWirelessGateway(ActionRemovePrivateWirelessGatewayParams, CancellationToken)"/>
    Task<HttpResponse<ActionRemovePrivateWirelessGatewayResponse>> RemovePrivateWirelessGateway(
        string id,
        ActionRemovePrivateWirelessGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_groups/{id}/actions/remove_wireless_blocklist</c>, but is otherwise the
/// same as <see cref="IActionService.RemoveWirelessBlocklist(ActionRemoveWirelessBlocklistParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRemoveWirelessBlocklistResponse>> RemoveWirelessBlocklist(
        ActionRemoveWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemoveWirelessBlocklist(ActionRemoveWirelessBlocklistParams, CancellationToken)"/>
    Task<HttpResponse<ActionRemoveWirelessBlocklistResponse>> RemoveWirelessBlocklist(
        string id,
        ActionRemoveWirelessBlocklistParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_groups/{id}/actions/set_private_wireless_gateway</c>, but is otherwise the
/// same as <see cref="IActionService.SetPrivateWirelessGateway(ActionSetPrivateWirelessGatewayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSetPrivateWirelessGatewayResponse>> SetPrivateWirelessGateway(
        ActionSetPrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetPrivateWirelessGateway(ActionSetPrivateWirelessGatewayParams, CancellationToken)"/>
    Task<HttpResponse<ActionSetPrivateWirelessGatewayResponse>> SetPrivateWirelessGateway(
        string id,
        ActionSetPrivateWirelessGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_groups/{id}/actions/set_wireless_blocklist</c>, but is otherwise the
/// same as <see cref="IActionService.SetWirelessBlocklist(ActionSetWirelessBlocklistParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSetWirelessBlocklistResponse>> SetWirelessBlocklist(
        ActionSetWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetWirelessBlocklist(ActionSetWirelessBlocklistParams, CancellationToken)"/>
    Task<HttpResponse<ActionSetWirelessBlocklistResponse>> SetWirelessBlocklist(
        string id,
        ActionSetWirelessBlocklistParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}