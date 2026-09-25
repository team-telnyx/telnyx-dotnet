using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <inheritdoc/>
public sealed class PartnerCampaignService : IPartnerCampaignService
{
    readonly Lazy<IPartnerCampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPartnerCampaignServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPartnerCampaignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PartnerCampaignService(this._client.WithOptions(modifier)); }

    public PartnerCampaignService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PartnerCampaignServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TelnyxDownstreamCampaign> Retrieve(
        PartnerCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxDownstreamCampaign> Retrieve(
        string campaignID,
        PartnerCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelnyxDownstreamCampaign> Update(
        PartnerCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxDownstreamCampaign> Update(
        string campaignID,
        PartnerCampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PartnerCampaignListPage> List(
        PartnerCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PartnerCampaignListSharedByMePage> ListSharedByMe(
        PartnerCampaignListSharedByMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListSharedByMe(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, CampaignSharingStatus>> RetrieveSharingStatus(
        PartnerCampaignRetrieveSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveSharingStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, CampaignSharingStatus>> RetrieveSharingStatus(
        string campaignID,
        PartnerCampaignRetrieveSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSharingStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PartnerCampaignServiceWithRawResponse : IPartnerCampaignServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPartnerCampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PartnerCampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PartnerCampaignServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxDownstreamCampaign>> Retrieve(
        PartnerCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<PartnerCampaignRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxDownstreamCampaign = await response.Deserialize<TelnyxDownstreamCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxDownstreamCampaign.Validate();
            }
            return telnyxDownstreamCampaign;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxDownstreamCampaign>> Retrieve(
        string campaignID,
        PartnerCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxDownstreamCampaign>> Update(
        PartnerCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<PartnerCampaignUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxDownstreamCampaign = await response.Deserialize<TelnyxDownstreamCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxDownstreamCampaign.Validate();
            }
            return telnyxDownstreamCampaign;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxDownstreamCampaign>> Update(
        string campaignID,
        PartnerCampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PartnerCampaignListPage>> List(
        PartnerCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PartnerCampaignListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PartnerCampaignListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PartnerCampaignListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PartnerCampaignListSharedByMePage>> ListSharedByMe(
        PartnerCampaignListSharedByMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PartnerCampaignListSharedByMeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PartnerCampaignListSharedByMePageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PartnerCampaignListSharedByMePage(this,
            parameters,
            page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, CampaignSharingStatus>>> RetrieveSharingStatus(
        PartnerCampaignRetrieveSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<PartnerCampaignRetrieveSharingStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<Dictionary<string, CampaignSharingStatus>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in deserializedResponse.Values)
                {
                    item.Validate();
                }
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, CampaignSharingStatus>>> RetrieveSharingStatus(
        string campaignID,
        PartnerCampaignRetrieveSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSharingStatus(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}