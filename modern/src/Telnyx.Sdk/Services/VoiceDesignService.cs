using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VoiceDesigns;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VoiceDesignService : IVoiceDesignService
{
    readonly Lazy<IVoiceDesignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceDesignServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVoiceDesignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VoiceDesignService(this._client.WithOptions(modifier)); }

    public VoiceDesignService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VoiceDesignServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VoiceDesignResponse> Create(
        VoiceDesignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VoiceDesignResponse> Retrieve(
        VoiceDesignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoiceDesignResponse> Retrieve(
        string id,
        VoiceDesignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoiceDesignListPage> List(
        VoiceDesignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        VoiceDesignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        VoiceDesignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteVersion(
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteVersion(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteVersion(
        long version,
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteVersion(parameters with{
            Version = version
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        VoiceDesignDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DownloadSample(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        string id,
        VoiceDesignDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DownloadSample(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoiceDesignRenameResponse> Rename(
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Rename(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoiceDesignRenameResponse> Rename(
        string id,
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VoiceDesignServiceWithRawResponse : IVoiceDesignServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceDesignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoiceDesignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceDesignServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceDesignResponse>> Create(
        VoiceDesignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VoiceDesignCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceDesignResponse = await response.Deserialize<VoiceDesignResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voiceDesignResponse.Validate();
            }
            return voiceDesignResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceDesignResponse>> Retrieve(
        VoiceDesignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceDesignRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceDesignResponse = await response.Deserialize<VoiceDesignResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voiceDesignResponse.Validate();
            }
            return voiceDesignResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoiceDesignResponse>> Retrieve(
        string id,
        VoiceDesignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceDesignListPage>> List(
        VoiceDesignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceDesignListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VoiceDesignListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VoiceDesignListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        VoiceDesignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceDesignDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        VoiceDesignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteVersion(
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Version' cannot be null"
            );
        }

        HttpRequest<VoiceDesignDeleteVersionParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteVersion(
        long version,
        VoiceDesignDeleteVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteVersion(parameters with{
            Version = version
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        VoiceDesignDownloadSampleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceDesignDownloadSampleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DownloadSample(
        string id,
        VoiceDesignDownloadSampleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DownloadSample(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceDesignRenameResponse>> Rename(
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VoiceDesignRenameParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<VoiceDesignRenameResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoiceDesignRenameResponse>> Rename(
        string id,
        VoiceDesignRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with{
            ID = id
        }, cancellationToken);
    }
}