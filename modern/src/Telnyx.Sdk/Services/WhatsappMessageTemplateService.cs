using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WhatsappMessageTemplates;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WhatsappMessageTemplateService : IWhatsappMessageTemplateService
{
    readonly Lazy<IWhatsappMessageTemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWhatsappMessageTemplateServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWhatsappMessageTemplateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WhatsappMessageTemplateService(this._client.WithOptions(modifier));
    }

    public WhatsappMessageTemplateService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WhatsappMessageTemplateServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WhatsappMessageTemplateRetrieveResponse> Retrieve(
        WhatsappMessageTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WhatsappMessageTemplateRetrieveResponse> Retrieve(
        string id,
        WhatsappMessageTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WhatsappMessageTemplateUpdateResponse> Update(
        WhatsappMessageTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WhatsappMessageTemplateUpdateResponse> Update(
        string id,
        WhatsappMessageTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        WhatsappMessageTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        WhatsappMessageTemplateDeleteParams? parameters = null,
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
public sealed class WhatsappMessageTemplateServiceWithRawResponse : IWhatsappMessageTemplateServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWhatsappMessageTemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WhatsappMessageTemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WhatsappMessageTemplateServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappMessageTemplateRetrieveResponse>> Retrieve(
        WhatsappMessageTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WhatsappMessageTemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var whatsappMessageTemplate = await response.Deserialize<WhatsappMessageTemplateRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                whatsappMessageTemplate.Validate();
            }
            return whatsappMessageTemplate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WhatsappMessageTemplateRetrieveResponse>> Retrieve(
        string id,
        WhatsappMessageTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappMessageTemplateUpdateResponse>> Update(
        WhatsappMessageTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WhatsappMessageTemplateUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var whatsappMessageTemplate = await response.Deserialize<WhatsappMessageTemplateUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                whatsappMessageTemplate.Validate();
            }
            return whatsappMessageTemplate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WhatsappMessageTemplateUpdateResponse>> Update(
        string id,
        WhatsappMessageTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WhatsappMessageTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WhatsappMessageTemplateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        WhatsappMessageTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}