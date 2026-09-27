using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Audio;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class AudioService : IAudioService
{
    readonly Lazy<IAudioServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudioServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAudioService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AudioService(this._client.WithOptions(modifier)); }

    public AudioService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AudioServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AudioTranscribeResponse> Transcribe(
        AudioTranscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Transcribe(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AudioServiceWithRawResponse : IAudioServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudioServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AudioServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudioServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AudioTranscribeResponse>> Transcribe(
        AudioTranscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudioTranscribeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<AudioTranscribeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}