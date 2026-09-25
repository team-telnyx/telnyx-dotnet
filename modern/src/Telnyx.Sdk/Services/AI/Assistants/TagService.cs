using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.Tags;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class TagService : ITagService
{
    readonly Lazy<ITagServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new TagService(this._client.WithOptions(modifier)); }

    public TagService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TagServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TagsResponse> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TagsResponse> Add(
        TagAddParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Add(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TagsResponse> Add(
        string assistantID,
        TagAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TagsResponse> Remove(
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Remove(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TagsResponse> Remove(
        string tag,
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            Tag = tag
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TagServiceWithRawResponse : ITagServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TagServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TagServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagsResponse>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TagListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var tagsResponse = await response.Deserialize<TagsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                tagsResponse.Validate();
            }
            return tagsResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagsResponse>> Add(
        TagAddParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<TagAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var tagsResponse = await response.Deserialize<TagsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                tagsResponse.Validate();
            }
            return tagsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TagsResponse>> Add(
        string assistantID,
        TagAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagsResponse>> Remove(
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Tag' cannot be null"
            );
        }

        HttpRequest<TagRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var tagsResponse = await response.Deserialize<TagsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                tagsResponse.Validate();
            }
            return tagsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TagsResponse>> Remove(
        string tag,
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            Tag = tag
        }, cancellationToken);
    }
}