using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <inheritdoc/>
public sealed class PlanService : IPlanService
{
    readonly Lazy<IPlanServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new PlanService(this._client.WithOptions(modifier)); }

    public PlanService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PlanServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PlanStepsCreatedResponse> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PlanStepsCreatedResponse> Create(
        string runID,
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanRetrieveResponse> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PlanRetrieveResponse> Retrieve(
        string runID,
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanStepsCreatedResponse> AddStepsToPlan(
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.AddStepsToPlan(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PlanStepsCreatedResponse> AddStepsToPlan(
        string runID,
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddStepsToPlan(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanStepResponse> GetStepDetails(
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetStepDetails(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PlanStepResponse> GetStepDetails(
        string stepID,
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStepDetails(parameters with{
            StepID = stepID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanStepResponse> UpdateStep(
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateStep(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PlanStepResponse> UpdateStep(
        string stepID,
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateStep(parameters with{
            StepID = stepID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlanServiceWithRawResponse : IPlanServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PlanServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlanServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanStepsCreatedResponse>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<PlanCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var planStepsCreatedResponse = await response.Deserialize<PlanStepsCreatedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                planStepsCreatedResponse.Validate();
            }
            return planStepsCreatedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PlanStepsCreatedResponse>> Create(
        string runID,
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<PlanRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var plan = await response.Deserialize<PlanRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                plan.Validate();
            }
            return plan;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        string runID,
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanStepsCreatedResponse>> AddStepsToPlan(
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<PlanAddStepsToPlanParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var planStepsCreatedResponse = await response.Deserialize<PlanStepsCreatedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                planStepsCreatedResponse.Validate();
            }
            return planStepsCreatedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PlanStepsCreatedResponse>> AddStepsToPlan(
        string runID,
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddStepsToPlan(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanStepResponse>> GetStepDetails(
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StepID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.StepID' cannot be null"
            );
        }

        HttpRequest<PlanGetStepDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var planStepResponse = await response.Deserialize<PlanStepResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                planStepResponse.Validate();
            }
            return planStepResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PlanStepResponse>> GetStepDetails(
        string stepID,
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStepDetails(parameters with{
            StepID = stepID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanStepResponse>> UpdateStep(
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StepID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.StepID' cannot be null"
            );
        }

        HttpRequest<PlanUpdateStepParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var planStepResponse = await response.Deserialize<PlanStepResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                planStepResponse.Validate();
            }
            return planStepResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PlanStepResponse>> UpdateStep(
        string stepID,
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateStep(parameters with{
            StepID = stepID
        }, cancellationToken);
    }
}