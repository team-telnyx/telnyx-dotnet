using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Services.Messaging10dlc.Campaign;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <inheritdoc/>
public sealed class CampaignService : ICampaignService
{
    readonly Lazy<ICampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICampaignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CampaignService(this._client.WithOptions(modifier)); }

    public CampaignService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CampaignServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _usecase =new(() => new UsecaseService(client)) ;
        _osr =new(() => new OsrService(client)) ;
    }

    readonly Lazy<IUsecaseService> _usecase;
    public IUsecaseService Usecase { get { return _usecase.Value; } }

    readonly Lazy<IOsrService> _osr;
    public IOsrService Osr { get { return _osr.Value; } }

    /// <inheritdoc/>
    public async Task<TelnyxCampaignCsp> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxCampaignCsp> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelnyxCampaignCsp> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxCampaignCsp> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignListPage> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> AcceptSharing(
        CampaignAcceptSharingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.AcceptSharing(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> AcceptSharing(
        string campaignID,
        CampaignAcceptSharingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.AcceptSharing(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignDeactivateResponse> Deactivate(
        CampaignDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Deactivate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CampaignDeactivateResponse> Deactivate(
        string campaignID,
        CampaignDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignGetMnoMetadataResponse> GetMnoMetadata(
        CampaignGetMnoMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetMnoMetadata(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CampaignGetMnoMetadataResponse> GetMnoMetadata(
        string campaignID,
        CampaignGetMnoMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetMnoMetadata(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> GetOperationStatus(
        CampaignGetOperationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetOperationStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> GetOperationStatus(
        string campaignID,
        CampaignGetOperationStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetOperationStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignGetSharingStatusResponse> GetSharingStatus(
        CampaignGetSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetSharingStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CampaignGetSharingStatusResponse> GetSharingStatus(
        string campaignID,
        CampaignGetSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSharingStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignSubmitAppealResponse> SubmitAppeal(
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SubmitAppeal(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CampaignSubmitAppealResponse> SubmitAppeal(
        string campaignID,
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitAppeal(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CampaignServiceWithRawResponse : ICampaignServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CampaignServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _usecase =new(() => new UsecaseServiceWithRawResponse(client)) ;
        _osr =new(() => new OsrServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IUsecaseServiceWithRawResponse> _usecase;
    public IUsecaseServiceWithRawResponse Usecase {
        get { return _usecase.Value; }
    }

    readonly Lazy<IOsrServiceWithRawResponse> _osr;
    public IOsrServiceWithRawResponse Osr { get { return _osr.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxCampaignCsp>> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxCampaignCsp = await response.Deserialize<TelnyxCampaignCsp>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxCampaignCsp.Validate();
            }
            return telnyxCampaignCsp;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxCampaignCsp>> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxCampaignCsp>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxCampaignCsp = await response.Deserialize<TelnyxCampaignCsp>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxCampaignCsp.Validate();
            }
            return telnyxCampaignCsp;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxCampaignCsp>> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignListPage>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CampaignListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CampaignListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CampaignListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> AcceptSharing(
        CampaignAcceptSharingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignAcceptSharingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> AcceptSharing(
        string campaignID,
        CampaignAcceptSharingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.AcceptSharing(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignDeactivateResponse>> Deactivate(
        CampaignDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignDeactivateParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CampaignDeactivateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CampaignDeactivateResponse>> Deactivate(
        string campaignID,
        CampaignDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignGetMnoMetadataResponse>> GetMnoMetadata(
        CampaignGetMnoMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignGetMnoMetadataParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CampaignGetMnoMetadataResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CampaignGetMnoMetadataResponse>> GetMnoMetadata(
        string campaignID,
        CampaignGetMnoMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetMnoMetadata(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> GetOperationStatus(
        CampaignGetOperationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignGetOperationStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> GetOperationStatus(
        string campaignID,
        CampaignGetOperationStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetOperationStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignGetSharingStatusResponse>> GetSharingStatus(
        CampaignGetSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignGetSharingStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CampaignGetSharingStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CampaignGetSharingStatusResponse>> GetSharingStatus(
        string campaignID,
        CampaignGetSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSharingStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignSubmitAppealResponse>> SubmitAppeal(
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<CampaignSubmitAppealParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CampaignSubmitAppealResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CampaignSubmitAppealResponse>> SubmitAppeal(
        string campaignID,
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitAppeal(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}