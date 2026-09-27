using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ChargesSummary;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ChargesSummaryService : IChargesSummaryService
{
    readonly Lazy<IChargesSummaryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChargesSummaryServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IChargesSummaryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ChargesSummaryService(this._client.WithOptions(modifier)); }

    public ChargesSummaryService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ChargesSummaryServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ChargesSummaryRetrieveResponse> Retrieve(
        ChargesSummaryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ChargesSummaryServiceWithRawResponse : IChargesSummaryServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChargesSummaryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ChargesSummaryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChargesSummaryServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargesSummaryRetrieveResponse>> Retrieve(
        ChargesSummaryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChargesSummaryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var chargesSummary = await response.Deserialize<ChargesSummaryRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                chargesSummary.Validate();
            }
            return chargesSummary;
        });
    }
}