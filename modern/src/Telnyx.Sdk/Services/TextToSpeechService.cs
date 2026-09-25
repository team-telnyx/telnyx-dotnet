using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TextToSpeech;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TextToSpeechService : ITextToSpeechService
{
    readonly Lazy<ITextToSpeechServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITextToSpeechServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITextToSpeechService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TextToSpeechService(this._client.WithOptions(modifier)); }

    public TextToSpeechService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TextToSpeechServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TextToSpeechGenerateSpeechResponse> GenerateSpeech(
        TextToSpeechGenerateSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GenerateSpeech(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TextToSpeechListVoicesResponse> ListVoices(
        TextToSpeechListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListVoices(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RetrieveSpeech(
        TextToSpeechRetrieveSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveSpeech(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TextToSpeechServiceWithRawResponse : ITextToSpeechServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITextToSpeechServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TextToSpeechServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TextToSpeechServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TextToSpeechGenerateSpeechResponse>> GenerateSpeech(
        TextToSpeechGenerateSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TextToSpeechGenerateSpeechParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TextToSpeechGenerateSpeechResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TextToSpeechListVoicesResponse>> ListVoices(
        TextToSpeechListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TextToSpeechListVoicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TextToSpeechListVoicesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveSpeech(
        TextToSpeechRetrieveSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TextToSpeechRetrieveSpeechParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}