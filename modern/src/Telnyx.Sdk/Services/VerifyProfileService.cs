using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VerifyProfiles;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VerifyProfileService : IVerifyProfileService
{
    readonly Lazy<IVerifyProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerifyProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVerifyProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VerifyProfileService(this._client.WithOptions(modifier)); }

    public VerifyProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VerifyProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileData> Create(
        VerifyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileData> Retrieve(
        VerifyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifyProfileData> Retrieve(
        string verifyProfileID,
        VerifyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileData> Update(
        VerifyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifyProfileData> Update(
        string verifyProfileID,
        VerifyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileListPage> List(
        VerifyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileData> Delete(
        VerifyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifyProfileData> Delete(
        string verifyProfileID,
        VerifyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageTemplate> CreateTemplate(
        VerifyProfileCreateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateTemplate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerifyProfileRetrieveTemplatesResponse> RetrieveTemplates(
        VerifyProfileRetrieveTemplatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveTemplates(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageTemplate> UpdateTemplate(
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateTemplate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageTemplate> UpdateTemplate(
        string templateID,
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTemplate(parameters with{
            TemplateID = templateID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VerifyProfileServiceWithRawResponse : IVerifyProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerifyProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerifyProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerifyProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileData>> Create(
        VerifyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerifyProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyProfileData = await response.Deserialize<VerifyProfileData>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyProfileData.Validate();
            }
            return verifyProfileData;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileData>> Retrieve(
        VerifyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VerifyProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VerifyProfileID' cannot be null"
            );
        }

        HttpRequest<VerifyProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyProfileData = await response.Deserialize<VerifyProfileData>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyProfileData.Validate();
            }
            return verifyProfileData;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifyProfileData>> Retrieve(
        string verifyProfileID,
        VerifyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileData>> Update(
        VerifyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VerifyProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VerifyProfileID' cannot be null"
            );
        }

        HttpRequest<VerifyProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyProfileData = await response.Deserialize<VerifyProfileData>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyProfileData.Validate();
            }
            return verifyProfileData;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifyProfileData>> Update(
        string verifyProfileID,
        VerifyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileListPage>> List(
        VerifyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VerifyProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VerifyProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VerifyProfileListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileData>> Delete(
        VerifyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VerifyProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VerifyProfileID' cannot be null"
            );
        }

        HttpRequest<VerifyProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyProfileData = await response.Deserialize<VerifyProfileData>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyProfileData.Validate();
            }
            return verifyProfileData;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifyProfileData>> Delete(
        string verifyProfileID,
        VerifyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            VerifyProfileID = verifyProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageTemplate>> CreateTemplate(
        VerifyProfileCreateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerifyProfileCreateTemplateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messageTemplate = await response.Deserialize<MessageTemplate>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messageTemplate.Validate();
            }
            return messageTemplate;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyProfileRetrieveTemplatesResponse>> RetrieveTemplates(
        VerifyProfileRetrieveTemplatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VerifyProfileRetrieveTemplatesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<VerifyProfileRetrieveTemplatesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageTemplate>> UpdateTemplate(
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TemplateID' cannot be null"
            );
        }

        HttpRequest<VerifyProfileUpdateTemplateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messageTemplate = await response.Deserialize<MessageTemplate>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messageTemplate.Validate();
            }
            return messageTemplate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageTemplate>> UpdateTemplate(
        string templateID,
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTemplate(parameters with{
            TemplateID = templateID
        }, cancellationToken);
    }
}