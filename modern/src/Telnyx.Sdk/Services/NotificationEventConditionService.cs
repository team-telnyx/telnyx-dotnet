using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationEventConditions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NotificationEventConditionService : INotificationEventConditionService
{
    readonly Lazy<INotificationEventConditionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationEventConditionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INotificationEventConditionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationEventConditionService(this._client.WithOptions(modifier));
    }

    public NotificationEventConditionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NotificationEventConditionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NotificationEventConditionListPage> List(
        NotificationEventConditionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NotificationEventConditionServiceWithRawResponse : INotificationEventConditionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationEventConditionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationEventConditionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationEventConditionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationEventConditionListPage>> List(
        NotificationEventConditionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationEventConditionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NotificationEventConditionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NotificationEventConditionListPage(this,
            parameters,
            page);
        });
    }
}