using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MobileVoiceConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MobileVoiceConnectionService : IMobileVoiceConnectionService
{
    readonly Lazy<IMobileVoiceConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMobileVoiceConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMobileVoiceConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobileVoiceConnectionService(this._client.WithOptions(modifier));
    }

    public MobileVoiceConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MobileVoiceConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MobileVoiceConnectionCreateResponse> Create(
        MobileVoiceConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MobileVoiceConnectionRetrieveResponse> Retrieve(
        MobileVoiceConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MobileVoiceConnectionRetrieveResponse> Retrieve(
        string id,
        MobileVoiceConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MobileVoiceConnectionUpdateResponse> Update(
        MobileVoiceConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MobileVoiceConnectionUpdateResponse> Update(
        string id,
        MobileVoiceConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MobileVoiceConnectionListPage> List(
        MobileVoiceConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MobileVoiceConnectionDeleteResponse> Delete(
        MobileVoiceConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MobileVoiceConnectionDeleteResponse> Delete(
        string id,
        MobileVoiceConnectionDeleteParams? parameters = null,
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
public sealed class MobileVoiceConnectionServiceWithRawResponse : IMobileVoiceConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMobileVoiceConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobileVoiceConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MobileVoiceConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileVoiceConnectionCreateResponse>> Create(
        MobileVoiceConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MobileVoiceConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobileVoiceConnection = await response.Deserialize<MobileVoiceConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobileVoiceConnection.Validate();
            }
            return mobileVoiceConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileVoiceConnectionRetrieveResponse>> Retrieve(
        MobileVoiceConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MobileVoiceConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobileVoiceConnection = await response.Deserialize<MobileVoiceConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobileVoiceConnection.Validate();
            }
            return mobileVoiceConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MobileVoiceConnectionRetrieveResponse>> Retrieve(
        string id,
        MobileVoiceConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileVoiceConnectionUpdateResponse>> Update(
        MobileVoiceConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MobileVoiceConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobileVoiceConnection = await response.Deserialize<MobileVoiceConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobileVoiceConnection.Validate();
            }
            return mobileVoiceConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MobileVoiceConnectionUpdateResponse>> Update(
        string id,
        MobileVoiceConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileVoiceConnectionListPage>> List(
        MobileVoiceConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MobileVoiceConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MobileVoiceConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MobileVoiceConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobileVoiceConnectionDeleteResponse>> Delete(
        MobileVoiceConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MobileVoiceConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobileVoiceConnection = await response.Deserialize<MobileVoiceConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobileVoiceConnection.Validate();
            }
            return mobileVoiceConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MobileVoiceConnectionDeleteResponse>> Delete(
        string id,
        MobileVoiceConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}