using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingUrlDomains;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingUrlDomainService : IMessagingUrlDomainService
{
    readonly Lazy<IMessagingUrlDomainServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingUrlDomainServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingUrlDomainService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingUrlDomainService(this._client.WithOptions(modifier));
    }

    public MessagingUrlDomainService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingUrlDomainServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingUrlDomainListPage> List(
        MessagingUrlDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessagingUrlDomainServiceWithRawResponse : IMessagingUrlDomainServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingUrlDomainServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingUrlDomainServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingUrlDomainServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingUrlDomainListPage>> List(
        MessagingUrlDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingUrlDomainListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingUrlDomainListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingUrlDomainListPage(this, parameters, page);
        });
    }
}