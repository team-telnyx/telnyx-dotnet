using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailTemplates;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailTemplateService : IEmailTemplateService
{
    readonly Lazy<IEmailTemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailTemplateServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailTemplateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailTemplateService(this._client.WithOptions(modifier)); }

    public EmailTemplateService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailTemplateServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateResponse> Create(
        EmailTemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateResponse> Retrieve(
        EmailTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailTemplateResponse> Retrieve(
        string id,
        EmailTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateResponse> Update(
        EmailTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailTemplateResponse> Update(
        string id,
        EmailTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateListPage> List(
        EmailTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EmailTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        EmailTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateRenderResponse> Render(
        EmailTemplateRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Render(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailTemplateRenderResponse> Render(
        string id,
        EmailTemplateRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Render(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailTemplateResponse> Replace(
        EmailTemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Replace(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailTemplateResponse> Replace(
        string id,
        EmailTemplateReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replace(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EmailTemplateServiceWithRawResponse : IEmailTemplateServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailTemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailTemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailTemplateServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateResponse>> Create(
        EmailTemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailTemplateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailTemplateResponse = await response.Deserialize<EmailTemplateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailTemplateResponse.Validate();
            }
            return emailTemplateResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateResponse>> Retrieve(
        EmailTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailTemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailTemplateResponse = await response.Deserialize<EmailTemplateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailTemplateResponse.Validate();
            }
            return emailTemplateResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailTemplateResponse>> Retrieve(
        string id,
        EmailTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateResponse>> Update(
        EmailTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailTemplateUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailTemplateResponse = await response.Deserialize<EmailTemplateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailTemplateResponse.Validate();
            }
            return emailTemplateResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailTemplateResponse>> Update(
        string id,
        EmailTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateListPage>> List(
        EmailTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailTemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailTemplateListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailTemplateListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EmailTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailTemplateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EmailTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateRenderResponse>> Render(
        EmailTemplateRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailTemplateRenderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmailTemplateRenderResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailTemplateRenderResponse>> Render(
        string id,
        EmailTemplateRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Render(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailTemplateResponse>> Replace(
        EmailTemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailTemplateReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailTemplateResponse = await response.Deserialize<EmailTemplateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailTemplateResponse.Validate();
            }
            return emailTemplateResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailTemplateResponse>> Replace(
        string id,
        EmailTemplateReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replace(parameters with{
            ID = id
        }, cancellationToken);
    }
}