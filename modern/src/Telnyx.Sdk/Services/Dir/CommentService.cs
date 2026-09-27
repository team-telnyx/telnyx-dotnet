using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir.Comments;

namespace Telnyx.Sdk.Services.Dir;

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
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CommentCreateResponse> Create(
        string dirID,
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommentListPage> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CommentListPage> List(
        string dirID,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
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
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

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
    }/// <inheritdoc/>
    public Task<HttpResponse<CommentCreateResponse>> Create(
        string dirID,
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommentListPage>> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<CommentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CommentListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CommentListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CommentListPage>> List(
        string dirID,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}