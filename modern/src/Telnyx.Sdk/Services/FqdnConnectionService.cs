using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.FqdnConnections;
using Telnyx.Sdk.Services.FqdnConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class FqdnConnectionService : IFqdnConnectionService
{
    readonly Lazy<IFqdnConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFqdnConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFqdnConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new FqdnConnectionService(this._client.WithOptions(modifier)); }

    public FqdnConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FqdnConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _fqdnAuthentication =new(() => new FqdnAuthenticationService(client)) ;
    }

    readonly Lazy<IFqdnAuthenticationService> _fqdnAuthentication;
    public IFqdnAuthenticationService FqdnAuthentication {
        get { return _fqdnAuthentication.Value; }
    }

    /// <inheritdoc/>
    public async Task<FqdnConnectionCreateResponse> Create(
        FqdnConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FqdnConnectionRetrieveResponse> Retrieve(
        FqdnConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnConnectionRetrieveResponse> Retrieve(
        string id,
        FqdnConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FqdnConnectionUpdateResponse> Update(
        FqdnConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnConnectionUpdateResponse> Update(
        string id,
        FqdnConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FqdnConnectionListPage> List(
        FqdnConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FqdnConnectionDeleteResponse> Delete(
        FqdnConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnConnectionDeleteResponse> Delete(
        string id,
        FqdnConnectionDeleteParams? parameters = null,
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
public sealed class FqdnConnectionServiceWithRawResponse : IFqdnConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFqdnConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FqdnConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FqdnConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _fqdnAuthentication =new(
            () => new FqdnAuthenticationServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IFqdnAuthenticationServiceWithRawResponse> _fqdnAuthentication;
    public IFqdnAuthenticationServiceWithRawResponse FqdnAuthentication {
        get { return _fqdnAuthentication.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnConnectionCreateResponse>> Create(
        FqdnConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FqdnConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdnConnection = await response.Deserialize<FqdnConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdnConnection.Validate();
            }
            return fqdnConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnConnectionRetrieveResponse>> Retrieve(
        FqdnConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdnConnection = await response.Deserialize<FqdnConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdnConnection.Validate();
            }
            return fqdnConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnConnectionRetrieveResponse>> Retrieve(
        string id,
        FqdnConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnConnectionUpdateResponse>> Update(
        FqdnConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdnConnection = await response.Deserialize<FqdnConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdnConnection.Validate();
            }
            return fqdnConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnConnectionUpdateResponse>> Update(
        string id,
        FqdnConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnConnectionListPage>> List(
        FqdnConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FqdnConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FqdnConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FqdnConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnConnectionDeleteResponse>> Delete(
        FqdnConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdnConnection = await response.Deserialize<FqdnConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdnConnection.Validate();
            }
            return fqdnConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnConnectionDeleteResponse>> Delete(
        string id,
        FqdnConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}