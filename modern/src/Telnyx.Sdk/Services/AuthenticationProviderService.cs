using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AuthenticationProviderService : IAuthenticationProviderService
{
    readonly Lazy<IAuthenticationProviderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuthenticationProviderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAuthenticationProviderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuthenticationProviderService(this._client.WithOptions(modifier));
    }

    public AuthenticationProviderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AuthenticationProviderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AuthenticationProviderCreateResponse> Create(
        AuthenticationProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AuthenticationProviderRetrieveResponse> Retrieve(
        AuthenticationProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AuthenticationProviderRetrieveResponse> Retrieve(
        string id,
        AuthenticationProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AuthenticationProviderUpdateResponse> Update(
        AuthenticationProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AuthenticationProviderUpdateResponse> Update(
        string id,
        AuthenticationProviderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AuthenticationProviderListPage> List(
        AuthenticationProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AuthenticationProviderDeleteResponse> Delete(
        AuthenticationProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AuthenticationProviderDeleteResponse> Delete(
        string id,
        AuthenticationProviderDeleteParams? parameters = null,
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
public sealed class AuthenticationProviderServiceWithRawResponse : IAuthenticationProviderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuthenticationProviderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuthenticationProviderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuthenticationProviderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthenticationProviderCreateResponse>> Create(
        AuthenticationProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AuthenticationProviderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var authenticationProvider = await response.Deserialize<AuthenticationProviderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                authenticationProvider.Validate();
            }
            return authenticationProvider;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthenticationProviderRetrieveResponse>> Retrieve(
        AuthenticationProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AuthenticationProviderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var authenticationProvider = await response.Deserialize<AuthenticationProviderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                authenticationProvider.Validate();
            }
            return authenticationProvider;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AuthenticationProviderRetrieveResponse>> Retrieve(
        string id,
        AuthenticationProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthenticationProviderUpdateResponse>> Update(
        AuthenticationProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AuthenticationProviderUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var authenticationProvider = await response.Deserialize<AuthenticationProviderUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                authenticationProvider.Validate();
            }
            return authenticationProvider;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AuthenticationProviderUpdateResponse>> Update(
        string id,
        AuthenticationProviderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthenticationProviderListPage>> List(
        AuthenticationProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AuthenticationProviderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AuthenticationProviderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AuthenticationProviderListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthenticationProviderDeleteResponse>> Delete(
        AuthenticationProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AuthenticationProviderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var authenticationProvider = await response.Deserialize<AuthenticationProviderDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                authenticationProvider.Validate();
            }
            return authenticationProvider;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AuthenticationProviderDeleteResponse>> Delete(
        string id,
        AuthenticationProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}