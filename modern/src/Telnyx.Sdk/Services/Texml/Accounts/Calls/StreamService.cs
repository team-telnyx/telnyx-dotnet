using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Streams;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <inheritdoc/>
public sealed class StreamService : IStreamService
{
    readonly Lazy<IStreamServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStreamServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IStreamService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new StreamService(this._client.WithOptions(modifier)); }

    public StreamService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new StreamServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<StreamStreamingSidJsonResponse> StreamingSidJson(
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StreamingSidJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<StreamStreamingSidJsonResponse> StreamingSidJson(
        string streamingSid,
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StreamingSidJson(parameters with{
            StreamingSid = streamingSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class StreamServiceWithRawResponse : IStreamServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStreamServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new StreamServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StreamServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<StreamStreamingSidJsonResponse>> StreamingSidJson(
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StreamingSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.StreamingSid' cannot be null"
            );
        }

        HttpRequest<StreamStreamingSidJsonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<StreamStreamingSidJsonResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<StreamStreamingSidJsonResponse>> StreamingSidJson(
        string streamingSid,
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StreamingSidJson(parameters with{
            StreamingSid = streamingSid
        }, cancellationToken);
    }
}