using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PrivateWirelessGateways;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PrivateWirelessGatewayService : IPrivateWirelessGatewayService
{
    readonly Lazy<IPrivateWirelessGatewayServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPrivateWirelessGatewayServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPrivateWirelessGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PrivateWirelessGatewayService(this._client.WithOptions(modifier));
    }

    public PrivateWirelessGatewayService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PrivateWirelessGatewayServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PrivateWirelessGatewayCreateResponse> Create(
        PrivateWirelessGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PrivateWirelessGatewayRetrieveResponse> Retrieve(
        PrivateWirelessGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PrivateWirelessGatewayRetrieveResponse> Retrieve(
        string id,
        PrivateWirelessGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PrivateWirelessGatewayListPage> List(
        PrivateWirelessGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PrivateWirelessGatewayDeleteResponse> Delete(
        PrivateWirelessGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PrivateWirelessGatewayDeleteResponse> Delete(
        string id,
        PrivateWirelessGatewayDeleteParams? parameters = null,
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
public sealed class PrivateWirelessGatewayServiceWithRawResponse : IPrivateWirelessGatewayServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPrivateWirelessGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PrivateWirelessGatewayServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PrivateWirelessGatewayServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PrivateWirelessGatewayCreateResponse>> Create(
        PrivateWirelessGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PrivateWirelessGatewayCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var privateWirelessGateway = await response.Deserialize<PrivateWirelessGatewayCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                privateWirelessGateway.Validate();
            }
            return privateWirelessGateway;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PrivateWirelessGatewayRetrieveResponse>> Retrieve(
        PrivateWirelessGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PrivateWirelessGatewayRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var privateWirelessGateway = await response.Deserialize<PrivateWirelessGatewayRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                privateWirelessGateway.Validate();
            }
            return privateWirelessGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PrivateWirelessGatewayRetrieveResponse>> Retrieve(
        string id,
        PrivateWirelessGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PrivateWirelessGatewayListPage>> List(
        PrivateWirelessGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PrivateWirelessGatewayListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PrivateWirelessGatewayListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PrivateWirelessGatewayListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PrivateWirelessGatewayDeleteResponse>> Delete(
        PrivateWirelessGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PrivateWirelessGatewayDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var privateWirelessGateway = await response.Deserialize<PrivateWirelessGatewayDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                privateWirelessGateway.Validate();
            }
            return privateWirelessGateway;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PrivateWirelessGatewayDeleteResponse>> Delete(
        string id,
        PrivateWirelessGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}