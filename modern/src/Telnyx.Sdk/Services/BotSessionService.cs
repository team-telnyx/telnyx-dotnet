using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotSessions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BotSessionService : IBotSessionService
{
    readonly Lazy<IBotSessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBotSessionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBotSessionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BotSessionService(this._client.WithOptions(modifier)); }

    public BotSessionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BotSessionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BotSessionListResponse> List(
        BotSessionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BotSessionServiceWithRawResponse : IBotSessionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBotSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BotSessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BotSessionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BotSessionListResponse>> List(
        BotSessionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BotSessionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var botSessions = await response.Deserialize<BotSessionListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                botSessions.Validate();
            }
            return botSessions;
        });
    }
}