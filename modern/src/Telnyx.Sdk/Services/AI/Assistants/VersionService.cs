using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants;
using Telnyx.Sdk.Models.AI.Assistants.Versions;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VersionService(this._client.WithOptions(modifier)); }

    public VersionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VersionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Retrieve(
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Update(
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Update(
        string versionID,
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssistantsList> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantsList> List(
        string assistantID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            VersionID = versionID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Promote(
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Promote(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Promote(
        string versionID,
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Promote(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Retrieve(
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Update(
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Update(
        string versionID,
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantsList>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<VersionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantsList = await response.Deserialize<AssistantsList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantsList.Validate();
            }
            return assistantsList;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantsList>> List(
        string assistantID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Promote(
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionPromoteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Promote(
        string versionID,
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Promote(parameters with{
            VersionID = versionID
        }, cancellationToken);
    }
}