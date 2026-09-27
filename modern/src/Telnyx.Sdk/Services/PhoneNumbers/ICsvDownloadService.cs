using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICsvDownloadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICsvDownloadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICsvDownloadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Starts generation of a CSV export for phone numbers matching the supplied
/// filters. The `csv_format` parameter selects the output format, and the response
/// contains the resulting download record.
/// </summary>
    Task<CsvDownloadCreateResponse> Create(
        CsvDownloadCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the current status and download details for the CSV export identified by
/// `id`.
/// </summary>
    Task<CsvDownloadRetrieveResponse> Retrieve(
        CsvDownloadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CsvDownloadRetrieveParams, CancellationToken)"/>
    Task<CsvDownloadRetrieveResponse> Retrieve(
        string id,
        CsvDownloadRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns CSV export jobs created for account phone numbers, including each
/// export's current status and pagination metadata.
/// </summary>
    Task<CsvDownloadListPage> List(
        CsvDownloadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICsvDownloadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICsvDownloadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICsvDownloadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/csv_downloads</c>, but is otherwise the
/// same as <see cref="ICsvDownloadService.Create(CsvDownloadCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CsvDownloadCreateResponse>> Create(
        CsvDownloadCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/csv_downloads/{id}</c>, but is otherwise the
/// same as <see cref="ICsvDownloadService.Retrieve(CsvDownloadRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CsvDownloadRetrieveResponse>> Retrieve(
        CsvDownloadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CsvDownloadRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CsvDownloadRetrieveResponse>> Retrieve(
        string id,
        CsvDownloadRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/csv_downloads</c>, but is otherwise the
/// same as <see cref="ICsvDownloadService.List(CsvDownloadListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CsvDownloadListPage>> List(
        CsvDownloadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}