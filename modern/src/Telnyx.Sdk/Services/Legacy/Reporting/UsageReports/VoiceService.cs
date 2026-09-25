using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Voice;

namespace Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

/// <inheritdoc/>
public sealed class VoiceService : IVoiceService
{
    readonly Lazy<IVoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVoiceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VoiceService(this._client.WithOptions(modifier)); }

    public VoiceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VoiceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VoiceCreateResponse> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VoiceRetrieveResponse> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoiceRetrieveResponse> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoiceListPage> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VoiceDeleteResponse> Delete(
        VoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoiceDeleteResponse> Delete(
        string id,
        VoiceDeleteParams? parameters = null,
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
public sealed class VoiceServiceWithRawResponse : IVoiceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceCreateResponse>> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voice = await response.Deserialize<VoiceCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voice.Validate();
            }
            return voice;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voice = await response.Deserialize<VoiceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voice.Validate();
            }
            return voice;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceListPage>> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VoiceListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VoiceListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceDeleteResponse>> Delete(
        VoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voice = await response.Deserialize<VoiceDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voice.Validate();
            }
            return voice;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoiceDeleteResponse>> Delete(
        string id,
        VoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}