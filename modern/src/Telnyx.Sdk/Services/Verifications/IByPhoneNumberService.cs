using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Verifications.ByPhoneNumber;
using ByPhoneNumber = Telnyx.Sdk.Services.Verifications.ByPhoneNumber;

namespace Telnyx.Sdk.Services.Verifications;

/// <summary>
/// Two factor authentication API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IByPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IByPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IByPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ByPhoneNumber::IActionService Actions { get; }

    /// <summary>
/// Returns a paginated list of verifications associated with the specified phone
/// number.
/// </summary>
    Task<ByPhoneNumberListResponse> List(
        ByPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ByPhoneNumberListParams, CancellationToken)"/>
    Task<ByPhoneNumberListResponse> List(
        string phoneNumber,
        ByPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IByPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IByPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IByPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ByPhoneNumber::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /verifications/by_phone_number/{phone_number}</c>, but is otherwise the
/// same as <see cref="IByPhoneNumberService.List(ByPhoneNumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ByPhoneNumberListResponse>> List(
        ByPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ByPhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<ByPhoneNumberListResponse>> List(
        string phoneNumber,
        ByPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}