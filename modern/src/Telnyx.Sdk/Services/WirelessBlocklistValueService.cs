using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WirelessBlocklistValues;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WirelessBlocklistValueService : IWirelessBlocklistValueService
{
    readonly Lazy<IWirelessBlocklistValueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWirelessBlocklistValueServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWirelessBlocklistValueService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WirelessBlocklistValueService(this._client.WithOptions(modifier));
    }

    public WirelessBlocklistValueService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WirelessBlocklistValueServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WirelessBlocklistValueListResponse> List(
        WirelessBlocklistValueListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WirelessBlocklistValueServiceWithRawResponse : IWirelessBlocklistValueServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWirelessBlocklistValueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WirelessBlocklistValueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WirelessBlocklistValueServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessBlocklistValueListResponse>> List(
        WirelessBlocklistValueListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WirelessBlocklistValueListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wirelessBlocklistValues = await response.Deserialize<WirelessBlocklistValueListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wirelessBlocklistValues.Validate();
            }
            return wirelessBlocklistValues;
        });
    }
}