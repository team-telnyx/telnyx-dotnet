using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.Runs;
using Telnyx.Sdk.Services.AI.Missions.Runs;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <inheritdoc/>
public sealed class RunService : IRunService
{
    readonly Lazy<IRunServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new RunService(this._client.WithOptions(modifier)); }

    public RunService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RunServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _events =new(() => new EventService(client)) ;
        _plan =new(() => new PlanService(client)) ;
        _telnyxAgents =new(() => new TelnyxAgentService(client)) ;
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events { get { return _events.Value; } }

    readonly Lazy<IPlanService> _plan;
    public IPlanService Plan { get { return _plan.Value; } }

    readonly Lazy<ITelnyxAgentService> _telnyxAgents;
    public ITelnyxAgentService TelnyxAgents {
        get { return _telnyxAgents.Value; }
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> Create(
        string missionID,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> Update(
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> Update(
        string runID,
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RunListPage> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RunListPage> List(
        string missionID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> CancelRun(
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CancelRun(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> CancelRun(
        string runID,
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CancelRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RunListRunsPage> ListRuns(
        RunListRunsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListRuns(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> PauseRun(
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PauseRun(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> PauseRun(
        string runID,
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PauseRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MissionRunResponse> ResumeRun(
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ResumeRun(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MissionRunResponse> ResumeRun(
        string runID,
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ResumeRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RunServiceWithRawResponse : IRunServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RunServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RunServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _events =new(() => new EventServiceWithRawResponse(client)) ;
        _plan =new(() => new PlanServiceWithRawResponse(client)) ;
        _telnyxAgents =new(
            () => new TelnyxAgentServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events { get { return _events.Value; } }

    readonly Lazy<IPlanServiceWithRawResponse> _plan;
    public IPlanServiceWithRawResponse Plan { get { return _plan.Value; } }

    readonly Lazy<ITelnyxAgentServiceWithRawResponse> _telnyxAgents;
    public ITelnyxAgentServiceWithRawResponse TelnyxAgents {
        get { return _telnyxAgents.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<RunCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> Create(
        string missionID,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<RunRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> Update(
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<RunUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> Update(
        string runID,
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunListPage>> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<RunListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MissionRunsListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RunListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RunListPage>> List(
        string missionID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> CancelRun(
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<RunCancelRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> CancelRun(
        string runID,
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CancelRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunListRunsPage>> ListRuns(
        RunListRunsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RunListRunsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MissionRunsListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RunListRunsPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> PauseRun(
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<RunPauseRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> PauseRun(
        string runID,
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PauseRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MissionRunResponse>> ResumeRun(
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<RunResumeRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var missionRunResponse = await response.Deserialize<MissionRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                missionRunResponse.Validate();
            }
            return missionRunResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MissionRunResponse>> ResumeRun(
        string runID,
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ResumeRun(parameters with{
            RunID = runID
        }, cancellationToken);
    }
}