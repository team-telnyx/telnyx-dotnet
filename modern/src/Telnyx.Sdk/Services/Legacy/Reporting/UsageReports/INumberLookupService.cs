using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

namespace Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

/// <summary>
/// Number lookup usage reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberLookupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberLookupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberLookupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Submits a new telco data (number lookup) usage report request. The report is
/// generated asynchronously; retrieve it by its identifier once ready.
/// </summary>
    Task<NumberLookupCreateResponse> Create(
        NumberLookupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a specific telco data usage report by its ID
/// </summary>
    Task<NumberLookupRetrieveResponse> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>
    Task<NumberLookupRetrieveResponse> Retrieve(
        string id,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of telco data usage reports
/// </summary>
    Task<NumberLookupListPage> List(
        NumberLookupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a specific telco data usage report by its ID
/// </summary>
    Task Delete(
        NumberLookupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NumberLookupDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        NumberLookupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberLookupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberLookupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberLookupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /legacy/reporting/usage_reports/number_lookup</c>, but is otherwise the
/// same as <see cref="INumberLookupService.Create(NumberLookupCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberLookupCreateResponse>> Create(
        NumberLookupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/number_lookup/{id}</c>, but is otherwise the
/// same as <see cref="INumberLookupService.Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        string id,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/number_lookup</c>, but is otherwise the
/// same as <see cref="INumberLookupService.List(NumberLookupListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberLookupListPage>> List(
        NumberLookupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /legacy/reporting/usage_reports/number_lookup/{id}</c>, but is otherwise the
/// same as <see cref="INumberLookupService.Delete(NumberLookupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        NumberLookupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NumberLookupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        NumberLookupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}