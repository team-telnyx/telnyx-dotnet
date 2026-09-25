using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AvailablePhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number search
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAvailablePhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAvailablePhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailablePhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Searches the Telnyx inventory for available phone numbers. Filters support
/// number patterns, location, number type, features, reservability, and other
/// inventory constraints; the response includes matching numbers and search
/// metadata.
/// </summary>
    Task<AvailablePhoneNumberListResponse> List(
        AvailablePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAvailablePhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAvailablePhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailablePhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /available_phone_numbers</c>, but is otherwise the
/// same as <see cref="IAvailablePhoneNumberService.List(AvailablePhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AvailablePhoneNumberListResponse>> List(
        AvailablePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}