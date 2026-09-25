using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WirelessBlocklistValues;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Wireless Blocklists operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWirelessBlocklistValueService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWirelessBlocklistValueServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessBlocklistValueService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve all wireless blocklist values for a given blocklist type. The request
/// returns `422` when `type` is missing or invalid.
/// </summary>
    Task<WirelessBlocklistValueListResponse> List(
        WirelessBlocklistValueListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWirelessBlocklistValueService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWirelessBlocklistValueServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessBlocklistValueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless_blocklist_values</c>, but is otherwise the
/// same as <see cref="IWirelessBlocklistValueService.List(WirelessBlocklistValueListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessBlocklistValueListResponse>> List(
        WirelessBlocklistValueListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}