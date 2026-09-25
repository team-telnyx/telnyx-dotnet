using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SiprecConnectors;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SiprecConnectorService : ISiprecConnectorService
{
    readonly Lazy<ISiprecConnectorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISiprecConnectorServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISiprecConnectorService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SiprecConnectorService(this._client.WithOptions(modifier)); }

    public SiprecConnectorService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SiprecConnectorServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SiprecConnectorResponse> Create(
        SiprecConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SiprecConnectorResponse> Retrieve(
        SiprecConnectorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SiprecConnectorResponse> Retrieve(
        string connectorName,
        SiprecConnectorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectorName = connectorName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SiprecConnectorResponse> Update(
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SiprecConnectorResponse> Update(
        string connectorName,
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectorName = connectorName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        SiprecConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string connectorName,
        SiprecConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ConnectorName = connectorName
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SiprecConnectorServiceWithRawResponse : ISiprecConnectorServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISiprecConnectorServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SiprecConnectorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SiprecConnectorServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SiprecConnectorResponse>> Create(
        SiprecConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SiprecConnectorCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var siprecConnectorResponse = await response.Deserialize<SiprecConnectorResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                siprecConnectorResponse.Validate();
            }
            return siprecConnectorResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SiprecConnectorResponse>> Retrieve(
        SiprecConnectorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectorName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectorName' cannot be null"
            );
        }

        HttpRequest<SiprecConnectorRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var siprecConnectorResponse = await response.Deserialize<SiprecConnectorResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                siprecConnectorResponse.Validate();
            }
            return siprecConnectorResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SiprecConnectorResponse>> Retrieve(
        string connectorName,
        SiprecConnectorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectorName = connectorName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SiprecConnectorResponse>> Update(
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectorName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectorName' cannot be null"
            );
        }

        HttpRequest<SiprecConnectorUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var siprecConnectorResponse = await response.Deserialize<SiprecConnectorResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                siprecConnectorResponse.Validate();
            }
            return siprecConnectorResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SiprecConnectorResponse>> Update(
        string connectorName,
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectorName = connectorName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SiprecConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectorName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectorName' cannot be null"
            );
        }

        HttpRequest<SiprecConnectorDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string connectorName,
        SiprecConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ConnectorName = connectorName
        }, cancellationToken);
    }
}