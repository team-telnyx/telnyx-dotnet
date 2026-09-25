using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VirtualCrossConnects;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VirtualCrossConnectService : IVirtualCrossConnectService
{
    readonly Lazy<IVirtualCrossConnectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVirtualCrossConnectServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVirtualCrossConnectService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VirtualCrossConnectService(this._client.WithOptions(modifier));
    }

    public VirtualCrossConnectService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VirtualCrossConnectServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectCreateResponse> Create(
        VirtualCrossConnectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectRetrieveResponse> Retrieve(
        VirtualCrossConnectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VirtualCrossConnectRetrieveResponse> Retrieve(
        string id,
        VirtualCrossConnectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectUpdateResponse> Update(
        VirtualCrossConnectUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VirtualCrossConnectUpdateResponse> Update(
        string id,
        VirtualCrossConnectUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectListPage> List(
        VirtualCrossConnectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VirtualCrossConnectDeleteResponse> Delete(
        VirtualCrossConnectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VirtualCrossConnectDeleteResponse> Delete(
        string id,
        VirtualCrossConnectDeleteParams? parameters = null,
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
public sealed class VirtualCrossConnectServiceWithRawResponse : IVirtualCrossConnectServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVirtualCrossConnectServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VirtualCrossConnectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VirtualCrossConnectServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectCreateResponse>> Create(
        VirtualCrossConnectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VirtualCrossConnectCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var virtualCrossConnect = await response.Deserialize<VirtualCrossConnectCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                virtualCrossConnect.Validate();
            }
            return virtualCrossConnect;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectRetrieveResponse>> Retrieve(
        VirtualCrossConnectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VirtualCrossConnectRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var virtualCrossConnect = await response.Deserialize<VirtualCrossConnectRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                virtualCrossConnect.Validate();
            }
            return virtualCrossConnect;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VirtualCrossConnectRetrieveResponse>> Retrieve(
        string id,
        VirtualCrossConnectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectUpdateResponse>> Update(
        VirtualCrossConnectUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VirtualCrossConnectUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var virtualCrossConnect = await response.Deserialize<VirtualCrossConnectUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                virtualCrossConnect.Validate();
            }
            return virtualCrossConnect;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VirtualCrossConnectUpdateResponse>> Update(
        string id,
        VirtualCrossConnectUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectListPage>> List(
        VirtualCrossConnectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VirtualCrossConnectListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VirtualCrossConnectListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VirtualCrossConnectListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VirtualCrossConnectDeleteResponse>> Delete(
        VirtualCrossConnectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<VirtualCrossConnectDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var virtualCrossConnect = await response.Deserialize<VirtualCrossConnectDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                virtualCrossConnect.Validate();
            }
            return virtualCrossConnect;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VirtualCrossConnectDeleteResponse>> Delete(
        string id,
        VirtualCrossConnectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}