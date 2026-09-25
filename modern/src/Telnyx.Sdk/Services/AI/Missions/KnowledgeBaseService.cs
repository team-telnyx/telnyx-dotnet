using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions.KnowledgeBases;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <inheritdoc/>
public sealed class KnowledgeBaseService : IKnowledgeBaseService
{
    readonly Lazy<IKnowledgeBaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKnowledgeBaseServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IKnowledgeBaseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new KnowledgeBaseService(this._client.WithOptions(modifier)); }

    public KnowledgeBaseService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new KnowledgeBaseServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<JsonElement> CreateKnowledgeBase(
        KnowledgeBaseCreateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateKnowledgeBase(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> CreateKnowledgeBase(
        string missionID,
        KnowledgeBaseCreateKnowledgeBaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateKnowledgeBase(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteKnowledgeBase(
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteKnowledgeBase(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetKnowledgeBase(
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetKnowledgeBase(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> GetKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> ListKnowledgeBases(
        KnowledgeBaseListKnowledgeBasesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListKnowledgeBases(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> ListKnowledgeBases(
        string missionID,
        KnowledgeBaseListKnowledgeBasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListKnowledgeBases(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> UpdateKnowledgeBase(
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateKnowledgeBase(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> UpdateKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class KnowledgeBaseServiceWithRawResponse : IKnowledgeBaseServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKnowledgeBaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new KnowledgeBaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KnowledgeBaseServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> CreateKnowledgeBase(
        KnowledgeBaseCreateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<KnowledgeBaseCreateKnowledgeBaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> CreateKnowledgeBase(
        string missionID,
        KnowledgeBaseCreateKnowledgeBaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateKnowledgeBase(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteKnowledgeBase(
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KnowledgeBaseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.KnowledgeBaseID' cannot be null"
            );
        }

        HttpRequest<KnowledgeBaseDeleteKnowledgeBaseParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetKnowledgeBase(
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KnowledgeBaseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.KnowledgeBaseID' cannot be null"
            );
        }

        HttpRequest<KnowledgeBaseGetKnowledgeBaseParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> ListKnowledgeBases(
        KnowledgeBaseListKnowledgeBasesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MissionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MissionID' cannot be null"
            );
        }

        HttpRequest<KnowledgeBaseListKnowledgeBasesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> ListKnowledgeBases(
        string missionID,
        KnowledgeBaseListKnowledgeBasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListKnowledgeBases(parameters with{
            MissionID = missionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> UpdateKnowledgeBase(
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KnowledgeBaseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.KnowledgeBaseID' cannot be null"
            );
        }

        HttpRequest<KnowledgeBaseUpdateKnowledgeBaseParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> UpdateKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateKnowledgeBase(parameters with{
            KnowledgeBaseID = knowledgeBaseID
        }, cancellationToken);
    }
}