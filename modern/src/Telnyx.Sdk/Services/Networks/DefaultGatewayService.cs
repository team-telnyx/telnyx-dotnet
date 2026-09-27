using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Networks.DefaultGateway;

namespace Telnyx.Sdk.Services.Networks;

/// <inheritdoc/>
public sealed class DefaultGatewayService : IDefaultGatewayService
{
    readonly Lazy<IDefaultGatewayServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDefaultGatewayServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDefaultGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new DefaultGatewayService(this._client.WithOptions(modifier)); }

    public DefaultGatewayService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DefaultGatewayServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DefaultGatewayCreateResponse> Create(
        DefaultGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DefaultGatewayCreateResponse> Create(
        string networkIdentifier,
        DefaultGatewayCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            NetworkIdentifier = networkIdentifier
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DefaultGatewayRetrieveResponse> Retrieve(
        DefaultGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DefaultGatewayRetrieveResponse> Retrieve(
        string id,
        DefaultGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DefaultGatewayDeleteResponse> Delete(
        DefaultGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DefaultGatewayDeleteResponse> Delete(
        string id,
        DefaultGatewayDeleteParams? parameters = null,
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
public sealed class DefaultGatewayServiceWithRawResponse : IDefaultGatewayServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDefaultGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DefaultGatewayServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DefaultGatewayServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DefaultGatewayCreateResponse>> Create(
        DefaultGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NetworkIdentifier == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NetworkIdentifier' cannot be null"
            );
        }

        HttpRequest<DefaultGatewayCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var defaultGateway = await response.Deserialize<DefaultGatewayCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                defaultGateway.Validate();
            }
            return defaultGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DefaultGatewayCreateResponse>> Create(
        string networkIdentifier,
        DefaultGatewayCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            NetworkIdentifier = networkIdentifier
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DefaultGatewayRetrieveResponse>> Retrieve(
        DefaultGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DefaultGatewayRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var defaultGateway = await response.Deserialize<DefaultGatewayRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                defaultGateway.Validate();
            }
            return defaultGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DefaultGatewayRetrieveResponse>> Retrieve(
        string id,
        DefaultGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DefaultGatewayDeleteResponse>> Delete(
        DefaultGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DefaultGatewayDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var defaultGateway = await response.Deserialize<DefaultGatewayDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                defaultGateway.Validate();
            }
            return defaultGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DefaultGatewayDeleteResponse>> Delete(
        string id,
        DefaultGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}