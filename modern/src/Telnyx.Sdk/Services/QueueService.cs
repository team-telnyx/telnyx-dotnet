using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Queues;
using Queues = Telnyx.Sdk.Services.Queues;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class QueueService : IQueueService
{
    readonly Lazy<IQueueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IQueueServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IQueueService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new QueueService(this._client.WithOptions(modifier)); }

    public QueueService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new QueueServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _calls =new(() => new Queues::CallService(client)) ;
    }

    readonly Lazy<Queues::ICallService> _calls;
    public Queues::ICallService Calls { get { return _calls.Value; } }

    /// <inheritdoc/>
    public async Task<QueueCreateResponse> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<QueueRetrieveResponse> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueRetrieveResponse> Retrieve(
        string queueName,
        QueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QueueUpdateResponse> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueUpdateResponse> Update(
        string queueName,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QueueListPage> List(
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string queueName,
        QueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            QueueName = queueName
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class QueueServiceWithRawResponse : IQueueServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IQueueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new QueueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public QueueServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _calls =new(() => new Queues::CallServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Queues::ICallServiceWithRawResponse> _calls;
    public Queues::ICallServiceWithRawResponse Calls {
        get { return _calls.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueCreateResponse>> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<QueueCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queue = await response.Deserialize<QueueCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queue.Validate();
            }
            return queue;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueRetrieveResponse>> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueName' cannot be null"
            );
        }

        HttpRequest<QueueRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queue = await response.Deserialize<QueueRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queue.Validate();
            }
            return queue;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueRetrieveResponse>> Retrieve(
        string queueName,
        QueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueUpdateResponse>> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueName' cannot be null"
            );
        }

        HttpRequest<QueueUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queue = await response.Deserialize<QueueUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queue.Validate();
            }
            return queue;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueUpdateResponse>> Update(
        string queueName,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueListPage>> List(
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<QueueListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<QueueListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new QueueListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueName' cannot be null"
            );
        }

        HttpRequest<QueueDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string queueName,
        QueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            QueueName = queueName
        }, cancellationToken);
    }
}