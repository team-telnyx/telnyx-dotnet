using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ChargesBreakdown;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChargesBreakdownService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChargesBreakdownServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargesBreakdownService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve a detailed breakdown of monthly charges for phone numbers in a
/// specified date range. The date range cannot exceed 31 days.
/// </summary>
    Task<ChargesBreakdownRetrieveResponse> Retrieve(
        ChargesBreakdownRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IChargesBreakdownService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChargesBreakdownServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargesBreakdownServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /charges_breakdown</c>, but is otherwise the
/// same as <see cref="IChargesBreakdownService.Retrieve(ChargesBreakdownRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ChargesBreakdownRetrieveResponse>> Retrieve(
        ChargesBreakdownRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}