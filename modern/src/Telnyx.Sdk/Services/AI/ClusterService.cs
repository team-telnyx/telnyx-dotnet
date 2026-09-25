using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Clusters;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class ClusterService : IClusterService
{
    readonly Lazy<IClusterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClusterServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IClusterService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ClusterService(this._client.WithOptions(modifier)); }

    public ClusterService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ClusterServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ClusterRetrieveResponse> Retrieve(
        ClusterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ClusterRetrieveResponse> Retrieve(
        string taskID,
        ClusterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ClusterListPage> List(
        ClusterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ClusterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string taskID,
        ClusterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            TaskID = taskID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ClusterComputeResponse> Compute(
        ClusterComputeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Compute(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> FetchGraph(
        ClusterFetchGraphParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.FetchGraph(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> FetchGraph(
        string taskID,
        ClusterFetchGraphParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchGraph(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ClusterServiceWithRawResponse : IClusterServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClusterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClusterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClusterServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClusterRetrieveResponse>> Retrieve(
        ClusterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<ClusterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var cluster = await response.Deserialize<ClusterRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                cluster.Validate();
            }
            return cluster;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ClusterRetrieveResponse>> Retrieve(
        string taskID,
        ClusterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClusterListPage>> List(
        ClusterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClusterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ClusterListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ClusterListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ClusterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<ClusterDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string taskID,
        ClusterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClusterComputeResponse>> Compute(
        ClusterComputeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ClusterComputeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ClusterComputeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> FetchGraph(
        ClusterFetchGraphParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<ClusterFetchGraphParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> FetchGraph(
        string taskID,
        ClusterFetchGraphParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchGraph(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}