using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Comments;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CommentService : ICommentService
{
    readonly Lazy<ICommentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICommentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICommentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CommentService(this._client.WithOptions(modifier)); }

    public CommentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CommentServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CommentCreateResponse> Create(
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CommentRetrieveResponse> Retrieve(
        CommentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CommentRetrieveResponse> Retrieve(
        string id,
        CommentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommentListResponse> List(
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CommentMarkAsReadResponse> MarkAsRead(
        CommentMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.MarkAsRead(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CommentMarkAsReadResponse> MarkAsRead(
        string id,
        CommentMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MarkAsRead(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CommentServiceWithRawResponse : ICommentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICommentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CommentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CommentServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommentCreateResponse>> Create(
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CommentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var comment = await response.Deserialize<CommentCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                comment.Validate();
            }
            return comment;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommentRetrieveResponse>> Retrieve(
        CommentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CommentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var comment = await response.Deserialize<CommentRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                comment.Validate();
            }
            return comment;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CommentRetrieveResponse>> Retrieve(
        string id,
        CommentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommentListResponse>> List(
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CommentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var comments = await response.Deserialize<CommentListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                comments.Validate();
            }
            return comments;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommentMarkAsReadResponse>> MarkAsRead(
        CommentMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CommentMarkAsReadParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CommentMarkAsReadResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CommentMarkAsReadResponse>> MarkAsRead(
        string id,
        CommentMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MarkAsRead(parameters with{
            ID = id
        }, cancellationToken);
    }
}