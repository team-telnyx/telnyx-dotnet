using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Regions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RegionService : IRegionService
{
    readonly Lazy<IRegionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRegionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RegionService(this._client.WithOptions(modifier)); }

    public RegionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RegionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RegionListResponse> List(
        RegionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RegionServiceWithRawResponse : IRegionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegionListResponse>> List(
        RegionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RegionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var regions = await response.Deserialize<RegionListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                regions.Validate();
            }
            return regions;
        });
    }
}