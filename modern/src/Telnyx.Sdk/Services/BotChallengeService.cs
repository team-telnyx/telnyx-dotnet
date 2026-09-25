using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotChallenge;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BotChallengeService : IBotChallengeService
{
    readonly Lazy<IBotChallengeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBotChallengeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBotChallengeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BotChallengeService(this._client.WithOptions(modifier)); }

    public BotChallengeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BotChallengeServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BotChallengeCreateResponse> Create(
        BotChallengeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BotChallengeServiceWithRawResponse : IBotChallengeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBotChallengeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BotChallengeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BotChallengeServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BotChallengeCreateResponse>> Create(
        BotChallengeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BotChallengeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var botChallenge = await response.Deserialize<BotChallengeCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                botChallenge.Validate();
            }
            return botChallenge;
        });
    }
}