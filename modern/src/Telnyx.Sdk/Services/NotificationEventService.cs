using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationEvents;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NotificationEventService : INotificationEventService
{
    readonly Lazy<INotificationEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationEventServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INotificationEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NotificationEventService(this._client.WithOptions(modifier)); }

    public NotificationEventService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NotificationEventServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NotificationEventListPage> List(
        NotificationEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NotificationEventServiceWithRawResponse : INotificationEventServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationEventServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationEventListPage>> List(
        NotificationEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NotificationEventListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NotificationEventListPage(this, parameters, page);
        });
    }
}