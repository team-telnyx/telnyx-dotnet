using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Conversations.InsightGroups.Insights;

namespace Telnyx.Sdk.Services.AI.Conversations.InsightGroups;

/// <inheritdoc/>
public sealed class InsightService : IInsightService
{
    readonly Lazy<IInsightServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInsightService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InsightService(this._client.WithOptions(modifier)); }

    public InsightService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InsightServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public Task Assign(
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Assign(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Assign(
        string insightID,
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Assign(parameters with{
            InsightID = insightID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteUnassign(
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteUnassign(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteUnassign(
        string insightID,
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteUnassign(parameters with{
            InsightID = insightID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InsightServiceWithRawResponse : IInsightServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InsightServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InsightServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public Task<HttpResponse> Assign(
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InsightID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InsightID' cannot be null"
            );
        }

        HttpRequest<InsightAssignParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Assign(
        string insightID,
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Assign(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteUnassign(
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InsightID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InsightID' cannot be null"
            );
        }

        HttpRequest<InsightDeleteUnassignParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteUnassign(
        string insightID,
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteUnassign(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }
}