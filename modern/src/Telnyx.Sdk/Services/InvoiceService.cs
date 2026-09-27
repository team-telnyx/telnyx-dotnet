using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Invoices;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class InvoiceService : IInvoiceService
{
    readonly Lazy<IInvoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInvoiceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InvoiceService(this._client.WithOptions(modifier)); }

    public InvoiceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InvoiceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InvoiceRetrieveResponse> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InvoiceRetrieveResponse> Retrieve(
        string id,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InvoiceServiceWithRawResponse : IInvoiceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InvoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceRetrieveResponse>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<InvoiceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var invoice = await response.Deserialize<InvoiceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                invoice.Validate();
            }
            return invoice;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InvoiceRetrieveResponse>> Retrieve(
        string id,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListPage>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<InvoiceListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new InvoiceListPage(this, parameters, page);
        });
    }
}