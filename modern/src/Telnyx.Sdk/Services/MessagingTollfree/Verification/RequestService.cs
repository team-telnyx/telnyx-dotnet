using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

namespace Telnyx.Sdk.Services.MessagingTollfree.Verification;

/// <inheritdoc/>
public sealed class RequestService : IRequestService
{
    readonly Lazy<IRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequestServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRequestService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RequestService(this._client.WithOptions(modifier)); }

    public RequestService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RequestServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingTollFreeVerificationVerificationRequestEgress> Create(
        RequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RequestRetrieveResponse> Retrieve(
        RequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequestRetrieveResponse> Retrieve(
        string id,
        RequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingTollFreeVerificationVerificationRequestEgress> Update(
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingTollFreeVerificationVerificationRequestEgress> Update(
        string id,
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RequestListPage> List(
        RequestListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RequestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        RequestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RequestRetrieveStatusHistoryResponse> RetrieveStatusHistory(
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveStatusHistory(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequestRetrieveStatusHistoryResponse> RetrieveStatusHistory(
        string id,
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveStatusHistory(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RequestServiceWithRawResponse : IRequestServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RequestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequestServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Create(
        RequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RequestCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingTollFreeVerificationVerificationRequestEgress = await response.Deserialize<MessagingTollFreeVerificationVerificationRequestEgress>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingTollFreeVerificationVerificationRequestEgress.Validate();
            }
            return messagingTollFreeVerificationVerificationRequestEgress;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequestRetrieveResponse>> Retrieve(
        RequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RequestRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequestRetrieveResponse>> Retrieve(
        string id,
        RequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Update(
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequestUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingTollFreeVerificationVerificationRequestEgress = await response.Deserialize<MessagingTollFreeVerificationVerificationRequestEgress>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingTollFreeVerificationVerificationRequestEgress.Validate();
            }
            return messagingTollFreeVerificationVerificationRequestEgress;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Update(
        string id,
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequestListPage>> List(
        RequestListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RequestListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RequestListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RequestListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RequestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequestDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        RequestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequestRetrieveStatusHistoryResponse>> RetrieveStatusHistory(
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequestRetrieveStatusHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RequestRetrieveStatusHistoryResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequestRetrieveStatusHistoryResponse>> RetrieveStatusHistory(
        string id,
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveStatusHistory(parameters with{
            ID = id
        }, cancellationToken);
    }
}