using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobileNetworkOperators;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MobileNetworkOperatorService : IMobileNetworkOperatorService
{
    readonly Lazy<IMobileNetworkOperatorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMobileNetworkOperatorServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMobileNetworkOperatorService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobileNetworkOperatorService(this._client.WithOptions(modifier));
    }

    public MobileNetworkOperatorService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MobileNetworkOperatorServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MobileNetworkOperatorListPage> List(
        MobileNetworkOperatorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MobileNetworkOperatorServiceWithRawResponse : IMobileNetworkOperatorServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMobileNetworkOperatorServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobileNetworkOperatorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MobileNetworkOperatorServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileNetworkOperatorListPage>> List(
        MobileNetworkOperatorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MobileNetworkOperatorListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MobileNetworkOperatorListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MobileNetworkOperatorListPage(this, parameters, page);
        });
    }
}