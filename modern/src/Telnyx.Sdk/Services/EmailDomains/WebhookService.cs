using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailDomains.Webhooks;

namespace Telnyx.Sdk.Services.EmailDomains;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WebhookService(this._client.WithOptions(modifier)); }

    public WebhookService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WebhookServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailWebhookResponse> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailWebhookResponse> Create(
        string domainID,
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailWebhookResponse> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailWebhookResponse> Retrieve(
        string id,
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailWebhookResponse> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailWebhookResponse> Update(
        string id,
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookListPage> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WebhookListPage> List(
        string domainID,
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailWebhookResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailWebhookResponse> Delete(
        string id,
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailWebhookResponse>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DomainID' cannot be null"
            );
        }

        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailWebhookResponse = await response.Deserialize<EmailWebhookResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailWebhookResponse.Validate();
            }
            return emailWebhookResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailWebhookResponse>> Create(
        string domainID,
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailWebhookResponse>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailWebhookResponse = await response.Deserialize<EmailWebhookResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailWebhookResponse.Validate();
            }
            return emailWebhookResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailWebhookResponse>> Retrieve(
        string id,
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailWebhookResponse>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailWebhookResponse = await response.Deserialize<EmailWebhookResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailWebhookResponse.Validate();
            }
            return emailWebhookResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailWebhookResponse>> Update(
        string id,
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListPage>> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DomainID' cannot be null"
            );
        }

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<WebhookListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new WebhookListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WebhookListPage>> List(
        string domainID,
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailWebhookResponse>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailWebhookResponse = await response.Deserialize<EmailWebhookResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailWebhookResponse.Validate();
            }
            return emailWebhookResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailWebhookResponse>> Delete(
        string id,
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}