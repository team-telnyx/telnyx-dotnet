using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.McpServers;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class McpServerService : IMcpServerService
{
    readonly Lazy<IMcpServerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMcpServerServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMcpServerService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new McpServerService(this._client.WithOptions(modifier)); }

    public McpServerService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new McpServerServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<McpServer> Create(
        McpServerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<McpServer> Retrieve(
        McpServerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<McpServer> Retrieve(
        string mcpServerID,
        McpServerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<McpServer> Update(
        McpServerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<McpServer> Update(
        string mcpServerID,
        McpServerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<McpServerListPage> List(
        McpServerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        McpServerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string mcpServerID,
        McpServerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class McpServerServiceWithRawResponse : IMcpServerServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMcpServerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new McpServerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public McpServerServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<McpServer>> Create(
        McpServerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<McpServerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mcpServer = await response.Deserialize<McpServer>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mcpServer.Validate();
            }
            return mcpServer;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<McpServer>> Retrieve(
        McpServerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mcpServer = await response.Deserialize<McpServer>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mcpServer.Validate();
            }
            return mcpServer;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<McpServer>> Retrieve(
        string mcpServerID,
        McpServerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<McpServer>> Update(
        McpServerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mcpServer = await response.Deserialize<McpServer>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mcpServer.Validate();
            }
            return mcpServer;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<McpServer>> Update(
        string mcpServerID,
        McpServerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<McpServerListPage>> List(
        McpServerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<McpServerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<List<McpServer>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in page)
                {
                    item.Validate();
                }
            }
            return new McpServerListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        McpServerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string mcpServerID,
        McpServerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }
}