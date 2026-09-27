using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CountryCoverage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CountryCoverageService : ICountryCoverageService
{
    readonly Lazy<ICountryCoverageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICountryCoverageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICountryCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CountryCoverageService(this._client.WithOptions(modifier)); }

    public CountryCoverageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CountryCoverageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CountryCoverageRetrieveResponse> Retrieve(
        CountryCoverageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CountryCoverageRetrieveCountryResponse> RetrieveCountry(
        CountryCoverageRetrieveCountryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveCountry(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CountryCoverageRetrieveCountryResponse> RetrieveCountry(
        string countryCode,
        CountryCoverageRetrieveCountryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCountry(parameters with{
            CountryCode = countryCode
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CountryCoverageServiceWithRawResponse : ICountryCoverageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICountryCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CountryCoverageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CountryCoverageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CountryCoverageRetrieveResponse>> Retrieve(
        CountryCoverageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CountryCoverageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var countryCoverage = await response.Deserialize<CountryCoverageRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                countryCoverage.Validate();
            }
            return countryCoverage;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CountryCoverageRetrieveCountryResponse>> RetrieveCountry(
        CountryCoverageRetrieveCountryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CountryCode == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CountryCode' cannot be null"
            );
        }

        HttpRequest<CountryCoverageRetrieveCountryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CountryCoverageRetrieveCountryResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CountryCoverageRetrieveCountryResponse>> RetrieveCountry(
        string countryCode,
        CountryCoverageRetrieveCountryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCountry(parameters with{
            CountryCode = countryCode
        }, cancellationToken);
    }
}