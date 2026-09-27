using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Addresses;
using Addresses = Telnyx.Sdk.Services.Addresses;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AddressService : IAddressService
{
    readonly Lazy<IAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AddressService(this._client.WithOptions(modifier)); }

    public AddressService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AddressServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Addresses::ActionService(client)) ;
    }

    readonly Lazy<Addresses::IActionService> _actions;
    public Addresses::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<AddressCreateResponse> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AddressRetrieveResponse> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddressListPage> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddressDeleteResponse> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AddressDeleteResponse> Delete(
        string id,
        AddressDeleteParams? parameters = null,
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
public sealed class AddressServiceWithRawResponse : IAddressServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddressServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(
            () => new Addresses::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Addresses::IActionServiceWithRawResponse> _actions;
    public Addresses::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressCreateResponse>> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var address = await response.Deserialize<AddressCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                address.Validate();
            }
            return address;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var address = await response.Deserialize<AddressRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                address.Validate();
            }
            return address;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressListPage>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AddressListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AddressListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressDeleteResponse>> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AddressDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var address = await response.Deserialize<AddressDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                address.Validate();
            }
            return address;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AddressDeleteResponse>> Delete(
        string id,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}