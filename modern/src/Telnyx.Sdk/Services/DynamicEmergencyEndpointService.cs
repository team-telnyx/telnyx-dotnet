using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class DynamicEmergencyEndpointService : IDynamicEmergencyEndpointService
{
    readonly Lazy<IDynamicEmergencyEndpointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDynamicEmergencyEndpointServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDynamicEmergencyEndpointService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DynamicEmergencyEndpointService(this._client.WithOptions(modifier));
    }

    public DynamicEmergencyEndpointService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DynamicEmergencyEndpointServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyEndpointCreateResponse> Create(
        DynamicEmergencyEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyEndpointRetrieveResponse> Retrieve(
        DynamicEmergencyEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DynamicEmergencyEndpointRetrieveResponse> Retrieve(
        string id,
        DynamicEmergencyEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyEndpointListPage> List(
        DynamicEmergencyEndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DynamicEmergencyEndpointDeleteResponse> Delete(
        DynamicEmergencyEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DynamicEmergencyEndpointDeleteResponse> Delete(
        string id,
        DynamicEmergencyEndpointDeleteParams? parameters = null,
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
public sealed class DynamicEmergencyEndpointServiceWithRawResponse : IDynamicEmergencyEndpointServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDynamicEmergencyEndpointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DynamicEmergencyEndpointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DynamicEmergencyEndpointServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyEndpointCreateResponse>> Create(
        DynamicEmergencyEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DynamicEmergencyEndpointCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyEndpoint = await response.Deserialize<DynamicEmergencyEndpointCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyEndpoint.Validate();
            }
            return dynamicEmergencyEndpoint;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyEndpointRetrieveResponse>> Retrieve(
        DynamicEmergencyEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DynamicEmergencyEndpointRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyEndpoint = await response.Deserialize<DynamicEmergencyEndpointRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyEndpoint.Validate();
            }
            return dynamicEmergencyEndpoint;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DynamicEmergencyEndpointRetrieveResponse>> Retrieve(
        string id,
        DynamicEmergencyEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyEndpointListPage>> List(
        DynamicEmergencyEndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DynamicEmergencyEndpointListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DynamicEmergencyEndpointListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DynamicEmergencyEndpointListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DynamicEmergencyEndpointDeleteResponse>> Delete(
        DynamicEmergencyEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DynamicEmergencyEndpointDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dynamicEmergencyEndpoint = await response.Deserialize<DynamicEmergencyEndpointDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dynamicEmergencyEndpoint.Validate();
            }
            return dynamicEmergencyEndpoint;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DynamicEmergencyEndpointDeleteResponse>> Delete(
        string id,
        DynamicEmergencyEndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}