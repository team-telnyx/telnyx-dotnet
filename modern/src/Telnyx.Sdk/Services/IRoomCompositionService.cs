using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RoomCompositions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Rooms Compositions operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRoomCompositionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoomCompositionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomCompositionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Asynchronously create a room composition.
/// </summary>
    Task<RoomCompositionCreateResponse> Create(
        RoomCompositionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the composition identified by `room_composition_id`, including its room
/// and session, processing status, media details, video layout, lifecycle
/// timestamps, and download URL.
/// </summary>
    Task<RoomCompositionRetrieveResponse> Retrieve(
        RoomCompositionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomCompositionRetrieveParams, CancellationToken)"/>
    Task<RoomCompositionRetrieveResponse> Retrieve(
        string roomCompositionID,
        RoomCompositionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of room compositions. Filter compositions by creation
/// date, room session, or processing status.
/// </summary>
    Task<RoomCompositionListPage> List(
        RoomCompositionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Synchronously delete a room composition.
/// </summary>
    Task Delete(
        RoomCompositionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomCompositionDeleteParams, CancellationToken)"/>
    Task Delete(
        string roomCompositionID,
        RoomCompositionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRoomCompositionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoomCompositionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomCompositionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /room_compositions</c>, but is otherwise the
/// same as <see cref="IRoomCompositionService.Create(RoomCompositionCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomCompositionCreateResponse>> Create(
        RoomCompositionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_compositions/{room_composition_id}</c>, but is otherwise the
/// same as <see cref="IRoomCompositionService.Retrieve(RoomCompositionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomCompositionRetrieveResponse>> Retrieve(
        RoomCompositionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomCompositionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RoomCompositionRetrieveResponse>> Retrieve(
        string roomCompositionID,
        RoomCompositionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_compositions</c>, but is otherwise the
/// same as <see cref="IRoomCompositionService.List(RoomCompositionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomCompositionListPage>> List(
        RoomCompositionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /room_compositions/{room_composition_id}</c>, but is otherwise the
/// same as <see cref="IRoomCompositionService.Delete(RoomCompositionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        RoomCompositionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomCompositionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string roomCompositionID,
        RoomCompositionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}