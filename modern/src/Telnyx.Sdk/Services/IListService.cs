using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.List;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Voice Channels
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IListService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve a list of all phone numbers using Channel Billing, grouped by Zone.
/// </summary>
    Task<ListRetrieveAllResponse> RetrieveAll(
        ListRetrieveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of phone numbers using Channel Billing for a specific Zone.
/// </summary>
    Task<ListRetrieveByZoneResponse> RetrieveByZone(
        ListRetrieveByZoneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveByZone(ListRetrieveByZoneParams, CancellationToken)"/>
    Task<ListRetrieveByZoneResponse> RetrieveByZone(
        string channelZoneID,
        ListRetrieveByZoneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /list</c>, but is otherwise the
/// same as <see cref="IListService.RetrieveAll(ListRetrieveAllParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ListRetrieveAllResponse>> RetrieveAll(
        ListRetrieveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /list/{channel_zone_id}</c>, but is otherwise the
/// same as <see cref="IListService.RetrieveByZone(ListRetrieveByZoneParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ListRetrieveByZoneResponse>> RetrieveByZone(
        ListRetrieveByZoneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveByZone(ListRetrieveByZoneParams, CancellationToken)"/>
    Task<HttpResponse<ListRetrieveByZoneResponse>> RetrieveByZone(
        string channelZoneID,
        ListRetrieveByZoneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}