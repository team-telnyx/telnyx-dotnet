using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WebSearch.Research;

namespace Telnyx.Sdk.Services.WebSearch;

/// <inheritdoc/>
public sealed class ResearchService : IResearchService
{
    readonly Lazy<IResearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IResearchServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IResearchService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ResearchService(this._client.WithOptions(modifier)); }

    public ResearchService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ResearchServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ResearchCreateResponse> Create(
        ResearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ResearchRetrieveResponse> Retrieve(
        ResearchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ResearchRetrieveResponse> Retrieve(
        string taskID,
        ResearchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ResearchServiceWithRawResponse : IResearchServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IResearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ResearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ResearchServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResearchCreateResponse>> Create(
        ResearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ResearchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var research = await response.Deserialize<ResearchCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                research.Validate();
            }
            return research;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResearchRetrieveResponse>> Retrieve(
        ResearchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<ResearchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var research = await response.Deserialize<ResearchRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                research.Validate();
            }
            return research;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ResearchRetrieveResponse>> Retrieve(
        string taskID,
        ResearchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}