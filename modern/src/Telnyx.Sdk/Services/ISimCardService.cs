using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCards;
using SimCards = Telnyx.Sdk.Services.SimCards;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIM Cards operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISimCardService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimCardServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    SimCards::IActionService Actions { get; }

    /// <summary>
/// Returns the details regarding a specific SIM card.
/// </summary>
    Task<SimCardRetrieveResponse> Retrieve(
        SimCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardRetrieveParams, CancellationToken)"/>
    Task<SimCardRetrieveResponse> Retrieve(
        string id,
        SimCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified SIM card's attributes and returns the updated SIM card.
/// </summary>
    Task<SimCardUpdateResponse> Update(
        SimCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardUpdateParams, CancellationToken)"/>
    Task<SimCardUpdateResponse> Update(
        string simCardID,
        SimCardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all SIM cards belonging to the user that match the given filters.
/// </summary>
    Task<SimCardListPage> List(
        SimCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// The SIM card will be decommissioned, removed from your account and you will stop
/// being charged.&lt;br /&gt;The SIM card won't be able to connect to the network
/// after the deletion is completed, thus making it impossible to consume
/// data.&lt;br/&gt; Transitioning to the disabled state may take a period of time.
/// Until the transition is completed, the SIM card status will be disabling
/// &lt;code&gt;disabling&lt;/code&gt;.&lt;br /&gt;In order to re-enable the SIM
/// card, you will need to re-register it.
/// </summary>
    Task<SimCardDeleteResponse> Delete(
        SimCardDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardDeleteParams, CancellationToken)"/>
    Task<SimCardDeleteResponse> Delete(
        string id,
        SimCardDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// It returns the activation code for an eSIM.&lt;br/&gt;&lt;br/&gt;  This API is only
/// available for eSIMs. If the given SIM is a physical SIM card, or has already been
/// installed, an error will be returned.
/// </summary>
    Task<SimCardGetActivationCodeResponse> GetActivationCode(
        SimCardGetActivationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetActivationCode(SimCardGetActivationCodeParams, CancellationToken)"/>
    Task<SimCardGetActivationCodeResponse> GetActivationCode(
        string id,
        SimCardGetActivationCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// It returns the device details where a SIM card is currently being used.
/// </summary>
    Task<SimCardGetDeviceDetailsResponse> GetDeviceDetails(
        SimCardGetDeviceDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetDeviceDetails(SimCardGetDeviceDetailsParams, CancellationToken)"/>
    Task<SimCardGetDeviceDetailsResponse> GetDeviceDetails(
        string id,
        SimCardGetDeviceDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// It returns the public IP requested for a SIM card.
/// </summary>
    Task<SimCardGetPublicIPResponse> GetPublicIP(
        SimCardGetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetPublicIP(SimCardGetPublicIPParams, CancellationToken)"/>
    Task<SimCardGetPublicIPResponse> GetPublicIP(
        string id,
        SimCardGetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This API allows listing a paginated collection of Wireless Connectivity Logs
/// associated with a SIM Card, for troubleshooting purposes.
/// </summary>
    Task<SimCardListWirelessConnectivityLogsPage> ListWirelessConnectivityLogs(
        SimCardListWirelessConnectivityLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListWirelessConnectivityLogs(SimCardListWirelessConnectivityLogsParams, CancellationToken)"/>
    Task<SimCardListWirelessConnectivityLogsPage> ListWirelessConnectivityLogs(
        string id,
        SimCardListWirelessConnectivityLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISimCardService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimCardServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    SimCards::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardService.Retrieve(SimCardRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardRetrieveResponse>> Retrieve(
        SimCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SimCardRetrieveResponse>> Retrieve(
        string id,
        SimCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /sim_cards/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardService.Update(SimCardUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardUpdateResponse>> Update(
        SimCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SimCardUpdateResponse>> Update(
        string simCardID,
        SimCardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards</c>, but is otherwise the
/// same as <see cref="ISimCardService.List(SimCardListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardListPage>> List(
        SimCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /sim_cards/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardService.Delete(SimCardDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDeleteResponse>> Delete(
        SimCardDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SimCardDeleteResponse>> Delete(
        string id,
        SimCardDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards/{id}/activation_code</c>, but is otherwise the
/// same as <see cref="ISimCardService.GetActivationCode(SimCardGetActivationCodeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGetActivationCodeResponse>> GetActivationCode(
        SimCardGetActivationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetActivationCode(SimCardGetActivationCodeParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGetActivationCodeResponse>> GetActivationCode(
        string id,
        SimCardGetActivationCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards/{id}/device_details</c>, but is otherwise the
/// same as <see cref="ISimCardService.GetDeviceDetails(SimCardGetDeviceDetailsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGetDeviceDetailsResponse>> GetDeviceDetails(
        SimCardGetDeviceDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetDeviceDetails(SimCardGetDeviceDetailsParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGetDeviceDetailsResponse>> GetDeviceDetails(
        string id,
        SimCardGetDeviceDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards/{id}/public_ip</c>, but is otherwise the
/// same as <see cref="ISimCardService.GetPublicIP(SimCardGetPublicIPParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardGetPublicIPResponse>> GetPublicIP(
        SimCardGetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetPublicIP(SimCardGetPublicIPParams, CancellationToken)"/>
    Task<HttpResponse<SimCardGetPublicIPResponse>> GetPublicIP(
        string id,
        SimCardGetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_cards/{id}/wireless_connectivity_logs</c>, but is otherwise the
/// same as <see cref="ISimCardService.ListWirelessConnectivityLogs(SimCardListWirelessConnectivityLogsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardListWirelessConnectivityLogsPage>> ListWirelessConnectivityLogs(
        SimCardListWirelessConnectivityLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListWirelessConnectivityLogs(SimCardListWirelessConnectivityLogsParams, CancellationToken)"/>
    Task<HttpResponse<SimCardListWirelessConnectivityLogsPage>> ListWirelessConnectivityLogs(
        string id,
        SimCardListWirelessConnectivityLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}