using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NoiseSuppressionEngines;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NoiseSuppressionEngineService : INoiseSuppressionEngineService
{
    readonly Lazy<INoiseSuppressionEngineServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INoiseSuppressionEngineServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INoiseSuppressionEngineService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NoiseSuppressionEngineService(this._client.WithOptions(modifier));
    }

    public NoiseSuppressionEngineService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NoiseSuppressionEngineServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NoiseSuppressionEngineListResponse> List(
        NoiseSuppressionEngineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NoiseSuppressionEngineServiceWithRawResponse : INoiseSuppressionEngineServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INoiseSuppressionEngineServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NoiseSuppressionEngineServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NoiseSuppressionEngineServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NoiseSuppressionEngineListResponse>> List(
        NoiseSuppressionEngineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NoiseSuppressionEngineListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var noiseSuppressionEngines = await response.Deserialize<NoiseSuppressionEngineListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                noiseSuppressionEngines.Validate();
            }
            return noiseSuppressionEngines;
        });
    }
}