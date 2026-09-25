using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.OAuthClients;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OAuthClientService : IOAuthClientService
{
    readonly Lazy<IOAuthClientServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthClientServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOAuthClientService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OAuthClientService(this._client.WithOptions(modifier)); }

    public OAuthClientService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OAuthClientServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<OAuthClientCreateResponse> Create(
        OAuthClientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthClientRetrieveResponse> Retrieve(
        OAuthClientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OAuthClientRetrieveResponse> Retrieve(
        string id,
        OAuthClientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OAuthClientUpdateResponse> Update(
        OAuthClientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OAuthClientUpdateResponse> Update(
        string id,
        OAuthClientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OAuthClientListPage> List(
        OAuthClientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        OAuthClientDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        OAuthClientDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OAuthClientServiceWithRawResponse : IOAuthClientServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthClientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthClientServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthClientServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthClientCreateResponse>> Create(
        OAuthClientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthClientCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauthClient = await response.Deserialize<OAuthClientCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauthClient.Validate();
            }
            return oauthClient;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthClientRetrieveResponse>> Retrieve(
        OAuthClientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OAuthClientRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauthClient = await response.Deserialize<OAuthClientRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauthClient.Validate();
            }
            return oauthClient;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OAuthClientRetrieveResponse>> Retrieve(
        string id,
        OAuthClientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthClientUpdateResponse>> Update(
        OAuthClientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OAuthClientUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauthClient = await response.Deserialize<OAuthClientUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauthClient.Validate();
            }
            return oauthClient;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OAuthClientUpdateResponse>> Update(
        string id,
        OAuthClientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthClientListPage>> List(
        OAuthClientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthClientListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<OAuthClientListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new OAuthClientListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        OAuthClientDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OAuthClientDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        OAuthClientDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}