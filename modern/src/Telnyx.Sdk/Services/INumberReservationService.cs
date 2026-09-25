using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumberReservations;
using NumberReservations = Telnyx.Sdk.Services.NumberReservations;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number reservations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberReservationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberReservationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberReservationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    NumberReservations::IActionService Actions { get; }

    /// <summary>
/// Creates a Phone Number Reservation for multiple numbers.
/// </summary>
    Task<NumberReservationCreateResponse> Create(
        NumberReservationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single phone number reservation, including its status
/// and the reserved numbers.
/// </summary>
    Task<NumberReservationRetrieveResponse> Retrieve(
        NumberReservationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberReservationRetrieveParams, CancellationToken)"/>
    Task<NumberReservationRetrieveResponse> Retrieve(
        string numberReservationID,
        NumberReservationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Gets a paginated list of phone number reservations.
/// </summary>
    Task<NumberReservationListPage> List(
        NumberReservationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberReservationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberReservationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberReservationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    NumberReservations::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /number_reservations</c>, but is otherwise the
/// same as <see cref="INumberReservationService.Create(NumberReservationCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberReservationCreateResponse>> Create(
        NumberReservationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_reservations/{number_reservation_id}</c>, but is otherwise the
/// same as <see cref="INumberReservationService.Retrieve(NumberReservationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberReservationRetrieveResponse>> Retrieve(
        NumberReservationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberReservationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberReservationRetrieveResponse>> Retrieve(
        string numberReservationID,
        NumberReservationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_reservations</c>, but is otherwise the
/// same as <see cref="INumberReservationService.List(NumberReservationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberReservationListPage>> List(
        NumberReservationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}