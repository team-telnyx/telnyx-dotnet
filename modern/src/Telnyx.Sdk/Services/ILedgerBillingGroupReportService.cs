using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.LedgerBillingGroupReports;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Ledger billing reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILedgerBillingGroupReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILedgerBillingGroupReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerBillingGroupReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a ledger billing group report, which aggregates ledger activity by
/// billing group.
/// </summary>
    Task<LedgerBillingGroupReportCreateResponse> Create(
        LedgerBillingGroupReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details and status of a previously created ledger billing group
/// report.
/// </summary>
    Task<LedgerBillingGroupReportRetrieveResponse> Retrieve(
        LedgerBillingGroupReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LedgerBillingGroupReportRetrieveParams, CancellationToken)"/>
    Task<LedgerBillingGroupReportRetrieveResponse> Retrieve(
        string id,
        LedgerBillingGroupReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ILedgerBillingGroupReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILedgerBillingGroupReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerBillingGroupReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ledger_billing_group_reports</c>, but is otherwise the
/// same as <see cref="ILedgerBillingGroupReportService.Create(LedgerBillingGroupReportCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LedgerBillingGroupReportCreateResponse>> Create(
        LedgerBillingGroupReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ledger_billing_group_reports/{id}</c>, but is otherwise the
/// same as <see cref="ILedgerBillingGroupReportService.Retrieve(LedgerBillingGroupReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LedgerBillingGroupReportRetrieveResponse>> Retrieve(
        LedgerBillingGroupReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LedgerBillingGroupReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LedgerBillingGroupReportRetrieveResponse>> Retrieve(
        string id,
        LedgerBillingGroupReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}