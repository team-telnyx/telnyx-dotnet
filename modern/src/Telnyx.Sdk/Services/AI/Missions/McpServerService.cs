using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.McpServers;

namespace Telnyx.Sdk.Services.AI.Missions;

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
    public async Task<JsonElement> CreateMcpServer(
        McpServerCreateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateMcpServer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> CreateMcpServer(
        string missionID,
        McpServerCreateMcpServerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateMcpServer(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteMcpServer(
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteMcpServer(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteMcpServer(
        string mcpServerID,
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetMcpServer(
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetMcpServer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> GetMcpServer(
        string mcpServerID,
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> ListMcpServers(
        McpServerListMcpServersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListMcpServers(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> ListMcpServers(
        string missionID,
        McpServerListMcpServersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMcpServers(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> UpdateMcpServer(
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateMcpServer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> UpdateMcpServer(
        string mcpServerID,
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
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
    public async Task<HttpResponse<JsonElement>> CreateMcpServer(
        McpServerCreateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<McpServerCreateMcpServerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> CreateMcpServer(
        string missionID,
        McpServerCreateMcpServerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateMcpServer(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteMcpServer(
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerDeleteMcpServerParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteMcpServer(
        string mcpServerID,
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetMcpServer(
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerGetMcpServerParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetMcpServer(
        string mcpServerID,
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> ListMcpServers(
        McpServerListMcpServersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<McpServerListMcpServersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> ListMcpServers(
        string missionID,
        McpServerListMcpServersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMcpServers(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> UpdateMcpServer(
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.McpServerID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.McpServerID' cannot be null"
            );
        }

        HttpRequest<McpServerUpdateMcpServerParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> UpdateMcpServer(
        string mcpServerID,
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateMcpServer(parameters with{
            McpServerID = mcpServerID
        }, cancellationToken);
    }
}