using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPHealthCheckTypes;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPHealthCheckTypeService : IGlobalIPHealthCheckTypeService
{
    readonly Lazy<IGlobalIPHealthCheckTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckTypeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckTypeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPHealthCheckTypeService(this._client.WithOptions(modifier));
    }

    public GlobalIPHealthCheckTypeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPHealthCheckTypeServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPHealthCheckTypeListResponse> List(
        GlobalIPHealthCheckTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPHealthCheckTypeServiceWithRawResponse : IGlobalIPHealthCheckTypeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPHealthCheckTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPHealthCheckTypeServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPHealthCheckTypeListResponse>> List(
        GlobalIPHealthCheckTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPHealthCheckTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPHealthCheckTypes = await response.Deserialize<GlobalIPHealthCheckTypeListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPHealthCheckTypes.Validate();
            }
            return globalIPHealthCheckTypes;
        });
    }
}