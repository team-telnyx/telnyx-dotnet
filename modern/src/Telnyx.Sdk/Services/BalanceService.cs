using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Balance;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BalanceService : IBalanceService
{
    readonly Lazy<IBalanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBalanceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BalanceService(this._client.WithOptions(modifier)); }

    public BalanceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BalanceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BalanceRetrieveResponse> Retrieve(
        BalanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BalanceServiceWithRawResponse : IBalanceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BalanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BalanceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceRetrieveResponse>> Retrieve(
        BalanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BalanceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var balance = await response.Deserialize<BalanceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                balance.Validate();
            }
            return balance;
        });
    }
}