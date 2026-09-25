using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Fqdns;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class FqdnService : IFqdnService
{
    readonly Lazy<IFqdnServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFqdnServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFqdnService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new FqdnService(this._client.WithOptions(modifier)); }

    public FqdnService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FqdnServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FqdnCreateResponse> Create(
        FqdnCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FqdnRetrieveResponse> Retrieve(
        FqdnRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnRetrieveResponse> Retrieve(
        string id,
        FqdnRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FqdnUpdateResponse> Update(
        FqdnUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnUpdateResponse> Update(
        string id,
        FqdnUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FqdnListPage> List(
        FqdnListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FqdnDeleteResponse> Delete(
        FqdnDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnDeleteResponse> Delete(
        string id,
        FqdnDeleteParams? parameters = null,
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
public sealed class FqdnServiceWithRawResponse : IFqdnServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFqdnServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FqdnServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FqdnServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnCreateResponse>> Create(
        FqdnCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FqdnCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdn = await response.Deserialize<FqdnCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdn.Validate();
            }
            return fqdn;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnRetrieveResponse>> Retrieve(
        FqdnRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdn = await response.Deserialize<FqdnRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdn.Validate();
            }
            return fqdn;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnRetrieveResponse>> Retrieve(
        string id,
        FqdnRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnUpdateResponse>> Update(
        FqdnUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdn = await response.Deserialize<FqdnUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdn.Validate();
            }
            return fqdn;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnUpdateResponse>> Update(
        string id,
        FqdnUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnListPage>> List(
        FqdnListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FqdnListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FqdnListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FqdnListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnDeleteResponse>> Delete(
        FqdnDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FqdnDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdn = await response.Deserialize<FqdnDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdn.Validate();
            }
            return fqdn;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnDeleteResponse>> Delete(
        string id,
        FqdnDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}