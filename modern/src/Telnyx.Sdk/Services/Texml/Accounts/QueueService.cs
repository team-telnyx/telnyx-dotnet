using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Queues;

namespace Telnyx.Sdk.Services.Texml.Accounts;

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
    }

    /// <inheritdoc/>
    public async Task<QueueResource> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueResource> Create(
        string accountSid,
        QueueCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QueueResource> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueResource> Retrieve(
        string queueSid,
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            QueueSid = queueSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QueueResource> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueResource> Update(
        string queueSid,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            QueueSid = queueSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QueueListPage> List(
        QueueListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<QueueListPage> List(
        string accountSid,
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
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
        string queueSid,
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            QueueSid = queueSid
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueResource>> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<QueueCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queueResource = await response.Deserialize<QueueResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queueResource.Validate();
            }
            return queueResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueResource>> Create(
        string accountSid,
        QueueCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueResource>> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueSid' cannot be null"
            );
        }

        HttpRequest<QueueRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queueResource = await response.Deserialize<QueueResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queueResource.Validate();
            }
            return queueResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueResource>> Retrieve(
        string queueSid,
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            QueueSid = queueSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueResource>> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueSid' cannot be null"
            );
        }

        HttpRequest<QueueUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var queueResource = await response.Deserialize<QueueResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                queueResource.Validate();
            }
            return queueResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueResource>> Update(
        string queueSid,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            QueueSid = queueSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueListPage>> List(
        QueueListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

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
    }/// <inheritdoc/>
    public Task<HttpResponse<QueueListPage>> List(
        string accountSid,
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.QueueSid' cannot be null"
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
        string queueSid,
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            QueueSid = queueSid
        }, cancellationToken);
    }
}