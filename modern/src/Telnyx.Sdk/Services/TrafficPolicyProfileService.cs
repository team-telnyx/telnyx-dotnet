using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.TrafficPolicyProfiles;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TrafficPolicyProfileService : ITrafficPolicyProfileService
{
    readonly Lazy<ITrafficPolicyProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITrafficPolicyProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITrafficPolicyProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TrafficPolicyProfileService(this._client.WithOptions(modifier));
    }

    public TrafficPolicyProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TrafficPolicyProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileCreateResponse> Create(
        TrafficPolicyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileRetrieveResponse> Retrieve(
        TrafficPolicyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TrafficPolicyProfileRetrieveResponse> Retrieve(
        string id,
        TrafficPolicyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileUpdateResponse> Update(
        TrafficPolicyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TrafficPolicyProfileUpdateResponse> Update(
        string id,
        TrafficPolicyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileListPage> List(
        TrafficPolicyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileDeleteResponse> Delete(
        TrafficPolicyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TrafficPolicyProfileDeleteResponse> Delete(
        string id,
        TrafficPolicyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrafficPolicyProfileListServicesPage> ListServices(
        TrafficPolicyProfileListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListServices(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TrafficPolicyProfileServiceWithRawResponse : ITrafficPolicyProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITrafficPolicyProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TrafficPolicyProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TrafficPolicyProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileCreateResponse>> Create(
        TrafficPolicyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrafficPolicyProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var trafficPolicyProfile = await response.Deserialize<TrafficPolicyProfileCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                trafficPolicyProfile.Validate();
            }
            return trafficPolicyProfile;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileRetrieveResponse>> Retrieve(
        TrafficPolicyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TrafficPolicyProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var trafficPolicyProfile = await response.Deserialize<TrafficPolicyProfileRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                trafficPolicyProfile.Validate();
            }
            return trafficPolicyProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TrafficPolicyProfileRetrieveResponse>> Retrieve(
        string id,
        TrafficPolicyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileUpdateResponse>> Update(
        TrafficPolicyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TrafficPolicyProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var trafficPolicyProfile = await response.Deserialize<TrafficPolicyProfileUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                trafficPolicyProfile.Validate();
            }
            return trafficPolicyProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TrafficPolicyProfileUpdateResponse>> Update(
        string id,
        TrafficPolicyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileListPage>> List(
        TrafficPolicyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TrafficPolicyProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<TrafficPolicyProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new TrafficPolicyProfileListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileDeleteResponse>> Delete(
        TrafficPolicyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TrafficPolicyProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var trafficPolicyProfile = await response.Deserialize<TrafficPolicyProfileDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                trafficPolicyProfile.Validate();
            }
            return trafficPolicyProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TrafficPolicyProfileDeleteResponse>> Delete(
        string id,
        TrafficPolicyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrafficPolicyProfileListServicesPage>> ListServices(
        TrafficPolicyProfileListServicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TrafficPolicyProfileListServicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<TrafficPolicyProfileListServicesPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new TrafficPolicyProfileListServicesPage(this,
            parameters,
            page);
        });
    }
}