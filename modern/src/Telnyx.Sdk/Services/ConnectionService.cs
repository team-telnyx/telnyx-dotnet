using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Connections;

namespace Telnyx.Sdk.Services;

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
        string id,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConnectionListPage> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConnectionListActiveCallsPage> ListActiveCalls(
        ConnectionListActiveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListActiveCalls(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConnectionListActiveCallsPage> ListActiveCalls(
        string connectionID,
        ConnectionListActiveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListActiveCalls(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConnectionRetrieveCountResponse> RetrieveCount(
        ConnectionRetrieveCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveCount(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
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
        string id,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectionListPage>> List(
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
            var page = await response.Deserialize<ConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectionListActiveCallsPage>> ListActiveCalls(
        ConnectionListActiveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<ConnectionListActiveCallsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ConnectionListActiveCallsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ConnectionListActiveCallsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConnectionListActiveCallsPage>> ListActiveCalls(
        string connectionID,
        ConnectionListActiveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListActiveCalls(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectionRetrieveCountResponse>> RetrieveCount(
        ConnectionRetrieveCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConnectionRetrieveCountParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConnectionRetrieveCountResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}