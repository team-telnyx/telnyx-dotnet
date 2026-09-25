using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService;
using Telnyx.Sdk.Services.TermsOfService;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TermsOfServiceService : ITermsOfServiceService
{
    readonly Lazy<ITermsOfServiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITermsOfServiceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITermsOfServiceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TermsOfServiceService(this._client.WithOptions(modifier)); }

    public TermsOfServiceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TermsOfServiceServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _numberReputation =new(() => new NumberReputationService(client)) ;
        _agreements =new(() => new AgreementService(client)) ;
        _brandedCalling =new(() => new BrandedCallingService(client)) ;
    }

    readonly Lazy<INumberReputationService> _numberReputation;
    public INumberReputationService NumberReputation {
        get { return _numberReputation.Value; }
    }

    readonly Lazy<IAgreementService> _agreements;
    public IAgreementService Agreements { get { return _agreements.Value; } }

    readonly Lazy<IBrandedCallingService> _brandedCalling;
    public IBrandedCallingService BrandedCalling {
        get { return _brandedCalling.Value; }
    }

    /// <inheritdoc/>
    public async Task<TermsOfServiceRetrieveInfoResponse> RetrieveInfo(
        TermsOfServiceRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveInfo(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TermsOfServiceRetrieveStatusResponse> RetrieveStatus(
        TermsOfServiceRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TermsOfServiceServiceWithRawResponse : ITermsOfServiceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITermsOfServiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TermsOfServiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TermsOfServiceServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _numberReputation =new(
            () => new NumberReputationServiceWithRawResponse(client)
        ) ;
        _agreements =new(() => new AgreementServiceWithRawResponse(client)) ;
        _brandedCalling =new(
            () => new BrandedCallingServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<INumberReputationServiceWithRawResponse> _numberReputation;
    public INumberReputationServiceWithRawResponse NumberReputation {
        get { return _numberReputation.Value; }
    }

    readonly Lazy<IAgreementServiceWithRawResponse> _agreements;
    public IAgreementServiceWithRawResponse Agreements {
        get { return _agreements.Value; }
    }

    readonly Lazy<IBrandedCallingServiceWithRawResponse> _brandedCalling;
    public IBrandedCallingServiceWithRawResponse BrandedCalling {
        get { return _brandedCalling.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TermsOfServiceRetrieveInfoResponse>> RetrieveInfo(
        TermsOfServiceRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TermsOfServiceRetrieveInfoParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TermsOfServiceRetrieveInfoResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TermsOfServiceRetrieveStatusResponse>> RetrieveStatus(
        TermsOfServiceRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TermsOfServiceRetrieveStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TermsOfServiceRetrieveStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}