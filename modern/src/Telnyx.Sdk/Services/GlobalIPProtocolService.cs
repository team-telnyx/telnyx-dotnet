using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPProtocols;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPProtocolService : IGlobalIPProtocolService
{
    readonly Lazy<IGlobalIPProtocolServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPProtocolServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPProtocolService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new GlobalIPProtocolService(this._client.WithOptions(modifier)); }

    public GlobalIPProtocolService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPProtocolServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPProtocolListResponse> List(
        GlobalIPProtocolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPProtocolServiceWithRawResponse : IGlobalIPProtocolServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPProtocolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPProtocolServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPProtocolServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPProtocolListResponse>> List(
        GlobalIPProtocolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPProtocolListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPProtocols = await response.Deserialize<GlobalIPProtocolListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPProtocols.Validate();
            }
            return globalIPProtocols;
        });
    }
}