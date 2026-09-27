using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.FineTuning.Jobs;

namespace Telnyx.Sdk.Services.AI.FineTuning;

/// <inheritdoc/>
public sealed class JobService : IJobService
{
    readonly Lazy<IJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new JobService(this._client.WithOptions(modifier)); }

    public JobService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new JobServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FineTuningJob> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FineTuningJob> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FineTuningJob> Retrieve(
        string jobID,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            JobID = jobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JobListResponse> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FineTuningJob> Cancel(
        JobCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Cancel(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FineTuningJob> Cancel(
        string jobID,
        JobCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with{
            JobID = jobID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JobServiceWithRawResponse : IJobServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new JobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FineTuningJob>> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<JobCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fineTuningJob = await response.Deserialize<FineTuningJob>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fineTuningJob.Validate();
            }
            return fineTuningJob;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FineTuningJob>> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.JobID' cannot be null"
            );
        }

        HttpRequest<JobRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fineTuningJob = await response.Deserialize<FineTuningJob>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fineTuningJob.Validate();
            }
            return fineTuningJob;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FineTuningJob>> Retrieve(
        string jobID,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            JobID = jobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JobListResponse>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<JobListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var jobs = await response.Deserialize<JobListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                jobs.Validate();
            }
            return jobs;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FineTuningJob>> Cancel(
        JobCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.JobID' cannot be null"
            );
        }

        HttpRequest<JobCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fineTuningJob = await response.Deserialize<FineTuningJob>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fineTuningJob.Validate();
            }
            return fineTuningJob;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FineTuningJob>> Cancel(
        string jobID,
        JobCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with{
            JobID = jobID
        }, cancellationToken);
    }
}