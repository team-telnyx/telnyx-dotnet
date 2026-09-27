using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberLookup;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumberLookupService : INumberLookupService
{
    readonly Lazy<INumberLookupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberLookupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberLookupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberLookupService(this._client.WithOptions(modifier)); }

    public NumberLookupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberLookupServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NumberLookupRetrieveResponse> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberLookupRetrieveResponse> Retrieve(
        string phoneNumber,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NumberLookupServiceWithRawResponse : INumberLookupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberLookupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberLookupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberLookupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<NumberLookupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberLookup = await response.Deserialize<NumberLookupRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberLookup.Validate();
            }
            return numberLookup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        string phoneNumber,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}