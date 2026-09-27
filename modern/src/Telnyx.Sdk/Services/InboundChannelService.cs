using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InboundChannels;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class InboundChannelService : IInboundChannelService
{
    readonly Lazy<IInboundChannelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundChannelServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInboundChannelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InboundChannelService(this._client.WithOptions(modifier)); }

    public InboundChannelService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InboundChannelServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InboundChannelUpdateResponse> Update(
        InboundChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundChannelListResponse> List(
        InboundChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InboundChannelServiceWithRawResponse : IInboundChannelServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundChannelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundChannelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundChannelServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundChannelUpdateResponse>> Update(
        InboundChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundChannelUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inboundChannel = await response.Deserialize<InboundChannelUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inboundChannel.Validate();
            }
            return inboundChannel;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundChannelListResponse>> List(
        InboundChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundChannelListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inboundChannels = await response.Deserialize<InboundChannelListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inboundChannels.Validate();
            }
            return inboundChannels;
        });
    }
}