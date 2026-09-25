using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPUsage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPUsageService : IGlobalIPUsageService
{
    readonly Lazy<IGlobalIPUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPUsageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPUsageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new GlobalIPUsageService(this._client.WithOptions(modifier)); }

    public GlobalIPUsageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPUsageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPUsageRetrieveResponse> Retrieve(
        GlobalIPUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPUsageServiceWithRawResponse : IGlobalIPUsageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPUsageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPUsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPUsageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPUsageRetrieveResponse>> Retrieve(
        GlobalIPUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPUsageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPUsage = await response.Deserialize<GlobalIPUsageRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPUsage.Validate();
            }
            return globalIPUsage;
        });
    }
}