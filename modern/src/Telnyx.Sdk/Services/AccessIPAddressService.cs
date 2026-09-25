using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AccessIPAddress;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AccessIPAddressService : IAccessIPAddressService
{
    readonly Lazy<IAccessIPAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccessIPAddressServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAccessIPAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AccessIPAddressService(this._client.WithOptions(modifier)); }

    public AccessIPAddressService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AccessIPAddressServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AccessIPAddressResponse> Create(
        AccessIPAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccessIPAddressResponse> Retrieve(
        AccessIPAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AccessIPAddressResponse> Retrieve(
        string accessIPAddressID,
        AccessIPAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AccessIPAddressID = accessIPAddressID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccessIPAddressListPage> List(
        AccessIPAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccessIPAddressResponse> Delete(
        AccessIPAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AccessIPAddressResponse> Delete(
        string accessIPAddressID,
        AccessIPAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AccessIPAddressID = accessIPAddressID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccessIPAddressServiceWithRawResponse : IAccessIPAddressServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccessIPAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccessIPAddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccessIPAddressServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPAddressResponse>> Create(
        AccessIPAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccessIPAddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var accessIPAddressResponse = await response.Deserialize<AccessIPAddressResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                accessIPAddressResponse.Validate();
            }
            return accessIPAddressResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPAddressResponse>> Retrieve(
        AccessIPAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccessIPAddressID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccessIPAddressID' cannot be null"
            );
        }

        HttpRequest<AccessIPAddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var accessIPAddressResponse = await response.Deserialize<AccessIPAddressResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                accessIPAddressResponse.Validate();
            }
            return accessIPAddressResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AccessIPAddressResponse>> Retrieve(
        string accessIPAddressID,
        AccessIPAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AccessIPAddressID = accessIPAddressID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPAddressListPage>> List(
        AccessIPAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccessIPAddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AccessIPAddressListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AccessIPAddressListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPAddressResponse>> Delete(
        AccessIPAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccessIPAddressID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccessIPAddressID' cannot be null"
            );
        }

        HttpRequest<AccessIPAddressDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var accessIPAddressResponse = await response.Deserialize<AccessIPAddressResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                accessIPAddressResponse.Validate();
            }
            return accessIPAddressResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AccessIPAddressResponse>> Delete(
        string accessIPAddressID,
        AccessIPAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AccessIPAddressID = accessIPAddressID
        }, cancellationToken);
    }
}