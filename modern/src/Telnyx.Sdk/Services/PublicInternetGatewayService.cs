using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PublicInternetGateways;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PublicInternetGatewayService : IPublicInternetGatewayService
{
    readonly Lazy<IPublicInternetGatewayServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPublicInternetGatewayServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPublicInternetGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PublicInternetGatewayService(this._client.WithOptions(modifier));
    }

    public PublicInternetGatewayService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PublicInternetGatewayServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PublicInternetGatewayCreateResponse> Create(
        PublicInternetGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PublicInternetGatewayRetrieveResponse> Retrieve(
        PublicInternetGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PublicInternetGatewayRetrieveResponse> Retrieve(
        string id,
        PublicInternetGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PublicInternetGatewayListPage> List(
        PublicInternetGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PublicInternetGatewayDeleteResponse> Delete(
        PublicInternetGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PublicInternetGatewayDeleteResponse> Delete(
        string id,
        PublicInternetGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PublicInternetGatewayServiceWithRawResponse : IPublicInternetGatewayServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPublicInternetGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PublicInternetGatewayServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PublicInternetGatewayServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublicInternetGatewayCreateResponse>> Create(
        PublicInternetGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PublicInternetGatewayCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var publicInternetGateway = await response.Deserialize<PublicInternetGatewayCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                publicInternetGateway.Validate();
            }
            return publicInternetGateway;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublicInternetGatewayRetrieveResponse>> Retrieve(
        PublicInternetGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PublicInternetGatewayRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var publicInternetGateway = await response.Deserialize<PublicInternetGatewayRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                publicInternetGateway.Validate();
            }
            return publicInternetGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PublicInternetGatewayRetrieveResponse>> Retrieve(
        string id,
        PublicInternetGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublicInternetGatewayListPage>> List(
        PublicInternetGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PublicInternetGatewayListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PublicInternetGatewayListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PublicInternetGatewayListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublicInternetGatewayDeleteResponse>> Delete(
        PublicInternetGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PublicInternetGatewayDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var publicInternetGateway = await response.Deserialize<PublicInternetGatewayDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                publicInternetGateway.Validate();
            }
            return publicInternetGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PublicInternetGatewayDeleteResponse>> Delete(
        string id,
        PublicInternetGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}