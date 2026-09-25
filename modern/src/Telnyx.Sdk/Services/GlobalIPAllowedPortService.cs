using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAllowedPorts;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPAllowedPortService : IGlobalIPAllowedPortService
{
    readonly Lazy<IGlobalIPAllowedPortServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPAllowedPortServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPAllowedPortService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAllowedPortService(this._client.WithOptions(modifier));
    }

    public GlobalIPAllowedPortService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPAllowedPortServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAllowedPortListResponse> List(
        GlobalIPAllowedPortListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPAllowedPortServiceWithRawResponse : IGlobalIPAllowedPortServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPAllowedPortServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAllowedPortServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPAllowedPortServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAllowedPortListResponse>> List(
        GlobalIPAllowedPortListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPAllowedPortListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAllowedPorts = await response.Deserialize<GlobalIPAllowedPortListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAllowedPorts.Validate();
            }
            return globalIPAllowedPorts;
        });
    }
}