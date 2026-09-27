using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.OAuthGrants;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OAuthGrantService : IOAuthGrantService
{
    readonly Lazy<IOAuthGrantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthGrantServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOAuthGrantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OAuthGrantService(this._client.WithOptions(modifier)); }

    public OAuthGrantService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OAuthGrantServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<OAuthGrantRetrieveResponse> Retrieve(
        OAuthGrantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OAuthGrantRetrieveResponse> Retrieve(
        string id,
        OAuthGrantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OAuthGrantListPage> List(
        OAuthGrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthGrantDeleteResponse> Delete(
        OAuthGrantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OAuthGrantDeleteResponse> Delete(
        string id,
        OAuthGrantDeleteParams? parameters = null,
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
public sealed class OAuthGrantServiceWithRawResponse : IOAuthGrantServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthGrantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthGrantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthGrantServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthGrantRetrieveResponse>> Retrieve(
        OAuthGrantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OAuthGrantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauthGrant = await response.Deserialize<OAuthGrantRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauthGrant.Validate();
            }
            return oauthGrant;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OAuthGrantRetrieveResponse>> Retrieve(
        string id,
        OAuthGrantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthGrantListPage>> List(
        OAuthGrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthGrantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<OAuthGrantListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new OAuthGrantListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthGrantDeleteResponse>> Delete(
        OAuthGrantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OAuthGrantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauthGrant = await response.Deserialize<OAuthGrantDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauthGrant.Validate();
            }
            return oauthGrant;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OAuthGrantDeleteResponse>> Delete(
        string id,
        OAuthGrantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}