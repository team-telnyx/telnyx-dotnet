using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Collections;
using Telnyx.Sdk.Services.AI.Collections;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class CollectionService : ICollectionService
{
    readonly Lazy<ICollectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICollectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CollectionService(this._client.WithOptions(modifier)); }

    public CollectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CollectionServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _settings =new(() => new SettingService(client)) ;
        _sources =new(() => new SourceService(client)) ;
    }

    readonly Lazy<ISettingService> _settings;
    public ISettingService Settings { get { return _settings.Value; } }

    readonly Lazy<ISourceService> _sources;
    public ISourceService Sources { get { return _sources.Value; } }

    /// <inheritdoc/>
    public async Task<CollectionEnvelope> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CollectionEnvelope> Retrieve(
        CollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CollectionEnvelope> Retrieve(
        string slug,
        CollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            Slug = slug
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CollectionEnvelope> Update(
        CollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CollectionEnvelope> Update(
        string uuid,
        CollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CollectionListPage> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string uuid,
        CollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            Uuid = uuid
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CollectionEnvelope> RetrieveByID(
        CollectionRetrieveByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveByID(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CollectionEnvelope> RetrieveByID(
        string uuid,
        CollectionRetrieveByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByID(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CollectionServiceWithRawResponse : ICollectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CollectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CollectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _settings =new(() => new SettingServiceWithRawResponse(client)) ;
        _sources =new(() => new SourceServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ISettingServiceWithRawResponse> _settings;
    public ISettingServiceWithRawResponse Settings {
        get { return _settings.Value; }
    }

    readonly Lazy<ISourceServiceWithRawResponse> _sources;
    public ISourceServiceWithRawResponse Sources {
        get { return _sources.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionEnvelope>> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CollectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var collectionEnvelope = await response.Deserialize<CollectionEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                collectionEnvelope.Validate();
            }
            return collectionEnvelope;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionEnvelope>> Retrieve(
        CollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Slug == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Slug' cannot be null"
            );
        }

        HttpRequest<CollectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var collectionEnvelope = await response.Deserialize<CollectionEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                collectionEnvelope.Validate();
            }
            return collectionEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CollectionEnvelope>> Retrieve(
        string slug,
        CollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            Slug = slug
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionEnvelope>> Update(
        CollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<CollectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var collectionEnvelope = await response.Deserialize<CollectionEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                collectionEnvelope.Validate();
            }
            return collectionEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CollectionEnvelope>> Update(
        string uuid,
        CollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionListPage>> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CollectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CollectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CollectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<CollectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string uuid,
        CollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionEnvelope>> RetrieveByID(
        CollectionRetrieveByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<CollectionRetrieveByIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var collectionEnvelope = await response.Deserialize<CollectionEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                collectionEnvelope.Validate();
            }
            return collectionEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CollectionEnvelope>> RetrieveByID(
        string uuid,
        CollectionRetrieveByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByID(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }
}