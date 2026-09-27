using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes;
using EmailInboxes = Telnyx.Sdk.Services.EmailInboxes;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailInboxService : IEmailInboxService
{
    readonly Lazy<IEmailInboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailInboxServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailInboxService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailInboxService(this._client.WithOptions(modifier)); }

    public EmailInboxService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailInboxServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _drafts =new(() => new EmailInboxes::DraftService(client)) ;
        _filters =new(() => new EmailInboxes::FilterService(client)) ;
        _messages =new(() => new EmailInboxes::MessageService(client)) ;
        _threads =new(() => new EmailInboxes::ThreadService(client)) ;
    }

    readonly Lazy<EmailInboxes::IDraftService> _drafts;
    public EmailInboxes::IDraftService Drafts { get { return _drafts.Value; } }

    readonly Lazy<EmailInboxes::IFilterService> _filters;
    public EmailInboxes::IFilterService Filters {
        get { return _filters.Value; }
    }

    readonly Lazy<EmailInboxes::IMessageService> _messages;
    public EmailInboxes::IMessageService Messages {
        get { return _messages.Value; }
    }

    readonly Lazy<EmailInboxes::IThreadService> _threads;
    public EmailInboxes::IThreadService Threads {
        get { return _threads.Value; }
    }

    /// <inheritdoc/>
    public async Task<EmailInboxResponse> Create(
        EmailInboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailInboxResponse> Retrieve(
        EmailInboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailInboxResponse> Retrieve(
        string id,
        EmailInboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailInboxListPage> List(
        EmailInboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EmailInboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        EmailInboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmailInboxServiceWithRawResponse : IEmailInboxServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailInboxServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailInboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailInboxServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _drafts =new(
            () => new EmailInboxes::DraftServiceWithRawResponse(client)
        ) ;
        _filters =new(
            () => new EmailInboxes::FilterServiceWithRawResponse(client)
        ) ;
        _messages =new(
            () => new EmailInboxes::MessageServiceWithRawResponse(client)
        ) ;
        _threads =new(
            () => new EmailInboxes::ThreadServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<EmailInboxes::IDraftServiceWithRawResponse> _drafts;
    public EmailInboxes::IDraftServiceWithRawResponse Drafts {
        get { return _drafts.Value; }
    }

    readonly Lazy<EmailInboxes::IFilterServiceWithRawResponse> _filters;
    public EmailInboxes::IFilterServiceWithRawResponse Filters {
        get { return _filters.Value; }
    }

    readonly Lazy<EmailInboxes::IMessageServiceWithRawResponse> _messages;
    public EmailInboxes::IMessageServiceWithRawResponse Messages {
        get { return _messages.Value; }
    }

    readonly Lazy<EmailInboxes::IThreadServiceWithRawResponse> _threads;
    public EmailInboxes::IThreadServiceWithRawResponse Threads {
        get { return _threads.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailInboxResponse>> Create(
        EmailInboxCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailInboxCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailInboxResponse = await response.Deserialize<EmailInboxResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailInboxResponse.Validate();
            }
            return emailInboxResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailInboxResponse>> Retrieve(
        EmailInboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailInboxRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailInboxResponse = await response.Deserialize<EmailInboxResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailInboxResponse.Validate();
            }
            return emailInboxResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailInboxResponse>> Retrieve(
        string id,
        EmailInboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailInboxListPage>> List(
        EmailInboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailInboxListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailInboxListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailInboxListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EmailInboxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailInboxDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EmailInboxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}