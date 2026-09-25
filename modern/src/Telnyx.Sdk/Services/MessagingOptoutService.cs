using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingOptouts;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingOptoutService : IMessagingOptoutService
{
    readonly Lazy<IMessagingOptoutServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingOptoutServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingOptoutService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessagingOptoutService(this._client.WithOptions(modifier)); }

    public MessagingOptoutService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingOptoutServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingOptoutListPage> List(
        MessagingOptoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessagingOptoutServiceWithRawResponse : IMessagingOptoutServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingOptoutServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingOptoutServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingOptoutServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingOptoutListPage>> List(
        MessagingOptoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingOptoutListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingOptoutListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingOptoutListPage(this, parameters, page);
        });
    }
}