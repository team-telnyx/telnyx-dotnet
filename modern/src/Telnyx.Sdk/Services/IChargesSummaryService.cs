using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ChargesSummary;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChargesSummaryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChargesSummaryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargesSummaryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve a summary of monthly charges for a specified date range. The date range
/// cannot exceed 31 days.
/// </summary>
    Task<ChargesSummaryRetrieveResponse> Retrieve(
        ChargesSummaryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IChargesSummaryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChargesSummaryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargesSummaryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /charges_summary</c>, but is otherwise the
/// same as <see cref="IChargesSummaryService.Retrieve(ChargesSummaryRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ChargesSummaryRetrieveResponse>> Retrieve(
        ChargesSummaryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}