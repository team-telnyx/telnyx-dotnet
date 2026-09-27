using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InboundChannels;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Voice Channels
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInboundChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundChannelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Update the number of Voice Channels for the US Zone. This allows your account to
/// handle multiple simultaneous inbound calls to US numbers. Use this endpoint to
/// increase or decrease your capacity based on expected call volume.
/// </summary>
    Task<InboundChannelUpdateResponse> Update(
        InboundChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the US Zone voice channels for your account. voice channels allows you
/// to use Channel Billing for calls to your Telnyx phone numbers. Please check the
/// &lt;a
/// href="https://support.telnyx.com/en/articles/8428806-global-channel-billing"&gt;Telnyx
/// Support Articles&lt;/a&gt; section for full information and examples of how to
/// utilize Channel Billing.
/// </summary>
    Task<InboundChannelListResponse> List(
        InboundChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInboundChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundChannelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /inbound_channels</c>, but is otherwise the
/// same as <see cref="IInboundChannelService.Update(InboundChannelUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InboundChannelUpdateResponse>> Update(
        InboundChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /inbound_channels</c>, but is otherwise the
/// same as <see cref="IInboundChannelService.List(InboundChannelListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InboundChannelListResponse>> List(
        InboundChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}