using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Payment;
using Telnyx.Sdk.Services.Payment;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PaymentService : IPaymentService
{
    readonly Lazy<IPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PaymentService(this._client.WithOptions(modifier)); }

    public PaymentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PaymentServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _autoRechargePrefs =new(() => new AutoRechargePrefService(client)) ;
    }

    readonly Lazy<IAutoRechargePrefService> _autoRechargePrefs;
    public IAutoRechargePrefService AutoRechargePrefs {
        get { return _autoRechargePrefs.Value; }
    }

    /// <inheritdoc/>
    public async Task<PaymentCreateStoredPaymentTransactionResponse> CreateStoredPaymentTransaction(
        PaymentCreateStoredPaymentTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateStoredPaymentTransaction(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PaymentServiceWithRawResponse : IPaymentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaymentServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _autoRechargePrefs =new(
            () => new AutoRechargePrefServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IAutoRechargePrefServiceWithRawResponse> _autoRechargePrefs;
    public IAutoRechargePrefServiceWithRawResponse AutoRechargePrefs {
        get { return _autoRechargePrefs.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaymentCreateStoredPaymentTransactionResponse>> CreateStoredPaymentTransaction(
        PaymentCreateStoredPaymentTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PaymentCreateStoredPaymentTransactionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PaymentCreateStoredPaymentTransactionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}