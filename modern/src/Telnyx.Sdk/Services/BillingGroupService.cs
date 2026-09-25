using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.BillingGroups;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BillingGroupService : IBillingGroupService
{
    readonly Lazy<IBillingGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBillingGroupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBillingGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BillingGroupService(this._client.WithOptions(modifier)); }

    public BillingGroupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BillingGroupServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BillingGroupCreateResponse> Create(
        BillingGroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillingGroupRetrieveResponse> Retrieve(
        BillingGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BillingGroupRetrieveResponse> Retrieve(
        string id,
        BillingGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillingGroupUpdateResponse> Update(
        BillingGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BillingGroupUpdateResponse> Update(
        string id,
        BillingGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillingGroupListPage> List(
        BillingGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillingGroupDeleteResponse> Delete(
        BillingGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BillingGroupDeleteResponse> Delete(
        string id,
        BillingGroupDeleteParams? parameters = null,
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
public sealed class BillingGroupServiceWithRawResponse : IBillingGroupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBillingGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BillingGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BillingGroupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingGroupCreateResponse>> Create(
        BillingGroupCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BillingGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var billingGroup = await response.Deserialize<BillingGroupCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                billingGroup.Validate();
            }
            return billingGroup;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingGroupRetrieveResponse>> Retrieve(
        BillingGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BillingGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var billingGroup = await response.Deserialize<BillingGroupRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                billingGroup.Validate();
            }
            return billingGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BillingGroupRetrieveResponse>> Retrieve(
        string id,
        BillingGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingGroupUpdateResponse>> Update(
        BillingGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BillingGroupUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var billingGroup = await response.Deserialize<BillingGroupUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                billingGroup.Validate();
            }
            return billingGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BillingGroupUpdateResponse>> Update(
        string id,
        BillingGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingGroupListPage>> List(
        BillingGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BillingGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<BillingGroupListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new BillingGroupListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingGroupDeleteResponse>> Delete(
        BillingGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BillingGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var billingGroup = await response.Deserialize<BillingGroupDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                billingGroup.Validate();
            }
            return billingGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BillingGroupDeleteResponse>> Delete(
        string id,
        BillingGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}