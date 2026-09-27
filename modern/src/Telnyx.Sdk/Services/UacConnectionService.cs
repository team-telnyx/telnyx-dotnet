using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.UacConnections;
using UacConnections = Telnyx.Sdk.Services.UacConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class UacConnectionService : IUacConnectionService
{
    readonly Lazy<IUacConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUacConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUacConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UacConnectionService(this._client.WithOptions(modifier)); }

    public UacConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UacConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new UacConnections::ActionService(client)) ;
    }

    readonly Lazy<UacConnections::IActionService> _actions;
    public UacConnections::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<UacConnectionCreateResponse> Create(
        UacConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UacConnectionRetrieveResponse> Retrieve(
        UacConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UacConnectionRetrieveResponse> Retrieve(
        string id,
        UacConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UacConnectionUpdateResponse> Update(
        UacConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UacConnectionUpdateResponse> Update(
        string id,
        UacConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UacConnectionListPage> List(
        UacConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UacConnectionDeleteResponse> Delete(
        UacConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UacConnectionDeleteResponse> Delete(
        string id,
        UacConnectionDeleteParams? parameters = null,
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
public sealed class UacConnectionServiceWithRawResponse : IUacConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUacConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UacConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UacConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new UacConnections::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<UacConnections::IActionServiceWithRawResponse> _actions;
    public UacConnections::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UacConnectionCreateResponse>> Create(
        UacConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UacConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var uacConnection = await response.Deserialize<UacConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                uacConnection.Validate();
            }
            return uacConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UacConnectionRetrieveResponse>> Retrieve(
        UacConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UacConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var uacConnection = await response.Deserialize<UacConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                uacConnection.Validate();
            }
            return uacConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UacConnectionRetrieveResponse>> Retrieve(
        string id,
        UacConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UacConnectionUpdateResponse>> Update(
        UacConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UacConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var uacConnection = await response.Deserialize<UacConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                uacConnection.Validate();
            }
            return uacConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UacConnectionUpdateResponse>> Update(
        string id,
        UacConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UacConnectionListPage>> List(
        UacConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UacConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<UacConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new UacConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UacConnectionDeleteResponse>> Delete(
        UacConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UacConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var uacConnection = await response.Deserialize<UacConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                uacConnection.Validate();
            }
            return uacConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UacConnectionDeleteResponse>> Delete(
        string id,
        UacConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}