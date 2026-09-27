using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallEvents;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CallEventService : ICallEventService
{
    readonly Lazy<ICallEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallEventServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICallEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CallEventService(this._client.WithOptions(modifier)); }

    public CallEventService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CallEventServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CallEventListPage> List(
        CallEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CallEventServiceWithRawResponse : ICallEventServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallEventServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallEventListPage>> List(
        CallEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CallEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CallEventListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CallEventListPage(this, parameters, page);
        });
    }
}