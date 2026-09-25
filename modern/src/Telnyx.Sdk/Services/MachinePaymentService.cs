using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MachinePayments;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MachinePaymentService : IMachinePaymentService
{
    readonly Lazy<IMachinePaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMachinePaymentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMachinePaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MachinePaymentService(this._client.WithOptions(modifier)); }

    public MachinePaymentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MachinePaymentServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MachinePaymentAccountCreditResponse> AccountCredit(
        MachinePaymentAccountCreditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.AccountCredit(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MachinePaymentServiceWithRawResponse : IMachinePaymentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMachinePaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MachinePaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MachinePaymentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MachinePaymentAccountCreditResponse>> AccountCredit(
        MachinePaymentAccountCreditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachinePaymentAccountCreditParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MachinePaymentAccountCreditResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}