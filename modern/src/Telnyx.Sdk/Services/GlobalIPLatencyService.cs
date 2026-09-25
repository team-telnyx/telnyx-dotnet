using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPLatency;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPLatencyService : IGlobalIPLatencyService
{
    readonly Lazy<IGlobalIPLatencyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPLatencyServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPLatencyService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new GlobalIPLatencyService(this._client.WithOptions(modifier)); }

    public GlobalIPLatencyService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPLatencyServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPLatencyRetrieveResponse> Retrieve(
        GlobalIPLatencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPLatencyServiceWithRawResponse : IGlobalIPLatencyServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPLatencyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPLatencyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPLatencyServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPLatencyRetrieveResponse>> Retrieve(
        GlobalIPLatencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPLatencyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPLatency = await response.Deserialize<GlobalIPLatencyRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPLatency.Validate();
            }
            return globalIPLatency;
        });
    }
}