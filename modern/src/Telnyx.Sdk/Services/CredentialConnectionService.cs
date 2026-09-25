using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;
using CredentialConnections = Telnyx.Sdk.Services.CredentialConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CredentialConnectionService : ICredentialConnectionService
{
    readonly Lazy<ICredentialConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICredentialConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICredentialConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CredentialConnectionService(this._client.WithOptions(modifier));
    }

    public CredentialConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CredentialConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new CredentialConnections::ActionService(client)) ;
    }

    readonly Lazy<CredentialConnections::IActionService> _actions;
    public CredentialConnections::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<CredentialConnectionCreateResponse> Create(
        CredentialConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CredentialConnectionRetrieveResponse> Retrieve(
        CredentialConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialConnectionRetrieveResponse> Retrieve(
        string id,
        CredentialConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CredentialConnectionUpdateResponse> Update(
        CredentialConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialConnectionUpdateResponse> Update(
        string id,
        CredentialConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CredentialConnectionListPage> List(
        CredentialConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CredentialConnectionDeleteResponse> Delete(
        CredentialConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialConnectionDeleteResponse> Delete(
        string id,
        CredentialConnectionDeleteParams? parameters = null,
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
public sealed class CredentialConnectionServiceWithRawResponse : ICredentialConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICredentialConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CredentialConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CredentialConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new CredentialConnections::ActionServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<CredentialConnections::IActionServiceWithRawResponse> _actions;
    public CredentialConnections::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialConnectionCreateResponse>> Create(
        CredentialConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CredentialConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialConnection = await response.Deserialize<CredentialConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialConnection.Validate();
            }
            return credentialConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialConnectionRetrieveResponse>> Retrieve(
        CredentialConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CredentialConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialConnection = await response.Deserialize<CredentialConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialConnection.Validate();
            }
            return credentialConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialConnectionRetrieveResponse>> Retrieve(
        string id,
        CredentialConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialConnectionUpdateResponse>> Update(
        CredentialConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CredentialConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialConnection = await response.Deserialize<CredentialConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialConnection.Validate();
            }
            return credentialConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialConnectionUpdateResponse>> Update(
        string id,
        CredentialConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialConnectionListPage>> List(
        CredentialConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CredentialConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CredentialConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CredentialConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialConnectionDeleteResponse>> Delete(
        CredentialConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CredentialConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialConnection = await response.Deserialize<CredentialConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialConnection.Validate();
            }
            return credentialConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialConnectionDeleteResponse>> Delete(
        string id,
        CredentialConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}