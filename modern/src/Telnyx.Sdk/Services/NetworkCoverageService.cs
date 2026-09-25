using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NetworkCoverage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NetworkCoverageService : INetworkCoverageService
{
    readonly Lazy<INetworkCoverageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INetworkCoverageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INetworkCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NetworkCoverageService(this._client.WithOptions(modifier)); }

    public NetworkCoverageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NetworkCoverageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NetworkCoverageListPage> List(
        NetworkCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NetworkCoverageServiceWithRawResponse : INetworkCoverageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INetworkCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NetworkCoverageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NetworkCoverageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkCoverageListPage>> List(
        NetworkCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NetworkCoverageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NetworkCoverageListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NetworkCoverageListPage(this, parameters, page);
        });
    }
}