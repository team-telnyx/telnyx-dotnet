using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Threads;
using Telnyx.Sdk.Services.EmailInboxes.Threads;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <inheritdoc/>
public sealed class ThreadService : IThreadService
{
    readonly Lazy<IThreadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IThreadServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IThreadService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ThreadService(this._client.WithOptions(modifier)); }

    public ThreadService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ThreadServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _labels =new(() => new LabelService(client)) ;
    }

    readonly Lazy<ILabelService> _labels;
    public ILabelService Labels { get { return _labels.Value; } }

    /// <inheritdoc/>
    public async Task<ThreadRetrieveResponse> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ThreadRetrieveResponse> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ThreadListPage> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ThreadListPage> List(
        string inboxID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ThreadServiceWithRawResponse : IThreadServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IThreadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ThreadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ThreadServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _labels =new(() => new LabelServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ILabelServiceWithRawResponse> _labels;
    public ILabelServiceWithRawResponse Labels { get { return _labels.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<ThreadRetrieveResponse>> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ThreadID' cannot be null"
            );
        }

        HttpRequest<ThreadRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var thread = await response.Deserialize<ThreadRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                thread.Validate();
            }
            return thread;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ThreadRetrieveResponse>> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ThreadListPage>> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<ThreadListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<InboundThreadListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ThreadListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ThreadListPage>> List(
        string inboxID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }
}