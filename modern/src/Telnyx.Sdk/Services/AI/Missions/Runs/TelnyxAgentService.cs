using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <inheritdoc/>
public sealed class TelnyxAgentService : ITelnyxAgentService
{
    readonly Lazy<ITelnyxAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITelnyxAgentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITelnyxAgentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TelnyxAgentService(this._client.WithOptions(modifier)); }

    public TelnyxAgentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TelnyxAgentServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TelnyxAgentListResponse> List(
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxAgentListResponse> List(
        string runID,
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelnyxAgentLinkResponse> Link(
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Link(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxAgentLinkResponse> Link(
        string runID,
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Unlink(
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unlink(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Unlink(
        string telnyxAgentID,
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Unlink(parameters with{
            TelnyxAgentID = telnyxAgentID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TelnyxAgentServiceWithRawResponse : ITelnyxAgentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITelnyxAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TelnyxAgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TelnyxAgentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxAgentListResponse>> List(
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<TelnyxAgentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxAgents = await response.Deserialize<TelnyxAgentListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxAgents.Validate();
            }
            return telnyxAgents;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxAgentListResponse>> List(
        string runID,
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxAgentLinkResponse>> Link(
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<TelnyxAgentLinkParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TelnyxAgentLinkResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxAgentLinkResponse>> Link(
        string runID,
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unlink(
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TelnyxAgentID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TelnyxAgentID' cannot be null"
            );
        }

        HttpRequest<TelnyxAgentUnlinkParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Unlink(
        string telnyxAgentID,
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unlink(parameters with{
            TelnyxAgentID = telnyxAgentID
        }, cancellationToken);
    }
}