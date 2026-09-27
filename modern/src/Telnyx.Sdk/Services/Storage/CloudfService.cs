using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Cloudfs;
using Cloudfs = Telnyx.Sdk.Services.Storage.Cloudfs;

namespace Telnyx.Sdk.Services.Storage;

/// <inheritdoc/>
public sealed class CloudfService : ICloudfService
{
    readonly Lazy<ICloudfServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICloudfServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICloudfService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CloudfService(this._client.WithOptions(modifier)); }

    public CloudfService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CloudfServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Cloudfs::ActionService(client)) ;
    }

    readonly Lazy<Cloudfs::IActionService> _actions;
    public Cloudfs::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<CloudfsFilesystemResponseWrapper> Create(
        CloudfCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CloudfsFilesystemDetailResponseWrapper> Retrieve(
        CloudfRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CloudfsFilesystemDetailResponseWrapper> Retrieve(
        string id,
        CloudfRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CloudfsFilesystemDetailResponseWrapper> Update(
        CloudfUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CloudfsFilesystemDetailResponseWrapper> Update(
        string id,
        CloudfUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CloudfListPage> List(
        CloudfListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CloudfsFilesystemDetailResponseWrapper> Delete(
        CloudfDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CloudfsFilesystemDetailResponseWrapper> Delete(
        string id,
        CloudfDeleteParams? parameters = null,
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
public sealed class CloudfServiceWithRawResponse : ICloudfServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICloudfServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CloudfServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CloudfServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(() => new Cloudfs::ActionServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Cloudfs::IActionServiceWithRawResponse> _actions;
    public Cloudfs::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CloudfsFilesystemResponseWrapper>> Create(
        CloudfCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CloudfCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var cloudfsFilesystemResponseWrapper = await response.Deserialize<CloudfsFilesystemResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                cloudfsFilesystemResponseWrapper.Validate();
            }
            return cloudfsFilesystemResponseWrapper;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Retrieve(
        CloudfRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CloudfRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var cloudfsFilesystemDetailResponseWrapper = await response.Deserialize<CloudfsFilesystemDetailResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                cloudfsFilesystemDetailResponseWrapper.Validate();
            }
            return cloudfsFilesystemDetailResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Retrieve(
        string id,
        CloudfRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Update(
        CloudfUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CloudfUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var cloudfsFilesystemDetailResponseWrapper = await response.Deserialize<CloudfsFilesystemDetailResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                cloudfsFilesystemDetailResponseWrapper.Validate();
            }
            return cloudfsFilesystemDetailResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Update(
        string id,
        CloudfUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CloudfListPage>> List(
        CloudfListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CloudfListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CloudfListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CloudfListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Delete(
        CloudfDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CloudfDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var cloudfsFilesystemDetailResponseWrapper = await response.Deserialize<CloudfsFilesystemDetailResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                cloudfsFilesystemDetailResponseWrapper.Validate();
            }
            return cloudfsFilesystemDetailResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Delete(
        string id,
        CloudfDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}