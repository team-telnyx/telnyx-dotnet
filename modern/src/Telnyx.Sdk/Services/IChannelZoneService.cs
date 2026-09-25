using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ChannelZones;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Voice Channels
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IChannelZoneService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChannelZoneServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelZoneService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Update the number of Voice Channels for the Non-US Zones. This allows your
/// account to handle multiple simultaneous inbound calls to Non-US numbers. Use
/// this endpoint to increase or decrease your capacity based on expected call
/// volume.
/// </summary>
    Task<GcbChannelZone> Update(
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ChannelZoneUpdateParams, CancellationToken)"/>
    Task<GcbChannelZone> Update(
        string channelZoneID,
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the non-US voice channels for your account. voice channels allow you to
/// use Channel Billing for calls to your Telnyx phone numbers. Please check the
/// &lt;a
/// href="https://support.telnyx.com/en/articles/8428806-global-channel-billing"&gt;Telnyx
/// Support Articles&lt;/a&gt; section for full information and examples of how to
/// utilize Channel Billing.
/// </summary>
    Task<ChannelZoneListPage> List(
        ChannelZoneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IChannelZoneService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChannelZoneServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelZoneServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /channel_zones/{channel_zone_id}</c>, but is otherwise the
/// same as <see cref="IChannelZoneService.Update(ChannelZoneUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GcbChannelZone>> Update(
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ChannelZoneUpdateParams, CancellationToken)"/>
    Task<HttpResponse<GcbChannelZone>> Update(
        string channelZoneID,
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /channel_zones</c>, but is otherwise the
/// same as <see cref="IChannelZoneService.List(ChannelZoneListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ChannelZoneListPage>> List(
        ChannelZoneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}