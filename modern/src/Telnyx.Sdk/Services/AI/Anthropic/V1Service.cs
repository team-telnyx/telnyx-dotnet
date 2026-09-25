using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Anthropic.V1;

namespace Telnyx.Sdk.Services.AI.Anthropic;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new V1Service(this._client.WithOptions(modifier)); }

    public V1Service (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new V1ServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> Messages(
        V1MessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Messages(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new V1ServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public V1ServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> Messages(
        V1MessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1MessagesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }
}