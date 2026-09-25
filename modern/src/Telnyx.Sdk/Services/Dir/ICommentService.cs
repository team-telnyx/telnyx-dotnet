using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.Comments;

namespace Telnyx.Sdk.Services.Dir;

/// <summary>
/// Read messages from the Telnyx vetting team and reply with clarifying information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICommentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Post a customer comment on a DIR (for example, to respond to reviewer notes).
/// Send only `content` (1–5000 chars) and an optional `parent_comment_id`; the
/// server sets the comment type, visibility, and author automatically. The
/// enterprise is resolved server-side from the DIR id.
/// </summary>
    Task<CommentCreateResponse> Create(
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CommentCreateParams, CancellationToken)"/>
    Task<CommentCreateResponse> Create(
        string dirID,
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List the comments on a DIR. The enterprise is resolved server-side from the DIR
/// id.
/// </summary>
    Task<CommentListPage> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CommentListParams, CancellationToken)"/>
    Task<CommentListPage> List(
        string dirID,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICommentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICommentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/comments</c>, but is otherwise the
/// same as <see cref="ICommentService.Create(CommentCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentCreateResponse>> Create(
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CommentCreateParams, CancellationToken)"/>
    Task<HttpResponse<CommentCreateResponse>> Create(
        string dirID,
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/comments</c>, but is otherwise the
/// same as <see cref="ICommentService.List(CommentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentListPage>> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CommentListParams, CancellationToken)"/>
    Task<HttpResponse<CommentListPage>> List(
        string dirID,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}