using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingPhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPortingPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPortingPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a list of your porting phone numbers.
/// </summary>
    Task<PortingPhoneNumberListPage> List(
        PortingPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPortingPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPortingPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_phone_numbers</c>, but is otherwise the
/// same as <see cref="IPortingPhoneNumberService.List(PortingPhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingPhoneNumberListPage>> List(
        PortingPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}