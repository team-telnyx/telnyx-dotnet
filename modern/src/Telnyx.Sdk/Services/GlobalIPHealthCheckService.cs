using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.GlobalIPHealthChecks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPHealthCheckService : IGlobalIPHealthCheckService
{
    readonly Lazy<IGlobalIPHealthCheckServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPHealthCheckService(this._client.WithOptions(modifier));
    }

    public GlobalIPHealthCheckService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPHealthCheckServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPHealthCheckCreateResponse> Create(
        GlobalIPHealthCheckCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPHealthCheckRetrieveResponse> Retrieve(
        GlobalIPHealthCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GlobalIPHealthCheckRetrieveResponse> Retrieve(
        string id,
        GlobalIPHealthCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPHealthCheckListPage> List(
        GlobalIPHealthCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPHealthCheckDeleteResponse> Delete(
        GlobalIPHealthCheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GlobalIPHealthCheckDeleteResponse> Delete(
        string id,
        GlobalIPHealthCheckDeleteParams? parameters = null,
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
public sealed class GlobalIPHealthCheckServiceWithRawResponse : IGlobalIPHealthCheckServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPHealthCheckServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPHealthCheckServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPHealthCheckServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPHealthCheckCreateResponse>> Create(
        GlobalIPHealthCheckCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPHealthCheckCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPHealthCheck = await response.Deserialize<GlobalIPHealthCheckCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPHealthCheck.Validate();
            }
            return globalIPHealthCheck;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPHealthCheckRetrieveResponse>> Retrieve(
        GlobalIPHealthCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<GlobalIPHealthCheckRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPHealthCheck = await response.Deserialize<GlobalIPHealthCheckRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPHealthCheck.Validate();
            }
            return globalIPHealthCheck;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GlobalIPHealthCheckRetrieveResponse>> Retrieve(
        string id,
        GlobalIPHealthCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPHealthCheckListPage>> List(
        GlobalIPHealthCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPHealthCheckListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<GlobalIPHealthCheckListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new GlobalIPHealthCheckListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPHealthCheckDeleteResponse>> Delete(
        GlobalIPHealthCheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<GlobalIPHealthCheckDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPHealthCheck = await response.Deserialize<GlobalIPHealthCheckDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPHealthCheck.Validate();
            }
            return globalIPHealthCheck;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GlobalIPHealthCheckDeleteResponse>> Delete(
        string id,
        GlobalIPHealthCheckDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}