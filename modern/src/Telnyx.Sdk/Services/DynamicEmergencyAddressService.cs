using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.DynamicEmergencyAddresses;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class DynamicEmergencyAddressService : IDynamicEmergencyAddressService
{
    readonly Lazy<IDynamicEmergencyAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDynamicEmergencyAddressServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDynamicEmergencyAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DynamicEmergencyAddressService(this._client.WithOptions(modifier));
    }

    public DynamicEmergencyAddressService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DynamicEmergencyAddressServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyAddressCreateResponse> Create(
        DynamicEmergencyAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyAddressRetrieveResponse> Retrieve(
        DynamicEmergencyAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DynamicEmergencyAddressRetrieveResponse> Retrieve(
        string id,
        DynamicEmergencyAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyAddressListPage> List(
        DynamicEmergencyAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyAddressDeleteResponse> Delete(
        DynamicEmergencyAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DynamicEmergencyAddressDeleteResponse> Delete(
        string id,
        DynamicEmergencyAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DynamicEmergencyAddressServiceWithRawResponse : IDynamicEmergencyAddressServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDynamicEmergencyAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DynamicEmergencyAddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DynamicEmergencyAddressServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyAddressCreateResponse>> Create(
        DynamicEmergencyAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DynamicEmergencyAddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyAddress = await response.Deserialize<DynamicEmergencyAddressCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyAddress.Validate();
            }
            return dynamicEmergencyAddress;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyAddressRetrieveResponse>> Retrieve(
        DynamicEmergencyAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DynamicEmergencyAddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyAddress = await response.Deserialize<DynamicEmergencyAddressRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyAddress.Validate();
            }
            return dynamicEmergencyAddress;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DynamicEmergencyAddressRetrieveResponse>> Retrieve(
        string id,
        DynamicEmergencyAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyAddressListPage>> List(
        DynamicEmergencyAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DynamicEmergencyAddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DynamicEmergencyAddressListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DynamicEmergencyAddressListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyAddressDeleteResponse>> Delete(
        DynamicEmergencyAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DynamicEmergencyAddressDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyAddress = await response.Deserialize<DynamicEmergencyAddressDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyAddress.Validate();
            }
            return dynamicEmergencyAddress;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DynamicEmergencyAddressDeleteResponse>> Delete(
        string id,
        DynamicEmergencyAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}