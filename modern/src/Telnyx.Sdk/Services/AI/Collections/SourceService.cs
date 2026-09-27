using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Collections.Sources;

namespace Telnyx.Sdk.Services.AI.Collections;

/// <inheritdoc/>
public sealed class SourceService : ISourceService
{
    readonly Lazy<ISourceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISourceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISourceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SourceService(this._client.WithOptions(modifier)); }

    public SourceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SourceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SourceCreateResponse> Create(
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceCreateResponse> Create(
        string uuid,
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SourceListResponse> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceListResponse> List(
        string uuid,
        SourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            SourceID = sourceID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SourceReplaceResponse> Replace(
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Replace(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceReplaceResponse> Replace(
        string uuid,
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SourceServiceWithRawResponse : ISourceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SourceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SourceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceCreateResponse>> Create(
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SourceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var source = await response.Deserialize<SourceCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                source.Validate();
            }
            return source;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceCreateResponse>> Create(
        string uuid,
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceListResponse>> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SourceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sources = await response.Deserialize<SourceListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sources.Validate();
            }
            return sources;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceListResponse>> List(
        string uuid,
        SourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SourceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SourceID' cannot be null"
            );
        }

        HttpRequest<SourceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            SourceID = sourceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceReplaceResponse>> Replace(
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SourceReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SourceReplaceResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceReplaceResponse>> Replace(
        string uuid,
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }
}