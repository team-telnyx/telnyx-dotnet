using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.X402.CreditAccount;
using CreditAccount = Telnyx.Sdk.Services.X402.CreditAccount;

namespace Telnyx.Sdk.Services.X402;

/// <inheritdoc/>
public sealed class CreditAccountService : ICreditAccountService
{
    readonly Lazy<ICreditAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditAccountServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICreditAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CreditAccountService(this._client.WithOptions(modifier)); }

    public CreditAccountService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CreditAccountServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _payments =new(() => new CreditAccount::PaymentService(client)) ;
    }

    readonly Lazy<CreditAccount::IPaymentService> _payments;
    public CreditAccount::IPaymentService Payments {
        get { return _payments.Value; }
    }

    /// <inheritdoc/>
    public async Task<CreditAccountCreateQuoteResponse> CreateQuote(
        CreditAccountCreateQuoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateQuote(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditAccountSettleResponse> Settle(
        CreditAccountSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Settle(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CreditAccountServiceWithRawResponse : ICreditAccountServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CreditAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditAccountServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _payments =new(
            () => new CreditAccount::PaymentServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<CreditAccount::IPaymentServiceWithRawResponse> _payments;
    public CreditAccount::IPaymentServiceWithRawResponse Payments {
        get { return _payments.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditAccountCreateQuoteResponse>> CreateQuote(
        CreditAccountCreateQuoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditAccountCreateQuoteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CreditAccountCreateQuoteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditAccountSettleResponse>> Settle(
        CreditAccountSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditAccountSettleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CreditAccountSettleResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}