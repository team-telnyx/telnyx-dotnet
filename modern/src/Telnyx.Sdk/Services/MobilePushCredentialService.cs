using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MobilePushCredentials;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MobilePushCredentialService : IMobilePushCredentialService
{
    readonly Lazy<IMobilePushCredentialServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMobilePushCredentialServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMobilePushCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobilePushCredentialService(this._client.WithOptions(modifier));
    }

    public MobilePushCredentialService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MobilePushCredentialServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PushCredentialResponse> Create(
        MobilePushCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PushCredentialResponse> Retrieve(
        MobilePushCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PushCredentialResponse> Retrieve(
        string pushCredentialID,
        MobilePushCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PushCredentialID = pushCredentialID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MobilePushCredentialListPage> List(
        MobilePushCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        MobilePushCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string pushCredentialID,
        MobilePushCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            PushCredentialID = pushCredentialID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MobilePushCredentialServiceWithRawResponse : IMobilePushCredentialServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMobilePushCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobilePushCredentialServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MobilePushCredentialServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PushCredentialResponse>> Create(
        MobilePushCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MobilePushCredentialCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var pushCredentialResponse = await response.Deserialize<PushCredentialResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                pushCredentialResponse.Validate();
            }
            return pushCredentialResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PushCredentialResponse>> Retrieve(
        MobilePushCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PushCredentialID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PushCredentialID' cannot be null"
            );
        }

        HttpRequest<MobilePushCredentialRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var pushCredentialResponse = await response.Deserialize<PushCredentialResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                pushCredentialResponse.Validate();
            }
            return pushCredentialResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PushCredentialResponse>> Retrieve(
        string pushCredentialID,
        MobilePushCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PushCredentialID = pushCredentialID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobilePushCredentialListPage>> List(
        MobilePushCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MobilePushCredentialListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MobilePushCredentialListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MobilePushCredentialListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        MobilePushCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PushCredentialID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PushCredentialID' cannot be null"
            );
        }

        HttpRequest<MobilePushCredentialDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string pushCredentialID,
        MobilePushCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PushCredentialID = pushCredentialID
        }, cancellationToken);
    }
}