using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SpeechToText;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SpeechToTextService : ISpeechToTextService
{
    readonly Lazy<ISpeechToTextServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeechToTextServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISpeechToTextService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SpeechToTextService(this._client.WithOptions(modifier)); }

    public SpeechToTextService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SpeechToTextServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SpeechToTextListProvidersResponse> ListProviders(
        SpeechToTextListProvidersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListProviders(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RetrieveTranscription(
        SpeechToTextRetrieveTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveTranscription(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpeechToTextServiceWithRawResponse : ISpeechToTextServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeechToTextServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SpeechToTextServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeechToTextServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpeechToTextListProvidersResponse>> ListProviders(
        SpeechToTextListProvidersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SpeechToTextListProvidersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SpeechToTextListProvidersResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveTranscription(
        SpeechToTextRetrieveTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpeechToTextRetrieveTranscriptionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}