using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WirelessBlocklists;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Wireless Blocklists operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWirelessBlocklistService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWirelessBlocklistServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessBlocklistService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a Wireless Blocklist to prevent SIMs from connecting to certain networks.
/// </summary>
    Task<WirelessBlocklistCreateResponse> Create(
        WirelessBlocklistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve information about a Wireless Blocklist.
/// </summary>
    Task<WirelessBlocklistRetrieveResponse> Retrieve(
        WirelessBlocklistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WirelessBlocklistRetrieveParams, CancellationToken)"/>
    Task<WirelessBlocklistRetrieveResponse> Retrieve(
        string id,
        WirelessBlocklistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified wireless blocklist. The update is processed
/// asynchronously, so the request is accepted and completes in the background.
/// </summary>
    Task<WirelessBlocklistUpdateResponse> Update(
        WirelessBlocklistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WirelessBlocklistUpdateParams, CancellationToken)"/>
    Task<WirelessBlocklistUpdateResponse> Update(
        string id,
        WirelessBlocklistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all Wireless Blocklists belonging to the user.
/// </summary>
    Task<WirelessBlocklistListPage> List(
        WirelessBlocklistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified wireless blocklist from your account. The
/// request returns `422` when the wireless blocklist is assigned to a SIM Card
/// Group.
/// </summary>
    Task Delete(
        WirelessBlocklistDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WirelessBlocklistDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        WirelessBlocklistDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWirelessBlocklistService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWirelessBlocklistServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessBlocklistServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /wireless_blocklists</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistService.Create(WirelessBlocklistCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessBlocklistCreateResponse>> Create(
        WirelessBlocklistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless_blocklists/{id}</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistService.Retrieve(WirelessBlocklistRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessBlocklistRetrieveResponse>> Retrieve(
        WirelessBlocklistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WirelessBlocklistRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WirelessBlocklistRetrieveResponse>> Retrieve(
        string id,
        WirelessBlocklistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /wireless_blocklists/{id}</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistService.Update(WirelessBlocklistUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessBlocklistUpdateResponse>> Update(
        WirelessBlocklistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WirelessBlocklistUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WirelessBlocklistUpdateResponse>> Update(
        string id,
        WirelessBlocklistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless_blocklists</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistService.List(WirelessBlocklistListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessBlocklistListPage>> List(
        WirelessBlocklistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /wireless_blocklists/{id}</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistService.Delete(WirelessBlocklistDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        WirelessBlocklistDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WirelessBlocklistDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        WirelessBlocklistDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}