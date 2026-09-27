using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Conversations.Insights;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <inheritdoc/>
public sealed class InsightService : IInsightService
{
    readonly Lazy<IInsightServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInsightService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InsightService(this._client.WithOptions(modifier)); }

    public InsightService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InsightServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateDetail> Create(
        InsightCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateDetail> Retrieve(
        InsightRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InsightTemplateDetail> Retrieve(
        string insightID,
        InsightRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InsightTemplateDetail> Update(
        InsightUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InsightTemplateDetail> Update(
        string insightID,
        InsightUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InsightListPage> List(
        InsightListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        InsightDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string insightID,
        InsightDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            InsightID = insightID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InsightServiceWithRawResponse : IInsightServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InsightServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InsightServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateDetail>> Create(
        InsightCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InsightCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateDetail = await response.Deserialize<InsightTemplateDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateDetail.Validate();
            }
            return insightTemplateDetail;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateDetail>> Retrieve(
        InsightRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InsightID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InsightID' cannot be null"
            );
        }

        HttpRequest<InsightRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateDetail = await response.Deserialize<InsightTemplateDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateDetail.Validate();
            }
            return insightTemplateDetail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InsightTemplateDetail>> Retrieve(
        string insightID,
        InsightRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightTemplateDetail>> Update(
        InsightUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InsightID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InsightID' cannot be null"
            );
        }

        HttpRequest<InsightUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var insightTemplateDetail = await response.Deserialize<InsightTemplateDetail>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                insightTemplateDetail.Validate();
            }
            return insightTemplateDetail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InsightTemplateDetail>> Update(
        string insightID,
        InsightUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InsightListPage>> List(
        InsightListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InsightListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<InsightListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new InsightListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        InsightDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InsightID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InsightID' cannot be null"
            );
        }

        HttpRequest<InsightDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string insightID,
        InsightDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            InsightID = insightID
        }, cancellationToken);
    }
}