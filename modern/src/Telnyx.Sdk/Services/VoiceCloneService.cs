using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VoiceClones;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VoiceCloneService : IVoiceCloneService
{
    readonly Lazy<IVoiceCloneServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceCloneServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVoiceCloneService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VoiceCloneService(this._client.WithOptions(modifier)); }

    public VoiceCloneService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VoiceCloneServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VoiceCloneResponse> Create(
        VoiceCloneCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VoiceCloneResponse> Update(
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoiceCloneResponse> Update(
        string id,
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoiceCloneListPage> List(
        VoiceCloneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        VoiceCloneDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        VoiceCloneDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VoiceCloneResponse> CreateFromUpload(
        VoiceCloneCreateFromUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateFromUpload(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        VoiceCloneDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DownloadSample(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        string id,
        VoiceCloneDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DownloadSample(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VoiceCloneServiceWithRawResponse : IVoiceCloneServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceCloneServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoiceCloneServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceCloneServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceCloneResponse>> Create(
        VoiceCloneCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VoiceCloneCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceCloneResponse = await response.Deserialize<VoiceCloneResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voiceCloneResponse.Validate();
            }
            return voiceCloneResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceCloneResponse>> Update(
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceCloneUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceCloneResponse = await response.Deserialize<VoiceCloneResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voiceCloneResponse.Validate();
            }
            return voiceCloneResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoiceCloneResponse>> Update(
        string id,
        VoiceCloneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceCloneListPage>> List(
        VoiceCloneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceCloneListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VoiceCloneListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VoiceCloneListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        VoiceCloneDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceCloneDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        VoiceCloneDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceCloneResponse>> CreateFromUpload(
        VoiceCloneCreateFromUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VoiceCloneCreateFromUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceCloneResponse = await response.Deserialize<VoiceCloneResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voiceCloneResponse.Validate();
            }
            return voiceCloneResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        VoiceCloneDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceCloneDownloadSampleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        string id,
        VoiceCloneDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DownloadSample(parameters with{
            ID = id
        }, cancellationToken);
    }
}