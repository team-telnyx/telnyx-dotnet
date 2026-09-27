using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Threads;
using Telnyx.Sdk.Models.EmailThreads;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailThreadService : IEmailThreadService
{
    readonly Lazy<IEmailThreadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailThreadServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailThreadService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailThreadService(this._client.WithOptions(modifier)); }

    public EmailThreadService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailThreadServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailThreadRetrieveResponse> Retrieve(
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailThreadRetrieveResponse> Retrieve(
        string threadID,
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailThreadListPage> List(
        EmailThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmailThreadServiceWithRawResponse : IEmailThreadServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailThreadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailThreadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailThreadServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailThreadRetrieveResponse>> Retrieve(
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ThreadID' cannot be null"
            );
        }

        HttpRequest<EmailThreadRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailThread = await response.Deserialize<EmailThreadRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailThread.Validate();
            }
            return emailThread;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailThreadRetrieveResponse>> Retrieve(
        string threadID,
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailThreadListPage>> List(
        EmailThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailThreadListParams> request = new()
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
            return new EmailThreadListPage(this, parameters, page);
        });
    }
}