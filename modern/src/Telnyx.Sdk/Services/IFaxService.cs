using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Faxes;
using Faxes = Telnyx.Sdk.Services.Faxes;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Programmable fax command operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFaxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFaxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFaxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Faxes::IActionService Actions { get; }

    /// <summary>
/// Send a fax. Files have size limits and page count limit validations. If a file
/// is bigger than 50MB or has more than 350 pages it will fail with
/// `file_size_limit_exceeded` and `page_count_limit_exceeded` respectively.
/// 
/// <para>**Supported file formats:**</para>
/// 
/// <para>- PDF (`application/pdf`) - TIFF (`application/tiff`, `image/tiff`) - JPEG
/// (`image/jpeg`) - PNG (`image/png`) - Microsoft Word `.doc`
/// (`application/msword`) - Microsoft Word `.docx`
/// (`application/vnd.openxmlformats-officedocument.wordprocessingml.document`) -
/// Rich Text Format `.rtf` (`application/rtf`) - Plain text `.txt` (`text/plain`)</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `fax.queued` - `fax.media.processed` - `fax.sending.started` -
/// `fax.delivered` - `fax.failed`</para>
/// </summary>
    Task<FaxCreateResponse> Create(
        FaxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single fax, including its current status.
/// </summary>
    Task<FaxRetrieveResponse> Retrieve(
        FaxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FaxRetrieveParams, CancellationToken)"/>
    Task<FaxRetrieveResponse> Retrieve(
        string id,
        FaxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of faxes sent or received on your account.
/// </summary>
    Task<FaxListPage> List(
        FaxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a fax resource from your account.
/// </summary>
    Task Delete(
        FaxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FaxDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        FaxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFaxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFaxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFaxServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Faxes::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /faxes</c>, but is otherwise the
/// same as <see cref="IFaxService.Create(FaxCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxCreateResponse>> Create(
        FaxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /faxes/{id}</c>, but is otherwise the
/// same as <see cref="IFaxService.Retrieve(FaxRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxRetrieveResponse>> Retrieve(
        FaxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FaxRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FaxRetrieveResponse>> Retrieve(
        string id,
        FaxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /faxes</c>, but is otherwise the
/// same as <see cref="IFaxService.List(FaxListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxListPage>> List(
        FaxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /faxes/{id}</c>, but is otherwise the
/// same as <see cref="IFaxService.Delete(FaxDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        FaxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FaxDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        FaxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}