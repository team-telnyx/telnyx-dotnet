using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VerifiedNumbers;
using VerifiedNumbers = Telnyx.Sdk.Services.VerifiedNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Verified Numbers operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerifiedNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerifiedNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifiedNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    VerifiedNumbers::IActionService Actions { get; }

    /// <summary>
/// Initiates phone number verification procedure. Supports DTMF extension dialing
/// for voice calls to numbers behind IVR systems.
/// </summary>
    Task<VerifiedNumberCreateResponse> Create(
        VerifiedNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a verified number on your account.
/// </summary>
    Task<VerifiedNumberDataWrapper> Retrieve(
        VerifiedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerifiedNumberRetrieveParams, CancellationToken)"/>
    Task<VerifiedNumberDataWrapper> Retrieve(
        string phoneNumber,
        VerifiedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Gets a paginated list of Verified Numbers.
/// </summary>
    Task<VerifiedNumberListPage> List(
        VerifiedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Remove a verified number from your account.
/// </summary>
    Task<VerifiedNumberDataWrapper> Delete(
        VerifiedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VerifiedNumberDeleteParams, CancellationToken)"/>
    Task<VerifiedNumberDataWrapper> Delete(
        string phoneNumber,
        VerifiedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVerifiedNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerifiedNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifiedNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    VerifiedNumbers::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /verified_numbers</c>, but is otherwise the
/// same as <see cref="IVerifiedNumberService.Create(VerifiedNumberCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifiedNumberCreateResponse>> Create(
        VerifiedNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /verified_numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="IVerifiedNumberService.Retrieve(VerifiedNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifiedNumberDataWrapper>> Retrieve(
        VerifiedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerifiedNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VerifiedNumberDataWrapper>> Retrieve(
        string phoneNumber,
        VerifiedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /verified_numbers</c>, but is otherwise the
/// same as <see cref="IVerifiedNumberService.List(VerifiedNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifiedNumberListPage>> List(
        VerifiedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /verified_numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="IVerifiedNumberService.Delete(VerifiedNumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifiedNumberDataWrapper>> Delete(
        VerifiedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VerifiedNumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VerifiedNumberDataWrapper>> Delete(
        string phoneNumber,
        VerifiedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}