using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingProfileMetrics;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingProfileMetricService : IMessagingProfileMetricService
{
    readonly Lazy<IMessagingProfileMetricServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingProfileMetricServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingProfileMetricService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingProfileMetricService(this._client.WithOptions(modifier));
    }

    public MessagingProfileMetricService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingProfileMetricServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileMetricListResponse> List(
        MessagingProfileMetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessagingProfileMetricServiceWithRawResponse : IMessagingProfileMetricServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingProfileMetricServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingProfileMetricServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingProfileMetricServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileMetricListResponse>> List(
        MessagingProfileMetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingProfileMetricListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingProfileMetrics = await response.Deserialize<MessagingProfileMetricListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingProfileMetrics.Validate();
            }
            return messagingProfileMetrics;
        });
    }
}