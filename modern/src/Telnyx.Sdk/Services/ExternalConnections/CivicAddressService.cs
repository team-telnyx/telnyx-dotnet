using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <inheritdoc/>
public sealed class CivicAddressService : ICivicAddressService
{
    readonly Lazy<ICivicAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICivicAddressServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICivicAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CivicAddressService(this._client.WithOptions(modifier)); }

    public CivicAddressService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CivicAddressServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CivicAddressRetrieveResponse> Retrieve(
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CivicAddressRetrieveResponse> Retrieve(
        string addressID,
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            AddressID = addressID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CivicAddressListResponse> List(
        CivicAddressListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CivicAddressListResponse> List(
        string id,
        CivicAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CivicAddressServiceWithRawResponse : ICivicAddressServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICivicAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CivicAddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CivicAddressServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CivicAddressRetrieveResponse>> Retrieve(
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AddressID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AddressID' cannot be null"
            );
        }

        HttpRequest<CivicAddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var civicAddress = await response.Deserialize<CivicAddressRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                civicAddress.Validate();
            }
            return civicAddress;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CivicAddressRetrieveResponse>> Retrieve(
        string addressID,
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            AddressID = addressID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CivicAddressListResponse>> List(
        CivicAddressListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CivicAddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var civicAddresses = await response.Deserialize<CivicAddressListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                civicAddresses.Validate();
            }
            return civicAddresses;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CivicAddressListResponse>> List(
        string id,
        CivicAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}