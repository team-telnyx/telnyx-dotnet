using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions;
using Missions = Telnyx.Sdk.Services.AI.Missions;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class MissionService : IMissionService
{
    readonly Lazy<IMissionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMissionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMissionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MissionService(this._client.WithOptions(modifier)); }

    public MissionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MissionServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _runs =new(() => new Missions::RunService(client)) ;
        _knowledgeBases =new(() => new Missions::KnowledgeBaseService(client)) ;
        _mcpServers =new(() => new Missions::McpServerService(client)) ;
        _tools =new(() => new Missions::ToolService(client)) ;
    }

    readonly Lazy<Missions::IRunService> _runs;
    public Missions::IRunService Runs { get { return _runs.Value; } }

    readonly Lazy<Missions::IKnowledgeBaseService> _knowledgeBases;
    public Missions::IKnowledgeBaseService KnowledgeBases {
        get { return _knowledgeBases.Value; }
    }

    readonly Lazy<Missions::IMcpServerService> _mcpServers;
    public Missions::IMcpServerService McpServers {
        get { return _mcpServers.Value; }
    }

    readonly Lazy<Missions::IToolService> _tools;
    public Missions::IToolService Tools { get { return _tools.Value; } }

    /// <inheritdoc/>
    public async Task<MissionResponse> Create(
        MissionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MissionResponse> Retrieve(
        MissionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionResponse> Retrieve(
        string missionID,
        MissionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MissionListPage> List(
        MissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> CloneMission(
        MissionCloneMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CloneMission(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> CloneMission(
        string missionID,
        MissionCloneMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CloneMission(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteMission(
        MissionDeleteMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteMission(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteMission(
        string missionID,
        MissionDeleteMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.DeleteMission(parameters with{
            MissionID = missionID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MissionListEventsPage> ListEvents(
        MissionListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListEvents(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MissionResponse> UpdateMission(
        MissionUpdateMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateMission(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionResponse> UpdateMission(
        string missionID,
        MissionUpdateMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateMission(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MissionServiceWithRawResponse : IMissionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMissionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MissionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MissionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _runs =new(() => new Missions::RunServiceWithRawResponse(client)) ;
        _knowledgeBases =new(
            () => new Missions::KnowledgeBaseServiceWithRawResponse(client)
        ) ;
        _mcpServers =new(
            () => new Missions::McpServerServiceWithRawResponse(client)
        ) ;
        _tools =new(() => new Missions::ToolServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Missions::IRunServiceWithRawResponse> _runs;
    public Missions::IRunServiceWithRawResponse Runs {
        get { return _runs.Value; }
    }

    readonly Lazy<Missions::IKnowledgeBaseServiceWithRawResponse> _knowledgeBases;
    public Missions::IKnowledgeBaseServiceWithRawResponse KnowledgeBases {
        get { return _knowledgeBases.Value; }
    }

    readonly Lazy<Missions::IMcpServerServiceWithRawResponse> _mcpServers;
    public Missions::IMcpServerServiceWithRawResponse McpServers {
        get { return _mcpServers.Value; }
    }

    readonly Lazy<Missions::IToolServiceWithRawResponse> _tools;
    public Missions::IToolServiceWithRawResponse Tools {
        get { return _tools.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionResponse>> Create(
        MissionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MissionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionResponse = await response.Deserialize<MissionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionResponse.Validate();
            }
            return missionResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionResponse>> Retrieve(
        MissionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<MissionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionResponse = await response.Deserialize<MissionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionResponse.Validate();
            }
            return missionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionResponse>> Retrieve(
        string missionID,
        MissionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionListPage>> List(
        MissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MissionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MissionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MissionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> CloneMission(
        MissionCloneMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<MissionCloneMissionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> CloneMission(
        string missionID,
        MissionCloneMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CloneMission(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteMission(
        MissionDeleteMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<MissionDeleteMissionParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteMission(
        string missionID,
        MissionDeleteMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteMission(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionListEventsPage>> ListEvents(
        MissionListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MissionListEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EventsListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MissionListEventsPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionResponse>> UpdateMission(
        MissionUpdateMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<MissionUpdateMissionParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionResponse = await response.Deserialize<MissionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionResponse.Validate();
            }
            return missionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionResponse>> UpdateMission(
        string missionID,
        MissionUpdateMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateMission(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }
}