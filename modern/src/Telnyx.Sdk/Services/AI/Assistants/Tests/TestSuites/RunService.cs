using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;
using Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Services.AI.Assistants.Tests.TestSuites;

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
        string suiteName,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            SuiteName = suiteName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Runs::TestRunResponse>> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Trigger(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<Runs::TestRunResponse>> Trigger(
        string suiteName,
        RunTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Trigger(parameters with{
            SuiteName = suiteName
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RunListPage>> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.SuiteName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SuiteName' cannot be null"
            );
        }

        HttpRequest<RunListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PaginatedTestRunList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RunListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RunListPage>> List(
        string suiteName,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            SuiteName = suiteName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Runs::TestRunResponse>>> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SuiteName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SuiteName' cannot be null"
            );
        }

        HttpRequest<RunTriggerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var testRunResponses = await response.Deserialize<List<Runs::TestRunResponse>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in testRunResponses)
                {
                    item.Validate();
                }
            }
            return testRunResponses;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<Runs::TestRunResponse>>> Trigger(
        string suiteName,
        RunTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Trigger(parameters with{
            SuiteName = suiteName
        }, cancellationToken);
    }
}