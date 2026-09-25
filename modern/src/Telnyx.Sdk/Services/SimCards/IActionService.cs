using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCards.Actions;

namespace Telnyx.Sdk.Services.SimCards;

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
/// This API fetches detailed information about a SIM card action to follow-up on an
/// existing asynchronous operation.
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
/// This API lists a paginated collection of SIM card actions. It enables exploring
/// a collection of existing asynchronous operations using specific filters.
/// </summary>
    Task<ActionListPage> List(
        ActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API triggers an asynchronous operation to disable voice on SIM cards
/// belonging to a specified SIM Card Group.&lt;br/&gt; For each SIM Card a SIM Card
/// Action will be generated. The status of the SIM Card Actions can be followed
/// through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// 
/// <para>The overall status of the Bulk SIM Card Action can be followed through the
/// [List Bulk SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-bulk-sim-card-actions)
/// API. </para>
/// </summary>
    Task<ActionBulkDisableVoiceResponse> BulkDisableVoice(
        ActionBulkDisableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API triggers an asynchronous operation to enable voice on SIM cards
/// belonging to a specified SIM Card Group.&lt;br/&gt; For each SIM Card a SIM Card
/// Action will be generated. The status of the SIM Card Actions can be followed
/// through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// 
/// <para>The overall status of the Bulk SIM Card Action can be followed through the
/// [List Bulk SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-bulk-sim-card-actions)
/// API. </para>
/// </summary>
    Task<ActionBulkEnableVoiceResponse> BulkEnableVoice(
        ActionBulkEnableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API triggers an asynchronous operation to set a public IP for each of the
/// specified SIM cards.&lt;br/&gt; For each SIM Card a SIM Card Action will be
/// generated. The status of the SIM Card Action can be followed through the [List
/// SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionBulkSetPublicIpsResponse> BulkSetPublicIps(
        ActionBulkSetPublicIpsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API disables a SIM card, disconnecting it from the network and making it
/// impossible to consume data.&lt;br/&gt; The API will trigger an asynchronous
/// operation called a SIM Card Action. Transitioning to the disabled state may take
/// a period of time. The status of the SIM Card Action can be followed through the
/// [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionDisableResponse> Disable(
        ActionDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ActionDisableParams, CancellationToken)"/>
    Task<ActionDisableResponse> Disable(
        string id,
        ActionDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API disables voice calling on a SIM card. The SIM card will no longer be
/// able to make or receive calls.&lt;br/&gt; The API will trigger an asynchronous
/// operation called a SIM Card Action. The status of the SIM Card Action can be
/// followed through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionDisableVoiceResponse> DisableVoice(
        ActionDisableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DisableVoice(ActionDisableVoiceParams, CancellationToken)"/>
    Task<ActionDisableVoiceResponse> DisableVoice(
        string id,
        ActionDisableVoiceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API enables a SIM card, connecting it to the network and making it possible
/// to consume data.&lt;br/&gt; To enable a SIM card, it must be associated with a
/// SIM card group.&lt;br/&gt; The API will trigger an asynchronous operation called
/// a SIM Card Action. Transitioning to the enabled state may take a period of time.
/// The status of the SIM Card Action can be followed through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionEnableResponse> Enable(
        ActionEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ActionEnableParams, CancellationToken)"/>
    Task<ActionEnableResponse> Enable(
        string id,
        ActionEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API enables voice calling on a SIM card. When a
/// &lt;code&gt;connection_id&lt;/code&gt; is provided, the SIM is associated with
/// the specified Mobile Voice Connection. The connection must be owned by the same
/// user and of type &lt;code&gt;mobile_voice&lt;/code&gt;.&lt;br/&gt; The API will
/// trigger an asynchronous operation called a SIM Card Action. The status of the
/// SIM Card Action can be followed through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionEnableVoiceResponse> EnableVoice(
        ActionEnableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EnableVoice(ActionEnableVoiceParams, CancellationToken)"/>
    Task<ActionEnableVoiceResponse> EnableVoice(
        string id,
        ActionEnableVoiceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API removes an existing public IP from a SIM card. &lt;br/&gt;&lt;br/&gt;  The
/// API will trigger an asynchronous operation called a SIM Card Action. The status of
/// the SIM Card Action can be followed through the [List SIM Card Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionRemovePublicIPResponse> RemovePublicIP(
        ActionRemovePublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemovePublicIP(ActionRemovePublicIPParams, CancellationToken)"/>
    Task<ActionRemovePublicIPResponse> RemovePublicIP(
        string id,
        ActionRemovePublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API makes a SIM card reachable on the public internet by mapping a random
/// public IP to the SIM card. &lt;br/&gt;&lt;br/&gt;  The API will trigger an asynchronous
/// operation called a SIM Card Action. The status of the SIM Card Action can be followed
/// through the [List SIM Card Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API. &lt;br/&gt;&lt;br/&gt;  Setting a Public IP to a SIM Card incurs a charge
/// and will only succeed if the account has sufficient funds.
/// </summary>
    Task<ActionSetPublicIPResponse> SetPublicIP(
        ActionSetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetPublicIP(ActionSetPublicIPParams, CancellationToken)"/>
    Task<ActionSetPublicIPResponse> SetPublicIP(
        string id,
        ActionSetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// The SIM card will be able to connect to the network once the process to set it
/// to standby has been completed, thus making it possible to consume
/// data.&lt;br/&gt; To set a SIM card to standby, it must be associated with SIM
/// card group.&lt;br/&gt; The API will trigger an asynchronous operation called a
/// SIM Card Action. Transitioning to the standby state may take a period of time.
/// The status of the SIM Card Action can be followed through the [List SIM Card
/// Action](https://developers.telnyx.com/api-reference/sim-card-actions/list-sim-card-actions)
/// API.
/// </summary>
    Task<ActionSetStandbyResponse> SetStandby(
        ActionSetStandbyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetStandby(ActionSetStandbyParams, CancellationToken)"/>
    Task<ActionSetStandbyResponse> SetStandby(
        string id,
        ActionSetStandbyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// It validates whether SIM card registration codes are valid or not.
/// </summary>
    Task<ActionValidateRegistrationCodesResponse> ValidateRegistrationCodes(
        ActionValidateRegistrationCodesParams? parameters = null,
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
/// Returns a raw HTTP response for <c>get /sim_card_actions/{id}</c>, but is otherwise the
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
/// Returns a raw HTTP response for <c>get /sim_card_actions</c>, but is otherwise the
/// same as <see cref="IActionService.List(ActionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionListPage>> List(
        ActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/actions/bulk_disable_voice</c>, but is otherwise the
/// same as <see cref="IActionService.BulkDisableVoice(ActionBulkDisableVoiceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionBulkDisableVoiceResponse>> BulkDisableVoice(
        ActionBulkDisableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/actions/bulk_enable_voice</c>, but is otherwise the
/// same as <see cref="IActionService.BulkEnableVoice(ActionBulkEnableVoiceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionBulkEnableVoiceResponse>> BulkEnableVoice(
        ActionBulkEnableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/actions/bulk_set_public_ips</c>, but is otherwise the
/// same as <see cref="IActionService.BulkSetPublicIps(ActionBulkSetPublicIpsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionBulkSetPublicIpsResponse>> BulkSetPublicIps(
        ActionBulkSetPublicIpsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/disable</c>, but is otherwise the
/// same as <see cref="IActionService.Disable(ActionDisableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionDisableResponse>> Disable(
        ActionDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ActionDisableParams, CancellationToken)"/>
    Task<HttpResponse<ActionDisableResponse>> Disable(
        string id,
        ActionDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/disable_voice</c>, but is otherwise the
/// same as <see cref="IActionService.DisableVoice(ActionDisableVoiceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionDisableVoiceResponse>> DisableVoice(
        ActionDisableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DisableVoice(ActionDisableVoiceParams, CancellationToken)"/>
    Task<HttpResponse<ActionDisableVoiceResponse>> DisableVoice(
        string id,
        ActionDisableVoiceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/enable</c>, but is otherwise the
/// same as <see cref="IActionService.Enable(ActionEnableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEnableResponse>> Enable(
        ActionEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ActionEnableParams, CancellationToken)"/>
    Task<HttpResponse<ActionEnableResponse>> Enable(
        string id,
        ActionEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/enable_voice</c>, but is otherwise the
/// same as <see cref="IActionService.EnableVoice(ActionEnableVoiceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEnableVoiceResponse>> EnableVoice(
        ActionEnableVoiceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EnableVoice(ActionEnableVoiceParams, CancellationToken)"/>
    Task<HttpResponse<ActionEnableVoiceResponse>> EnableVoice(
        string id,
        ActionEnableVoiceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/remove_public_ip</c>, but is otherwise the
/// same as <see cref="IActionService.RemovePublicIP(ActionRemovePublicIPParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRemovePublicIPResponse>> RemovePublicIP(
        ActionRemovePublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RemovePublicIP(ActionRemovePublicIPParams, CancellationToken)"/>
    Task<HttpResponse<ActionRemovePublicIPResponse>> RemovePublicIP(
        string id,
        ActionRemovePublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/set_public_ip</c>, but is otherwise the
/// same as <see cref="IActionService.SetPublicIP(ActionSetPublicIPParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSetPublicIPResponse>> SetPublicIP(
        ActionSetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetPublicIP(ActionSetPublicIPParams, CancellationToken)"/>
    Task<HttpResponse<ActionSetPublicIPResponse>> SetPublicIP(
        string id,
        ActionSetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/{id}/actions/set_standby</c>, but is otherwise the
/// same as <see cref="IActionService.SetStandby(ActionSetStandbyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSetStandbyResponse>> SetStandby(
        ActionSetStandbyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SetStandby(ActionSetStandbyParams, CancellationToken)"/>
    Task<HttpResponse<ActionSetStandbyResponse>> SetStandby(
        string id,
        ActionSetStandbyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_cards/actions/validate_registration_codes</c>, but is otherwise the
/// same as <see cref="IActionService.ValidateRegistrationCodes(ActionValidateRegistrationCodesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionValidateRegistrationCodesResponse>> ValidateRegistrationCodes(
        ActionValidateRegistrationCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}