using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CallControlApplications;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CallControlApplicationService : ICallControlApplicationService
{
    readonly Lazy<ICallControlApplicationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallControlApplicationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICallControlApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallControlApplicationService(this._client.WithOptions(modifier));
    }

    public CallControlApplicationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CallControlApplicationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CallControlApplicationCreateResponse> Create(
        CallControlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallControlApplicationRetrieveResponse> Retrieve(
        CallControlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallControlApplicationRetrieveResponse> Retrieve(
        string id,
        CallControlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallControlApplicationUpdateResponse> Update(
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallControlApplicationUpdateResponse> Update(
        string id,
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallControlApplicationListPage> List(
        CallControlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallControlApplicationDeleteResponse> Delete(
        CallControlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallControlApplicationDeleteResponse> Delete(
        string id,
        CallControlApplicationDeleteParams? parameters = null,
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
public sealed class CallControlApplicationServiceWithRawResponse : ICallControlApplicationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallControlApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallControlApplicationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallControlApplicationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallControlApplicationCreateResponse>> Create(
        CallControlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CallControlApplicationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callControlApplication = await response.Deserialize<CallControlApplicationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callControlApplication.Validate();
            }
            return callControlApplication;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallControlApplicationRetrieveResponse>> Retrieve(
        CallControlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CallControlApplicationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callControlApplication = await response.Deserialize<CallControlApplicationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callControlApplication.Validate();
            }
            return callControlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallControlApplicationRetrieveResponse>> Retrieve(
        string id,
        CallControlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallControlApplicationUpdateResponse>> Update(
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CallControlApplicationUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callControlApplication = await response.Deserialize<CallControlApplicationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callControlApplication.Validate();
            }
            return callControlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallControlApplicationUpdateResponse>> Update(
        string id,
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallControlApplicationListPage>> List(
        CallControlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CallControlApplicationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CallControlApplicationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CallControlApplicationListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallControlApplicationDeleteResponse>> Delete(
        CallControlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CallControlApplicationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callControlApplication = await response.Deserialize<CallControlApplicationDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callControlApplication.Validate();
            }
            return callControlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallControlApplicationDeleteResponse>> Delete(
        string id,
        CallControlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}