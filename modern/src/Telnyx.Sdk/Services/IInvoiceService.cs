using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Invoices;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve a single invoice by its unique identifier.
/// </summary>
    Task<InvoiceRetrieveResponse> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<InvoiceRetrieveResponse> Retrieve(
        string id,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your invoices, with support for sorting.
/// </summary>
    Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInvoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /invoices/{id}</c>, but is otherwise the
/// same as <see cref="IInvoiceService.Retrieve(InvoiceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InvoiceRetrieveResponse>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceRetrieveResponse>> Retrieve(
        string id,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /invoices</c>, but is otherwise the
/// same as <see cref="IInvoiceService.List(InvoiceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InvoiceListPage>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}