using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.Tools;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <inheritdoc/>
public sealed class ToolService : IToolService
{
    readonly Lazy<IToolServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new ToolService(this._client.WithOptions(modifier)); }

    public ToolService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ToolServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<JsonElement> CreateTool(
        ToolCreateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateTool(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> CreateTool(
        string missionID,
        ToolCreateToolParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateTool(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteTool(
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteTool(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteTool(
        string toolID,
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteTool(parameters with{
            ToolID = toolID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetTool(
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetTool(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> GetTool(
        string toolID,
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetTool(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> ListTools(
        ToolListToolsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListTools(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> ListTools(
        string missionID,
        ToolListToolsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTools(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> UpdateTool(
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateTool(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> UpdateTool(
        string toolID,
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTool(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ToolServiceWithRawResponse : IToolServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ToolServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ToolServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> CreateTool(
        ToolCreateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<ToolCreateToolParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> CreateTool(
        string missionID,
        ToolCreateToolParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateTool(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteTool(
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolDeleteToolParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteTool(
        string toolID,
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteTool(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetTool(
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolGetToolParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetTool(
        string toolID,
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetTool(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> ListTools(
        ToolListToolsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<ToolListToolsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> ListTools(
        string missionID,
        ToolListToolsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTools(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> UpdateTool(
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolUpdateToolParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> UpdateTool(
        string toolID,
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTool(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }
}