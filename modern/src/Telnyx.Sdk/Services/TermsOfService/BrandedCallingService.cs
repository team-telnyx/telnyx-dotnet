using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;
using Telnyx.Sdk.Models.TermsOfService.BrandedCalling;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <inheritdoc/>
public sealed class BrandedCallingService : IBrandedCallingService
{
    readonly Lazy<IBrandedCallingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrandedCallingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBrandedCallingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BrandedCallingService(this._client.WithOptions(modifier)); }

    public BrandedCallingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BrandedCallingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TosAgreementWrapped> Agree(
        BrandedCallingAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Agree(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BrandedCallingServiceWithRawResponse : IBrandedCallingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrandedCallingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BrandedCallingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrandedCallingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TosAgreementWrapped>> Agree(
        BrandedCallingAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandedCallingAgreeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var tosAgreementWrapped = await response.Deserialize<TosAgreementWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                tosAgreementWrapped.Validate();
            }
            return tosAgreementWrapped;
        });
    }
}