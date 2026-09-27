using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Enterprises;
using Enterprises = Telnyx.Sdk.Services.Enterprises;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EnterpriseService : IEnterpriseService
{
    readonly Lazy<IEnterpriseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEnterpriseServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEnterpriseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EnterpriseService(this._client.WithOptions(modifier)); }

    public EnterpriseService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EnterpriseServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _reputation =new(() => new Enterprises::ReputationService(client)) ;
        _dir =new(() => new Enterprises::DirService(client)) ;
    }

    readonly Lazy<Enterprises::IReputationService> _reputation;
    public Enterprises::IReputationService Reputation {
        get { return _reputation.Value; }
    }

    readonly Lazy<Enterprises::IDirService> _dir;
    public Enterprises::IDirService Dir { get { return _dir.Value; } }

    /// <inheritdoc/>
    public async Task<EnterprisePublicWrapped> Create(
        EnterpriseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnterprisePublicWrapped> Retrieve(
        EnterpriseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterprisePublicWrapped> Retrieve(
        string enterpriseID,
        EnterpriseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnterprisePublicWrapped> Update(
        EnterpriseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterprisePublicWrapped> Update(
        string enterpriseID,
        EnterpriseUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnterpriseListPage> List(
        EnterpriseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EnterpriseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string enterpriseID,
        EnterpriseDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnterprisePublicWrapped> BrandedCalling(
        EnterpriseBrandedCallingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.BrandedCalling(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterprisePublicWrapped> BrandedCalling(
        string enterpriseID,
        EnterpriseBrandedCallingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.BrandedCalling(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EnterpriseServiceWithRawResponse : IEnterpriseServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEnterpriseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EnterpriseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EnterpriseServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _reputation =new(
            () => new Enterprises::ReputationServiceWithRawResponse(client)
        ) ;
        _dir =new(() => new Enterprises::DirServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Enterprises::IReputationServiceWithRawResponse> _reputation;
    public Enterprises::IReputationServiceWithRawResponse Reputation {
        get { return _reputation.Value; }
    }

    readonly Lazy<Enterprises::IDirServiceWithRawResponse> _dir;
    public Enterprises::IDirServiceWithRawResponse Dir {
        get { return _dir.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterprisePublicWrapped>> Create(
        EnterpriseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EnterpriseCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterprisePublicWrapped = await response.Deserialize<EnterprisePublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterprisePublicWrapped.Validate();
            }
            return enterprisePublicWrapped;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterprisePublicWrapped>> Retrieve(
        EnterpriseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<EnterpriseRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterprisePublicWrapped = await response.Deserialize<EnterprisePublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterprisePublicWrapped.Validate();
            }
            return enterprisePublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterprisePublicWrapped>> Retrieve(
        string enterpriseID,
        EnterpriseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterprisePublicWrapped>> Update(
        EnterpriseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<EnterpriseUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterprisePublicWrapped = await response.Deserialize<EnterprisePublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterprisePublicWrapped.Validate();
            }
            return enterprisePublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterprisePublicWrapped>> Update(
        string enterpriseID,
        EnterpriseUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterpriseListPage>> List(
        EnterpriseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EnterpriseListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EnterpriseListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EnterpriseListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EnterpriseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<EnterpriseDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string enterpriseID,
        EnterpriseDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterprisePublicWrapped>> BrandedCalling(
        EnterpriseBrandedCallingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<EnterpriseBrandedCallingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterprisePublicWrapped = await response.Deserialize<EnterprisePublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterprisePublicWrapped.Validate();
            }
            return enterprisePublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterprisePublicWrapped>> BrandedCalling(
        string enterpriseID,
        EnterpriseBrandedCallingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.BrandedCalling(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}