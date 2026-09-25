using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.FaxApplications;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class FaxApplicationService : IFaxApplicationService
{
    readonly Lazy<IFaxApplicationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFaxApplicationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFaxApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new FaxApplicationService(this._client.WithOptions(modifier)); }

    public FaxApplicationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FaxApplicationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FaxApplicationCreateResponse> Create(
        FaxApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FaxApplicationRetrieveResponse> Retrieve(
        FaxApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FaxApplicationRetrieveResponse> Retrieve(
        string id,
        FaxApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FaxApplicationUpdateResponse> Update(
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FaxApplicationUpdateResponse> Update(
        string id,
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FaxApplicationListPage> List(
        FaxApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FaxApplicationDeleteResponse> Delete(
        FaxApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FaxApplicationDeleteResponse> Delete(
        string id,
        FaxApplicationDeleteParams? parameters = null,
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
public sealed class FaxApplicationServiceWithRawResponse : IFaxApplicationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFaxApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FaxApplicationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FaxApplicationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxApplicationCreateResponse>> Create(
        FaxApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FaxApplicationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var faxApplication = await response.Deserialize<FaxApplicationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                faxApplication.Validate();
            }
            return faxApplication;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxApplicationRetrieveResponse>> Retrieve(
        FaxApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FaxApplicationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var faxApplication = await response.Deserialize<FaxApplicationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                faxApplication.Validate();
            }
            return faxApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FaxApplicationRetrieveResponse>> Retrieve(
        string id,
        FaxApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxApplicationUpdateResponse>> Update(
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FaxApplicationUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var faxApplication = await response.Deserialize<FaxApplicationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                faxApplication.Validate();
            }
            return faxApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FaxApplicationUpdateResponse>> Update(
        string id,
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxApplicationListPage>> List(
        FaxApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FaxApplicationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FaxApplicationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FaxApplicationListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxApplicationDeleteResponse>> Delete(
        FaxApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FaxApplicationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var faxApplication = await response.Deserialize<FaxApplicationDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                faxApplication.Validate();
            }
            return faxApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FaxApplicationDeleteResponse>> Delete(
        string id,
        FaxApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}