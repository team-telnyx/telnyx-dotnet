using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.TelephonyCredentials;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TelephonyCredentialService : ITelephonyCredentialService
{
    readonly Lazy<ITelephonyCredentialServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITelephonyCredentialServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITelephonyCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TelephonyCredentialService(this._client.WithOptions(modifier));
    }

    public TelephonyCredentialService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TelephonyCredentialServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TelephonyCredentialCreateResponse> Create(
        TelephonyCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TelephonyCredentialRetrieveResponse> Retrieve(
        TelephonyCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelephonyCredentialRetrieveResponse> Retrieve(
        string id,
        TelephonyCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelephonyCredentialUpdateResponse> Update(
        TelephonyCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelephonyCredentialUpdateResponse> Update(
        string id,
        TelephonyCredentialUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelephonyCredentialListPage> List(
        TelephonyCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TelephonyCredentialDeleteResponse> Delete(
        TelephonyCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelephonyCredentialDeleteResponse> Delete(
        string id,
        TelephonyCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> CreateToken(
        TelephonyCredentialCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateToken(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<string> CreateToken(
        string id,
        TelephonyCredentialCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateToken(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TelephonyCredentialServiceWithRawResponse : ITelephonyCredentialServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITelephonyCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TelephonyCredentialServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TelephonyCredentialServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelephonyCredentialCreateResponse>> Create(
        TelephonyCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TelephonyCredentialCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telephonyCredential = await response.Deserialize<TelephonyCredentialCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telephonyCredential.Validate();
            }
            return telephonyCredential;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelephonyCredentialRetrieveResponse>> Retrieve(
        TelephonyCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TelephonyCredentialRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telephonyCredential = await response.Deserialize<TelephonyCredentialRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telephonyCredential.Validate();
            }
            return telephonyCredential;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelephonyCredentialRetrieveResponse>> Retrieve(
        string id,
        TelephonyCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelephonyCredentialUpdateResponse>> Update(
        TelephonyCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TelephonyCredentialUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telephonyCredential = await response.Deserialize<TelephonyCredentialUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telephonyCredential.Validate();
            }
            return telephonyCredential;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelephonyCredentialUpdateResponse>> Update(
        string id,
        TelephonyCredentialUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelephonyCredentialListPage>> List(
        TelephonyCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TelephonyCredentialListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<TelephonyCredentialListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new TelephonyCredentialListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelephonyCredentialDeleteResponse>> Delete(
        TelephonyCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TelephonyCredentialDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telephonyCredential = await response.Deserialize<TelephonyCredentialDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telephonyCredential.Validate();
            }
            return telephonyCredential;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelephonyCredentialDeleteResponse>> Delete(
        string id,
        TelephonyCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> CreateToken(
        TelephonyCredentialCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TelephonyCredentialCreateTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<string>> CreateToken(
        string id,
        TelephonyCredentialCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateToken(parameters with{
            ID = id
        }, cancellationToken);
    }
}