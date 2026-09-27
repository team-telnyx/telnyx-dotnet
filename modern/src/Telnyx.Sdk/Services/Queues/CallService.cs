using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Queues.Calls;

namespace Telnyx.Sdk.Services.Queues;

/// <inheritdoc/>
public sealed class CallService : ICallService
{
    readonly Lazy<ICallServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new CallService(this._client.WithOptions(modifier)); }

    public CallService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CallServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CallRetrieveResponse> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallRetrieveResponse> Retrieve(
        string callControlID,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Update(
        string callControlID,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with{
            CallControlID = callControlID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallListPage> List(
        CallListParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallListPage> List(
        string queueName,
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Remove(
        string callControlID,
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with{
            CallControlID = callControlID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CallServiceWithRawResponse : ICallServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<CallRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var call = await response.Deserialize<CallRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                call.Validate();
            }
            return call;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        string callControlID,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<CallUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Update(
        string callControlID,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallListPage>> List(
        CallListParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueName' cannot be null"
            );
        }

        HttpRequest<CallListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CallListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CallListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallListPage>> List(
        string queueName,
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<CallRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string callControlID,
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }
}