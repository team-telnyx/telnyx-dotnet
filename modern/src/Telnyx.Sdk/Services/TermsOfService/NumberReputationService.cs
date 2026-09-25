using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;
using Telnyx.Sdk.Models.TermsOfService.NumberReputation;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <inheritdoc/>
public sealed class NumberReputationService : INumberReputationService
{
    readonly Lazy<INumberReputationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberReputationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberReputationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberReputationService(this._client.WithOptions(modifier)); }

    public NumberReputationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberReputationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TosAgreementWrapped> Agree(
        NumberReputationAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Agree(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NumberReputationServiceWithRawResponse : INumberReputationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberReputationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberReputationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberReputationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TosAgreementWrapped>> Agree(
        NumberReputationAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberReputationAgreeParams> request = new()
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