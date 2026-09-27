using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VirtualCrossConnectsCoverage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VirtualCrossConnectsCoverageService : IVirtualCrossConnectsCoverageService
{
    readonly Lazy<IVirtualCrossConnectsCoverageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVirtualCrossConnectsCoverageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVirtualCrossConnectsCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VirtualCrossConnectsCoverageService(this._client.WithOptions(modifier));
    }

    public VirtualCrossConnectsCoverageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VirtualCrossConnectsCoverageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectsCoverageListPage> List(
        VirtualCrossConnectsCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VirtualCrossConnectsCoverageServiceWithRawResponse : IVirtualCrossConnectsCoverageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVirtualCrossConnectsCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VirtualCrossConnectsCoverageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VirtualCrossConnectsCoverageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectsCoverageListPage>> List(
        VirtualCrossConnectsCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VirtualCrossConnectsCoverageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VirtualCrossConnectsCoverageListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VirtualCrossConnectsCoverageListPage(this,
            parameters,
            page);
        });
    }
}