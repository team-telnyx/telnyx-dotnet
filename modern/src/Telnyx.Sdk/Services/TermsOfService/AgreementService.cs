using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.TermsOfService.Agreements;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <inheritdoc/>
public sealed class AgreementService : IAgreementService
{
    readonly Lazy<IAgreementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgreementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAgreementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AgreementService(this._client.WithOptions(modifier)); }

    public AgreementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AgreementServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TosAgreementWrapped> Retrieve(
        AgreementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TosAgreementWrapped> Retrieve(
        string agreementID,
        AgreementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AgreementID = agreementID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgreementListPage> List(
        AgreementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AgreementServiceWithRawResponse : IAgreementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgreementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AgreementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgreementServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TosAgreementWrapped>> Retrieve(
        AgreementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgreementID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AgreementID' cannot be null"
            );
        }

        HttpRequest<AgreementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    }/// <inheritdoc/>
    public Task<HttpResponse<TosAgreementWrapped>> Retrieve(
        string agreementID,
        AgreementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AgreementID = agreementID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgreementListPage>> List(
        AgreementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgreementListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AgreementListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AgreementListPage(this, parameters, page);
        });
    }
}