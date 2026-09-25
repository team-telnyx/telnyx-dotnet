using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Pricing.Products;

namespace Telnyx.Sdk.Services.Pricing;

/// <inheritdoc/>
public sealed class ProductService : IProductService
{
    readonly Lazy<IProductServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IProductService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ProductService(this._client.WithOptions(modifier)); }

    public ProductService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ProductServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ProductRetrievePage> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProductRetrievePage> Retrieve(
        string slug,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            Slug = slug
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductListPage> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ProductServiceWithRawResponse : IProductServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ProductServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProductServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductRetrievePage>> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Slug == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Slug' cannot be null"
            );
        }

        HttpRequest<ProductRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ProductRetrievePageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ProductRetrievePage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProductRetrievePage>> Retrieve(
        string slug,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            Slug = slug
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductListPage>> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProductListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ProductListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ProductListPage(this, parameters, page);
        });
    }
}