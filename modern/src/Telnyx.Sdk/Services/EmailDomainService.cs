using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailDomains;
using EmailDomains = Telnyx.Sdk.Services.EmailDomains;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailDomainService : IEmailDomainService
{
    readonly Lazy<IEmailDomainServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailDomainServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailDomainService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailDomainService(this._client.WithOptions(modifier)); }

    public EmailDomainService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailDomainServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _webhooks =new(() => new EmailDomains::WebhookService(client)) ;
    }

    readonly Lazy<EmailDomains::IWebhookService> _webhooks;
    public EmailDomains::IWebhookService Webhooks {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<EmailDomainResponse> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainResponse> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainResponse> Retrieve(
        string id,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainResponse> Update(
        EmailDomainUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainResponse> Update(
        string id,
        EmailDomainUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainListPage> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainResponse> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainResponse> Delete(
        string id,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainRetrieveDnsRecordsResponse> RetrieveDnsRecords(
        EmailDomainRetrieveDnsRecordsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveDnsRecords(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainRetrieveDnsRecordsResponse> RetrieveDnsRecords(
        string domainID,
        EmailDomainRetrieveDnsRecordsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDnsRecords(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainRetrieveHealthResponse> RetrieveHealth(
        EmailDomainRetrieveHealthParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveHealth(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainRetrieveHealthResponse> RetrieveHealth(
        string id,
        EmailDomainRetrieveHealthParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHealth(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainRotateDkimResponse> RotateDkim(
        EmailDomainRotateDkimParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RotateDkim(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainRotateDkimResponse> RotateDkim(
        string domainID,
        EmailDomainRotateDkimParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateDkim(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainResponse> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Verify(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDomainResponse> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EmailDomainServiceWithRawResponse : IEmailDomainServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailDomainServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailDomainServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailDomainServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _webhooks =new(
            () => new EmailDomains::WebhookServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<EmailDomains::IWebhookServiceWithRawResponse> _webhooks;
    public EmailDomains::IWebhookServiceWithRawResponse Webhooks {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainResponse>> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailDomainCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDomainResponse = await response.Deserialize<EmailDomainResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDomainResponse.Validate();
            }
            return emailDomainResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainResponse>> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailDomainRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDomainResponse = await response.Deserialize<EmailDomainResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDomainResponse.Validate();
            }
            return emailDomainResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainResponse>> Retrieve(
        string id,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainResponse>> Update(
        EmailDomainUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailDomainUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDomainResponse = await response.Deserialize<EmailDomainResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDomainResponse.Validate();
            }
            return emailDomainResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainResponse>> Update(
        string id,
        EmailDomainUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainListPage>> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailDomainListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailDomainListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailDomainListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainResponse>> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailDomainDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDomainResponse = await response.Deserialize<EmailDomainResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDomainResponse.Validate();
            }
            return emailDomainResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainResponse>> Delete(
        string id,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainRetrieveDnsRecordsResponse>> RetrieveDnsRecords(
        EmailDomainRetrieveDnsRecordsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DomainID' cannot be null"
            );
        }

        HttpRequest<EmailDomainRetrieveDnsRecordsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmailDomainRetrieveDnsRecordsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainRetrieveDnsRecordsResponse>> RetrieveDnsRecords(
        string domainID,
        EmailDomainRetrieveDnsRecordsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDnsRecords(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainRetrieveHealthResponse>> RetrieveHealth(
        EmailDomainRetrieveHealthParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailDomainRetrieveHealthParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmailDomainRetrieveHealthResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainRetrieveHealthResponse>> RetrieveHealth(
        string id,
        EmailDomainRetrieveHealthParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHealth(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainRotateDkimResponse>> RotateDkim(
        EmailDomainRotateDkimParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DomainID' cannot be null"
            );
        }

        HttpRequest<EmailDomainRotateDkimParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmailDomainRotateDkimResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainRotateDkimResponse>> RotateDkim(
        string domainID,
        EmailDomainRotateDkimParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateDkim(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainResponse>> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DomainID' cannot be null"
            );
        }

        HttpRequest<EmailDomainVerifyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDomainResponse = await response.Deserialize<EmailDomainResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDomainResponse.Validate();
            }
            return emailDomainResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDomainResponse>> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with{
            DomainID = domainID
        }, cancellationToken);
    }
}