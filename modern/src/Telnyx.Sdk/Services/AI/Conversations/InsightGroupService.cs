using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Conversations.InsightGroups;
using InsightGroups = Telnyx.Sdk.Services.AI.Conversations.InsightGroups;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <inheritdoc/>
public sealed class InsightGroupService : IInsightGroupService
{
    readonly Lazy<IInsightGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInsightGroupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInsightGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InsightGroupService(this._client.WithOptions(modifier)); }

    public InsightGroupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InsightGroupServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _insights =new(() => new InsightGroups::InsightService(client)) ;
    }

    readonly Lazy<InsightGroups::IInsightService> _insights;
    public InsightGroups::IInsightService Insights {
        get { return _insights.Value; }
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateGroupDetail> Retrieve(
        InsightGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InsightTemplateGroupDetail> Retrieve(
        string groupID,
        InsightGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            GroupID = groupID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateGroupDetail> Update(
        InsightGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InsightTemplateGroupDetail> Update(
        string groupID,
        InsightGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            GroupID = groupID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        InsightGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string groupID,
        InsightGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            GroupID = groupID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateGroupDetail> InsightGroups(
        InsightGroupInsightGroupsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.InsightGroups(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InsightGroupRetrieveInsightGroupsPage> RetrieveInsightGroups(
        InsightGroupRetrieveInsightGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveInsightGroups(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InsightGroupServiceWithRawResponse : IInsightGroupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInsightGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InsightGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InsightGroupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _insights =new(
            () => new InsightGroups::InsightServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<InsightGroups::IInsightServiceWithRawResponse> _insights;
    public InsightGroups::IInsightServiceWithRawResponse Insights {
        get { return _insights.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateGroupDetail>> Retrieve(
        InsightGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GroupID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.GroupID' cannot be null"
            );
        }

        HttpRequest<InsightGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateGroupDetail = await response.Deserialize<InsightTemplateGroupDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateGroupDetail.Validate();
            }
            return insightTemplateGroupDetail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InsightTemplateGroupDetail>> Retrieve(
        string groupID,
        InsightGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            GroupID = groupID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateGroupDetail>> Update(
        InsightGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GroupID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.GroupID' cannot be null"
            );
        }

        HttpRequest<InsightGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateGroupDetail = await response.Deserialize<InsightTemplateGroupDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateGroupDetail.Validate();
            }
            return insightTemplateGroupDetail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InsightTemplateGroupDetail>> Update(
        string groupID,
        InsightGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            GroupID = groupID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        InsightGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GroupID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.GroupID' cannot be null"
            );
        }

        HttpRequest<InsightGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string groupID,
        InsightGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            GroupID = groupID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateGroupDetail>> InsightGroups(
        InsightGroupInsightGroupsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InsightGroupInsightGroupsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateGroupDetail = await response.Deserialize<InsightTemplateGroupDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateGroupDetail.Validate();
            }
            return insightTemplateGroupDetail;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightGroupRetrieveInsightGroupsPage>> RetrieveInsightGroups(
        InsightGroupRetrieveInsightGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InsightGroupRetrieveInsightGroupsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<InsightGroupRetrieveInsightGroupsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new InsightGroupRetrieveInsightGroupsPage(this,
            parameters,
            page);
        });
    }
}