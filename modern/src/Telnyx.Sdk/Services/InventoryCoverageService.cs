using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InventoryCoverage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class InventoryCoverageService : IInventoryCoverageService
{
    readonly Lazy<IInventoryCoverageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInventoryCoverageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInventoryCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InventoryCoverageService(this._client.WithOptions(modifier)); }

    public InventoryCoverageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InventoryCoverageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InventoryCoverageListResponse> List(
        InventoryCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InventoryCoverageServiceWithRawResponse : IInventoryCoverageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInventoryCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InventoryCoverageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InventoryCoverageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InventoryCoverageListResponse>> List(
        InventoryCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InventoryCoverageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inventoryCoverages = await response.Deserialize<InventoryCoverageListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inventoryCoverages.Validate();
            }
            return inventoryCoverages;
        });
    }
}