using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.OAuth;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OAuthService : IOAuthService
{
    readonly Lazy<IOAuthServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOAuthService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OAuthService(this._client.WithOptions(modifier)); }

    public OAuthService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OAuthServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<OAuthRetrieveResponse> Retrieve(
        OAuthRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OAuthRetrieveResponse> Retrieve(
        string consentToken,
        OAuthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConsentToken = consentToken
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OAuthGrantsResponse> Grants(
        OAuthGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Grants(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthIntrospectResponse> Introspect(
        OAuthIntrospectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Introspect(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthRegisterResponse> Register(
        OAuthRegisterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Register(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<string> RetrieveAuthorize(
        OAuthRetrieveAuthorizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveAuthorize(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthRetrieveJwksResponse> RetrieveJwks(
        OAuthRetrieveJwksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveJwks(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OAuthTokenResponse> Token(
        OAuthTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Token(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OAuthServiceWithRawResponse : IOAuthServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthRetrieveResponse>> Retrieve(
        OAuthRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConsentToken == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConsentToken' cannot be null"
            );
        }

        HttpRequest<OAuthRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var oauth = await response.Deserialize<OAuthRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                oauth.Validate();
            }
            return oauth;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OAuthRetrieveResponse>> Retrieve(
        string consentToken,
        OAuthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConsentToken = consentToken
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthGrantsResponse>> Grants(
        OAuthGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthGrantsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<OAuthGrantsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthIntrospectResponse>> Introspect(
        OAuthIntrospectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthIntrospectParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<OAuthIntrospectResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthRegisterResponse>> Register(
        OAuthRegisterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthRegisterParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<OAuthRegisterResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> RetrieveAuthorize(
        OAuthRetrieveAuthorizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthRetrieveAuthorizeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthRetrieveJwksResponse>> RetrieveJwks(
        OAuthRetrieveJwksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthRetrieveJwksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<OAuthRetrieveJwksResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthTokenResponse>> Token(
        OAuthTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<OAuthTokenResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}