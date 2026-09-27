using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging.Rcs;
using Telnyx.Sdk.Services.Messaging.Rcs;

namespace Telnyx.Sdk.Services.Messaging;

/// <summary>
/// Send RCS messages
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IAgentService Agents { get; }

    /// <summary>
/// Adds a test phone number to an RCS agent for testing purposes.
/// </summary>
    Task<RcInviteTestNumberResponse> InviteTestNumber(
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InviteTestNumber(RcInviteTestNumberParams, CancellationToken)"/>
    Task<RcInviteTestNumberResponse> InviteTestNumber(
        string phoneNumber,
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns RCS capability information for multiple recipients in one request.
/// </summary>
    Task<RcListBulkCapabilitiesResponse> ListBulkCapabilities(
        RcListBulkCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the RCS features supported by the specified recipient for the selected
/// agent.
/// </summary>
    Task<RcRetrieveCapabilitiesResponse> RetrieveCapabilities(
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCapabilities(RcRetrieveCapabilitiesParams, CancellationToken)"/>
    Task<RcRetrieveCapabilitiesResponse> RetrieveCapabilities(
        string phoneNumber,
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IAgentServiceWithRawResponse Agents { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>put /messaging/rcs/test_number_invite/{id}/{phone_number}</c>, but is otherwise the
/// same as <see cref="IRcService.InviteTestNumber(RcInviteTestNumberParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RcInviteTestNumberResponse>> InviteTestNumber(
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InviteTestNumber(RcInviteTestNumberParams, CancellationToken)"/>
    Task<HttpResponse<RcInviteTestNumberResponse>> InviteTestNumber(
        string phoneNumber,
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging/rcs/bulk_capabilities</c>, but is otherwise the
/// same as <see cref="IRcService.ListBulkCapabilities(RcListBulkCapabilitiesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RcListBulkCapabilitiesResponse>> ListBulkCapabilities(
        RcListBulkCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging/rcs/capabilities/{agent_id}/{phone_number}</c>, but is otherwise the
/// same as <see cref="IRcService.RetrieveCapabilities(RcRetrieveCapabilitiesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RcRetrieveCapabilitiesResponse>> RetrieveCapabilities(
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCapabilities(RcRetrieveCapabilitiesParams, CancellationToken)"/>
    Task<HttpResponse<RcRetrieveCapabilitiesResponse>> RetrieveCapabilities(
        string phoneNumber,
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}