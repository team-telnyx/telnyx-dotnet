using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Integrations.Connections;

namespace Telnyx.Sdk.Services.AI.Integrations;

/// <inheritdoc/>
public sealed class ConnectionService : IConnectionService
{
    readonly Lazy<IConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ConnectionService(this._client.WithOptions(modifier)); }

    public ConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConnectionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ConnectionRetrieveResponse> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConnectionRetrieveResponse> Retrieve(
        string userConnectionID,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            UserConnectionID = userConnectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConnectionListResponse> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string userConnectionID,
        ConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            UserConnectionID = userConnectionID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConnectionServiceWithRawResponse : IConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.UserConnectionID' cannot be null"
            );
        }

        HttpRequest<ConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var connection = await response.Deserialize<ConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                connection.Validate();
            }
            return connection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        string userConnectionID,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            UserConnectionID = userConnectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectionListResponse>> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var connections = await response.Deserialize<ConnectionListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                connections.Validate();
            }
            return connections;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.UserConnectionID' cannot be null"
            );
        }

        HttpRequest<ConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string userConnectionID,
        ConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            UserConnectionID = userConnectionID
        }, cancellationToken);
    }
}